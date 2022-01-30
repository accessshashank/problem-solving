using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.GreedyAlgos
{
    class FractionalKnapsack
    {
        static void Main(string[] args)
        {
            var items = new List<Item>();
            items.Add(new Item { Weight = 20, Value = 100 });
            items.Add(new Item { Weight = 30, Value = 120 });
            items.Add(new Item { Weight = 10, Value = 60 });

            int capacity = 50;

            FillKnapsackWithMaximumValue(items, capacity);
        }

        private static void FillKnapsackWithMaximumValue(List<Item> items, int capacity)
        {
            var output = new List<Item>();
            CalcDensity(items);
            var comp = new ItemComparer();
            items.Sort(comp);

            int k = 0;
            while(capacity > 0)
            {
                if(capacity >= items[k].Weight)
                {
                    output.Add(new Item { Weight = items[k].Weight, Value = items[k].Value });
                    capacity = capacity - items[k].Weight;
                    k++;
                }
                else
                {
                    output.Add(new Item { Weight = capacity, Value = (int)(capacity*items[k].Density) });
                    capacity = 0;
                }
            }

            Console.WriteLine("Total Weight = "+output.Sum(e => e.Weight));
            Console.WriteLine("Total Value = "+output.Sum(e => e.Value));
        }

        private static void CalcDensity(List<Item> items)
        {
            foreach (var item in items)
            {
                item.Density = item.Value / item.Weight;
            }
        }
    }

    public class ItemComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return y.Density.CompareTo(x.Density);
        }
    }

    public class Item
    {
        public int Weight { get; set; }
        public int Value { get; set; }
        public decimal Density { get; set; }
    }
}
