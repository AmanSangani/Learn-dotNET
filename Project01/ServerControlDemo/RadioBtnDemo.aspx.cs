using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.ServerControlDemo
{
    public partial class RadioBtnDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            if(rbtnMale.Checked)
            {
                lblDisplay.Text = "Male";
            }
            else if (rbtnFemale.Checked)
            {
                lblDisplay.Text = "Female";
            }
            else if(rbtnOthers.Checked)
            {
                lblDisplay.Text = "Others";
            }
            else
            {
                lblDisplay.Text = "Select Gender";
            }
        }
    }
}