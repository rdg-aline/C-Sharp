using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Pluralsight.ConcurrentCollections.BuyAndSell
{
	public class SalesPerson
	{
		public string Name { get; }
		public SalesPerson(string name)
		{
			this.Name = name;
		}

		public void ServeCustomer(StockController controller)
		{
//			Thread.Sleep(Rnd.NextInt(100));
			string code = TShirtProvider.SelectRandomShirt().Code;

			bool buy = Rnd.TrueWithProb(0.1);
			if (buy)
			{
				int quantity = Rnd.NextInt(17) + 1;
				controller.BuyStock(code, quantity);
				DisplayPurchase(code, quantity);
			}
			else
			{
				bool success = controller.TrySellItem(code);
				DisplaySaleAttempt(success, code);
			}
		}

		public void Work(TimeSpan workDay, StockController controller)
		{
			Console.WriteLine($"{Name} starting work");
			DateTime start = DateTime.Now;
			while (DateTime.Now - start < workDay)
			{
				ServeCustomer(controller);
			}
			Console.WriteLine($"{Name} signing off");
		}

		public void DisplayPurchase(string code, int quantity)
		{
			Console.WriteLine($"{Name} bought {quantity} of {TShirtProvider.AllShirtsByCode[code]}");
		}

		public void DisplaySaleAttempt(bool success, string code)
		{
			int threadId = Thread.CurrentThread.ManagedThreadId;
			if (success)
				Console.WriteLine($"{Name} sold {TShirtProvider.AllShirtsByCode[code]}");
			else
				Console.WriteLine($"{Name} couldn't sell {TShirtProvider.AllShirtsByCode[code]}: Out of stock");
		}


	}
} 
