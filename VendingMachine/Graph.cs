using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Graph
    {
        /// <summary>
        /// X , Y   Startpoint.  Insert Money.
        /// </summary>
        public int X { get; set; } = 0;
        public int Y { get; set; } = 7;

        private readonly int Line = 4;    // Place on screen.
        private readonly int Col = 10;

        /// <summary>
        /// Clear top
        /// </summary>
        public void ClearInfolineOnToP()
        {
            int l = Line + 1;
            int c = Col + 2;
            WriteAt(@"                                                              ", c, l++);
            WriteAt(@"                                                              ", c, l++);
            WriteAt(@"                                                              ", c, l++);
        }

        /// <summary>
        /// Quit Now.
        /// </summary>
        public void QuitGameQuestion()
        {
            int line = Line + 1;
            int col = Col + 2;
            Console.CursorVisible = false;
            ConsoleColor btmp = Console.BackgroundColor;
            ConsoleColor ftmp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;

            WriteAt(@"                   Vill du verkligen avbryta?                 ", col, line++);
            WriteAt(@"                            Ja / Nej                          ", col, line++);
            WriteAt(@"                              [N]                             ", col, line++);

            Console.BackgroundColor = btmp;
            Console.ForegroundColor = ftmp;
        }

        /// <summary>
        /// The Machine.
        /// </summary>
        public void Menu()
        {
            Console.CursorVisible = false;
            ConsoleColor tmp = Console.ForegroundColor;
            //Console.ForegroundColor = ConsoleColor.Blue;

            if (X < 0) X = 0; if (X > 2) X = 2;     // Safty check.
            if (Y < 0) Y = 0; if (Y > 7) Y = 7;

            int line = Line;                        // Place menu.
            int col = Col;

            int _x = X * 21 + col + 3;              // Cursor item position.
            int _y = Y * 4 + line + 8;

            line--; // Facelift ;-)

            WriteAt(@"                      ╔════════════════════╗                     ", col, line++);
            WriteAt(@" ╔════════════════════╝    Information:    ╚════════════════════╗", col, line++);  // 0
            WriteAt(@" ║   Välkommen till Hotell Californias Digitala varuautomat.    ║", col, line++);
            WriteAt(@" ║                   Flytta med piltangenter.                   ║", col, line++);
            WriteAt(@" ║             Tryck enter för att köpa vald vara.              ║", col, line++);
            WriteAt(@" ╚══════════════════════════════════════════════════════════════╝", col, line++);
            WriteAt(@"           1                    2                    3           ", col, line++);
            WriteAt(@" ╔════════════════════╦════════════════════╦════════════════════╗", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@"A║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ╠════════════════════╬════════════════════╬════════════════════╣", col, line++);  // 10
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@"B║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ╠════════════════════╬════════════════════╬════════════════════╣", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@"C║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ╠════════════════════╬════════════════════╬════════════════════╣", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@"D║                    ║                    ║                    ║", col, line++);  // 20
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ╠════════════════════╬════════════════════╬════════════════════╣", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@"E║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ╠════════════════════╬════════════════════╬════════════════════╣", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@"F║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ╠════════════════════╬════════════════════╬════════════════════╣", col, line++);  // 30
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@"G║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ╠════════════════════╬════════════════════╬════════════════════╣", col, line++);
            WriteAt(@" ║                    ║                    ║                    ║", col, line++);
            WriteAt(@" ║   Sätt in pengar   ║  Köp valda varor   ║      Varukorg      ║", col, line++);
            WriteAt(@" ║                    ║                    ║      ________./    ║", col, line++);
            WriteAt(@" ║                    ║                    ║      ▒▒▒▒▒▒▒▒▒     ║", col, line++);
            WriteAt(@" ║  Konto:     0 Kr   ║  Valda varor:  0   ║       ▒▒▒▒▒▒▒      ║", col, line++);
            WriteAt(@" ║                    ║                    ║       /______\     ║", col, line++);   // 40
            WriteAt(@" ║                    ║Esc för att avsluta.║      (o)    (o)    ║", col, line++);
            WriteAt(@" ╚════════════════════╩════════════════════╩════════════════════╝", col, line++);
            WriteAt(@"                                                                 ", col, line++);
            WriteAt(@"                                                                 ", col, line++);   // 44          

            Console.ForegroundColor = ConsoleColor.Red;
            
            WriteAt("▒▒▒▒▒", _x, _y - 1);
            WriteAt("▒▒▒▒▒", _x + 13, _y - 1);
            WriteAt("▒", _x, _y);
            WriteAt("▒", _x + 17, _y);
            WriteAt("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒", _x, _y + 1);

            Console.ForegroundColor = tmp;
        }

        /// <summary>
        /// Display products in chart.
        /// </summary>
        /// <param name="M"></param>
        public void DisplayOrBuyShoppingCart(Machine M)
        {
            Console.Clear();
            int line = Line;                        // Place menu.
            int col = Col; // -5;
 
            WriteAt("Du har följande varor i din korg.", col, line++);

            line++;
            int ProdNr = 0;
            foreach (var items in M.ShopingCart)
            {
                ProdNr++;
                WriteAt("(" + ProdNr.ToString() + ")", col-5, line);
                WriteAt(items.ProductName ,col, line);
                WriteAt(" Kostar " + items.ProductPrice + " Kr", col + 18, line++);
                WriteAt(items.ProductDeskription, col, line++);
                WriteAt(items.ProductUsage, col, line++);

                if (items.ServiceInfo != null)
                {
                    WriteAt("Detta är ingen fysisk vara. " + items.ServiceInfo, col, line++);
                }
                line++;
                line++;
            }

            WriteAt("Tryck enter för att fortsätta.", col, line++);
            Console.ReadKey();
            Console.Clear();

        }

        /// <summary>
        /// Buyer information.
        /// </summary>
        /// <param name="line"></param>
        public void DisplayItemInfoOnTop(string line)
        {
            ConsoleColor btmp = Console.BackgroundColor;
            ConsoleColor ftmp = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            ClearInfolineOnToP();

            string[] item = line.Split(new char[] { ';', '\r' });

            int _x =  Col + 4 + 30;
            int _y =  Line + 1;

            WriteAt(item[3], _x - item[3].Length / 2 - 2, _y + 0);
            WriteAt(item[5], _x - item[5].Length / 2 - 2, _y + 1);
            WriteAt(item[6], _x - item[6].Length / 2 - 2, _y + 2);

            Console.BackgroundColor = btmp;
            Console.ForegroundColor = ftmp;
        }

        /// <summary>
        /// Not enough money.
        /// </summary>
        /// <param name="cash"></param>
        public void DispalyOutOfMoneyOnTop(int cash)
        {
            ConsoleColor btmp = Console.BackgroundColor;
            ConsoleColor ftmp = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;

            ClearInfolineOnToP();

            int line = Line + 1;
            int col = Col + 5;
            WriteAt("              Du kan inte köpa denna vara!", col, line++);
            WriteAt("          Du har " + cash.ToString() + " kronor kvar att handla för.", col, line++);
            WriteAt("             Tryck enter för att fortsätta.", col, line++);
            Console.ReadKey();

            Console.BackgroundColor = btmp;
            Console.ForegroundColor = ftmp;
        }

        /// <summary>
        /// Money 
        /// </summary>
        /// <param name="cache"></param>
        public void DisplayMonyInMachine(int cache)
        {
            string money = cache.ToString();
            WriteAt("Konto:         ",Col+ 4,Line + 39);
            WriteAt(money + " Kr", Col + 17 - money.Length, Line + 39);
        }

        /// <summary>
        /// Items in cart
        /// </summary>
        /// <param name="nr"></param>
        public void DisplayItemsInCart(int nr)
        {
            string items = nr.ToString();
            WriteAt(items, Col + 40 - items.Length, Line + 39);
        }
        /// <summary>
        /// Insert money
        /// </summary>
        /// <param name="Cash"></param>
        public void InsertMoneyMenu(int Cash)
        {
            Console.Clear();
            int line = Line + 10;                        
            int col = Col + 30;
         
            WriteAt("Välj belopp    1-9", col, line++);
            WriteAt("                  ", col, line++);
            WriteAt("0. Avslut    (Esc)", col, line++);
            WriteAt("                  ", col, line++);
            WriteAt("1.         1000 Kr", col, line++);
            WriteAt("2.          500 Kr", col, line++);
            WriteAt("3.          100 Kr", col, line++);
            WriteAt("4.           50 Kr", col, line++);
            WriteAt("5.           20 Kr", col, line++);
            WriteAt("6.           10 Kr", col, line++);
            WriteAt("7.            5 Kr", col, line++);
            WriteAt("8.            1 Kr", col, line++);
            WriteAt("                  ", col, line++);
            WriteAt(" Konto:       0 Kr", col, line++);
            string s = Cash.ToString();
            WriteAt(s, col + 15 - s.Length, line - 1);
            WriteAt("                  ", col, line++);

        }

        /// <summary>
        /// Return money
        /// </summary>
        /// <param name="Wallet"></param>
        public void ReturnMoney(int[] Wallet)
        {
            Console.Clear();
            int line = Line + 10;                        
            int col = Col + 30;

            WriteAt("  Återbetalning:  ", col, line++);
            WriteAt("                  ", col, line++);
            WriteAt("                  ", col, line++);
            WriteAt("Antal:     Valör: ", col, line++);

            WriteAt("           1000 Kr", col, line++);
            WriteAt(Wallet[1].ToString(), col + 5 - Wallet[1].ToString().Length, line - 1);
            WriteAt("            500 Kr", col, line++);
            WriteAt(Wallet[2].ToString(), col + 5 - Wallet[2].ToString().Length, line - 1);
            WriteAt("            100 Kr", col, line++);
            WriteAt(Wallet[3].ToString(), col + 5 - Wallet[3].ToString().Length, line - 1);
            WriteAt("             50 Kr", col, line++);
            WriteAt(Wallet[4].ToString(), col + 5 - Wallet[4].ToString().Length, line - 1);
            WriteAt("             20 Kr", col, line++);
            WriteAt(Wallet[5].ToString(), col + 5 - Wallet[5].ToString().Length, line - 1);
            WriteAt("             10 Kr", col, line++);
            WriteAt(Wallet[6].ToString(), col + 5 - Wallet[6].ToString().Length, line - 1);
            WriteAt("              5 Kr", col, line++);
            WriteAt(Wallet[7].ToString(), col + 5 - Wallet[7].ToString().Length, line - 1);
            WriteAt("              1 Kr", col, line++);
            WriteAt(Wallet[8].ToString(), col + 5 - Wallet[8].ToString().Length, line - 1);
            WriteAt("                  ", col, line++);
            WriteAt("Konto:        0 Kr", col, line++);
            string s = Wallet[0].ToString();
            WriteAt(s, col + 15 - s.Length, line - 1);
            WriteAt("                  ", col, line++);
            WriteAt("   Tryck enter.   ", col, line++);
        }

        /// <summary>
        /// Place products on screen.
        /// </summary>
        /// <param name="items"></param>
        public void PlaceItemOnScreen(string items) 
        {

            string[] item = items.Split(new char[] { ';', '\r' });
            if (Int32.TryParse(item[0], out int y) == false) return;
            if (Int32.TryParse(item[1], out int x) == false) return;

            int _x = x * 21 + Col + 4 + 8;
            int _y = y * 4 + Line + 7;
            
            // Center and write.
            WriteAt(item[4] + " Kr", _x - item[4].Length / 2 -2, _y + 0);
            WriteAt(item[3], _x - item[3].Length / 2, _y + 1);

        }

        /// <summary>
        /// Write engine
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch
            {
                Console.Clear();
                Console.SetWindowSize(150, 60);
            }
        }

    }
}
