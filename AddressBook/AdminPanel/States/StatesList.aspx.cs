using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace AddressBook.AdminPanel.States
{
    public partial class StatesList : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

            //connObj.ConnectionString = "data source=AMAN;initial catalog=AddressBook;Integrated Security=True;";
            //--------OR------------------
            connObj.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;

            #endregion Establish Connection

            try
            {
                #region Connection and Command Object
                connObj.Open();

                SqlCommand cmdObj = new SqlCommand();

                cmdObj.Connection = connObj;

                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command Object

                #region Store Procedure, Execute and Read/Bind Data
                cmdObj.CommandText = "PR_States_SelectAll";

                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                gvState.DataSource = sdrObj;
                gvState.DataBind();

                #endregion Store Procedure, Execute and Read/Bind Data
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
        #endregion FillGridView

        #region Row Command
        protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Delete Record
            if (e.CommandName == "DeleteRecord")
            {
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    DeleteStateRecord(e.CommandArgument.ToString().Trim());
                }
            }
            #endregion Delete Record
        }
        #endregion Row Command

        #region Delete State Record
        private void DeleteStateRecord(string StateCode)
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

                cmdObj.CommandText = "PR_State_DeleteByPK";

                cmdObj.Parameters.AddWithValue("@StateCode", StateCode);

                cmdObj.ExecuteNonQuery();

                FillGridView();

                #endregion Store Procedure, Parameters and Execute

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
                Response.Write("Sql Error: " + sqlEx.Message);
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
        #endregion Delete State Record

    }
}

