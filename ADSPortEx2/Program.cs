using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADSPortEx2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // HELPER FUNCTIONS ---------------------------------------------------------------------------------------------------------------------------

            // Display menu options
            int menu()
            {
                Console.WriteLine(
                "Select an option\n" +
                "1. Add item to tree\n" +
                "2. Delete item from tree\n" +
                "3. Update item in tree\n" +
                "4. Display all items\n" +
                "5. Display earliest released game\n" +
                "6. Display tree height\n" +
                "7. Display item count\n" +
                "8. Exit Program\n" +
                ">>> "
                );
                int cmd;
                do
                {
                    if (int.TryParse(Console.ReadLine(), out cmd) && cmd > 0 && cmd <= 8)
                    {
                        break;
                    }
                    Console.WriteLine("Enter a valid command.");
                } while (true);
                return cmd;
            }

            // Insert item into tree
            void addItem(BSTree<VideoGame> tree)
            {
                if (tree == null)
                {
                    throw new Exception("addItem must take tree argument");
                }
                Console.WriteLine("\nType -1 to go back\n");
                Console.WriteLine("Enter game title: ");
                var title = Console.ReadLine().ToLower().Trim();
                if (title == "-1")
                {
                    return;
                }
                Console.WriteLine("Enter developer: ");
                var developer = Console.ReadLine().ToLower().Trim();
                if (developer == "-1")
                {
                    return;
                }
                Console.WriteLine("Enter release year: ");
                int release;
                do
                {
                    if (int.TryParse(Console.ReadLine(), out release) && release > 1000 && release <= 3000)
                    {
                        break;
                    }
                        Console.WriteLine("Enter valid input.");
                } while (true);
                if (release == -1)
                {
                    return;
                }
                VideoGame game = new VideoGame(title, developer, release);
                tree.InsertItem(game);
                Console.WriteLine($"\nSuccessfully added {title} to tree\n");
            }

            // Display items by users choice of tree traversal
            void displayItems(BSTree<VideoGame> tree)
            {
                Console.WriteLine(
                "Select an option\n" +
                "1. Pre-order\n" +
                "2. In-order\n" +
                "3. Post-order\n" +
                "4. BFS\n" +
                "5. Go back\n" +
                ">>> "
                );
                int cmd;
                do
                {
                    if (int.TryParse(Console.ReadLine(), out cmd) && cmd > 0 && cmd <= 5)
                    {
                        break;
                    }
                    Console.WriteLine("Enter a valid command.");
                } while (true);

                switch (cmd)
                {
                    case 1:
                        tree.PreOrder();
                        break;
                    case 2:
                        tree.InOrder();
                        break;
                    case 3:
                        tree.PostOrder();
                        break;
                    case 4:
                        tree.BFS();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }

            // TODO 
            void updateItem(BSTree<VideoGame> tree)
            {
                Console.WriteLine("To update a game please enter:\n1. Game Title\n2.Release Year\n");
                string game = Console.ReadLine().ToLower().Trim();
                int release;
                do
                {
                    if (int.TryParse(Console.ReadLine().ToLower().Trim(), out release) && release > 1000 && release <= 3000)
                    {
                        break;
                    }
                    Console.WriteLine("Enter valid year.");
                } while (true);

                var gameNode = new VideoGame();
                gameNode.Title = game;
                gameNode.Releaseyear = release;
                var found = tree.FindNode(gameNode);
                if (found == null)
                {
                    Console.WriteLine("\nTitle or release year is incorrect\nGoing back...\n"); // Search is only based on release year but this message is more appropriate for the user
                    return;
                }
                VideoGame foundGame = (VideoGame)found.Data;

                Console.WriteLine($"{foundGame.ToString()}"); // Displays found games data
                Console.WriteLine("\nGame Found!");

                Console.WriteLine("\nType -1 to go back\n");
                Console.WriteLine($"Change {foundGame.Title}s title: (leave blank to keep the same) ");
                var newtitle = Console.ReadLine().ToLower().Trim();
                if (newtitle == "-1")
                {
                    return;
                } else if (newtitle == "")
                {
                    newtitle = foundGame.Title;
                }
                    Console.WriteLine($"Change {foundGame.Title}s developer: (leave blank to keep the same) ");
                var newdeveloper = Console.ReadLine().ToLower().Trim();
                if (newdeveloper == "-1")
                {
                    return;
                } else if (newdeveloper == "")
                {
                    newdeveloper = foundGame.Developer;
                }
                    Console.WriteLine("Enter release year: (type 0 to keep the same) ");
                int newrelease;
                do
                {
                    if (int.TryParse(Console.ReadLine(), out newrelease) && newrelease > 1000 && newrelease <= 3000)
                    {
                        break;
                    } else if (newrelease == -1)
                    {
                        return;
                    } else if (newrelease == 0)
                    {
                        newrelease = foundGame.Releaseyear;
                        break;
                    }
                    Console.WriteLine("Enter valid year.");
                } while (true);

                gameNode.Title = newtitle;
                gameNode.Developer = newdeveloper;
                gameNode.Releaseyear = newrelease;
                
                tree.Update(gameNode);
                Console.WriteLine("\nSuccessfully Updated Game!\n");
            }

            var BST = new BSTree<VideoGame>();

            while (true)
            {
                int cmd = menu();

                // Switch Case more readable than else-if
                switch (cmd)
                {
                    case 1:
                        addItem(BST);
                        break;
                    case 2:
                        throw new NotImplementedException();
                    case 3:
                        updateItem(BST);
                        break;
                    case 4:
                        displayItems(BST);
                        break;
                    case 5:
                        var game = BST.EarliestGame();
                        Console.WriteLine($"Earliest game: {game.Title} by {game.Developer}\n" +
                                          $"Release - {game.Releaseyear}\n");
                        break;
                    case 6:
                        throw new NotImplementedException();
                    case 7:
                        throw new NotImplementedException();
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }

            Console.ReadLine();

        }
    }
}
