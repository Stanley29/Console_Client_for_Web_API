using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryWebClient;

namespace WebConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu m = new Menu();
            ShoppingManager sm = new ShoppingManager();

            do
            {
                m.Start();
                switch (m.Choice)
                {
                    case 1://get items list
                        
                        sm.GetShopApply();
                        foreach (var b in ShoppingManager._shopitems)
                        {
                            Console.WriteLine($"Id: {b.Id}\tName: {b.Name}\tPrice: " +
                        $"{b.Price}\tManufacturer: {b.Manufacturer}\t");
                        }
                        

                        Console.WriteLine("Task completed succesfully!");
                        Console.ReadKey();
                        break;
                    case 2://get item
                        Console.WriteLine("Get shopping object by ID...");
                        Console.WriteLine("Please, input Id:");
                        string ID = Console.ReadLine();
                        Guid guid = new Guid(ID);
                        
                        ShoppingItem outputProduct = sm.GetShoppingApply(guid);
                        Console.WriteLine($"Id: {outputProduct.Id}\tName: {outputProduct.Name}\tPrice: " +
                        $"{outputProduct.Price}\tManufacturer: {outputProduct.Manufacturer}\t");

                        break;
                    case 3://create one item
                            
                        Console.WriteLine("Creating shopping object...");
                        
                        
                        Console.WriteLine("Please, input name:");
                        string Name3 = Console.ReadLine();
                        Console.WriteLine("Please, input Price:");
                        string Price3 = Console.ReadLine();
                        decimal price = Convert.ToDecimal(Price3);
                        Console.WriteLine("Please, input Manufacturer:");
                        string Manufacturer = Console.ReadLine();
                        


                        ShoppingItem product = new ShoppingItem
                        {
                            
                            Name = Name3,
                            Price = price,
                            Manufacturer = Manufacturer
                        };

                        
                        Console.WriteLine($"Created at: {sm.CreateShoppingApply(product)}");

                        break;
                    case 4://update one item
                           // Update the product
                        Console.WriteLine("Updating shopping object...");
                        
                        Console.WriteLine("Please, input Id:");
                        string ID4 = Console.ReadLine();
                        Guid guid4 = new Guid(ID4);
                        Console.WriteLine("Please, input name:");
                        string NAME4 = Console.ReadLine();
                        Console.WriteLine("Please, input price:");                      
                        string Price4 = Console.ReadLine();
                        decimal price4 = Convert.ToDecimal(Price4);
                        Console.WriteLine("Please, input Manufacturer:");
                        string Manufacturer4 = Console.ReadLine();

                        ShoppingItem product4 = new ShoppingItem
                        {
                            Id = guid4,
                            Name = NAME4,
                            Price = price4,
                            Manufacturer = Manufacturer4
                        };

                        
                        Console.WriteLine($"Update at: {sm.UpdateShoppingApply(product4)}");

                        break;
                    case 5://delete one certain item
                           //    // Delete the product
                        Console.WriteLine("Deleting shopping object...");
                        Console.WriteLine("Please, input Id:");
                        string ID5 = Console.ReadLine();
                        Guid guid5 = new Guid(ID5);
                        Console.WriteLine($"Delete at: {sm.DeleteShoppingApply(guid5)}");
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }

                if (m.Choice == 6)
                {
                    break;
                }

            } while (m.AllowContinue());
            m.Finish();
        }
    }
}
