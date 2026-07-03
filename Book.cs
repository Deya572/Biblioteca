using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public bool Availability { get; set; }
        public string Borrower { get; set; }

        public Book(string isbn, string title, string author, int year, double price, bool availability, string borrower)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            Year = year;
            Price = price;
            Availability = availability;
            Borrower = borrower;
        }

        public override string ToString()
        {
            return $"ISBN: {Isbn},Заглавие: {Title}, Автор: {Author}, Година: {Year}, Цена: {Price:F2}лв, Налична: {Availability}, Заемател: {Borrower}";
        }

        public string ToFileRow()
        {
            return $"{Isbn},{Title},{Author},{Year},{Price:F2},{Availability},{Borrower}";
        }
    }
}
