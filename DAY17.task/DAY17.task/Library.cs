using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace DAY17.task
{
    internal class Library : Book
    {
        public Book[] Books = new Book[0];

        public void AddBook(ref Book[] books, string bookName, double bookPrice, string bookGenre)
        {
            bool exists = false;

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null && books[i].Name == bookName && books[i].Genre == bookGenre)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                Array.Resize(ref books, books.Length + 1);

                Book newBook = new Book(bookName, bookGenre, bookPrice);
                books[books.Length - 1] = newBook;

                Console.WriteLine("Kitab elave olundu");
            }
            else
            {
                Console.WriteLine("Bu kitab artiq movcuddur.");
            }



        }

        public void RemoveBookByName(ref Book[] books, string bookName)
        {
            int indexToRemove = -1;

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Name == bookName)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove != -1)
            {
                Book[] updatedBooks = new Book[books.Length - 1];
                for (int i = 0, j = 0; i < books.Length; i++)
                {
                    if (i != indexToRemove)
                    {
                        updatedBooks[j++] = books[i];
                    }
                }

                books = updatedBooks;
                Console.WriteLine("**Kitab silindi");
            }
            else
            {
                Console.WriteLine("Bu kitab tapılmadı");
            }

        }

        public Book FindBookByName(ref Book[] books, string name)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null && books[i].Name == name)
                {
                    books[i].ShowInfo();
                    return books[i];
                }
            }

            Console.WriteLine("Kitab tapilmadi.");
            return null;
        }

       







    }
}
