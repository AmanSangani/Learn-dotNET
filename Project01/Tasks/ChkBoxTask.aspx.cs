using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.Tasks
{
    public partial class ChkBoxTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            String str = "";

            if (chkMaths.Checked)
            {
                str += "Maths ";
            }
            if(chkPhysics.Checked)
            {
                str += "Physics ";
            }
            if (chkChemistry.Checked)
            {
                str += "Chemistry ";
            }

            lblResult.Text = str;
        }

        protected void chkALl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkALl.Checked)
            {
                chkReverse.Checked = false;
                chkNone.Checked = false;
                chkChemistry.Checked = true;
                chkMaths.Checked = true;
                chkPhysics.Checked = true;
            }
            if (!chkALl.Checked)
            {
                chkChemistry.Checked = false;
                chkMaths.Checked = false;
                chkPhysics.Checked = false;
            }
        }

        protected void chkNone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNone.Checked)
            {
                chkReverse.Checked = false;
                chkALl.Checked = false;
                chkChemistry.Checked = false;
                chkMaths.Checked = false;
                chkPhysics.Checked = false;
            }
        }

        protected void chkReverse_CheckedChanged(object sender, EventArgs e)
        {
            chkALl.Checked = false;
            chkNone.Checked = false;    
            chkChemistry.Checked = !chkChemistry.Checked;
            chkMaths.Checked = !chkMaths.Checked;
            chkPhysics.Checked = !chkPhysics.Checked;
        }

        String str = "";

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if(chkCspit.Checked || chkDepstar.Checked)
            {
                btnResult.Visible = true;
            }
            else
            {
                btnResult.Visible = false;
            }
            if(chkDepstar.Checked)
            {
                chkBranch1.Text = "DCE";
                chkBranch2.Text = "DCSE";

                chkBranch1.Visible = true;
                chkBranch2.Visible = true;
            }
            else
            {
                chkBranch1.Visible = false;
                chkBranch2.Visible = false;
            }
            if (chkCspit.Checked)
            {
                chkBranch3.Text = "CE";
                chkBranch4.Text = "CSE";

                chkBranch3.Visible = true;
                chkBranch4.Visible = true;
            }
            else
            {
                chkBranch3.Visible = false;
                chkBranch4.Visible = false;
            }
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            if(chkBranch1.Checked)
            {
                str += " " + chkBranch1.Text;
            }
            if(chkBranch2.Checked)
            {
                str += " " + chkBranch2.Text;
            }
            if (chkBranch3.Checked)
            {
                str += " " + chkBranch3.Text;
            }
            if (chkBranch4.Checked)
            {
                str += " " + chkBranch4.Text;
            }
            lblClg.Text = str;  
        }
    }
}