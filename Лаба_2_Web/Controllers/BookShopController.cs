using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Лаба_2_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookShopController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookShopController(ApplicationDbContext context) =>
            _context = context;

        [HttpGet("GetUsers")]
        public ActionResult GetUsers()
        {
            return Ok(_context.Users
                        .Include(u => u.Shops)
                        .Include(u => u.Books)
                        .Include(u => u.Categories)
                        .ToList());
        }

        [HttpDelete("DeleteUser")]
        public ActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) { return BadRequest(); }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("UpdateUser")]

        public ActionResult UpdateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var existingUser = _context.Users.Find(user.Id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = user.Name;
            existingUser.Surname = user.Surname;
            existingUser.Age = user.Age;
            existingUser.CreatedAt = user.CreatedAt;
            existingUser.Shops = user.Shops;
            existingUser.Books = user.Books;
            existingUser.Categories = user.Categories;

            _context.SaveChanges();

            return Ok(existingUser);
        }

        [HttpPost("AddUser")]

        public ActionResult CreateUser(User user)
        {
            if (user == null) { return NotFound(); }
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();    
        }

        [HttpGet("GetManagers")]
        public ActionResult GetManagers()
        {
            return Ok(_context.Managers
                .Include(m => m.Clients)
                .ToList());
        }

        [HttpDelete("DeleteManager")]
        public ActionResult DeleteManager(int id)
        {
            var manager = _context.Managers.Find(id);
            if (manager == null) { return BadRequest(); }
            _context.Managers.Remove(manager);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("UpdateManager")]

        public ActionResult UpdateManager(Manager manager)
        {
            if (manager == null)
            {
                return BadRequest();
            }

            var existingManager = _context.Managers.Find(manager.Id);
            if (existingManager == null)
            {
                return NotFound();
            }

            existingManager.Surname = manager.Surname;
            existingManager.Name = manager.Name;
            existingManager.Age = manager.Age;
            existingManager.CreatedAt = manager.CreatedAt;
            existingManager.Clients = manager.Clients;


            _context.SaveChanges();

            return Ok(existingManager);
        }

        [HttpPost("AddManager")]

        public ActionResult CreateManager(Manager manager)
        {
            if (manager == null) { return NotFound(); }
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("GetBooks")]

        public ActionResult GetBooks()
        {
            return Ok(_context.Books
                .Include(b => b.Readers)
                .Include(b => b.Shops)
                .Include(b => b.Categories)
                .ToList());
        }

        [HttpDelete("DeleteBook")]

        public ActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) { return BadRequest(); }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("UpdateBook")]

        public ActionResult UpdateBook(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            var existingBook = _context.Books.Find(book.Id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Author = book.Author;
            existingBook.СoverPath = book.СoverPath;
            existingBook.FilePath = book.FilePath;
            existingBook.Title = book.Title;    
            existingBook.Readers = book.Readers;
            existingBook.Shops  = book.Shops;
            existingBook.Categories = book.Categories;


            _context.SaveChanges();

            return Ok(existingBook);
        }

        [HttpPost("AddBook")]

        public ActionResult CreateBook(Book book)
        {
            if (book == null) { return NotFound(); }
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("GetShops")]

        public ActionResult GetShop()
        {
            return Ok(_context.Shops
                .Include(s => s.Books)
                .ToList());
        }

        [HttpDelete("DeleteShop")]

        public ActionResult DeleteShop(int id)
        {
            var shop = _context.Shops.Find(id);
            if (shop == null) { return BadRequest(); }
            _context.Shops.Remove(shop);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("UpdateShop")]

        public ActionResult UpdateShop(Shop shop)
        {
            if (shop == null)
            {
                return BadRequest();
            }

            var existingShop = _context.Shops.Find(shop.Id);
            if (existingShop == null)
            {
                return NotFound();
            }

            existingShop.Address = shop.Address;
            existingShop.Books = shop.Books;


            _context.SaveChanges();

            return Ok(existingShop);
        }

        [HttpPost("AddShop")]

        public ActionResult CreateShop(Shop shop)
        {
            if (shop == null) { return NotFound(); }
            _context.Shops.Add(shop);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("GetCatrgory")]

        public ActionResult GetCategory()
        {
            return Ok(_context.Categories
                .Include(c => c.Books)
                .ToList());
        }

        [HttpDelete("DeleteCatrgory")]

        public ActionResult DeleteCatrgory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) { return BadRequest(); }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("UpdateCategory")]

        public ActionResult UpdateCategory(Сategory category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            var existingCategory = _context.Categories.Find(category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;  
            existingCategory.Books = category.Books;


            _context.SaveChanges();

            return Ok(existingCategory);
        }

        [HttpPost("AddCategory")]

        public ActionResult CreateCategory(Сategory category)
        {
            if (category == null) { return NotFound(); }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok();
        }
    }
}

