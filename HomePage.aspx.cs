using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    public string radioButtonValue;
    public string dropDownListValue;
    public string textBoxValue;
    public int value1;
   
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {

            //search function
            DropDownListSearchOption.DataSource = BusinessLogic.PopulateCatagory();

            DropDownListSearchOption.DataTextField = "Name";
            DropDownListSearchOption.DataValueField = "CategoryID";

            DropDownListSearchOption.DataBind();
            Repeater1.DataSource = BusinessLogic.ListBooks();
            Repeater1.DataBind();
            RadioButtonListSearchOption.SelectedIndex = 2;
        }



    }



    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "Details")
        {
            Control control;
            control = e.Item.FindControl("Label1");
            int bookID = Convert.ToInt32(((Label)control).Text);
            Book b = BusinessLogic.getBookByID(bookID);
            Session["book"] = b;
            Response.Redirect("DetailPage.aspx");

        }
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        if (RadioButtonListSearchOption.SelectedIndex != -1)
        {

            if (RadioButtonListSearchOption.SelectedItem.Text != "Category")
            {
                textBoxValue = TextBoxSearch.Text;

            }

            radioButtonValue = RadioButtonListSearchOption.SelectedItem.Text;
            value1 = Convert.ToInt32(DropDownListSearchOption.SelectedValue);

            if (radioButtonValue == "Title")
            {
                List<Book> b = BusinessLogic.SearchByTitle(textBoxValue);
                if (b.Count == 0)
                {
                    Response.Redirect("ResultNotFoundPage.aspx");
                }
                else
                {
                    Repeater1.DataSource = b;
                    Repeater1.DataBind();
                }


            }
            else if (radioButtonValue == "Author")
            {
                List<Book> b = BusinessLogic.SearchByAuthor(textBoxValue);
                if (b.Count == 0)
                {
                    Response.Redirect("ResultNotFoundPage.aspx");
                }
                else
                {
                    Repeater1.DataSource = b;
                    Repeater1.DataBind();
                }
            }
            else if (radioButtonValue == "Category")
            {

                TextBoxSearch.Text = "";
                List<Book> b = BusinessLogic.SearchByCatagory(value1);
                if (b.Count == 0)
                {
                    Response.Redirect("ResultNotFoundPage.aspx");
                }
                Repeater1.DataSource = b;
                Repeater1.DataBind();
            }
        }
    }

    protected void DropDownListSearchOption_SelectedIndexChanged(object sender, EventArgs e)
    {

        RadioButtonListSearchOption.SelectedIndex = 2;
        TextBoxSearch.Enabled = false;
    }

    protected void RadioButtonListSearchOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListSearchOption.SelectedValue.Equals("Category"))
        {
            DropDownListSearchOption.Enabled = true;
            TextBoxSearch.Enabled = false;
        }
        else
        {
            DropDownListSearchOption.Enabled = false;
            TextBoxSearch.Enabled = true;
        }

    }
}