using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.Tasks
{
    public partial class RadioBtnListTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rblCollegeName.Items.Add(new ListItem("Depstar"));
                rblCollegeName.Items.Add(new ListItem("Cspit"));
                rblCollegeName.Items.Add(new ListItem("Darshan"));
                rblCollegeName.Items.Add(new ListItem("Marwadi"));
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if(rblCollegeName.SelectedIndex >=0)
            {
                lblTest.Text += rblCollegeName.SelectedItem.Text;
            }
            else
            {
                lblTest.Text = "Please Select College";
            }

            if(rblCollegeName.SelectedIndex == 0)
            {
                rblBranchName.Items.Add(new ListItem("DCE"));
                rblBranchName.Items.Add(new ListItem("DCSE"));
                rblBranchName.Items.Add(new ListItem("DIT"));
            }
            else if(rblCollegeName.SelectedIndex == 1)
            {
                rblBranchName.Items.Add(new ListItem("CE"));
                rblBranchName.Items.Add(new ListItem("CSE"));
                rblBranchName.Items.Add(new ListItem("IT"));
                rblBranchName.Items.Add(new ListItem("EE"));
                rblBranchName.Items.Add(new ListItem("EC"));
            }
            else if (rblCollegeName.SelectedIndex == 2)
            {
                rblBranchName.Items.Add(new ListItem("CE"));
                rblBranchName.Items.Add(new ListItem("IT"));
                rblBranchName.Items.Add(new ListItem("ME"));
                rblBranchName.Items.Add(new ListItem("CIVIL"));
            }
            else if (rblCollegeName.SelectedIndex == 3)
            {
                rblBranchName.Items.Add(new ListItem("CSE"));
                rblBranchName.Items.Add(new ListItem("IT"));
                rblBranchName.Items.Add(new ListItem("ENV"));
                rblBranchName.Items.Add(new ListItem("BBA"));
            }
        }

        protected void btnDispaly_Click(object sender, EventArgs e)
        {
            if (rblBranchName.SelectedIndex >= 0)
            {
                lblTest.Text = rblCollegeName.SelectedItem.Text + " - " + rblBranchName.SelectedItem.Text;
            }
            else
            {
                lblTest.Text += "Please Select Branch";
            }
        }
    }
}