using ClassLibrary1;
using ConsoleTables;

namespace BudgetApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            bool running = true;

            while(running)
            {
                running = menu.ShowMenu();
            }
        }
    }
}

