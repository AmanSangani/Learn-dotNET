using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project01.ServerControlDemo
{
    public partial class TxtBoxDemo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCopy_Click(object sender, EventArgs e)
        {
            txtBox2.Text = txtBox1.Text;
        }
    }
}