using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class UpdatePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //name = Request.QueryString["username"];
        if (!IsPostBack)
        {
            ddlCategory.DataSource = getCategories();
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, "All");
            ViewSearchControls();
            BindGrid();
        }
    }

    private void ViewSearchControls()
    {
        ddlCategory.SelectedIndex = -1;
        txtSearch.Text = "";
        if (ddlField.SelectedValue == "All")
        {
            ddlCategory.Visible = false;
            txtSearch.Visible = false;
        }
        if (ddlField.SelectedValue == "Title" || ddlField.SelectedValue == "ISBN")
        {
            ddlCategory.Visible = false;
            txtSearch.Visible = true;
        }
        if (ddlField.SelectedValue == "Category")
        {
            ddlCategory.Visible = true;
            txtSearch.Visible = false;
        }
    }

    private List<String> getCategories()
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            return entities.Categories.Select(c => c.Name).ToList<String>();
        }
    }

    private void BindGrid()
    {
        if (ddlField.SelectedValue == "Title" && txtSearch.Text != "")
        {
            GridView1.DataSource = BusinessLogic.ListBooksByTitle(txtSearch.Text);
            GridView1.DataBind();
        }
        else if (ddlField.SelectedValue == "ISBN" && txtSearch.Text != "")
        {
            GridView1.DataSource = BusinessLogic.ListBooksByISBN(txtSearch.Text);
            GridView1.DataBind();
        }
        else if (ddlField.SelectedValue == "Category" && ddlCategory.Text != "All")
        {
            GridView1.DataSource = BusinessLogic.ListBooksByCategory(ddlCategory.SelectedValue);
            GridView1.DataBind();
        }
        else /*(ddlField.SelectedValue == "All" || txtSearch.Text == "")*/
        {
            GridView1.DataSource = BusinessLogic.ListBooksAll();
            GridView1.DataBind();
        }
        if (GridView1.Rows.Count == 0) litNoResults.Text = "No results found!";
        else litNoResults.Text = "";
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;

        BindGrid();
    }

    private string getStock(int bookid)
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            return entities.Books.Where(b => b.BookID == bookid).Select(s => s.Stock).First().ToString();
        }
    }

    private string getPrice(int bookid)
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            return entities.Books.Where(b => b.BookID == bookid).Select(s => s.Price).First().ToString();
        }
    }

    private string getDiscount(int bookid)
    {
        using (BookshopEntities entities = new BookshopEntities())
        {
            return entities.Books.Where(b => b.BookID == bookid).Select(s => s.Discount).First().ToString();
        }
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        int bookId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        string stock = (row.FindControl("txtStock") as TextBox).Text == "" ?
            getStock(bookId) : (row.FindControl("txtStock") as TextBox).Text;
        string price = (row.FindControl("txtPrice") as TextBox).Text == "" ?
            getPrice(bookId) : (row.FindControl("txtPrice") as TextBox).Text;
        string discount = (row.FindControl("txtDiscount") as TextBox).Text == "" ?
            getDiscount(bookId) : (row.FindControl("txtDiscount") as TextBox).Text;
        BusinessLogic.UpdateBook(bookId, stock, price, discount);
        GridView1.EditIndex = -1;
        BindGrid();
    }

    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGrid();
    }

    protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewSearchControls();
        BindGrid();
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int bookId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        BusinessLogic.DeleteBook(bookId);
        BindGrid();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlCat.DataSource = getCategories();
            ddlCat.DataBind();
            for (int i = 0; i < 1000; i++) ddlStock.Items.Add(i.ToString());
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblAuthor.Text = lblDiscount.Text = lblTitle.Text = lblPrice.Text = lblISBN.Text =
            litAdded.Text = "";
        if (validateAddContents())
        {
            string title = txtTitle.Text;
            string isbn = txtISBN.Text;
            string categoryName = ddlCat.SelectedValue;
            string author = txtAuthor.Text;
            int stock = int.Parse(ddlStock.SelectedValue.ToString());
            decimal price = decimal.Parse(txtPrice.Text);
            decimal discount = decimal.Parse(txtDiscount.Text);

            try
            {
                BusinessLogic.AddBook(title, isbn, categoryName, author, stock, price, discount);
                BindGrid();
                litAdded.Text = "Book has been added!";
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        mp1.Show();
    }

    private bool validateAddContents()
    {
        bool isValidate = true;
        if (txtTitle.Text == "")
        { lblTitle.Text = "Title is required"; isValidate = false; }
        else { lblTitle.Text = ""; }
        if (txtISBN.Text == "")
        { lblISBN.Text = "ISBN is required"; ; isValidate = false; }
        else { lblISBN.Text = ""; }
        if (txtAuthor.Text == "")
        { lblAuthor.Text = "Author is required"; isValidate = false; }
        else lblAuthor.Text = "";
        if (txtPrice.Text == "")
        { lblPrice.Text = "Price is required"; isValidate = false; }
        else lblPrice.Text = "";
        if (txtDiscount.Text == "")
        { lblDiscount.Text = "Discount is required"; isValidate = false; }
        else lblDiscount.Text = "";
        var regCurrency = new Regex(@"^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$");
        if (!regCurrency.IsMatch(txtPrice.Text))
        {
            lblPrice.Text = (lblPrice.Text == "") ? "Price must be in currency format"
                 : lblPrice.Text + "\nPrice must be in currency format";
            isValidate = false;
        }
        else lblPrice.Text = (lblPrice.Text == "") ? lblPrice.Text : "";
        var regDiscount = new Regex(@"^[0-9]{2}$");
        if (!regDiscount.IsMatch(txtDiscount.Text))
        {
            lblDiscount.Text = (lblDiscount.Text == "") ? "\nDiscount can only be maximum 2 digits"
                  : lblDiscount.Text + "\nDiscount can only be maximum 2 digits";
            isValidate = false;
        }
        else lblDiscount.Text = (lblDiscount.Text == "") ? lblDiscount.Text : "";
        return isValidate;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblAuthor.Text = lblDiscount.Text = lblTitle.Text = lblPrice.Text = lblISBN.Text =
            litAdded.Text = "";
        txtAuthor.Text = txtDiscount.Text = txtTitle.Text = txtPrice.Text = txtISBN.Text = "";
        ddlCat.SelectedIndex = ddlStock.SelectedIndex = -1;
        mp1.Hide();
    }
}