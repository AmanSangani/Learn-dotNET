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
    }
}