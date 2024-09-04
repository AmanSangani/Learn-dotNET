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
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CountryCode"] != null)
                {
                    FillControls(Request.QueryString["CountryCode"].ToString().Trim());
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            //Declare Local Varialble to Insert Data
            SqlString strCountryCode = SqlString.Null;
            SqlString strCountryName = SqlString.Null;
            SqlString strCountryCapital = SqlString.Null;

            if (txtCountryCode.Text.Trim() == "" || txtCountryName.Text.Trim() == "" || txtCountryCapital.Text.Trim() == "")
            {
                lblMsj.Text += "Enter Required Fields...";
                return;
            }

            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            //connObj.ConnectionString = "data source=AMAN;initial catalog=AddressBook;Integrated Security=True;";

            try
            {
                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                //SqlCommand cmdObj = new SqlCommand();
                //cmdObj.Connection = connObj;

                //---------OR-----------------

                SqlCommand cmdObj = connObj.CreateCommand();


                cmdObj.CommandType = CommandType.StoredProcedure;

                strCountryCode = txtCountryCode.Text.Trim();
                strCountryName = txtCountryName.Text.Trim();
                strCountryCapital = txtCountryCapital.Text.Trim();

                cmdObj.Parameters.AddWithValue("@CountryCode", strCountryCode);
                cmdObj.Parameters.AddWithValue("@CountryName", strCountryName);
                cmdObj.Parameters.AddWithValue("@CountryCapital", strCountryCapital);

                if (Request.QueryString["CountryCode"] != null)
                {
                    //Edit Mode
                    cmdObj.CommandText = "PR_Country_UpdateByPK";
                    cmdObj.ExecuteNonQuery();
                    Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
                }
                else
                {
                    //Add Mode
                    cmdObj.CommandText = "PR_Country_Insert";
                    cmdObj.ExecuteNonQuery();
                    lblMsj.Text = "Data Inserted Successfully...";

                    txtCountryCode.Text = "";
                    txtCountryName.Text = "";
                    txtCountryCapital.Text = "";

                    txtCountryCode.Focus();
                }
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
                if (connObj.State == ConnectionState.Open)
                {
                    connObj.Close();
                }
            }
        }

        private void FillControls(SqlString CountryCode)
        {
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            try
            {
                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                SqlCommand cmdObj = connObj.CreateCommand();

                cmdObj.CommandType = CommandType.StoredProcedure;

                cmdObj.CommandText = "PR_Country_SelectByPK";

                cmdObj.Parameters.AddWithValue("@CountryCode", CountryCode.ToString().Trim());

                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                if(sdrObj.HasRows)
                {
                    while (sdrObj.Read())
                    {
                        if (!sdrObj["CountryCode"].Equals(DBNull.Value))
                        {
                            txtCountryCode.Text = sdrObj["CountryCode"].ToString();
                            txtCountryCode.ReadOnly = true;
                        }
                        if (!sdrObj["CountryName"].Equals(DBNull.Value))
                        {
                            txtCountryName.Text = sdrObj["CountryName"].ToString();
                        }
                        if (!sdrObj["CountryCapital"].Equals(DBNull.Value))
                        {
                            txtCountryCapital.Text = sdrObj["CountryCapital"].ToString();
                        }
                        break;
                    }
                }
                else
                {
                    lblMsj.Text += "No Data for selected Country : " + CountryCode.ToString();
                }

            }
            catch(SqlException sqlEx)
            {
                Response.Write("Sql Exception: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                if(connObj.State == ConnectionState.Open)
                {
                    connObj.Close();
                }
            }
        }
    }
}