using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressBook.AdminPanel.States
{
    public partial class StatesAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            //Declare Local Varialble to Insert Data
            SqlString strStateCode = SqlString.Null;
            SqlString strStateName = SqlString.Null;
            SqlString strStateCapital = SqlString.Null;
            SqlString strCountryCode = SqlString.Null;

            if (
                txtStateCode.Text.Trim() == "" || 
                txtStateName.Text.Trim() == "" ||
                txtStateCapital.Text.Trim() == "" || 
                txtCountryCode.Text.Trim() == ""
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

                cmdObj.CommandText = "PR_States_Insert";

                strStateCode = txtStateCode.Text.Trim();
                strStateName = txtStateName.Text.Trim();
                strStateCapital = txtStateCapital.Text.Trim();
                strCountryCode = txtCountryCode.Text.Trim();

                cmdObj.Parameters.AddWithValue("@StateCode", strStateCode);
                cmdObj.Parameters.AddWithValue("@StateName", strStateName);
                cmdObj.Parameters.AddWithValue("@StateCapital", strStateCapital);
                cmdObj.Parameters.AddWithValue("@CountryCode", strCountryCode);

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

                txtStateCode.Text = "";
                txtStateName.Text = "";
                txtStateCapital.Text = "";

                txtStateCode.Focus();
            }
        }
    }
}