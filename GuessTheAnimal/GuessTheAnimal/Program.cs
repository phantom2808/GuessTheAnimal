using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GuessTheAnimal
{
    class Program
    {
        static XDocument xDoc = XDocument.Load("Animals.xml");

        /// <summary>
        /// String helper method to capitalise the first letter of a string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);

            return new string(a);
        }

        /// <summary>
        /// /Query XML for all animals. Executes a LINQ query.
        /// </summary>
        static void DisplayAllAnimals()
        {
            var animals = from r in xDoc.Descendants("Animal")
                          select r;

            foreach (var animal in animals)
            {
                Console.WriteLine("Animal name:-" + animal.Element("name").Value);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Finds the animal based on the answers the user provides to the questions. Executes a LINQ query.
        /// </summary>
        /// <param name="sound"></param>
        /// <param name="feature"></param>
        /// <param name="colour"></param>
        static void FindAnimal(string sound, string feature, string colour)
        {
            try
            {
                var selectedEmp = from r in xDoc.Descendants("Animal")
                                  .Where(r => (string)r.Element("sound").Value == sound.ToLower() &&
                                  (string)r.Element("feature").Value == feature.ToLower() &&
                                  (string)r.Element("colour").Value == colour.ToLower())
                                  select r;

                XElement a = selectedEmp.ElementAt(0);

                //Return the found animal to the console
                Console.WriteLine(a.Element("name").Value + "; has a " + a.Element("feature").Value + ", " + a.Element("sound").Value + " and is " + a.Element("colour").Value);
            }
            catch (Exception e)
            {
                Console.WriteLine("You got me!! I have no idea what Animal you have thought of....maybe you should add this Animal to the game?");
            }
        }

        /// <summary>
        /// Add an amimal to the game (XML file)
        /// </summary>
        static void AddAnimal()
        {
            try
            {
                Console.WriteLine("Enter the Animals name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the Animals sound:");
                string sound = Console.ReadLine();

                Console.WriteLine("Enter the Animals feature:");
                string feature = Console.ReadLine();

                Console.WriteLine("Enter the Animals colour:");
                string colour = Console.ReadLine();

                XElement root = xDoc.Element("Animals");

                IEnumerable<XElement> rows = root.Descendants("Animal");
                XElement firstRow = rows.First();

                xDoc.Root.Add(
                    new XElement("Animal",
                    new XElement("name", UppercaseFirst(name)),
                    new XElement("sound", sound.ToLower()),
                    new XElement("feature", feature.ToLower()),
                    new XElement("colour", colour.ToLower())));

                xDoc.Save("Animals.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to add the Animal.");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Driver for the GuessTheAnimal game.
        /// </summary>
        static void PlayGuessTheAnimal()
        {
            if (Console.ReadLine().Equals("add"))
            {
                AddAnimal();
            }
            else
            {
                Console.WriteLine("What sound does the Animals make:");
                string sound = Console.ReadLine();
                Console.WriteLine("What is the main feature of the Animal:");
                string feature = Console.ReadLine();
                Console.WriteLine("What is the colour of the Animal:");
                string colour = Console.ReadLine();

                FindAnimal(sound, feature, colour);
            }
        }

        static void Main()
        {
            Console.WriteLine("GuessTheAnimal [To add an animal enter 'add']");
            Console.WriteLine("");
            Console.WriteLine("Please think of an animal...");
            Console.WriteLine("I will guess the animal by asking three questions. [Press Enter to start]");

            PlayGuessTheAnimal();

            Console.WriteLine("");
            Console.WriteLine("Press 'y' to play again");

            string restart = Console.ReadLine();

            if (restart == "y")
            {
                Console.Clear();
                Main();
            }
        }
    }
}
