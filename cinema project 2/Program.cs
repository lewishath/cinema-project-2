using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cinema_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool valid = false;
            do
            {


                // introduction
                Console.WriteLine("Welcome to Aquinas Muliplex!");
                Console.WriteLine("We are presently showing:");
                Console.WriteLine("1. Filth (18)");
                Console.WriteLine("2. Rush (15)");
                Console.WriteLine("3. How I Live Now (15)");
                Console.WriteLine("4. Thor: The Dark World (12)");
                Console.WriteLine("5. Planes (U)");

                // information

                TimeSpan time = TimeSpan.FromHours(2);

                Console.WriteLine("Enter your age:");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the number of the film you wish to see:");
                string filmchoice = Console.ReadLine();
                int choice = int.Parse(filmchoice);

                switch (choice)
                {
                    case 1:
                        filmchoice = "Filth";
                        break;

                    case 2:
                        filmchoice = "Rush";
                        break;

                    case 3:
                        filmchoice = "How I Live Now";
                        break;

                    case 4:
                        filmchoice = "Thor: The Dark World";
                        break;

                    case 5:
                        filmchoice = "Planes";
                        break;
                }

                string availablefilms = " ";

                if (choice > 5 || choice <= 0)
                {
                    Console.WriteLine("Access denied - no such film!");
                }

                int choiceage = 0;
                switch (choiceage)
                {
                    case 1:
                        choiceage = 18;
                        break;

                    case 2:
                        choiceage = 15;
                        break;

                    case 3:
                        choiceage = 15;
                        break;

                    case 4:
                        choiceage = 12;
                        break;

                    case 5:
                        choiceage = 0;
                        break;
                }


                DateTime booking = DateTime.Today;
                DateTime today = DateTime.Today;
                DateTime deadline = today.AddDays(7);

                TimeSpan show1 = TimeSpan.FromHours(15);
                TimeSpan show2 = TimeSpan.FromHours(17);
                TimeSpan show3 = TimeSpan.FromHours(19);

                if (choiceage > age && age > 14)
                {
                    availablefilms = "4,3,2,1";
                    Console.WriteLine("Access denied - you are too young to watch this!");
                    Console.WriteLine($"You can watch {availablefilms} though! Enter which number you wish to see!");
                    choice = int.Parse(Console.ReadLine());
                }
                else if (choiceage > age && age > 11)
                {
                    availablefilms = "4,5";
                    Console.WriteLine("Access denied - you are too young to watch this!");
                    Console.WriteLine($"You can watch {availablefilms} though! Enter which number you wish to see!");
                    choice = int.Parse(Console.ReadLine());
                }
                else if (choiceage > age && age > 0)
                {
                    availablefilms = "5";
                    Console.WriteLine("Access denied - you are too young to watch this!");
                    Console.WriteLine($"You can watch {availablefilms} though! Enter which number you wish to see!");
                    choice = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine($"You are old enough to watch {choice}!");
                    Console.WriteLine("You can book your ticket(s) for 7 days in advance, enter the date you wish to see this film. (dd/mm/yyyy)");
                    booking = DateTime.Parse(Console.ReadLine());
                }

                while (booking > deadline || booking < today) 
                {
                    Console.WriteLine($"You can not book for this day, book within the deadline, {deadline}");
                    booking = DateTime.Parse(Console.ReadLine());
                }
                

                if (deadline >= booking)
                {
                    Console.WriteLine($"Great, you can book for {booking}, what time would you like?");
                    Console.WriteLine($"{show1}");
                    Console.WriteLine($"{show2}");
                    Console.WriteLine($"{show3}");

                    try
                    {
                        time = TimeSpan.Parse(Console.ReadLine());

                        if (time != show1 && time != show2 && time != show3)
                        {
                            Console.WriteLine("There are no available bookings for this time, book again.");
                            time = TimeSpan.Parse(Console.ReadLine());
                        }
                    }
                    catch
                    {
                        Console.WriteLine("This is not a time! Enter again");
                        time = TimeSpan.Parse(Console.ReadLine());
                    }
                }

                Random RNG = new Random();
                int screen = RNG.Next(1, 16);

                Console.WriteLine("Great, here is your ticket!");

                // ticket
                Console.WriteLine("--------------------");
                Console.WriteLine("Aquinas Multiplex");
                Console.WriteLine($"Film: {filmchoice}");
                Console.WriteLine($"Date: {booking}");
                Console.WriteLine($"Time: {time}");
                Console.WriteLine($"Screen: {screen}");
                Console.WriteLine("--------------------");

                Console.WriteLine("Would you like to book again (yes/no)");
                string answer = Console.ReadLine();
                string answer2 = answer.ToUpper();

                if (answer2 == "YES")
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.Write("Goodbye, press any key to end the program");
                    Console.ReadKey();
                }
            } while (valid == true);
        }

    }
}
