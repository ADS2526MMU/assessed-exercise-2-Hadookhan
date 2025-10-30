using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Film class implementation for Assessed Exercise 2

    class VideoGame : IComparable
    {

        private string title;
        private string developer;
        private int releaseyear;

        public VideoGame()
        {
            Title = null;
            Developer = null;
            Releaseyear = 0;
        }

        public VideoGame(string title, string developer, int releaseyear)
        {
            Title = title;
            Developer = developer;
            Releaseyear = releaseyear;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Developer
        {
            get { return developer; }
            set { developer = value; }
        }

        public int Releaseyear
        {
            get { return releaseyear; }
            set { releaseyear = value; }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            VideoGame other = (VideoGame)obj;
            // This is how the binary search tree will be distributed
            return Title.ToLower().CompareTo(other.Title.ToLower());
        }

        // Overrides the ToString method
        public override string ToString()
        {
            return $"\nTitle : {title}\n" +
                $"Developer : {developer}\n" +
                $"Release : {releaseyear}\n";
        }

    }// End of class
}
