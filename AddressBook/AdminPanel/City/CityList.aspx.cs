using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace AddressBook.AdminPanel.City
{
    public partial class CityList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connObj = new SqlConnection();

            connObj.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;

            try
            {
                connObj.Open();

                SqlCommand cmdObj = new SqlCommand();

                cmdObj.Connection = connObj;

                cmdObj.CommandType = CommandType.StoredProcedure;

                cmdObj.CommandText = "PR_City_SelectAll";

                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                gvCity.DataSource = sdrObj;
                gvCity.DataBind();
            }
            catch (SqlException sqlEx)
            {
                Response.Write("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                connObj.Close();
            }
        }
    }
}