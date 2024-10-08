﻿using System;
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

                dlContact.DataSource = sdrObj;
                dlContact.DataBind();

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

        #region Row Command for GridView
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
        #endregion Row Command for GridView

        #region  Row Command for DataList
        protected void dlContact_ItemCommand(object source, DataListCommandEventArgs e)
        {
            #region Delete Record
            if (e.CommandName == "DeleteRecord")
            {
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    string[] args = e.CommandArgument.ToString().Split(';');
                    string ContactID = args[0];
                    string imagePath = args.Length > 1 ? args[1] : string.Empty;

                    DeleteImage(imagePath);
                    DeleteContactWiseCategory(ContactID);
                    DeleteContactRecord(ContactID);
                    FillContactData();
                }
            }
            #endregion Delete Record
        }
        #endregion Row Command for DataList

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

        #region Delete Contact wise Category Record

        private void DeleteContactWiseCategory(string ContactID)
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

                cmdObj.CommandText = "PR_CategoryWiseContact_DeleteByContactID";

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

        #endregion Delete Contact wise Category Record

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