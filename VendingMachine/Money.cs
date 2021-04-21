using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Money
    {
        Graph Gr = new Graph();
        public int[] Wallet = new int[] { 0, 1000, 500, 100, 50, 20, 10, 5, 1 };

        /// <summary>
        /// insert money
        /// </summary>
        public void InsertMoney()
        {
            do
            {
                Gr.InsertMoneyMenu(Wallet[0]);
                char key = Console.ReadKey().KeyChar;
                key = char.ToUpper(key);

                switch (key)
                {
                    case '0': return;
                    case '1': { Wallet[0] += Wallet[1]; break; }
                    case '2': { Wallet[0] += Wallet[2]; break; }
                    case '3': { Wallet[0] += Wallet[3]; break; }
                    case '4': { Wallet[0] += Wallet[4]; break; }
                    case '5': { Wallet[0] += Wallet[5]; break; }
                    case '6': { Wallet[0] += Wallet[6]; break; }
                    case '7': { Wallet[0] += Wallet[7]; break; }
                    case '8': { Wallet[0] += Wallet[8]; break; }
                    case '\u001B': { return; }  // Esc.
                }

            } while (true);
        }

        /// <summary>
        /// Return money to user.
        /// </summary>
        public void ReturnMoney()
        {
            int[] ToUser = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // Just to show it's empty.
            ToUser[0] = Wallet[0];

            int p = 1;
            do
            {
                if (Wallet[0] >= Wallet[p]) 
                {     
                    Wallet[0] -= Wallet[p];
                    ToUser[p] += 1; 
                }
                else
                {
                    p++;    // Try next denom.
                }

            } while (Wallet[0] > 0);

            Gr.ReturnMoney(ToUser);
            Console.ReadKey();

        }


    }
}
