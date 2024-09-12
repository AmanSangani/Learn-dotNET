using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace AddressBook.AdminPanel.Contacts
{
    public partial class ContactList : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillContactData();
            }
        }

        #endregion Page Load

        #region FillContactData
        private void FillContactData()
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

                cmdObj.CommandText = "PR_Contact_SelectAllByUserID";

                cmdObj.Parameters.AddWithValue("@UserID", Session["UserID"]);

                SqlDataReader sdrObj = cmdObj.ExecuteReader();

                gvContact.DataSource = sdrObj;
                gvContact.DataBind();

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
        #endregion FillContactData

        #region Row Command
        protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Delete Record
            if (e.CommandName == "DeleteRecord")
            {
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    string[] args = e.CommandArgument.ToString().Split(';');

                    String ContactID = args[0];
                    string imagePath = args[1];

                    DeleteImage(imagePath);
                    DeleteContactRecord(ContactID);
                    FillContactData();
                }
            }
            #endregion Delete Record
        }
        #endregion Row Command

        #region Delete Image
        private void DeleteImage(String imagePath)
        {
            FileInfo file = new FileInfo(Server.MapPath(imagePath));

            if(file.Exists)
            {
                file.Delete();
            }
            else
            {
                lblMsj.Text = "File Not Available...";
            }
        }
        #endregion Delete Image

        #region Delte Contact Record
        private void DeleteContactRecord(string ContactID)
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

                cmdObj.CommandText = "PR_Contact_DeleteByPk_UserID";

                cmdObj.Parameters.AddWithValue("@UserID", Session["UserID"]);
                cmdObj.Parameters.AddWithValue("@ContactID", ContactID);

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
        #endregion Delte Contact Record

    }
}