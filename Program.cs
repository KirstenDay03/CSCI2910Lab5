namespace CSCI2910Lab5
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            JokesAPI api = new JokesAPI();
            int jokeCount = 0;  //Keeps track of the number of jokes read

            Console.WriteLine("-------------------------------------------");   //Menu header
            Console.WriteLine("Welcome to the Chuck Norris Joke Generator!\n" +
                              "      What would you like to do?");

            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("-------------------------------------------");   //Creates menu
                Console.WriteLine("1. Get a random joke\n" +
                                  "2. Get a joke from a specific category\n" +
                                  "3. Exit");
                Console.WriteLine("-------------------------------------------");

                Console.Write("Please enter the number of your selection: ");

                string response = Console.ReadLine();

                Console.WriteLine();

                if (response == "1")    //Sends a request for a random joke
                {
                    jokeCount++;

                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine($"Joke {jokeCount}: {await api.GetRandomJoke()}");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine();
                }
                else if (response == "2")   //Sends a request for a joke from a specific category
                {
                    List<string> list = new List<string>();

                    list = await api.GetJokeCategories();

                    bool goodInput = false;
                    while (!goodInput)
                    {

                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("              Category List");
                        Console.WriteLine("-------------------------------------------");

                        foreach (string category in list)
                        {
                            Console.WriteLine(category);
                        }

                        Console.WriteLine("-------------------------------------------");

                    
                        Console.Write("Please enter your chosen category: ");

                        string selection = Console.ReadLine().ToLower();
                        Console.WriteLine();
                    
                    
                        try
                        {
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine($"Joke {jokeCount+1}: {await api.GetJokeFromCategory(selection)}");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine();

                            goodInput = true;
                            jokeCount++;
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Incorrect Input. Please try again.");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine();
                        }
                    }
                }
                else if(response == "3")    //Ends the program and tells the user how many jokes they read
                {
                quit= true;
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine($"Thank you for using the Chuck Norris Joke Generator!\n" +
                                      $"You read {jokeCount} Jokes");
                    Console.WriteLine("-----------------------------------------------------");
                }
                else    //If none of the menu options are selected, this else tells the user to try again
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine($"{response} is not an option.\n" +
                                      $" Please select one of the menu options.");
                    Console.WriteLine("-------------------------------------------");
                }
            }

            
        }//End Main
    }//End Program
}//End Namespace