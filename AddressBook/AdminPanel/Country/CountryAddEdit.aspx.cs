using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddressBook.AdminPanel.Country
{
    public partial class CountryAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["CountryCode"] != null)
            {
                lblMsj.Text = "Edit Mode..." + Request.QueryString["CountryCode"].ToString().Trim();
            }
            else
            {
                lblMsj.Text = "Add Mode...";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            //Declare Local Varialble to Insert Data
            SqlString strCountryCode = SqlString.Null;
            SqlString strCountryName = SqlString.Null;
            SqlString strCountryCapital = SqlString.Null;

            if(txtCountryCode.Text.Trim() == "" || txtCountryName.Text.Trim() == "" || txtCountryCapital.Text.Trim() == "")
            {
                lblMsj.Text += "Enter Required Fields...";
                return;
            }

            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            //connObj.ConnectionString = "data source=AMAN;initial catalog=AddressBook;Integrated Security=True;";

            try
            {
                connObj.Open();

                //SqlCommand cmdObj = new SqlCommand();
                //cmdObj.Connection = connObj;

                //---------OR-----------------

                SqlCommand cmdObj = connObj.CreateCommand();


                cmdObj.CommandType = CommandType.StoredProcedure;

                cmdObj.CommandText = "PR_Country_Insert";

                strCountryCode = txtCountryCode.Text.Trim();
                strCountryName = txtCountryName.Text.Trim();
                strCountryCapital = txtCountryCapital.Text.Trim();

                cmdObj.Parameters.AddWithValue("@CountryCode", strCountryCode);
                cmdObj.Parameters.AddWithValue("@CountryName", strCountryName);
                cmdObj.Parameters.AddWithValue("@CountryCapital", strCountryCapital);

                cmdObj.ExecuteNonQuery();

            }
            catch (SqlException sqlEx) 
            {
                Response.Write("Error: " + sqlEx.Message);
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                connObj.Close();
                lblMsj.Text = "Data Inserted Successfully...";

                txtCountryCode.Text = "";
                txtCountryName.Text = "";
                txtCountryCapital.Text = "";

                txtCountryCode.Focus();
            }
        }
    }
}