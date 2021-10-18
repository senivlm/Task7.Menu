using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Ingredients ingredients = new Ingredients();
                ingredients.ReadIngredientsFromFile(@"C:\Users\Ростик\source\repos\Task7.Menu\Dishes.txt");
                ingredients.ReadPricesFromFile(@"C:\Users\Ростик\source\repos\Task7.Menu\Price.txt");
                ingredients.GetAllIngredients();
                string str = ingredients.ToString();
                Console.WriteLine(str);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
