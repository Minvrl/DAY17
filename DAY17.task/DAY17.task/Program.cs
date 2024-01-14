using System;
using System.Text;

namespace DAY17.task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[0];
            Library library = new Library();

            char opt;
            do
            {
                Console.WriteLine("\n=======HOMEPAGE=======");
                Console.WriteLine("1. Kitab elave et");
                Console.WriteLine("2. Kitab sil");
                Console.WriteLine("3. Bütün kitablara bax");
                Console.WriteLine("4. Secilmiş kitaba bax (ada göre)");
                Console.WriteLine("5. Ada göre axtarış et");
                Console.WriteLine("0. Proqrami bitir");
                opt = char.Parse(Console.ReadLine());

                switch (opt)
                {
                    case '1':
                        string bookName;
                        double bookPrice;
                        string bookPriceStr;
                        string bookGenre;

                        do
                        {
                            Console.Write("\nKitabin adini daxil edin : ");
                            bookName = Spacing(Console.ReadLine());
                        } while (string.IsNullOrEmpty(bookName) || bookName.Length < 3 || bookName.Length > 20 || !IsLetter(bookName));
                        
                        do
                        {
                            Console.Write("  Janrini daxil edin : ");
                            bookGenre = Console.ReadLine();

                        } while (string.IsNullOrEmpty(bookName) || !IsLetter(bookGenre));

                        do
                        {
                            Console.Write("   Qiymetini daxil edin :");
                            bookPriceStr = Console.ReadLine();
                        } while (!double.TryParse(bookPriceStr, out bookPrice) || bookPrice < 0);
                        library.AddBook(ref books, bookName, bookPrice, bookGenre);

                        break;
                    case '2':
                        ShowBooks(ref books);
                        string removeBook;
                        do
                        {
                            Console.WriteLine("Silmek istediyiniz kitabin adini daxil edin :");
                            removeBook = Console.ReadLine();

                        } while (string.IsNullOrEmpty(removeBook) || !IsLetter(removeBook));

                        library.RemoveBookByName(ref books, removeBook);
                        break;
                    case '3':
                        ShowBooks(ref books);
                        break;
                    case '4':
                        string findBook;
                        do
                        {
                            Console.Write("Baxmaq istediyiniz kitabin adini daxil edin : ");
                            findBook = Console.ReadLine();
                        } while (string.IsNullOrEmpty(findBook) || !IsLetter(findBook));

                        library.FindBookByName(ref books, findBook);
                        break;
                    case '5':
                        string search;
                        do
                        {
                            Console.Write("Baxmaq istediyiniz kitabin adini veya janrini daxil edin: ");
                            search = Console.ReadLine();
                        } while (string.IsNullOrEmpty(search) || !IsLetter(search));

                        bool bookFound = false;

                        for (int i = 0; i < books.Length; i++)
                        {
                            if (books[i] != null && (books[i].Name.Contains(search) || books[i].Genre.Contains(search)))
                            {
                                books[i].ShowInfo();
                                bookFound = true;
                            }
                        }

                        if (!bookFound)
                        {
                            Console.WriteLine("Kitab tapilmadi.");
                        }
                        break;
                    default:
                        if(opt != '0')
                            Console.WriteLine("Duzgun operator daxil edin !");
                        break;
                }

            } while (opt != '0');

        }

        #region Additional Methods
        static bool IsLetter(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                    return false;

            }
            return true;

        }

        static void ShowBooks(ref Book[] books)
        {
            if (books == null || books.Length == 0)
            {
                Console.WriteLine("Kitab yoxdur.");
                return;
            }

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    Console.WriteLine($"   {i + 1}. {books[i].Name},{books[i].Genre} - {books[i].Price}");
                }
            }
        }

        static string Spacing(string str)
        {
            StringBuilder newStr = new StringBuilder();
            bool lastSpace = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsWhiteSpace(str[i]))
                {
                    if (!lastSpace)
                    {
                        newStr.Append(' ');
                    }
                    lastSpace = true;
                }
                else
                {
                    newStr.Append(str[i]);
                    lastSpace = false;
                }
            }

            return newStr.ToString().Trim();
        }
        #endregion
    }
}
