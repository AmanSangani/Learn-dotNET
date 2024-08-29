using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.ListControl
{
    public partial class ListBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstbCountry.Items)
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