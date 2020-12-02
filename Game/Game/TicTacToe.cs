﻿using System;
using System.Linq;



namespace Game
{
    public class TicTacToe
    {

        // Play
        public static void Play()
        {
            //Local variables
            string[] spaces = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string winner = null;
            bool stalemate = false;

            string player;
            string marker;

            //Display board
            DisplayBoard(spaces);

            //Play until someone wins
            int turns = 1;
            while (winner == null && !stalemate)
            {
                //Select player
                player = (turns % 2 == 0) ? "Player 2" : "Player 1";
                marker = (turns % 2 == 0) ? "0" : "X";

                //if (turns %2 == 0)
                //{
                //    player = "Player 2";
                //    marker = "0";
                //}
                //else
                //{
                //    player = "Player 1";
                //    marker = "X";
                //}

                //Choose space
                int space = ValidateSpace(spaces, $"[{player}]: Please choose a space ...") - 1;
                spaces[space] = marker;

                //refresh board
                DisplayBoard(spaces);

                //Check for winners
                winner = checkWinner(spaces, marker);
                stalemate = CheckStalemate(spaces, winner);

                turns++;




            }

            //Display winner
            if (winner != null)
            {
                Console.WriteLine("\r\n ================================================");
                Console.WriteLine($"Winner : {winner}");
                Console.WriteLine("=====================================================");
            }
            else if (stalemate)
            {
                Console.WriteLine("\r\n ================================================");
                Console.WriteLine("Oops, looks like a stalemate!");
                Console.WriteLine("=====================================================");
            }






        }



        //Game Board
        private static void DisplayBoard(string[] spaces)
        {
            Console.Clear();

            //HEader
            Console.Clear();
            Console.WriteLine("\r\n ===================================");
            Console.WriteLine(" Tic-Tac-Toe ");
            Console.WriteLine("==================================== \r\n");


            //Instructions
            Console.WriteLine(" ");

            //Board
            Console.WriteLine($"     |    |       ");
            Console.Write($"  {spaces[0]}  | {spaces[1]}  | {spaces[2]} \r\n");
            Console.WriteLine($" ____|____|______ ");
            Console.WriteLine($"     |    |       ");
            Console.Write($"  {spaces[3]}  | {spaces[4]}  | {spaces[5]} \r\n");
            Console.WriteLine($" ____|____|______ ");
            Console.WriteLine($"     |    |       ");
            Console.Write($"  {spaces[6]}  | {spaces[7]}  | {spaces[8]} \r\n");
            Console.WriteLine($"     |    |       ");
            Console.WriteLine("");


        }


        //Check Lines
        private static string checkWinner(string[] spaces, string marker)
        {
            string winner = null;
            if (
                //Horinzontals
                (spaces[0] == spaces[1] && spaces[1] == spaces[2])
                || (spaces[3] == spaces[4] && spaces[4] == spaces[5])
                || (spaces[6] == spaces[7] && spaces[7] == spaces[8])

                //Verticals
                || (spaces[0] == spaces[3] && spaces[3] == spaces[6])
                || (spaces[1] == spaces[4] && spaces[4] == spaces[6])
                || (spaces[2] == spaces[5] && spaces[5] == spaces[8])

                //Diagnals
                || (spaces[0] == spaces[4] && spaces[4] == spaces[8])
                || (spaces[2] == spaces[4] && spaces[4] == spaces[6])
                )
            {
                winner = marker;
            }
            return winner;
        }

        //Check for stalemate
        private static bool CheckStalemate(string[] spaces, string winner)
        {
            bool stalemate = false;
            if(winner == null && spaces.Distinct().Count() == 2)
            {
                stalemate = true;
            }

            return stalemate;
        }


        //validate space
        private static int ValidateSpace(string[] spaces, string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            int guess;

            while (!Int32.TryParse(input, out guess) || guess < 0 || guess > 9 || spaces[guess - 1] == "X")
            {


                Console.WriteLine("Invalid input, Please try again: ");
                input = Console.ReadLine();
            }

            return guess;
        }

    // End class
    }
}
