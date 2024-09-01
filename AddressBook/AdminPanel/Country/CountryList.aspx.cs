using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

namespace AddressBook.AdminPanel.Country
{
    public partial class CountryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Step-1: Establish Connection--------------------------------------------------------------------------------------
            SqlConnection connObj = new SqlConnection();

            // Option 1: Using Windows Authentication
            connObj.ConnectionString = "data source=AMAN;initial catalog=AddressBook;Integrated Security=True;";

            // Option 2: Using SQL Server Authentication
            // connObj.ConnectionString = "data source=AMAN;initial catalog=AddressBook;Integrated Security=False;User ID=yourUsername;Password=yourPassword;";

            try
            {
                //Open the Connection
                connObj.Open();


                //Step-2 : Do Your Work--------------------------------------------------------------------------------------


                //Prepare the Command Object
                SqlCommand cmdObj = new SqlCommand();

                //Map command Object with Connection Object
                cmdObj.Connection = connObj;

                //Define Command Type
                cmdObj.CommandType = CommandType.StoredProcedure;
                //cmdObj.CommandType = CommandType.TableDirect;
                //cmdObj.CommandType = CommandType.Text;

                //Write Query / Store Procedure
                cmdObj.CommandText = "PR_Country_SelectAll";

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
            }
            catch (SqlException sqlEx)
            {
                Response.Write("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                // Close the Connection
                connObj.Close();
            }

        }
    }
}
