using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{

    public class Machine
    {
        string[] lines;
        public List<IProduct> ShopingCart = new List<IProduct> { };

        Graph Gr = new Graph();
        Money Cash = new Money();

        /// <summary>
        /// Menu... Or. Machine user interface.
        /// </summary>
        public void Menu()
        {
            InstallProductInMachine();

            do
            {
                Gr.Menu();
                DisplayMachineProductOnMenu();
                DisplaySelectedItemInformation();

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            AddItemToCart();
                            break;
                        }

                    case ConsoleKey.Escape:
                        {
                            if (AskIfUserWantToQuit()) return;
                            break;
                        }

                    case ConsoleKey.LeftArrow: { Gr.X--; break; }
                    case ConsoleKey.RightArrow: { Gr.X++; break; }

                    case ConsoleKey.UpArrow: { Gr.Y--; break; }
                    case ConsoleKey.DownArrow: { Gr.Y++; break; }

                    case ConsoleKey.PageUp: { Gr.Y = 0; break; }
                    case ConsoleKey.PageDown: { Gr.Y = 99; break; }
                }

            } while (true);
        }

        /// <summary>
        /// Products on screen
        /// </summary>
        public void DisplayMachineProductOnMenu()
        {
            foreach (string line in lines)
            {
                Gr.PlaceItemOnScreen(line);
            }
            Gr.DisplayMonyInMachine(Cash.Wallet[0]);
            Gr.DisplayItemsInCart(ShopingCart.Count);
        }

        /// <summary>
        /// Selected product information.
        /// </summary>
        public void DisplaySelectedItemInformation()
        {
            if (Gr.Y > 6) return;
            int Pos = Gr.Y * 3 + Gr.X;
            Gr.DisplayItemInfoOnTop(lines[Pos + 1]);
        }

        /// <summary>
        /// Add money
        /// </summary>
        public void InsertMoney()
        {
            Cash.InsertMoney();
        }

        /// <summary>
        /// Show products in chart
        /// </summary>
        public void ShowShopingCart()
        {
            Gr.DisplayOrBuyShoppingCart(this);
        }

        /// <summary>
        /// Buy selected products
        /// </summary>
        public void BuySelectedProducts()
        {
            Gr.DisplayOrBuyShoppingCart(this);
            Cash.ReturnMoney();
            ShopingCart.Clear();
        }

        /// <summary>
        /// Quit Y/N
        /// </summary>
        /// <returns></returns>
        public bool AskIfUserWantToQuit()
        {
            Gr.QuitGameQuestion();
            char key;
            key = Console.ReadKey().KeyChar;
            key = char.ToUpper(key);
            if (key == 'J') return true;       // Just end program..
            return false;
        }

        /// <summary>
        /// User need to insert money.
        /// </summary>
        /// <returns></returns>
        public bool OutOfCash()
        {
            int Pos = Gr.Y * 3 + Gr.X;
            string[] item = lines[Pos + 1].Split(new char[] { ';', '\r' });

            if (Int32.TryParse(item[4], out int ProductPrice) == false) return true;
            if (Cash.Wallet[0] < ProductPrice) return true;
            return false;
        }

        /// <summary>
        /// Lower line only for funktions, Money, Buy, Cart
        /// </summary>
        public void MachineFunction()
        {
            if (Gr.X == 0) Cash.InsertMoney();
            if (Gr.X == 1) BuySelectedProducts();
            if (Gr.X == 2) ShowShopingCart();
            return;
        }

        /// <summary>
        /// Add products to Shoping Cart.
        /// </summary>
        public void AddItemToCart()
        {
            if (Gr.Y > 6) { MachineFunction(); return; }

            if (OutOfCash() == true)
            {
                Gr.DispalyOutOfMoneyOnTop(Cash.Wallet[0]);
                return;
            }

            int Pos = Gr.Y * 3 + Gr.X;
            ShopingCart.Add(new ProductInCart(lines[Pos + 1]));

            ProductInCart p = ShopingCart[ShopingCart.Count - 1] as ProductInCart;
            int.TryParse(p.ProductPrice, out int cost);
            Cash.Wallet[0] -= cost;

        }

        /// <summary>
        /// Machine products in stock
        /// </summary>
        public void InstallProductInMachine()
        {
            lines = System.IO.File.ReadAllText(@".\VM-Items.txt").Split(new char[] { '\n' });
        }

    }

}
