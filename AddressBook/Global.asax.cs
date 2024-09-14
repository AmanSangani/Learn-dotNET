using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AddressBook
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            #region Country Routes

            routes.MapPageRoute("AddressBookCountryList", "AdminPanel/Country/List", "~/AdminPanel/Country/CountryList.aspx");

            routes.MapPageRoute("AddressBookCountryAdd", "AdminPanel/Country/{OperationName}", "~/AdminPanel/Country/CountryAddEdit.aspx");
            
            routes.MapPageRoute("AddressBookCountryEdit", "AdminPanel/Country/{OperationName}/{CountryCode}", "~/AdminPanel/Country/CountryAddEdit.aspx");

            #endregion Country Routes

            #region State Routes

            routes.MapPageRoute("AddressBookStateList", "AdminPanel/State/List", "~/AdminPanel/States/StatesList.aspx");

            routes.MapPageRoute("AddressBookStateAdd", "AdminPanel/State/{OperationName}", "~/AdminPanel/States/StatesAddEdit.aspx");

            routes.MapPageRoute("AddressBookStateEdit", "AdminPanel/State/{OperationName}/{StateCode}", "~/AdminPanel/States/StatesAddEdit.aspx");

            #endregion State Routes

            #region City Routes

            routes.MapPageRoute("AddressBookCityList", "AdminPanel/City/List", "~/AdminPanel/City/CityList.aspx");

            routes.MapPageRoute("AddressBookCityAdd", "AdminPanel/City/{OperationName}", "~/AdminPanel/City/CityAddEdit.aspx");

            routes.MapPageRoute("AddressBookCityEdit", "AdminPanel/City/{OperationName}/{CityCode}", "~/AdminPanel/City/CityAddEdit.aspx");

            #endregion City Routes

            #region Contact Routes

            routes.MapPageRoute("AddressBookContactList", "AdminPanel/Contact/List", "~/AdminPanel/Contacts/ContactList.aspx");

            routes.MapPageRoute("AddressBookContactAdd", "AdminPanel/Contact/{OperationName}", "~/AdminPanel/Contacts/ContactAddEdit.aspx");

            routes.MapPageRoute("AddressBookContactEdit", "AdminPanel/Contact/{OperationName}/{ContactID}", "~/AdminPanel/Contacts/ContactAddEdit.aspx");

            #endregion Contact Routes

        }

    }
}