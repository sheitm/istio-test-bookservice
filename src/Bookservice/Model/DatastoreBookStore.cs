using System.Linq;
using Google.Cloud.Datastore.V1;
using Google.Protobuf;

namespace Bookservice.Model
{
    public class DatastoreBookStore : IBookStore
    {
        private readonly string _projectId;
        private readonly DatastoreDb _db;

        /// <summary>
        /// Create a new datastore-backed bookstore.
        /// </summary>
        /// <param name="projectId">Your Google Cloud project id</param>
        public DatastoreBookStore(string projectId)
        {
            _projectId = projectId;
            _db = DatastoreDb.Create(_projectId);
        }

        // [START create]
        public void Create(Book book)
        {
            var entity = book.ToEntity();
            entity.Key = _db.CreateKeyFactory("Book").CreateIncompleteKey();
            var keys = _db.Insert(new[] { entity });
            book.Id = keys.First().Path.First().Id;
        }
        // [END create]

        public void Delete(long id)
        {
            _db.Delete(id.ToKey());
        }

        // [START list]
        public BookList List(int pageSize, string nextPageToken)
        {
            var query = new Query("Book") { Limit = pageSize };
            if (!string.IsNullOrWhiteSpace(nextPageToken))
                query.StartCursor = ByteString.FromBase64(nextPageToken);
            var results = _db.RunQuery(query);
            return new BookList()
            {
                Books = results.Entities.Select(entity => entity.ToBook()),
                NextPageToken = results.Entities.Count == query.Limit ?
                    results.EndCursor.ToBase64() : null
            };
        }
        // [END list]

        public Book Read(long id)
        {
            return _db.Lookup(id.ToKey())?.ToBook();
        }

        public void Update(Book book)
        {
            _db.Update(book.ToEntity());
        }
    }
}
