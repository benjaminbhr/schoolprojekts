using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    public class Genre
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string genre;

        public string _Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public Genre(string genre)
        {
            this._Genre = genre;
        }
        public Genre(int id, string genre) :this(genre)
        {
            this.ID = id;
        }

    }
}
