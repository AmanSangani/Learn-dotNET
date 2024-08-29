using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.Tasks
{
    public partial class DropDownTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ListItem listItem = new ListItem();
            listItem.Text = txtCountryName.Text;
            listItem.Value = txtCountryCode.Text;

            Boolean Add = true;

            foreach (ListItem li in ddlCountry.Items)
            {
                if (li.Text == listItem.Text && li.Value == listItem.Value)
                {
                    lblMsg.Text = "Already there...";
                    Add = false;
                    break;
                }
            }

            if(Add)
            {
                ddlCountry.Items.Add(listItem);
                lblMsg.Text = "Added Successfully...";
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            ListItem listItem = new ListItem();
            listItem.Text = txtCountryName.Text;
            listItem.Value = txtCountryCode.Text;

            Boolean removed = false;

            foreach (ListItem li in ddlCountry.Items)
            {
                if (li.Text == listItem.Text && li.Value == listItem.Value)
                {
                    ddlCountry.Items.Remove(listItem);
                    lblMsg.Text = "Revomed...";
                    removed = true;
                    break;
                }
            }
            if (!removed)
            {
                lblMsg.Text = "No such Item Exists...";
            }
            
        }
    }
}