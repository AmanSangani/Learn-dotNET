using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlTypes;

namespace AddressBook.AdminPanel.Country
{
    public partial class CountryList : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGridView();
            }
        }
        #endregion Page Load

        #region FillGridView
        private void FillGridView()
        {
            #region Establish Connection
            SqlConnection connObj = new SqlConnection();

            // Option 1: Using Windows Authentication
            connObj.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;

            // Option 2: Using SQL Server Authentication
            // connObj.ConnectionString = "data source=AMAN;initial catalog=AddressBook;Integrated Security=False;User ID=yourUsername;Password=yourPassword;";

            #endregion Establish Connection

            try
            {
                #region Connection and Command Object
                //Open the Connection
                connObj.Open();

                //Prepare the Command Object
                SqlCommand cmdObj = new SqlCommand();

                //Map command Object with Connection Object
                cmdObj.Connection = connObj;

                //Define Command Type
                cmdObj.CommandType = CommandType.StoredProcedure;
                //cmdObj.CommandType = CommandType.TableDirect;
                //cmdObj.CommandType = CommandType.Text;

                #endregion Connection and Command Object

                #region Store Procedure and Read/Bind Data
                //Write Query / Store Procedure
                cmdObj.CommandText = "PR_Country_SelectAllByUserID";

                cmdObj.Parameters.AddWithValue("@UserID", Session["UserID"]);

                //Step-3 : Read and Display Data--------------------------------------------------------------------------------------

                //cmdObj.ExecuteReader(); //Selet Queries
                //cmdObj.ExecuteNonQuery(); //Insert/Update/Delete
                //cmdObj.ExecuteScalar(); //Only one Scalar Value is return
                //cmdObj.ExecuteXmlReader(); //XML Format Data
                    
                // Define which Command to Read
                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                // Define where to Display Data
                gvCountry.DataSource = sdrObj;
                gvCountry.DataBind();

                #endregion Store Procedure and Read/Bind Data
            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
                Response.Write("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            #endregion Exception Handling

            #region Close Connection
            finally
            {
                // Close the Connection
                connObj.Close();
            }
            #endregion Close Connection

        }
        #endregion FillGridView

        #region Row-Command
        protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Delete Record
            if (e.CommandName == "DeleteRecord")
            {
                if(e.CommandArgument.ToString() != "")
                {
                    DeleteCountryRecord(e.CommandArgument.ToString().Trim());
                }
            }
            #endregion Delete Record
        }
        #endregion Row-Command

        #region Delete Country Record
        private void DeleteCountryRecord(SqlString CountryCode)
        {
            #region Establish Connection
            SqlConnection connObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Establish Connection

            try
            {
                #region Connection and Command Object
                connObj.Open();

                SqlCommand cmdObj = connObj.CreateCommand();

                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command Object

                #region Store Procedure, Parameters and Execute
                cmdObj.CommandText = "PR_Country_DeleteByPK_UserID";

                cmdObj.Parameters.AddWithValue("@CountryCode", CountryCode);
                cmdObj.Parameters.AddWithValue("@UserID", Session["UserID"]);

                cmdObj.ExecuteNonQuery();

                //Recall function to fill the updated data
                FillGridView();

                #endregion Store Procedure, Parameters and Execute

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
                Response.Write("SQL Error: " + sqlEx.Message);
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
        #endregion Delete Country Record

    }
}
