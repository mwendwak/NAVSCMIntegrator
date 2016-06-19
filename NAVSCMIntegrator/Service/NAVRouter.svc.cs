using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace NAVSCMIntegrator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class NavRouter : INavProduct, INavInboundCustomers   //INHERIT ALL ENTITY INTERFACES
    {
        /* *********************************CUSTOMER RELATED FUNCTIONS****************************************** */
        /*public string createCustomer(NavCustomer navCustomer)
        {
            return CustomerManager.NavCustomerCreate(navCustomer);
        }

        public NavCustomer parseJsonCustomer(string navCustomerData)
        {
            NavCustomer newCust = new NavCustomer(navCustomerData);
            return newCust;
        }

        public NavCustomer parseStringCustomer(string xCustomerID, string xCustomerNames, string xCustomerBusGroup, string xRouteSalesArea
            , string xPINNo, string xCustomerPhoneNo, string xPostingGroup, string xVATGroup)
        {
            NavCustomer newCust = new NavCustomer();
            newCust.CustomerID = xCustomerID;
            newCust.CustomerNames = xCustomerNames;
            newCust.CustomerBusGroup = xCustomerBusGroup;
            newCust.RouteSalesArea = xRouteSalesArea;
            newCust.PINNo = xPINNo;
            newCust.CustomerPhoneNo = xCustomerPhoneNo;
            newCust.PostingGroup = xPostingGroup;
            newCust.VATGroup = xVATGroup;
            return newCust;
        }

        public bool validateCustomer(NavCustomer navCustomer)
        {
            return true; //write code to perform the proper customer rec validations
        }
        /* *********************************PRODUCTS RELATED FUNCTIONS****************************************** */
        [WebInvoke(Method = "GET",
                       RequestFormat = WebMessageFormat.Json,
                       ResponseFormat = WebMessageFormat.Json,
                       BodyStyle = WebMessageBodyStyle.Wrapped,
                       UriTemplate = "Products")]
        public List<NavProduct> getProductsAll()
        {
            ProductManager ProdManager = new ProductManager();
            
            return ProdManager.getAllNavProducts();
        }
        [WebInvoke(Method = "GET",
                       RequestFormat = WebMessageFormat.Json,
                       ResponseFormat = WebMessageFormat.Json,
                       UriTemplate = "ProductId{productCode}")]
        public NavProduct getProductFiltered(string productCode)
        {
            ProductManager ProdManager = new ProductManager();
            return ProdManager.getNavProduct(productCode);
        }
        /* *********************************NAV CUSTOMERS RELATED FUNCTIONS****************************************** */
        [WebInvoke(Method = "GET",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.Wrapped,
               UriTemplate = "Customers")]
        public List<NavCustomer> NavCustomers()
        {
            CustomerManager custManager = new CustomerManager();
            return custManager.getAllNavCustomers();
        }

        public NavCustomer getNavCustomerFiltered(string custCode)
        {
            CustomerManager CustManager = new CustomerManager();
            return CustManager.getNavCustomer(custCode);
        }
    }
}
