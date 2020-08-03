using System;
using System.ComponentModel;
using System.IO.Pipes;

namespace RockPaparScissors
{
    enum Roshambo
    {
        Rock,
        Paper,
        Scissors
    }

    abstract class Player
    {
        public string Name { get; set; }

        public Roshambo Choice { get; set; }
                   
      
        public virtual void GenerateRoshambo()
        {
           //return $"{RoshamboValue}({(int)RoshamboValue})";
        }
    }
    class RandomPlayer
    {
        public string Com1 { get; set; }
        
        public static Roshambo RoshamboValue { get; set; }

        public static Random random = new Random();
        public RandomPlayer(string com1Name)
        {
            Com1 = com1Name;
        }        
        public static void GenerateRoshambo()
        {
            Roshambo rock = Roshambo.Rock;
            Roshambo paper = Roshambo.Paper;
            Roshambo scissors = Roshambo.Scissors;

            int roshambo = random.Next(3);                      
             
           if(roshambo == (int)rock)
            {
                RoshamboValue = Roshambo.Rock;
                Console.WriteLine($"{RoshamboValue}");
            }
           else if (roshambo == (int)paper)
            {
                RoshamboValue = Roshambo.Paper;
                Console.WriteLine($"{RoshamboValue}");
            }
           else if (roshambo == (int)scissors)
            {
                RoshamboValue = Roshambo.Scissors;
                Console.WriteLine($"{RoshamboValue}");
            }
            


        
        }
    }
    class Rock
    {
        public string Com2 { get; set; }
        public Rock(string com2Name)
        {
            Com2 = com2Name;
        }

        public static string GenerateRoshambo()
        {
            return $"{Roshambo.Rock}";
        }
    }
    class HumanPlayer : Player
    {

        public override void GenerateRoshambo()
        {
            bool repeat = true;

            while (repeat)
            {
                Console.WriteLine("Rock, Paper, Scissors? (R/P/S) :");
                string choice = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (choice == "r")
                {
                    Choice = Roshambo.Rock;
                    Console.WriteLine($"{Name}: {Roshambo.Rock}");
                    repeat = false;
                }
                else if (choice == "p")
                {
                    Choice = Roshambo.Paper;
                    Console.WriteLine($"{Name}: {Roshambo.Paper}");
                    repeat = false;
                }
                else if (choice == "s")
                {
                    Choice = Roshambo.Scissors;
                    Console.WriteLine($"{Name}: {Roshambo.Scissors}");
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }
            }
        }

    }


    class Program
    {
        static void Play(Player thePlayer)
        {
            thePlayer.GenerateRoshambo();
        }     
        
        static void Main(string[] args)
        {
            bool repeat = true; 

            Rock rock = new Rock("Button Mashers");
            RandomPlayer randomPlayer = new RandomPlayer("Skills"); 

            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.WriteLine();

            Console.WriteLine("Please enter your name: ");
            HumanPlayer player = new HumanPlayer();
            player.Name = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine($"Would you like to play against the {rock.Com2} or {randomPlayer.Com1}? (b/s)");
            string playerAns = Console.ReadLine().ToLower();
            Console.WriteLine();

            while (playerAns != "b" && playerAns != "s")
            {
                Console.WriteLine("Please enter valid answer");
                playerAns = Console.ReadLine().ToLower();
            }

            do
            {
                if (playerAns == "b")
                {
                    Play(player);
                    Console.WriteLine($"{rock.Com2}: {Roshambo.Rock}");

                    if (player.Choice == Roshambo.Rock)
                    {
                        Console.WriteLine("Result : Draw");
                    }
                    else if (player.Choice == Roshambo.Paper)
                    {
                        Console.WriteLine("Result : Win");
                    }
                    else if (player.Choice == Roshambo.Scissors)
                    {
                        Console.WriteLine("Result : Lose");
                    }

                }
                else if (playerAns == "s")
                {
                    Play(player);
                    Console.Write($"{randomPlayer.Com1}: ");
                    RandomPlayer.GenerateRoshambo();

                    if (player.Choice == Roshambo.Scissors && RandomPlayer.RoshamboValue == Roshambo.Paper)
                    {
                        Console.WriteLine("Result : Win");
                    }
                    else if (player.Choice == Roshambo.Rock && RandomPlayer.RoshamboValue  == Roshambo.Scissors)
                    {
                        Console.WriteLine("Result : Win");
                    }
                    else if (player.Choice == Roshambo.Paper && RandomPlayer.RoshamboValue == Roshambo.Rock)
                    {
                        Console.WriteLine("Result : Win");
                    }
                    else if (player.Choice == Roshambo.Scissors && RandomPlayer.RoshamboValue == Roshambo.Rock)
                    {
                        Console.WriteLine("Result : Lose");
                    }
                    else if (player.Choice == Roshambo.Rock && RandomPlayer.RoshamboValue  == Roshambo.Paper)
                    {
                        Console.WriteLine("Result : Lose");
                    }
                    else if (player.Choice == Roshambo.Paper && RandomPlayer.RoshamboValue == Roshambo.Scissors)
                    {
                        Console.WriteLine("Result : Lose");
                    }
                    else
                    {
                        Console.WriteLine("Result : Tie");
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid choice");
                }


                Console.WriteLine();

                Console.WriteLine("Would you like to play again? (y/n)");
                string contAns = Console.ReadLine().ToLower();
                Console.WriteLine();

                while(contAns != "y" && contAns != "n")
                {
                    Console.WriteLine("Please enter valid answer");
                    contAns = Console.ReadLine().ToLower();
                }
                if (contAns == "n")
                {
                    repeat = false;
                }
                else if (contAns == "y")
                {
                        
                }           

            } while (repeat);

        }
    }
}
