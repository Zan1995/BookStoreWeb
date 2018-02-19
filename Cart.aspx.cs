using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;

public partial class Cart : System.Web.UI.Page
{
    BookshopEntities context = new BookshopEntities();
    string userID = "1";
    string realUserID = "1";
    

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            //use this one later to connect with the ID

            BindGrid();

        }


    }

    protected void BindGrid()
    {
        try
        {

            GridView1.DataSource = context.CartDetails.Where(cd => cd.UserID == userID).Select(cd => new { cd.Book.Title, cd.Book.Author, cd.Book.Category.Name, cd.Book.Price, cd.Book.Stock, cd.BookQuant, cd.Book.Discount }).ToList();
            List<CartDetail> cartList = context.CartDetails.Where(cd => cd.UserID == userID).ToList();
            //TextBox tb = (TextBox)GridView1.FindControl("Total");
            //tb.Text =context;

            GridView1.DataBind();

            var cList = context.CartDetails.Where(cd => cd.UserID == userID).ToList();
            tbxTotal.Text = BusinessLogic.TotalAmount(cartList).ToString();
            tbxDiscount.Text = BusinessLogic.DiscountAmount(cartList).ToString();
            tbxAfterDiscount.Text = BusinessLogic.TotalAmountAfterDiscount(cartList).ToString();

            //Label lblComputeTemp = (e.Row.FindControl("lblCompute") as Label);
            if (cList.Count == 0)
            {
                lblSuccess.Text = "Your cart is empty.";
            }
            else
            {
                lblSuccess.Text = "Your cart is ready. ^_^";
            }

        }

        catch (Exception e)
        {
            lblSuccess.Text = "Your cart is empty.";
        }

    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        int bookQuant = Convert.ToInt32((row.FindControl("tbxQ") as TextBox).Text);
        string title = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        BusinessLogic.UpdateQuant(title, bookQuant, userID);
        GridView1.EditIndex = -1;
        BindGrid();
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string bookTitle = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        BusinessLogic.DeleteCartItem(bookTitle, userID);
        BindGrid();
    }

    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGrid();
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        if (User.Identity.Name == "")
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            realUserID = User.Identity.Name;
            bool successful = BusinessLogic.MakeOrder(userID, realUserID);
            btnOrder.Visible = false;
            lblSuccess.Visible = true;
            GridView1.Visible = false;

            if (successful)
            {
                lblSuccess.Text = "Your order has been successfully made.";
            }
            else
                lblSuccess.Text = "Sorry, your order could not be made at the moment.";
        }


    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string title = e.Row.Cells[0].Text;
        //CartDetail cd = context.CartDetails.Where(cdp => cdp.Book.Title == title && cdp.UserID==userID).First();


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //double totalPrice = (double) cd.BookQuant * Convert.ToDouble(e.Row.Cells[4].Text) * Convert.ToDouble(e.Row.Cells[5].Text);
            //e.Row.Cells[6].Text = title;
            var quantity = e.Row.FindControl("lblQ") as Label;

            e.Row.Cells[6].Text = (Convert.ToDouble(quantity.Text) * Convert.ToDouble(e.Row.Cells[4].Text) * (1 - Convert.ToDouble(e.Row.Cells[5].Text))).ToString();

            //(Convert.ToDouble(quantity.Text) * Convert.ToDouble(e.Row.Cells[4].Text) * Convert.ToDouble(e.Row.Cells[5].Text).ToString();

            //e.Row.Cells[6].Text = (Convert.ToDouble(quantity.ToString()) * Convert.ToDouble(e.Row.Cells[4].ToString()) * Convert.ToDouble(e.Row.Cells[5].ToString())).ToString();

        }
    }
}