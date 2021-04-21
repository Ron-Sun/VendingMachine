using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine
{

    class Program
    {
        /// <summary>
        /// Here we go again.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 60);
            Machine M = new Machine();          
            M.Menu();
        }
    }
}
