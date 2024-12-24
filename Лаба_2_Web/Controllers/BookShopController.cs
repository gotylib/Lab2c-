using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Лаба_2_Web.Core.DTO;
using Лаба_2_Web.Core.DTO.Links;

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
                        .Include(u => u.Books)
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

        public ActionResult UpdateUser([FromBody] UserDto user)
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

            _context.SaveChanges();

            return Ok(existingUser);
        }

        [HttpPost("AddUser")]

        public ActionResult CreateUser([FromBody] UserDto user)
        {
            if (user == null) { return NotFound(); }
            var newUser = new User(user.CreatedAt, user.Name, user.Surname, user.Age);
            _context.Users.Add(newUser);
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

        public ActionResult UpdateManager([FromBody] ManagerDto manager)
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


            _context.SaveChanges();

            return Ok(existingManager);
        }

        [HttpPost("AddManager")]

        public ActionResult CreateManager([FromBody] ManagerDto manager)
        {
            if (manager == null) { return NotFound(); }
            var newManager = new Manager(manager.CreatedAt, manager.Name, manager.Surname, manager.Age);
            _context.Managers.Add(newManager);
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

        public ActionResult UpdateBook([FromBody] BookDto book)
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


            _context.SaveChanges();

            return Ok(existingBook);
        }

        [HttpPost("AddBook")]

        public ActionResult CreateBook([FromBody]BookDto book)
        {
            if (book == null) { return NotFound(); }
            var newBook = new Book(book.Title, book.Author, book.FilePath, book.СoverPath);
            _context.Books.Add(newBook);
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

        public ActionResult UpdateShop([FromBody] ShopDto shop)
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


            _context.SaveChanges();

            return Ok(existingShop);
        }

        [HttpPost("AddShop")]

        public ActionResult CreateShop([FromBody] ShopDto shop)
        {
            if (shop == null) { return NotFound(); }
            var newShop = new Shop(shop.Address);
            _context.Shops.Add(newShop);
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

        public ActionResult UpdateCategory([FromBody] CategoryDto category)
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


            _context.SaveChanges();

            return Ok(existingCategory);
        }

        [HttpPost("AddCategory")]

        public ActionResult CreateCategory([FromBody] CategoryDto category)
        {
            if (category == null) { return NotFound(); }
            var newCategory = new Сategory(category.Name);
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("LinkUser")]

        public ActionResult LinkUser([FromBody] UserLinkDto userLink)
        {
            if (userLink.IdUser == 0 || userLink.IdBook == 0)
            {
                return BadRequest("Invalid ID.");
            }

            var user = _context.Users.Find(userLink.IdUser);
            var book = _context.Books.Find(userLink.IdBook);

            if (user == null || book == null)
            {
                return NotFound("User or book not found.");
            }

            user.Books.Add(book);
            book.Readers.Add(user);

            _context.SaveChanges();

            return Ok();

        }

        [HttpPost("LinkManager")]
        public ActionResult LinkManager([FromBody] ManagerLinkDto managerLink)
        {
            if (managerLink.IdManager == 0 || managerLink.IdUser == 0)
            {
                return BadRequest("Invalid ID.");
            }
            var manager = _context.Managers.Find(managerLink.IdManager);
            var user  = _context.Users.Find(managerLink.IdUser);

            if (user == null || manager == null)
            {
                return NotFound("User or book not found.");
            }
            manager.Clients.Add(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("LinkShop")]
        public ActionResult LinkShop([FromBody] ShopLinkDto shopLink)
        {
            if (shopLink.IdShop == 0 || shopLink.IdBook == 0)
            {
                return BadRequest("Invalid ID.");
            }

            var shop = _context.Shops.Find(shopLink.IdShop);
            var book = _context.Books.Find(shopLink.IdBook);

            if(shop == null || book == null)
            {
                return NotFound("User or book not found.");
            }

            shop.Books.Add(book);
            book.Shops.Add(shop);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("LinkCategory")]
        public ActionResult LinkCategory([FromBody]  CategoryLinkDto categoryLink)
        {
            if (categoryLink.IdCategory == 0 || categoryLink.IdBook == 0)
            {
                return BadRequest("Invalid ID.");
            }

            var category = _context.Categories.Find(categoryLink.IdCategory);
            var book = _context.Books.Find(categoryLink.IdBook);

            if (category == null || book == null)
            {
                return NotFound("User or book not found.");
            }

            category.Books.Add(book);
            book.Categories.Add(category);
            _context.SaveChanges();
            return Ok();
        }

        
    }
}

