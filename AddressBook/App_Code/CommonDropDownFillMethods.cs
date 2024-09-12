using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AddressBook.App_Code
{
    public static class CommonDropDownFillMethods
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

    }
}