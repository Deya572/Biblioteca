namespace Biblioteca
{
    internal class Program
    {
        private const string FilePath = "library.txt";
        static void Main(string[] args)
        {
            List<Book> library = LoadBooksFromFile();
            bool running = true;

            while (running)
            {
                Console.WriteLine("--- МЕНЮ БИБЛИОТЕКА ---");
                Console.WriteLine("1. AddBook Добави книга");
                Console.WriteLine("2. Списък с всички книги");
                Console.WriteLine("3. Заеми книга");
                Console.WriteLine("4. Върни книга");
                Console.WriteLine("5. Изход: ");
                Console.WriteLine("Избор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("ISBN: ");
                        string isbn = Console.ReadLine();

                        Console.Write("Заглавие: ");
                        string title = Console.ReadLine();

                        Console.Write("Автор: ");
                        string author = Console.ReadLine();

                        Console.Write("Година: ");
                        int year = int.Parse(Console.ReadLine());

                        Console.Write("Цена: ");
                        double price = double.Parse(Console.ReadLine().Replace('.', ','));

                        Book newBook = new Book(isbn, title, author, year, price, true, "Няма");
                        library.Add(newBook);

                        SaveBooksToFile(library);
                        Console.WriteLine("Книгата е добавена успешно!");
                        break;

                    case "2":
                        foreach (var b in library)
                        {
                            Console.WriteLine(b);
                        }
                        break;
                    case "3":
                        Console.Write("Въведете заглавието на книгата, която искате да заемете: ");
                        string titleToBorrow = Console.ReadLine();
                        Book bookToBorrow = library.Find(b => b.Title.Equals(titleToBorrow, StringComparison.OrdinalIgnoreCase));

                        if (bookToBorrow != null)
                        {
                            if (bookToBorrow.Availability)
                            {
                                Console.Write("Въведете името на заемателя: ");
                                bookToBorrow.Borrower = Console.ReadLine();
                                bookToBorrow.Availability = false;
                                SaveBooksToFile(library);
                                Console.WriteLine($"Книгата \"{bookToBorrow.Title}\" е успешно заета!.");
                            }
                            else
                            {
                                Console.WriteLine($"Съжалявяме, книгата вече е заета от: {bookToBorrow.Borrower}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Книгата не е намерена!");
                        }
                        break;

                    case "4":
                        Console.Write(": ");
                        var borrodBook = library.FindAll(b => !b.Availability);
                        foreach (var b in borrodBook)
                        {
                            Console.WriteLine(b);
                        }
                        Console.Write("Въведете ISBN на книгата, която искате да върнете: ");
                        string returnIsbn = Console.ReadLine();
                        Book bookToReturn = library.Find(b => b.Isbn.Equals(returnIsbn));

                        if (bookToReturn != null)
                        {
                            bookToReturn.Availability = true;
                            bookToReturn.Borrower = "Няма";
                            SaveBooksToFile(library);
                            Console.WriteLine($"Книгата \"{bookToReturn.Title}\" е успешно върната!");
                        }
                        else
                        {
                            Console.WriteLine($"Грешен или книгата не е била заета!");
                        }
                        break;

                }
            }
        }

        static List<Book> LoadBooksFromFile()
        {
            List<Book> library = new List<Book>();
            if (File.Exists(FilePath))
            {
                foreach (string line in File.ReadAllLines(FilePath))
                {
                    var b = Book.ToFileRow(line);
                    if (b != null)
                    {
                        library.Add(b);
                    }
                }
            }
            return library;
        }

        static void SaveBooksToFile(List<Book> library)
        {
            List<string> rows = new List<string>();
            foreach (var b in library)
            {
                rows.Add(b.ToFileRow());
            }
            File.WriteAllLines(FilePath, rows);
        }
    }
}
