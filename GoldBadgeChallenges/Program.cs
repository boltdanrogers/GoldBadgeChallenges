using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Cafe


{
    class Program
    {
        static void Main(string[] args)
        {
            //just going to instantiate and call the run method of that programUI class
            ProgramUI programUserInterface = new ProgramUI();

            //and now call the object's run method

            programUserInterface.Run();

            //and there we go, it'll do it's thing and then get here again right before it exits

            Console.WriteLine("Press Enter to exit program:");
            Console.ReadLine();
        
        }
    }
}
