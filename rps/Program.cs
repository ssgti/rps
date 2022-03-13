using System;

namespace rps
{
    class Program
    {
        static int ConvertToNum(string playerChoice)
        {
            if (playerChoice == "r")      //rock
            {
                return 1;
            }
            else if (playerChoice == "p") //paper
            {
                return 2;
            }
            else if (playerChoice == "s") //scissors
            {
                return 3;
            }
            return 0;
        }
        static int Encounter(int pChoiceNum, int cpuChoice)
        {
            int scored = 1; //returns 1 if player scores
            switch (pChoiceNum)
            {
                case 1: //rock
                    switch (cpuChoice)
                    {
                        case 2: //rock vs paper
                            Console.WriteLine("paper beats rock - CPU wins");
                            break;
                        case 3: //rock vs scissors
                            Console.WriteLine("rock beats scissors - player wins");
                            return (scored);
                    }
                    break;
                case 2: //paper
                    switch (cpuChoice)
                    {
                        case 1: //paper vs rock
                            Console.WriteLine("paper beats rock - player wins");
                            return (scored);
                        case 3: //paper vs scissors
                            Console.WriteLine("scissors beats paper - CPU wins");
                            break;
                    }
                    break;
                case 3: //scissors
                    switch (cpuChoice)
                    {
                        case 1: //scissors vs rock
                            Console.WriteLine("rock beats scissors - CPU wins");
                            break;
                        case 2: //scissors vs paper
                            Console.WriteLine("scissors beats paper - player wins");
                            return (scored);
                    }
                    break;
            }
            return 0;
        }
        static void Main(string[] args)
        {
            bool debug = false;
            int playerScore = 0;
            int cpuScore = 0;
            string playerChoice;
            int pChoiceNum;
            int cpuChoice;
            Random rnd = new Random();

            Console.WriteLine("rock paper scissors game");
            Console.WriteLine("you play against the computer");
            Console.WriteLine("first to 10 points wins");
            Console.Write("would you like debug mode (y/n)");
            char answer = char.Parse(Console.ReadLine());
            if (answer == 'y')
            {
                debug = true;
            }

            do
            {
                Console.Write("rock, paper or scissors (r/p/s)");
                playerChoice = Console.ReadLine();
                pChoiceNum = ConvertToNum(playerChoice);
                cpuChoice = rnd.Next(1, 4);
                if (debug == true)
                {
                    Console.WriteLine("cpu chooses " + cpuChoice);
                }
                if (pChoiceNum == cpuChoice)
                {
                    Console.WriteLine("draw");
                    Console.WriteLine();
                }
                else
                {
                    if (Encounter(pChoiceNum, cpuChoice) == 1) //there are probably much better ways of doing this
                    {
                        playerScore++;
                    }
                    else
                    {
                        cpuScore++;
                    }
                    if (debug == true)
                    {
                        Console.WriteLine(playerScore + " " + cpuScore);
                    }
                    Console.WriteLine();
                }
            } while (playerScore < 10 && cpuScore < 10);
            if (playerScore == 10)
            {
                Console.WriteLine("you win");
            }
            else if (cpuScore == 10)
            {
                Console.WriteLine("you lose");
            }
            Console.ReadLine();
        }
    }
}