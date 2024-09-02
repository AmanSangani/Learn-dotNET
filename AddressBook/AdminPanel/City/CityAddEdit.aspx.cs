using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressBook.AdminPanel.City
{
    public partial class CityAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            //Declare Local Varialble to Insert Data
            SqlString strCityCode = SqlString.Null;
            SqlString strCityName = SqlString.Null;
            SqlString strStateCode = SqlString.Null;

            if (
                txtCityCode.Text.Trim() == "" ||
                txtCityName.Text.Trim() == "" ||
                txtStateCode.Text.Trim() == ""
            )
            {
                lblMsj.Text += "Enter Required Fields...";
                return;
            }

            SqlConnection connObj = new SqlConnection("data source=AMAN;initial catalog=AddressBook;Integrated Security=True;");

            //connObj.ConnectionString = "data source=AMAN;initial catalog=AddressBook;Integrated Security=True;";

            try
            {
                connObj.Open();

                //SqlCommand cmdObj = new SqlCommand();
                //cmdObj.Connection = connObj;

                //---------OR-----------------

                SqlCommand cmdObj = connObj.CreateCommand();


                cmdObj.CommandType = CommandType.StoredProcedure;

                cmdObj.CommandText = "PR_City_Insert";

                strCityCode = txtCityCode.Text.Trim();
                strCityName = txtCityName.Text.Trim();
                strStateCode = txtStateCode.Text.Trim();

                cmdObj.Parameters.AddWithValue("@CityCode", strCityCode);
                cmdObj.Parameters.AddWithValue("@CityName", strCityName);
                cmdObj.Parameters.AddWithValue("@StateCode", strStateCode);

                cmdObj.ExecuteNonQuery();

            }
            catch (SqlException sqlEx)
            {
                Response.Write("Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                connObj.Close();
                lblMsj.Text = "Data Inserted Successfully...";

                txtCityCode.Text = "";
                txtCityName.Text = "";
                txtStateCode.Text = "";

                txtCityCode.Focus();
            }
        }
    }
}