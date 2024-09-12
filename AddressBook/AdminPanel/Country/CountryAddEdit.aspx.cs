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

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region Routes

                //if (Request.QueryString["CountryCode"] != null)
                //{
                //    FillControls(Request.QueryString["CountryCode"].ToString().Trim());
                //}

                if (Page.RouteData.Values["OperationName"] != null)
                {
                    #region Add Route
                    if (Page.RouteData.Values["OperationName"].ToString() == "Add")
                    {
                        lblAddEdit.Text = Page.RouteData.Values["OperationName"].ToString();
                    }
                    #endregion Add Route

                    #region Edit Route
                    else if (Page.RouteData.Values["OperationName"].ToString() == "Edit")
                    {
                        if (Page.RouteData.Values["CountryCode"] != null)
                        {
                            lblAddEdit.Text += " | CountryCode : " + Page.RouteData.Values["CountryCode"].ToString();
                            FillControls(Page.RouteData.Values["CountryCode"].ToString().Trim());
                        }
                        else
                        {
                            Response.Redirect("~/AdminPanel/Country/List");
                        }
                    }
                    #endregion Edit Route

                    #region Invalid Route
                    else
                    {
                        Response.Redirect("~/AdminPanel/Country/List");
                    }
                    #endregion Invalid Route

                }

                #endregion Routes

            }
        }

        #endregion Page Load

        #region Button : Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Declare Local Variables
            //Declare Local Varialble to Insert Data
            SqlString strCountryCode = SqlString.Null;
            SqlString strCountryName = SqlString.Null;
            SqlString strCountryCapital = SqlString.Null;
            #endregion Declare Local Variables

            #region Server Side Validation
            if (txtCountryCode.Text.Trim() == "" || txtCountryName.Text.Trim() == "" || txtCountryCapital.Text.Trim() == "")
            {
                lblMsj.Text += "Enter Required Fields...";
                return;
            }
            #endregion Server Side Validation

            #region Establish Connection
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            //connObj.ConnectionString = "data source=AMAN;initial catalog=AddressBook;Integrated Security=True;";
            #endregion Establish Connection

            try
            {
                #region Connection and Command Objects
                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                //SqlCommand cmdObj = new SqlCommand();
                //cmdObj.Connection = connObj;

                //---------OR-----------------

                SqlCommand cmdObj = connObj.CreateCommand();

                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command Objects

                #region Parameters

                strCountryCode = txtCountryCode.Text.Trim();
                strCountryName = txtCountryName.Text.Trim();
                strCountryCapital = txtCountryCapital.Text.Trim();

                cmdObj.Parameters.AddWithValue("@UserID", Session["UserID"]);
                cmdObj.Parameters.AddWithValue("@CountryCode", strCountryCode);
                cmdObj.Parameters.AddWithValue("@CountryName", strCountryName);
                cmdObj.Parameters.AddWithValue("@CountryCapital", strCountryCapital);

                #endregion Parameters

                #region Add-Mode / Edit-Mode

                if (Request.QueryString["CountryCode"] != null)
                {
                    #region Edit-Mode

                    cmdObj.CommandText = "PR_Country_UpdateByPK_UserID";
                    cmdObj.ExecuteNonQuery();
                    Response.Redirect("~/AdminPanel/Country/CountryList.aspx");

                    #endregion Edit-Mode
                }
                else
                {
                    #region Add-Mode
                    
                    cmdObj.CommandText = "PR_Country_Insert";
                    cmdObj.ExecuteNonQuery();
                    lblMsj.Text = "Data Inserted Successfully...";

                    txtCountryCode.Text = "";
                    txtCountryName.Text = "";
                    txtCountryCapital.Text = "";

                    txtCountryCode.Focus();

                    #endregion Add-Mode
                }

                #endregion Add-Mode / Edit-Mode

            }
            #region Exception Handling
            catch (SqlException sqlEx) 
            {
                Response.Write("Error: " + sqlEx.Message);
            }
            catch(Exception ex)
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
        #endregion Button : Save

        #region Fill Controls On Edit
        private void FillControls(SqlString CountryCode)
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
                cmdObj.CommandText = "PR_Country_SelectByPK_UserID";

                cmdObj.Parameters.AddWithValue("@UserID", Session["UserID"]);
                cmdObj.Parameters.AddWithValue("@CountryCode", CountryCode.ToString().Trim());

                SqlDataReader sdrObj = cmdObj.ExecuteReader();
                #endregion Store Procedure, Parameters and Execute

                #region Assign Values to Controls
                if (sdrObj.HasRows)
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
                if(connObj.State == ConnectionState.Open)
                {
                    connObj.Close();
                }
            }
            #endregion Close Connection

        }
        #endregion Fill Controls On Edit

        #region Button : Cancel
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
        }
        #endregion Button : Cancel

    }
}