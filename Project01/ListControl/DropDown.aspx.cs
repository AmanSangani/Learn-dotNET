using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.ListControl
{
    public partial class DropDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlCountry.Items.Add(new ListItem("India", "91"));

                ListItem liEngland = new ListItem();
                liEngland.Text = "England";
                liEngland.Value = "99";

                ddlCountry.Items.Add(liEngland);

                ddlCountry.Items.Add(new ListItem("China", "97"));
            }
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            //lblResult.Text = ddlCountry.SelectedItem.Text;
            //lblResult.Text += " - " + ddlCountry.SelectedValue;
            //lblResult.Text += " - " + Convert.ToString(ddlCountry.SelectedIndex);
            //lblResult.Text += " - " + ddlCountry.SelectedIndex.ToString();

            foreach(ListItem li in ddlCountry.Items)
            {
                if (li.Selected)
                {
                    lblResult.Text += "<strong>" + li.Text + ", " + "</strong>";
                }
                else
                {
                    lblResult.Text += li.Text + ", ";
                }
            }
        }
    }
}