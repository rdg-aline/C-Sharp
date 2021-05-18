using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Collections.ObjectModel;

namespace Pluralsight.ConcurrentCollections.BuyAndSell
{
	public class StockController
	{
		private ConcurrentDictionary<string, int> _stock = new ConcurrentDictionary<string, int>();
		int _totalQuantityBought;
		int _totalQuantitySold;


		public void BuyStock(string code, int quantity)
		{
			// this was the line you had to replace
			//_stock.AddOrUpdate(code, quantity, (key, oldValue) => oldValue + quantity);

			// and this is how to do it
			// first, make sure the item exists in the dictionary
			_stock.TryAdd(code, 0);

			// now keep trying to update the value. If the update fails, we continue trying until it succeeds.
			// It's only going to fail if another thread sneaks in and changes the stock for this shirt
			// in between the getting the stock and updating it, and we'd have to be incredibly unlucky for 
			// that to happen more than once or twice in succession, so in any normal situation, this loop
			// isn't going to iterate more than a couple of times.

			// Note that the indexer is fine here because I've just made sure the item is in the 
			// dictionary AND there is no code anywhere in StockController that can remove it from 
			// the dictionary, once added.
			bool success;
			do
			{
				int oldStock = _stock[code];
				success = _stock.TryUpdate(code, oldStock + quantity, oldStock);
			} while (!success);

			// this doesn't change
			Interlocked.Add(ref _totalQuantityBought, quantity);
		}

		public bool TrySellItem(string code)
		{
			bool success = false;
			int newStockLevel = _stock.AddOrUpdate(code,
				(itemName) => { success = false; return 0; },
				(itemName, oldValue) =>
				{
					if (oldValue == 0)
					{
						success = false;
						return 0;
					}
					else
					{
						success = true;
						return oldValue - 1;
					}
				});
			if (success)
				Interlocked.Increment(ref _totalQuantitySold);
			return success;
		}

		public void DisplayStatus()
		{
			int totalStock = _stock.Values.Sum();
			Console.WriteLine("\r\nBought = " + _totalQuantityBought);
			Console.WriteLine("Sold   = " + _totalQuantitySold);
			Console.WriteLine("Stock  = " + totalStock);
			int error = totalStock + _totalQuantitySold - _totalQuantityBought;
			if (error == 0)
				Console.WriteLine("Stock levels match");
			else
				Console.WriteLine("Error in stock level: " + error);

			Console.WriteLine();
			Console.WriteLine("Stock levels by item:");
			foreach (TShirt shirt in TShirtProvider.AllShirts)
			{
				int stockLevel = _stock.GetOrAdd(shirt.Code, 0);
				Console.WriteLine("{0,-30}: {1}", shirt.Name, stockLevel);
			}
		}

		public IReadOnlyDictionary<string, int> Stock => new ReadOnlyDictionary<string, int>(_stock);

	}
}
