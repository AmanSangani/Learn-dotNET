using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.Tasks
{
    public partial class ListBoxTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lstbCountry.Items.Add(new ListItem("India","91"));
                lstbCountry.Items.Add(new ListItem("Nepal", "92"));
                lstbCountry.Items.Add(new ListItem("Bangladesh", "93"));
                lstbCountry.Items.Add(new ListItem("China", "94"));
            }
        }

        protected void btnMoveRight_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstbCountry.Items)
            {
                if (li.Selected)
                {
                    lstbMoved.Items.Add(li);
                    //lstbCountry.Items.Remove(li);
                }
            }
        }

        protected void btnMoveRightAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstbCountry.Items)
            {
                    lstbMoved.Items.Add(li);
                    //lstbCountry.Items.Remove(li);
            }
        }

        protected void btnMoveLeft_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstbMoved.Items)
            {
                if (li.Selected)
                {
                    lstbCountry.Items.Add(li);
                    //lstbMoved.Items.Remove(li);
                }
            }
        }

        protected void btnMoveLeftAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstbMoved.Items)
            {
                lstbCountry.Items.Add(li);
                //lstbMoved.Items.Remove(li);
            }
        }
    }
}