using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Create a Menu driven interface here so a user can interact with your implementations

            //I.e. while(true){
            // print to user - "Select an option"
            // "1. Add item to tree"
            // "2. Display all items... ect
            //}

            var game1 = new VideoGame("Minecraft", "Notch", 2009);
            var game2 = new VideoGame("Rainbow 6 Siege", "Ubisoft", 2015);
            var game3 = new VideoGame("Black Ops 2", "Infinity Ward", 2012);
            var game4 = new VideoGame("Tetris", "Dev1", 1995);

            var Tree = new BSTree<VideoGame>(game1);
            Tree.InsertItem(game2);
            Tree.InsertItem(game4);
            Tree.InsertItem(game3);

            string buffer = "";
            Tree.InOrder(ref buffer);
            Console.WriteLine(buffer);
            Console.WriteLine(Tree.EarliestGame().Title);
            Console.WriteLine(Tree.Height());



            Console.ReadLine();

        }
    }
}
