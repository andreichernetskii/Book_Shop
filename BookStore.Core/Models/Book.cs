using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 250;

        // without setter cause it's a domain model
        public Guid Id { get; }
        public string Title { get; } = string.Empty; // Cannot be empty or exceed MAX_TITLE_LENGTH.
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        // Private constructor to ensure that the object creation process is tightly
        // controlled and cannot bypass the validation logic defined in the Create method
        private Book(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        // A tuple containing the created Book instance and an error message (if validation fails).
        // method Create allows to centralize and enforce business rules or validation logic
        // (e.g., checking if the title is empty or exceeds the maximum length).
        // From Factory Method Pattern.
        public static (Book Book, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Title cannot be empty or longer than {MAX_TITLE_LENGTH} symbols!";
            }

            var book = new Book(id, title, description, price);

            return (book, error);
        }
    }
}
