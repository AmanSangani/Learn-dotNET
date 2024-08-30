using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.Tasks
{
    public partial class ChkBoxListTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cblSubject.Items.Add(new ListItem("Physics"));
                cblSubject.Items.Add(new ListItem("Chemistry"));
                cblSubject.Items.Add(new ListItem("Maths"));
                cblSubject.Items.Add(new ListItem("Biology"));
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            foreach(ListItem li in cblSubject.Items)
            {
                if (li.Selected)
                {
                    lblShow.Text += "<strong>" + li.Text + "</strong> <br />";
                }
                else
                {
                    lblShow.Text += li.Text + "<br />";
                }
            }
        }

        protected void chkALl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkALl.Checked)
            {
                chkReverse.Checked = false;
                chkNone.Checked = false;

                foreach(ListItem li in cblSubject.Items)
                {
                    li.Selected = true;
                }
            }
            if (!chkALl.Checked)
            {
                foreach (ListItem li in cblSubject.Items)
                {
                    li.Selected = false;
                }
            }
        }

        protected void chkNone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNone.Checked)
            {
                chkReverse.Checked = false;
                chkALl.Checked = false;

                foreach (ListItem li in cblSubject.Items)
                {
                    li.Selected = false;
                }
            }
        }

        protected void chkReverse_CheckedChanged(object sender, EventArgs e)
        {
            chkALl.Checked = false;
            chkNone.Checked = false;
            if (chkReverse.Checked)
            {
                foreach (ListItem li in cblSubject.Items)
                {
                    li.Selected = !li.Selected;
                }
            }
        }
    }
}