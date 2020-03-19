using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight
{
    public class Actor
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public Actor(string firstname,string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
        public Actor(int id, string firstname, string lastname)
            :this(firstname,lastname)
        {
            this.ID = id;
        }
    }
}
