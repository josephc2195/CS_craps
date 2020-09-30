using System;

namespace Assignment1
{
    class Craps
    {
        //declaring a Random() object
        static Random rdNum = new Random();

        static void Main(string[] args)
        {
            int dice1 = 0;
            int dice2 = 0;
            int chips = 100;
            int wager = 0;
            bool cont = true;
            string playAgain;

            Console.WriteLine("Welcome to Craps");
            Console.WriteLine("You will start with 100 chips");
            Console.WriteLine("You will roll 2 die to start the game. The roll determines what the next steps will be");
            Console.WriteLine();

            //as long as they want to continue playing, and they have chips, the program will run
            while(cont == true && chips > 0) {

                //asking user for wager amount
                Console.WriteLine("Chips available: " + chips);
                Console.Write("Please enter the amount of chips you would like to wager: ");
                wager = int.Parse(Console.ReadLine());

                //checking the user does not wager more chips then s(he) have.
                while(wager > chips)
                {
                    Console.Write("You do not have that ammount of chips. Please enter a correct amount ");
                    wager = int.Parse(Console.ReadLine());
                }
                chips = chips - wager;

                //Generating and storing random number from 1-7 in dice variables
                dice1 = rdNum.Next(1, 7);
                dice2 = rdNum.Next(1, 7);
                int sum = dice1 + dice2;

                Console.WriteLine("First roll: " + sum);

                //if user rolls a 7 or 11 on the first roll, they automatically win. Wager amount gets doubled and returned to user.
                if (sum == 7 || sum == 11)
                {
                    Console.WriteLine("You won!");
                    chips = chips + (wager * 2);
                    Console.WriteLine("Chips remaining: " + chips);
                    Console.WriteLine("Continue playing? (Type 'y' or 'n')");
                    playAgain = Console.ReadLine();

                    //as long as user doesn't type n the game will continue
                    if (playAgain == "n")
                    {
                        cont = false;
                    }
                }

                //if user rolls a 2, 3, or 12 on first roll they lose.
                else if (sum == 2 || sum == 3 || sum == 12)
                {
                    Console.WriteLine("You lose");
                    Console.WriteLine("Chips remaining: " + chips);
                    Console.WriteLine("Continue playing? (Type 'y' or 'n')");
                    playAgain = Console.ReadLine();

                    if (playAgain == "n")
                    {
                        cont = false;
                    }
                }
                //if user rolls anything else, this will be considered their point. 
                else
                {

                    Console.WriteLine("You scored " + sum + ". This is your new point. You must now roll this number again to win.");
                    Console.WriteLine("However, if you roll a 7 before rolling your point, you lose.");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();

                    int point = sum;
                    sum = 0;

                    //if the user rolls a 7 they lose, if they roll the sum they win. 
                    while (sum != 7 && sum != point)
                    {
                        dice1 = rdNum.Next(1, 7);
                        dice2 = rdNum.Next(1, 7);
                        sum = dice1 + dice2;

                        Console.WriteLine("You rolled: " + sum);
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }

                    //once the user is out of the while loop, they would have either won or lost
                    //in this if case is if they win
                    if (sum == point)
                    {
                        chips = chips + (wager * 2);
                        Console.WriteLine("You won! Here's double your wager! ");
                        Console.WriteLine("Chips remaining: " + chips);
                        Console.WriteLine("Continue playing? (Type 'y' or 'n')");
                        playAgain = Console.ReadLine();

                        if (playAgain == "n")
                        {
                            cont = false;
                        }
                    }

                    //in this case they lose
                    else
                    {
                        Console.WriteLine("You lose");
                        Console.WriteLine("Chips remaining: " + chips);
                        Console.WriteLine("Continue playing? (Type 'y' or 'n')");
                        playAgain = Console.ReadLine();

                        if(playAgain == "n")
                        {
                            cont = false;
                        }
                    }
                }

            }

            
        }
    }
}
