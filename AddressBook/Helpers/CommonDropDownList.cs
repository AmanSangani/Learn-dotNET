using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AddressBook.Helpers
{
    public static class CommonDropDownList
    {
        #region Fill Country DropDown List
        public static void FillCountryDropDownList(DropDownList ddl, String UserID)
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

                cmdObj.Parameters.AddWithValue("@UserID", UserID);

                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                if (sdrObj.HasRows)
                {
                    ddl.DataSource = sdrObj;
                    ddl.DataValueField = "CountryCode";
                    ddl.DataTextField = "CountryName";
                    ddl.DataBind();
                }

                ddl.Items.Insert(0, new ListItem("Select Country", "-1"));

                #endregion Store Procedure, Execute, Data Read and Bind

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
            }
            catch (Exception ex)
            {
            }
            #endregion Exception Handling

            #region Close Connection
            finally
            {
                connObj.Close();
            }
            #endregion Close Connection

        }
        #endregion Fill Country DropDown List

        #region Fill State DropDown List
        public static void FillStateDropDownList(DropDownList ddl, String UserID, String CountryCode)
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

                cmdObj.Parameters.AddWithValue("@UserID", UserID);
                cmdObj.Parameters.AddWithValue("@CountryCode", CountryCode);

                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                if (sdrObj.HasRows)
                {
                    ddl.DataSource = sdrObj;
                    ddl.DataValueField = "StateCode";
                    ddl.DataTextField = "StateName";
                    ddl.DataBind();
                }
                ddl.Items.Insert(0, new ListItem("Select State", "-1"));

                #endregion Store Procedure, Parameter, Execute and Read/Bind Data

            }
            #region Exception Handling
            catch (SqlException sqlEx)
            {
            }
            catch (Exception ex)
            {
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
        #endregion Fill State DropDown List

    }
}