using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace AddressBook.AdminPanel.States
{
    public partial class StatesAddEdit : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDropDownList();
            }
        }
        #endregion Page Load

        #region Fill DropDown List
        private void FillDropDownList()
        {
            #region Establish Connection
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Establish Connection

            try
            {

                #region Connection And Command

                connObj.Open();

                SqlCommand cmdObj = connObj.CreateCommand();

                cmdObj.CommandType = CommandType.StoredProcedure;

                cmdObj.CommandText = "PR_Country_SelectForDropDownList";

                #endregion Connection And Command

                #region Data Read and Bind

                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                if (sdrObj.HasRows)
                {
                    ddlCountryCode.DataSource = sdrObj;
                    ddlCountryCode.DataValueField = "CountryCode";
                    ddlCountryCode.DataTextField = "CountryName";
                    ddlCountryCode.DataBind();
                }

                ddlCountryCode.Items.Insert(0, new ListItem("Select Country", "-1"));

                #endregion Data Read and Bind

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
                Response.Write("Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            #endregion Exception Handling

            #region Close Connection
            finally
            {
                connObj.Close();
            }
            #endregion Close Connection

        }
        #endregion Fill DropDown List

        #region Button : Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Declare Local Variables
            //Declare Local Varialble to Insert Data
            SqlString strStateCode = SqlString.Null;
            SqlString strStateName = SqlString.Null;
            SqlString strStateCapital = SqlString.Null;
            SqlString strCountryCode = SqlString.Null;
            #endregion Declare Local Variables

            #region ServerSide Validation
            if (ddlCountryCode.SelectedValue == "-1")
            {
                lblMsj.Text += "Select Country...";
                return;
            }

            if (
                txtStateCode.Text.Trim() == "" || 
                txtStateName.Text.Trim() == "" ||
                txtStateCapital.Text.Trim() == "" ||
                ddlCountryCode.SelectedValue.Trim() == ""
            )
            {
                lblMsj.Text += "Enter Required Fields...";
                return;
            }
            #endregion ServerSide Validation

            #region Establish Connection
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            //connObj.ConnectionString = "data source=AMAN;initial catalog=AddressBook;Integrated Security=True;";
            #endregion Establish Connection

            try
            {
                #region Connection and Command Objects
                connObj.Open();

                //SqlCommand cmdObj = new SqlCommand();
                //cmdObj.Connection = connObj;

                //---------OR-----------------

                SqlCommand cmdObj = connObj.CreateCommand();


                cmdObj.CommandType = CommandType.StoredProcedure;
                #endregion Connection and Command Objects

                #region Store Procedure, Parameters and Execute

                cmdObj.CommandText = "PR_States_Insert";

                strStateCode = txtStateCode.Text.Trim();
                strStateName = txtStateName.Text.Trim();
                strStateCapital = txtStateCapital.Text.Trim();
                strCountryCode = ddlCountryCode.SelectedValue.Trim();

                cmdObj.Parameters.AddWithValue("@StateCode", strStateCode);
                cmdObj.Parameters.AddWithValue("@StateName", strStateName);
                cmdObj.Parameters.AddWithValue("@StateCapital", strStateCapital);
                cmdObj.Parameters.AddWithValue("@CountryCode", strCountryCode);

                cmdObj.ExecuteNonQuery();

                #endregion Store Procedure, Parameters and Execute

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
                Response.Write("Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            #endregion Exception Handling

            #region Close Connection
            finally
            {
                connObj.Close();
                lblMsj.Text = "Data Inserted Successfully...";

                txtStateCode.Text = "";
                txtStateName.Text = "";
                txtStateCapital.Text = "";

                txtStateCode.Focus();
            }
            #endregion Close Connection

        }

        #endregion Button : Save

    }
}


