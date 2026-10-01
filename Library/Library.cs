using System;
using System.Collections.Generic;

class Book {
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int Copies { get; set; }

    public Book(string title, string author, int year, int copies) {
        Title = title;
        Author = author;
        Year = year;
        Copies = copies;
    }
}

namespace Library
{
    // Main class with all the program data.
    class Program
    {
        static void Main()
        {
            // Initialising library.
            List<Book> library = new();

            while (true) {
                Console.WriteLine("Welcome to the library managment system.");
                Console.WriteLine("Please select your options:");
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. List all books with availability");
                Console.WriteLine("3. Take out a book if it's available");
                Console.WriteLine("4. Return a book");

                string userInput = Console.ReadLine();

                // Inputting the book.
                if (userInput == "1")
                {
                    Console.Write("What is the book title?: ");
                    string title = Console.ReadLine();

                    Console.Write("Who is the author?: ");
                    string author = Console.ReadLine();

                    Console.Write("What year was the book released?: ");
                    int year = int.Parse(Console.ReadLine());

                    Console.Write("How many copies are available?: ");
                    int copies = int.Parse(Console.ReadLine());

                    // Adding book to library.
                    Book currentBook = new(title, author, year, copies);
                    library.Add(currentBook);
                    Console.WriteLine("Book has been added to the bookshelf.");
                }
                else if (userInput == "2")
                {
                    for (int i = 0; i < library.Count; i++)
                    {
                        Console.WriteLine(library[i].Title);
                        Console.WriteLine(library[i].Author);
                        Console.WriteLine(library[i].Year);
                        Console.WriteLine(library[i].Copies);
                    }
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("What book would you like to borrow?");
                    string borrowedBook = Console.ReadLine();

                    bool bookFound = false;

                    for (int i = 0; i < library.Count; i++)
                    {
                        if (library[i].Title == borrowedBook && library[i].Copies > 0)
                        {
                            library[i].Copies = library[i].Copies - 1;
                            Console.WriteLine("Copy of " + borrowedBook + " has been borrowed. " + library[i].Copies + " remain.");
                            bookFound = true;
                        }
                    }
                    if (bookFound == false) {
                            Console.WriteLine("This book is not registered with us.");
                        }
                }
                else if (userInput == "4")
                {
                    Console.WriteLine("What book would you like to return?");
                    string returnedBook = Console.ReadLine();

                    bool bookFound = false;

                    for (int i = 0; i < library.Count; i++)
                    {
                        if (library[i].Title == returnedBook)
                        {
                            library[i].Copies = library[i].Copies + 1;
                            Console.WriteLine("Copy of " + returnedBook + " has been returned. " + library[i].Copies + " are now available.");
                            bookFound = true;
                        }
                    }
                    if (bookFound == false) {
                            Console.WriteLine("This book is not registered with us.");
                        }
                }
                else
                {
                    Console.WriteLine("Invald input. Please try again.");
                }
            }

        }
    }
}
