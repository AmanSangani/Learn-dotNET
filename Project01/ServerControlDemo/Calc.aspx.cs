using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.ServerControlDemo
{
    public partial class Calc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblAnswer.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) + Convert.ToInt32(txtNo2.Text));
        }
        protected void btnSub_Click(object sender, EventArgs e)
        {
            lblAnswer.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) - Convert.ToInt32(txtNo2.Text));
        }
        protected void btnMul_Click(object sender, EventArgs e)
        {
            lblAnswer.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) * Convert.ToInt32(txtNo2.Text));
        }
        protected void btnDiv_Click(object sender, EventArgs e)
        {
            if(txtNo2.Text == "0")
            {
                lblAnswer.Text = "Invalid Input";
            }
            else
            {
                lblAnswer.Text = Convert.ToString(Convert.ToInt32(txtNo1.Text) / Convert.ToInt32(txtNo2.Text));
            }
        }
    }
}