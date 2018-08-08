using System.Collections.Generic;

namespace Bookservice.Model
{
    public class BookList
    {
        public IEnumerable<Book> Books;
        public string NextPageToken;
    }
}
