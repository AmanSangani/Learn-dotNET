using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace AddressBook.AdminPanel.City
{
    public partial class CityList : System.Web.UI.Page
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

            connObj.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;

            #endregion Establish Connection

            try
            {
                #region Connection and Command Object

                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                SqlCommand cmdObj = new SqlCommand();

                cmdObj.Connection = connObj;

                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command Object

                #region Store Procedure, Execute and Read/Bind Data

                cmdObj.CommandText = "PR_City_SelectAll";

                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                gvCity.DataSource = sdrObj;
                gvCity.DataBind();

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
                if (connObj.State == ConnectionState.Open)
                {
                    connObj.Close();
                }
            }
            #endregion Close Connection
        }


        #endregion FillGridView

        #region Row Command
        protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Delete Record
            if (e.CommandName == "DeleteRecord")
            {
                if(e.CommandArgument.ToString().Trim() != "")
                {
                    DeleteCityRecord(e.CommandArgument.ToString().Trim());
                    FillGridView();
                }
            }
            #endregion Delete Record
        }
        #endregion Row Command

        #region Delte City Record
        private void DeleteCityRecord(string CityCode)
        {
            #region Establish Connection

            SqlConnection connObj = new SqlConnection();

            connObj.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;

            #endregion Establish Connection

            try
            {
                #region Connection and Command Object

                if (connObj.State != ConnectionState.Open)
                {
                    connObj.Open();
                }

                SqlCommand cmdObj = new SqlCommand();

                cmdObj.Connection = connObj;

                cmdObj.CommandType = CommandType.StoredProcedure;

                #endregion Connection and Command Object

                #region Store Procedure, Execute and Read/Bind Data

                cmdObj.CommandText = "PR_City_DeleteByPK";

                cmdObj.Parameters.AddWithValue("@CityCode", CityCode);

                cmdObj.ExecuteNonQuery();

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
                if (connObj.State == ConnectionState.Open)
                {
                    connObj.Close();
                }
            }
            #endregion Close Connection
        }
        #endregion Delte City Record

    }
}