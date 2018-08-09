using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookservice.Model
{
    public interface IBookStore
    {
        /// <summary>
        /// Creates a new book.  The Id of the book will be filled when the
        /// function returns.
        /// </summary>
        void Create(Book book);

        Book Read(long id);

        void Update(Book book);

        void Delete(long id);

        BookList List(int pageSize, string nextPageToken);
    }
}
