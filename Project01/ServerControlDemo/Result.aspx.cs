using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.ServerControlDemo
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(txtSub1.Text) + Convert.ToInt32(txtSub2.Text) + Convert.ToInt32(txtSub3.Text) + Convert.ToInt32(txtSub4.Text);
            int percentage = total / 4;
            lblPercentage.Text = Convert.ToString(percentage);

            if(percentage >= 90)
            {
                lblRemarks.Text = "Excellent";
            }
            else if(percentage >= 80 &&  percentage < 90)
            {
                lblRemarks.Text = "Very Good";
            }
            else if (percentage >= 60 && percentage < 80)
            {
                lblRemarks.Text = "Good";
            }
            else
            {
                lblRemarks.Text = "Improve";
            }
        }
    }
}