using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    public class Movie
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public Movie(string title,string description,string date)
        {
            this.Title = title;
            this.Description = description;
            this.Date = date;
        }
        public Movie(int id,string title,string description,string date) :this(title,description,date)
        {
            this.ID = id;
        }


    }
}
