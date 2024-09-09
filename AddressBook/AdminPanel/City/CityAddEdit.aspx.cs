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

namespace AddressBook.AdminPanel.City
{
    public partial class CityAddEdit : System.Web.UI.Page
    {

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillCountryDropDownList();
                if(Request.QueryString["CityCode"] != null)
                {
                    FillControls(Request.QueryString["CityCode"].ToString().Trim());
                }
            }
        }
        #endregion Page Load

        #region FillCountryDropDownList
        private void FillCountryDropDownList()
        {
            #region Establish Connection
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Establish Connection

            try
            {
                #region Connection and Command Object
                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                SqlCommand cmdObj = connObj.CreateCommand();
                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command Object

                #region Store procedure, Execute and Data Read/Bind

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

                #endregion Store procedure, Execute and Data Read/Bind

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
                if(connObj.State == ConnectionState.Open)
                {
                    connObj.Close();
                }
            }
            #endregion Close Connection

        }
        #endregion FillCountryDropDownList

        #region FillStateDropDownList
        private void FillStateDropDownList(SqlString CountryCode)
        {
            #region Establish Connection
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Establish Connection

            try
            {
                #region Connection and Command Object

                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                SqlCommand cmdObj = connObj.CreateCommand();

                cmdObj.CommandType = CommandType.StoredProcedure;
                #endregion Connection and Command Object

                #region Store Procedure, Parameter, Execute and Read/Bind Data

                cmdObj.CommandText = "PR_States_SelectForDropDownList";
                cmdObj.Parameters.AddWithValue("@CountryCode", CountryCode.ToString());
                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                if (sdrObj.HasRows)
                {
                    ddlStateName.DataSource = sdrObj;
                    ddlStateName.DataValueField = "StateCode";
                    ddlStateName.DataTextField = "StateName";
                    ddlStateName.DataBind();
                }
                ddlStateName.Items.Insert(0, new ListItem("Select State", "-1"));

                #endregion Store Procedure, Parameter, Execute and Read/Bind Data

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
                if(connObj.State == ConnectionState.Open)
                {
                    connObj.Close();
                }
            }
            #endregion Close Connection

        }
        #endregion FillStateDropDownList

        #region Fill Controls On Edit
        private void FillControls(SqlString CityCode)
        {
            #region Establish Connection

            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            #endregion Establish Connection

            try
            {
                #region Connection and Command Object

                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                SqlCommand cmdObj = connObj.CreateCommand();

                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command Object

                #region Store Procedure, Parameters and Execute
                cmdObj.CommandText = "PR_City_SelectByPK";

                cmdObj.Parameters.AddWithValue("@CityCode", CityCode.ToString().Trim());

                SqlDataReader sdrObj = cmdObj.ExecuteReader();
                #endregion Store Procedure, Parameters and Execute

                #region Assign Values to Controls

                if (sdrObj.HasRows)
                {
                    while (sdrObj.Read())
                    {
                        if (!sdrObj["CountryCode"].Equals(DBNull.Value))
                        {
                            ddlCountryCode.SelectedValue = sdrObj["CountryCode"].ToString();
                            ddlCountryCode.Enabled = false;
                            FillStateDropDownList(sdrObj["CountryCode"].ToString());
                        }
                        if (!sdrObj["StateCode"].Equals(DBNull.Value))
                        {
                            ddlStateName.SelectedValue = sdrObj["StateCode"].ToString();
                            ddlStateName.Enabled = false;
                        }
                        if (!sdrObj["CityCode"].Equals(DBNull.Value))
                        {
                            txtCityCode.Text = sdrObj["CityCode"].ToString();
                            txtCityCode.Enabled = false;
                        }
                        if (!sdrObj["CityName"].Equals(DBNull.Value))
                        {
                            txtCityName.Text = sdrObj["CityName"].ToString();
                        }
                        break;
                    }
                }
                else
                {
                    lblMsj.Text += "No Data for selected City : " + CityCode.ToString();
                }
                #endregion Assign Values to Controls

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
                Response.Write("Sql Exception: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            #endregion Exception Handling

            #region Close Connection
            finally
            {
                if (connObj.State == ConnectionState.Open)
                {
                    connObj.Close();
                }
            }
            #endregion Close Connection

        }
        #endregion Fill Controls On Edit

        #region Button : Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Local Varialble
            //Declare Local Varialble to Insert Data
            SqlString strCityCode = SqlString.Null;
            SqlString strCityName = SqlString.Null;
            SqlString strStateCode = SqlString.Null;
            #endregion Local Varialble

            #region Server Side Validation
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
            #endregion Server Side Validation

            #region Establish Connection
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Establish Connection

            try
            {
                #region Connection and Command object
                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                //SqlCommand cmdObj = new SqlCommand();
                //cmdObj.Connection = connObj;

                //---------OR-----------------

                SqlCommand cmdObj = connObj.CreateCommand();


                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command object

                #region Parameters

                strCityCode = txtCityCode.Text.Trim();
                strCityName = txtCityName.Text.Trim();

                cmdObj.Parameters.AddWithValue("@CityCode", strCityCode);
                cmdObj.Parameters.AddWithValue("@CityName", strCityName);

                #endregion Parameters

                #region Add-Mode / Edit-Mode

                if (Request.QueryString["CityCode"] != null)
                {
                    #region Edit-Mode

                    cmdObj.CommandText = "PR_City_UpdateByPK";
                    cmdObj.ExecuteNonQuery();
                    Response.Redirect("~/AdminPanel/City/CityList.aspx");

                    #endregion Edit-Mode
                }
                else
                {
                    #region Add-Mode

                    cmdObj.CommandText = "PR_City_Insert";

                    strStateCode = ddlStateName.SelectedValue.Trim();

                    cmdObj.Parameters.AddWithValue("@StateCode", strStateCode);

                    cmdObj.ExecuteNonQuery();

                    lblMsj.Text = "Data Inserted Successfully...";

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
                if(connObj.State == ConnectionState.Open)
                {
                    connObj.Close();
                }

                lblMsj.Text = "Data Inserted Successfully...";

                txtCityCode.Text = "";
                txtCityName.Text = "";

                txtCityCode.Focus();
            }
            #endregion Close Connection

        }
        #endregion Button : Save

        #region DropDownList Selection Change
        protected void ddlCountryCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Request.QueryString["CityCode"] == null)
            {
                ddlStateName.Items.Clear();

                SqlString str = SqlString.Null;

                str = ddlCountryCode.SelectedValue;

                FillStateDropDownList(str);
            }
        }
        #endregion DropDownList Selection Change

        #region Button : Cancel
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/City/CityList.aspx");
        }
        #endregion Button : Cancel

    }
}