using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetailPage : System.Web.UI.Page
{
    static List<Book> bList;

    static DetailPage()
    {
        bList = new List<Book>();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Book book = (Book)Session["book"];
            Image1.ImageUrl = "images/" + book.ISBN + ".jpg";
            string categoryName = BusinessLogic.GetCategoryName(book.CategoryID);
            LabelAuthor.Text = book.Author;
            LabelCategoryName.Text = categoryName;
            LabelPrice.Text = book.Price.ToString();
            LabelStock.Text = book.Stock.ToString();
            LabelTitleName.Text = book.Title;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Book book = (Book)Session["book"];
        int quantity = 1;
        string userID = "1";
        CartDetail c = BusinessLogic.GetCartDetails(book.BookID, userID);
        if (c == null)
        {
            BusinessLogic.AddCart(userID, book.BookID, quantity);
        }
        else
        {
            BusinessLogic.UpdateCart(c.CartDetailID);
        }
        if (User.Identity.Name == null)
        {
            Response.Redirect(".aspx");
        }
        
        Response.Redirect("Cart.aspx");
    }
}