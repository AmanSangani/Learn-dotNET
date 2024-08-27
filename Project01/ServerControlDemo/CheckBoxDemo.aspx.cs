using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.ServerControlDemo
{
    public partial class CheckBoxDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            //lblDisplay.Text = "";
            if(chkMale.Checked) 
            {
                lblDisplay.Text += "Male";
            }
            if(chkFemale.Checked)
            {
                lblDisplay.Text += " Female";
            }
            if(chkOthers.Checked)
            {
                lblDisplay.Text += " Others";
            }
        }
    }
}