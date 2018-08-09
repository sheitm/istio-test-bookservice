using Bookservice.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bookservice.Controllers
{
    [Produces("application/json")]
    [Route("api/Books")]
    public class BooksController : Controller
    {
        private const int PageSize = 10;

        private readonly IBookStore _store;

        public BooksController(IBookStore store)
        {
            _store = store;
        }

        //// GET: api/Books
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return _store.List(PageSize,)
        //}

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public Book Get(long id)
        {
            return _store.Read(id);
        }
        
        // POST: api/Books
        [HttpPost]
        public long Post([FromBody]Book value)
        {
            _store.Create(value);
            return value.Id;
        }
        
        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Book value)
        {
            _store.Update(value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _store.Delete(id);
        }
    }
}
