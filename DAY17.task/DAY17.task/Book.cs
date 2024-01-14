using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DAY17.task
{
    internal class Book:Product
    {
        
        public Book()
        {

        }
        
        public Book(string name, string genre, double price)
        {
            Name = name;
            Price = price;
            Genre = genre;
        }
        
        public string Genre;

        public void ShowInfo()
        {
            Console.WriteLine($"AD - {this.Name} // JANR - {this.Genre} // QIYMET : {this.Price}");
        }
    }
}
