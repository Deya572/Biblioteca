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
