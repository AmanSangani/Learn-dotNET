using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.Tasks
{
    public partial class RadioBtnTask : System.Web.UI.Page
    {
        static String str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (rbtnDEPSTAR.Checked)
            {
                str = "DEPSTAR";
                lblTest.Text = str;
                rbtnBranch1.Text = "DCE";
                rbtnBranch2.Text = "DCSE";
                rbtnBranch1.Visible = true;
                rbtnBranch2.Visible = true;
            }
            if(rbtnCSPIT.Checked)
            {
                str = "CSPIT";
                rbtnBranch1.Text = "CE";
                rbtnBranch2.Text = "CSE";
                rbtnBranch1.Visible = true;
                rbtnBranch2.Visible = true;
            }
        }

        protected void btnDispaly_Click(object sender, EventArgs e)
        {
            lblTest.Text =  str + " -> ";
            if (rbtnBranch1.Checked)
            {
                lblTest.Text += rbtnBranch1.Text;
            }
            if (rbtnBranch2.Checked)
            {
                lblTest.Text += rbtnBranch2.Text;
            }
        }
    }
}