using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task7.Menu
{
    class Ingredients
    {
        private Dictionary<string, double> dishes;
        private Dictionary<string, double> prices;
        private Dictionary<string, (double, double)> ingredientsList;

        public Ingredients()
        {
            dishes = new Dictionary<string, double>();
            prices = new Dictionary<string, double>();
            ingredientsList = new Dictionary<string, (double, double)>();
        }

        public Ingredients(Dictionary<string, double> dishes, Dictionary<string, double> prices)
        {
            this.dishes = dishes;
            this.prices = prices;
        }

        public void AddIngredients(string product, double weight)
        {
            if(dishes.ContainsKey(product))
            {
                dishes[product] += weight;
            }
            else
            {
                dishes.Add(product, weight);   
            }
        }

        public void AddPrices(string product, double price)
        {
            if (!prices.ContainsKey(product))
            {
                prices.Add(product, price);
            } 
        }

        public void ReadIngredientsFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string data;
                    bool isEmpty = true;
                    while (!sr.EndOfStream)
                    {
                        data = sr.ReadLine();
                        isEmpty = false;
                        if (data.Length == 0)
                        {
                            continue;
                        }
                        string[] productInfo = data.Split();
                        if (productInfo.Count() == 1)
                        {
                            continue;
                        }

                        double weight = Convert.ToDouble(productInfo[1]);
                        AddIngredients(productInfo[0], weight);

                    }
                    if (isEmpty)
                    {
                        throw new Exception("File is empty!");
                    }
                    sr.Close();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        public void ReadPricesFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string data;
                    bool isEmpty = true;
                    while (!sr.EndOfStream)
                    {
                        data = sr.ReadLine();
                        if (data.Length == 0)
                        {
                            break;
                        }
                        string[] productInfo = data.Split();

                        double price = Convert.ToDouble(productInfo[1]);
                        AddPrices(productInfo[0], price);

                        isEmpty = false;
                    }
                    if (isEmpty)
                    {
                        throw new Exception("File is empty!");
                    }
                    sr.Close();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        public override string ToString()
        {
            string str = "";
            foreach(var product in ingredientsList)
            {
                str += $"{product.Key} {product.Value.Item1} {product.Value.Item2}\n";
            }
            return str;
        }

        public void GetAllIngredients()
        {
            foreach(var product in dishes)
            {
                if (prices.ContainsKey(product.Key))
                {
                    double price = product.Value * prices[product.Key];
                    ingredientsList.Add(product.Key, (product.Value, price));
                }
            }
        }

    }
}
