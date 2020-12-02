using System;
using System.Linq;

// Name: Harris, Tia
// Lasy Update: 10/02/2020
// Synopsis: Game development code excercise, TicTacToe

namespace Game
{
    class Program
    {

        // Application entry point
        public static void Main(string[] args)
        {
            bool play = true;
            while (play)
            {
                //Instantiate
                TicTacToe.Play();

                //Ask the user if they want to play again
                play = PlayAgain();


            }

            //Exit Message
            Console.WriteLine("Maybe next time! Have a great day!");



        }

        //Allow user to run application again
        private static bool PlayAgain()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Would you like ti play again? [Y/N]");

            string response = Console.ReadLine().ToUpper();
            return (response == "Y") ? true : false;

        }




    // End class
    }
}
