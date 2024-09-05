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

                if (Request.QueryString["StateCode"] != null)
                {
                    FillControls(Request.QueryString["StateCode"].ToString().Trim());
                }
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

                #endregion Connection And Command

                #region Store Procedure, Execute, Data Read and Bind
                
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

                #endregion Store Procedure, Execute, Data Read and Bind

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

        #region FillControls on Edit
        private void FillControls(String StateCode)
        {
            #region Establish Connection
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Establish Connection

            try
            {
                #region Connection and Command Object

                if(connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                SqlCommand cmdObj = connObj.CreateCommand();

                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command Object

                #region Store Procedure, Parameter and Execute 

                cmdObj.CommandText = "PR_State_SelectByPK";

                cmdObj.Parameters.AddWithValue("@StateCode", StateCode);

                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                #endregion Store Procedure, Parameter and Execute 

                #region Assign Value to Controls

                if (sdrObj.HasRows)
                {
                    while(sdrObj.Read())
                    {
                        if (!sdrObj["CountryCode"].Equals(DBNull.Value))
                        {
                            ddlCountryCode.SelectedValue = sdrObj["CountryCode"].ToString();
                            ddlCountryCode.Enabled = false;
                        }
                        if (!sdrObj["StateCode"].Equals(DBNull.Value))
                        {
                            txtStateCode.Text = sdrObj["StateCode"].ToString();
                            txtStateCode.Enabled = false;
                        }
                        if (!sdrObj["StateName"].Equals(DBNull.Value))
                        {
                            txtStateName.Text = sdrObj["StateName"].ToString();
                        }
                        if (!sdrObj["StateCapital"].Equals(DBNull.Value))
                        {
                            txtStateCapital.Text = sdrObj["StateCapital"].ToString();
                        }
                        break;
                    }
                }

                #endregion Assign Value to Controls

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
                Response.Write("SQL Error: " + sqlEx.Message);
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            #endregion Exception Handling

            #region Close Connection
            finally
            {
                if(connObj.State == ConnectionState.Open)
                {
                    connObj.Close();
                }
            }
            #endregion Close Connection

        }
        #endregion FillControls on Edit

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

                #region Parameters
                strStateCode = txtStateCode.Text.Trim();
                strStateName = txtStateName.Text.Trim();
                strStateCapital = txtStateCapital.Text.Trim();

                cmdObj.Parameters.AddWithValue("@StateCode", strStateCode);
                cmdObj.Parameters.AddWithValue("@StateName", strStateName);
                cmdObj.Parameters.AddWithValue("@StateCapital", strStateCapital);
                #endregion Parameters

                #region Add-Mode / Edit-Mode

                if (Request.QueryString["StateCode"] != null)
                {
                    #region Edit-Mode

                    cmdObj.CommandText = "PR_State_UpdateByPK";

                    cmdObj.ExecuteNonQuery();
                    
                    Response.Redirect("~/AdminPanel/States/StatesList.aspx");

                    #endregion Edit-Mode
                }
                else
                {
                    #region Add-Mode

                    strCountryCode = ddlCountryCode.SelectedValue.Trim();
                    cmdObj.Parameters.AddWithValue("@CountryCode", strCountryCode);

                    cmdObj.CommandText = "PR_States_Insert";

                    cmdObj.ExecuteNonQuery();

                    lblMsj.Text = "Data Inserted Successfully...";

                    txtStateCode.Text = "";
                    txtStateName.Text = "";
                    txtStateCapital.Text = "";

                    txtStateCode.Focus();

                    #endregion Add-Mode
                }

                #endregion Add-Mode / Edit-Mode

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

        #endregion Button : Save

        #region Button : Cancel
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/States/StatesList.aspx");
        }
        #endregion Button : Cancel

    }
}


