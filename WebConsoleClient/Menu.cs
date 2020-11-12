using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebConsoleClient
{
    class Menu
    {
        public string Ans { get; set; }
        public int Choice { get; set; }
        public void Start()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n\t =====================");
            Console.WriteLine("\n\t Web API test client");
            Console.WriteLine("\n\t =====================");
            Console.WriteLine("\n\t =");
            Console.WriteLine("\t 1: GET items"); //get items list
            Console.WriteLine("\t 2: GET item ");//get one certain item
            Console.WriteLine("\t 3: POST item");//create one item
            Console.WriteLine("\t 4: PUT item");//update one item
            Console.WriteLine("\t 5: DELETE item");//delete one certain item
            
            Console.WriteLine("\t 6: Exit");
            Console.WriteLine("\n\t =====================");
            Console.WriteLine("\n\t Please, make your choice");
            try
            {
                Choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception err)
            {
                Console.WriteLine("{0} - error of the menu option choice!", err.Message);
            }

        }

        public void Finish()
        {
            Console.WriteLine("\nProgram finished");
        }

        public bool AllowContinue()
        {
            Console.Write("\n Continue (y/n)? - ");
            Ans = Console.ReadLine();
            return (Ans == "y");
            //return true;
        }

        public bool AllowLoop()
        {
            Console.Write("\n Break the loop(y)? - \n");

            // Ans = Console.ReadLine();
            //if (Ans == "y")
            //{
            //    return false;

            //}
            return true;

        }
    }
}
