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
            if (!Page.IsPostBack)
            {
                FillCountryDropDownList();
                //FillStateDropDownList();
            }
        }

        private void FillCountryDropDownList()
        {
            SqlConnection connObj = new SqlConnection("data source=AMAN;initial catalog=AddressBook;Integrated Security=True;");
            try
            {
                connObj.Open();

                SqlCommand cmdObj = connObj.CreateCommand();
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.CommandText = "PR_Country_SelectForDropDownList";
                SqlDataReader sdrObj = cmdObj.ExecuteReader();
                
                if (sdrObj.HasRows)
                {
                    ddlCountryCode.DataSource = sdrObj;
                    ddlCountryCode.DataValueField = "CountryCode";
                    ddlCountryCode.DataTextField = "CountryName";
                    ddlCountryCode.DataBind();
                }
                ddlCountryCode.Items.Insert(0, new ListItem("Select Country", "-1"));

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
            }
        }

        private void FillStateDropDownList(SqlString str)
        {
            SqlConnection connObj = new SqlConnection("data source=AMAN;initial catalog=AddressBook;Integrated Security=True;");
            try
            {
                connObj.Open();

                SqlCommand cmdObj = connObj.CreateCommand();
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.CommandText = "PR_States_SelectForDropDownList";
                cmdObj.Parameters.AddWithValue("@CountryCode", str.ToString());
                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                if (sdrObj.HasRows)
                {
                    ddlStateName.DataSource = sdrObj;
                    ddlStateName.DataValueField = "StateCode";
                    ddlStateName.DataTextField = "StateName";
                    ddlStateName.DataBind();
                }
                ddlStateName.Items.Insert(0, new ListItem("Select State", "-1"));

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
            }
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
                ddlStateName.SelectedValue.Trim() == ""
            )
            {
                lblMsj.Text += "Enter Required Fields...";
                return;
            }


            if (ddlCountryCode.SelectedValue == "-1")
            {
                lblMsj.Text += "Select Country...";
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
                strStateCode = ddlStateName.SelectedValue.Trim();

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

                txtCityCode.Focus();
            }
        }

        protected void ddlCountryCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            //ddlStateName.DataSource = null;
            //ddlStateName.DataBind();

            SqlString str = SqlString.Null;

            str = ddlCountryCode.SelectedValue;
            
            lblMsj.Text = str.ToString();

            FillStateDropDownList(str);
        }
        protected void btnTemp_Click(object sender, EventArgs e)
        {
            SqlString str = SqlString.Null;

            str = ddlStateName.SelectedValue;

            lblMsj.Text = str.ToString();
        }
    }
}