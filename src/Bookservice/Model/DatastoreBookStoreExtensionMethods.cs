using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Datastore.V1;

namespace Bookservice.Model
{
    public static class DatastoreBookStoreExtensionMethods
    {
        /// <summary>
        /// Make a datastore key given a book's id.
        /// </summary>
        /// <param name="id">A book's id.</param>
        /// <returns>A datastore key.</returns>
        public static Key ToKey(this long id) =>
            new Key().WithElement("Book", id);

        /// <summary>
        /// Make a book id given a datastore key.
        /// </summary>
        /// <param name="key">A datastore key</param>
        /// <returns>A book id.</returns>
        public static long ToId(this Key key) => key.Path.First().Id;

        /// <summary>
        /// Create a datastore entity with the same values as book.
        /// </summary>
        /// <param name="book">The book to store in datastore.</param>
        /// <returns>A datastore entity.</returns>
        /// [START toentity]
        public static Entity ToEntity(this Book book) => new Entity()
        {
            Key = book.Id.ToKey(),
            ["Title"] = book.Title,
            ["Author"] = book.Author,
            ["PublishedDate"] = book.PublishedDate?.ToUniversalTime(),
            ["ImageUrl"] = book.ImageUrl,
            ["Description"] = book.Description,
            ["CreateById"] = book.CreatedById
        };
        // [END toentity]

        /// <summary>
        /// Unpack a book from a datastore entity.
        /// </summary>
        /// <param name="entity">An entity retrieved from datastore.</param>
        /// <returns>A book.</returns>
        public static Book ToBook(this Entity entity) => new Book()
        {
            Id = entity.Key.Path.First().Id,
            Title = (string)entity["Title"],
            Author = (string)entity["Author"],
            PublishedDate = (DateTime?)entity["PublishedDate"],
            ImageUrl = (string)entity["ImageUrl"],
            Description = (string)entity["Description"],
            CreatedById = (string)entity["CreatedById"]
        };
    }

}
