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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (rbtnDEPSTAR.Checked)
            {
                lblTest.Text = "DEPSTAR Selected";
                rbtnBranch1.Text = "DCE";
                rbtnBranch2.Text = "DCSE";
                rbtnBranch1.Visible = true;
                rbtnBranch2.Visible = true;
            }
            if(rbtnCSPIT.Checked)
            {
                lblTest.Text = "CSPIT Selected";
                rbtnBranch1.Text = "CE";
                rbtnBranch2.Text = "CSE";
                rbtnBranch1.Visible = true;
                rbtnBranch2.Visible = true;
            }
        }
    }
}