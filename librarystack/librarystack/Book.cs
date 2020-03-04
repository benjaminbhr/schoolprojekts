using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarystack
{
    public class Book
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string genre;

		public string Genre
		{
			get { return genre; }
			set { genre = value; }
		}

		private int pages;

		public int Pages
		{
			get { return pages; }
			set { pages = value; }
		}

		private string author;

		public string Author
		{
			get { return author; }
			set { author = value; }
		}

		public Book(string name,string genre,int pages,string author)
		{
			this.Name = name;
			this.Genre = genre;
			this.Pages = pages;
			this.Author = author;
		}




	}
}
