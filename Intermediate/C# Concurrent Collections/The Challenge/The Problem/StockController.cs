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
            // This is the method implementation you must change
            // Remember, the logic needs to ensure that the item with key code is in the dictionary, 
            // and add quantity to that item in a thread-safe manner.
            // If the item is not currently in the dictionary, then it's not yet in stock
            // so its current value is 0.

            // The rules are: You may use any of concurrent dictionary's low-level TryXXXX methods
            // (TryGetValue(), TryAdd(), TryUpdate(), etc.) but you may NOT use the higher level methods
            // GetOrAdd() and AddOrUpdate(). And you may not use locks or any other explicit
            // thread synchronisation tools.

            //_stock.AddOrUpdate(code, quantity, (key, oldValue) => oldValue + quantity);
            //Interlocked.Add(ref _totalQuantityBought, quantity);

            var checkExistItem = _stock.TryAdd(code, 0); //true - if add , false if already exist in Dictionary

            if (!_stock.ContainsKey(code) && checkExistItem == true)
            {
                _stock.TryAdd(code, 0);
            }
            else
            {
                var oldValue = _stock[code];
                _stock.TryUpdate(code, oldValue + quantity, oldValue);

            }
            //_totalQuantityBought += quantity;
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
