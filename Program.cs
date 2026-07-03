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
    }
}
