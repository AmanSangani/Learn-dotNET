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
            for (int i = lstbCountry.Items.Count - 1; i >= 0; i--)
            {
                ListItem li = lstbCountry.Items[i];
                if (li.Selected)
                {
                    lstbMoved.Items.Add(li);
                    lstbCountry.Items.Remove(li);
                }
            }
        }

        protected void btnMoveRightAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstbCountry.Items)
            {
                    lstbMoved.Items.Add(li);
            }
            foreach (ListItem li in lstbMoved.Items)
            {
                lstbCountry.Items.Remove(li);
            }
        }

        protected void btnMoveLeft_Click(object sender, EventArgs e)
        {
            for (int i = lstbMoved.Items.Count - 1; i >= 0; i--)
            {
                ListItem li = lstbMoved.Items[i];
                if (li.Selected)
                {
                    lstbCountry.Items.Add(li);
                    lstbMoved.Items.Remove(li);
                }
            }
        }

        protected void btnMoveLeftAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstbMoved.Items)
            {
                lstbCountry.Items.Add(li);
            }
            foreach (ListItem li in lstbCountry.Items)
            {
                lstbMoved.Items.Remove(li);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean Add = true;
            foreach (ListItem li in lstbCountry.Items)
            {
                if (li.Text == txtCountryName.Text && li.Value == txtCountryCode.Text)
                {
                    Add = false;
                    lblMsg.Text = "Already Exists...";
                    break;
                }
            }
            if (Add)
            {
                lstbCountry.Items.Add(new ListItem(txtCountryName.Text, txtCountryCode.Text));
                lblMsg.Text = "Added Successfully";
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Boolean Remove = false;
            foreach (ListItem li in lstbCountry.Items)
            {
                if (li.Text == txtCountryName.Text && li.Value == txtCountryCode.Text)
                {
                    Remove = true;
                    break;
                }
            }
            if (Remove)
            {
                lstbCountry.Items.Remove(new ListItem(txtCountryName.Text, txtCountryCode.Text));
                lblMsg.Text = "Removed Successfully";
            }
            else
            {
                lblMsg.Text = "No such Data...";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Boolean Update = false;
            foreach (ListItem li in lstbCountry.Items)
            {
                if (li.Text == txtCountryName.Text && li.Value == txtCountryCode.Text)
                {
                    Update = true;
                    break;
                }
            }
            if (Update)
            {
                lstbCountry.Items.Remove(new ListItem(txtCountryName.Text, txtCountryCode.Text));
                lstbCountry.Items.Add(new ListItem(txtNewCountryName.Text, txtNewCountryCode.Text));
                lblMsg.Text = "Updated Successfully";
            }
            else
            {
                lblMsg.Text = "No such Data...";
            }
        }
    }
}