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
                "\nSelect an option:\n" +
                "1. Add item to tree\n" +
                "2. Delete item from tree\n" +
                "3. Update item in tree\n" +
                "4. Display all items\n" +
                "5. Display earliest released game\n" +
                "6. Display tree height\n" +
                "7. Display item count\n" +
                "8. Display items from a certain year\n" +
                "9. Exit Program\n" +
                ">>> "
                );
                int cmd;
                do
                {
                    if (int.TryParse(Console.ReadLine(), out cmd) && cmd > 0 && cmd <= 9)
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
                if (tree.FindNode(game) != null)
                {
                    Console.WriteLine("\nGame already exists in tree.");
                    return;
                }
                tree.InsertItem(game);
                Console.WriteLine($"\nSuccessfully added {title} to tree\n");
            }

            // Display items by users choice of tree traversal
            void displayItems(BSTree<VideoGame> tree)
            {
                Console.WriteLine(
                "\nSelect an option:\n" +
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

                // Edge case incase tree is empty (CANNOT TRAVERSE EMPTY TREE), still permits going back and invalid inputs
                if (tree.Count() == 0 && cmd < 5)
                {
                    Console.WriteLine("\nTree is currently empty!");
                    return;
                }

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
                        tree.LevelOrder();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }

            
            void updateItem(BSTree<VideoGame> tree)
            {
                Console.WriteLine("To update a game please enter Game Title:\n");
                string game = Console.ReadLine().ToLower().Trim();

                var gameNode = new VideoGame();
                gameNode.Title = game;
                Node<VideoGame> found = tree.FindNode(gameNode);
                if (found == null)
                {
                    Console.WriteLine("\nTitle does not exist\nGoing back...\n");
                    return;
                }
                VideoGame foundGame = found.Data;

                Console.WriteLine($"{foundGame.ToString()}"); // Displays found games data
                Console.WriteLine("\nGame Found!");

                Console.WriteLine("\nType -1 to go back\n");

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

                gameNode.Title = foundGame.Title;
                gameNode.Developer = newdeveloper;
                gameNode.Releaseyear = newrelease;
                
                tree.Update(gameNode);
                Console.WriteLine("\nSuccessfully Updated Game!\n");
            }

            void ItemsFromYear(BSTree<VideoGame> tree)
            {
                Console.WriteLine("\nEnter Year: (-1 to go back) ");
                int year;

                do
                {
                    if (int.TryParse(Console.ReadLine(), out year) && year > 1000 && year <= 3000)
                    {
                        break;
                    }
                    else if (year == -1)
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter valid year.");
                } while (true);

                tree.ListGamesWithYear(year);

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
                        // Edge case incase tree is empty (CANNOT TRAVERSE EMPTY TREE)
                        if (BST.Count() == 0)
                        {
                            Console.WriteLine("\nTree is currently empty!");
                            break;
                        }
                        var game = BST.EarliestGame();
                        Console.WriteLine($"Earliest game: {game.Title} by {game.Developer}\n" +
                                          $"Release - {game.Releaseyear}\n");
                        break;
                    case 6:
                        var height = BST.Height();
                        Console.WriteLine($"\nHeight of the tree: {height}");
                        break;
                    case 7:
                        var count = BST.Count();
                        Console.WriteLine($"\nTotal Items in tree: {count}");
                        break;
                    case 8:
                        ItemsFromYear(BST);
                        break;
                    case 9:
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
