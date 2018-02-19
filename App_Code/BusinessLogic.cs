using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BusinesLogic
/// </summary>
public class BusinessLogic
{
     static BookshopEntities Mybooks = new BookshopEntities();

    public BusinessLogic()
    {

    }

    public static List<Book> ListBooks()
    {


        return Mybooks.Books.ToList<Book>();

    }

    public static Book getBookByID(int bookID)
    {


        return Mybooks.Books.Where
                (x => x.BookID == bookID).ToList<Book>()[0];

    }

    public static List<Category> CategoryChoice()
    {


        return Mybooks.Categories.ToList<Category>();

    }

    public static string GetCategoryName(int id)
    {


        Category category = Mybooks.Categories.Where(c => c.CategoryID == id).ToList<Category>()[0];
        return category.Name;

    }

    public static CartDetail GetCartDetails(int bookID, string userID)
    {
        CartDetail cart = Mybooks.CartDetails.Where(c => c.BookID == bookID && c.UserID == userID).FirstOrDefault<CartDetail>();
        return cart;
    }

    public static void AddCart(string userID, int bookID, int quantity)
    {


        CartDetail cart = new CartDetail();
        cart.BookID = bookID;
        cart.UserID = userID;
        cart.BookQuant = quantity;
        Mybooks.CartDetails.Add(cart);
        Mybooks.SaveChanges();

    }

    public static void UpdateCart(int cartDetailID)
    {
        CartDetail cart = Mybooks.CartDetails.Where(c => c.CartDetailID == cartDetailID).First<CartDetail>();
        cart.BookQuant += 1;
        Mybooks.SaveChanges();

    }

    public static List<Book> SearchByTitle(string title)
    {
        return Mybooks.Books.Where(x => x.Title.Contains(title.Trim())).ToList();
    }

    public static List<Book> SearchByAuthor(string author)
    {
        return Mybooks.Books.Where(x => x.Author.Contains(author.Trim())).ToList();

    }
    public static List<Category> PopulateCatagory()

    {

        return Mybooks.Categories.ToList<Category>();

    }

    public static List<Book> SearchByCatagory(int value)
    {
        return Mybooks.Books.Where(x => x.CategoryID == value).ToList();
    }

    public static void DeleteCartItem(string title, string userID)
    {
        using (BookshopEntities context = new BookshopEntities())
        {
            CartDetail cd = context.CartDetails.Where(cdetail => cdetail.Book.Title == title && cdetail.UserID == userID).First();
            context.CartDetails.Remove(cd);
            context.SaveChanges();
        }
    }

    public static void UpdateQuant(string title, int bookQuant, string userID)
    {
        using (BookshopEntities context = new BookshopEntities())
        {
            CartDetail cd = context.CartDetails.Where(cdetail => cdetail.Book.Title == title && cdetail.UserID == userID).First();
            cd.BookQuant = bookQuant;
            context.SaveChanges();
        }
    }

    public static bool MakeOrder(string userID, string realUserID)
    {
        try
        {
            using (BookshopEntities context = new BookshopEntities())
            {
                Order o = new Order();
                o.UserID = realUserID;
                o.OrderDate = DateTime.Today;

                //Cart c = context.Carts.Where(cart => cart.UserID == userID).First();
                List<CartDetail> cdList = context.CartDetails.Where(cdetail => cdetail.UserID == userID).ToList();


                foreach (CartDetail cd in cdList)
                {
                    OrderDetail od = new OrderDetail();
                    od.Order = o;
                    od.BookID = (int)cd.BookID;
                    od.Quantity = (int)cd.BookQuant;
                    context.OrderDetails.Add(od);
                    Book b = context.Books.Where(book => book.BookID == cd.BookID).First();
                    b.Stock = b.Stock - (int)cd.BookQuant;
                    context.SaveChanges();
                }

                context.CartDetails.RemoveRange(cdList);

                context.SaveChanges();
                //context.Carts.Remove(c);
                //context.SaveChanges();

            }
            return true;
        }
        catch (Exception e)
        {
            return false;
        }

    }


    public static double DiscountAmount(List<CartDetail> cartList)
    {
        double discount = 0;
        foreach (CartDetail cd in cartList)
        {
            discount += Convert.ToDouble(cd.Book.Price) * Convert.ToInt32(cd.BookQuant) * Convert.ToInt32(cd.Book.Discount);
        }
        return Math.Round(discount, 2);
    }

    public static double TotalAmount(List<CartDetail> cartList)
    {
        double sum = 0;
        foreach (CartDetail cd in cartList)
        {
            sum += Convert.ToDouble(cd.Book.Price) * Convert.ToInt32(cd.BookQuant);
        }
        return sum;
    }

    public static double TotalAmountAfterDiscount(List<CartDetail> cartList)
    {
        double afterDiscount = 0;
        foreach (CartDetail cd in cartList)
        {
            afterDiscount = TotalAmount(cartList) - DiscountAmount(cartList);
        }
        return Math.Round(afterDiscount, 2);
    }

    public static void AddBook(string title, string isbn, string categoryName, string author, int stock,
            decimal price, decimal discount)
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            Book book = new Book
            {
                Title = title,
                ISBN = isbn,
                CategoryID = getCategoryID(categoryName),
                Author = author,
                Stock = stock,
                Price = price,
                Discount = discount
            };
            entities.Books.Add(book);
            entities.SaveChanges();
        }
    }

    public static void UpdateBook(int bookId,
        string stock, string price, string discount)
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            Book book = entities.Books.Where(p => p.BookID == bookId).First<Book>();
            book.Stock = Int32.Parse(stock);
            book.Price = Decimal.Parse(price);
            book.Discount = Decimal.Parse(discount);
            entities.SaveChanges();
        }
    }

    public static void DeleteBook(int bookId)
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            Book book = entities.Books.Where(b => b.BookID == bookId).First<Book>();
            entities.Books.Remove(book);
            entities.SaveChanges();
        }
    }

    public static List<Book> ListBooksBy(string name)
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            //return entities.Books.Where(p => p.Username == name).ToList<Order>();
            return entities.Books.ToList<Book>();
        }
    }

    static DataTable ConvertListToDataTable(List<Book> list)
    {
        // New table.
        DataTable table = new DataTable();

        // Get max columns.
        //int columns = 0;

        // Add columns.
        table.Columns.Add("BookID", typeof(int));
        table.Columns.Add("Title", typeof(string));
        table.Columns.Add("CategoryName", typeof(string));
        table.Columns.Add("ISBN", typeof(string));
        table.Columns.Add("Author", typeof(string));
        table.Columns.Add("Stock", typeof(int));
        table.Columns.Add("Price", typeof(decimal));
        table.Columns.Add("Discount", typeof(decimal));

        // Add rows.
        for (int i = 0; i < list.Count; i++)
        {
            Book b = list[i];
            string catName = getCategoryName(b.CategoryID);
            table.Rows.Add(b.BookID, b.Title, catName, b.ISBN, b.Author, b.Stock, b.Price, b.Discount);
        }
        //foreach (var array in list)
        //{
        //    table.Rows.Add(array);
        //}
        return table;
    }

    public static DataTable ListBooksAll()
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            //return entities.Books.Where(p => p.Username == name).ToList<Order>();
            return ConvertListToDataTable(entities.Books.ToList<Book>());
        }
    }

    public static DataTable ListBooksByTitle(string title)
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            //return entities.Books.Where(p => p.Username == name).ToList<Order>();
            return ConvertListToDataTable(entities.Books.Where(b => b.Title.Contains(title.Trim())).ToList<Book>());
        }
    }

    public static DataTable ListBooksByISBN(string isbn)
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            //return entities.Books.Where(p => p.Username == name).ToList<Order>();
            return ConvertListToDataTable(entities.Books.Where(b => b.ISBN.Contains(isbn.Trim())).ToList<Book>());
        }
    }

    public static DataTable ListBooksByCategory(string category)
    {
        int id = getCategoryID(category);
        using (BookshopEntities entities = new BookshopEntities())
        {
            //return entities.Books.Where(p => p.Username == name).ToList<Order>();
            return ConvertListToDataTable(entities.Books.Where(b => b.CategoryID == id).ToList<Book>());
        }
    }

    private static string getCategoryName(int catID)
    {

        using (BookshopEntities entities = new BookshopEntities())
        {
            List<Category> categories = entities.Categories.ToList<Category>();
            foreach (Category c in categories)
            {
                if (c.CategoryID == catID)
                    return c.Name;
            }
            return String.Empty;
        }
    }

    private static int getCategoryID(string category)
    {

        using (BookshopEntities entities = new BookshopEntities())
        {
            List<Category> categories = entities.Categories.ToList<Category>();
            foreach (Category c in categories)
            {
                if (c.Name.Equals(category/*, StringComparison.CurrentCultureIgnoreCase*/))
                    return c.CategoryID;
            }
            return 0;
        }

    }

}