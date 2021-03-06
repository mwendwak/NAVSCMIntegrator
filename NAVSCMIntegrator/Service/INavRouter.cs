﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;

namespace NAVSCMIntegrator
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    /*[ServiceContract(Namespace = "http://localhost/NAVSCMIntegrator/Customers")]
    public interface INavCustomer
    {
        [OperationContract]
        Boolean validateCustomer(NavCustomer navCustomer);
        [OperationContract]
        string createCustomer(NavCustomer navCustomer);
        [OperationContract]
        NavCustomer parseJsonCustomer(string navCustomerData);
        [OperationContract]
        NavCustomer parseStringCustomer(string xCustomerID,string xCustomerNames,string xCustomerBusGroup, string xRouteSalesArea
            , string xPINNo, string xCustomerPhoneNo, string xPostingGroup, string xVATGroup);
    }
    */
    [ServiceContract(Namespace = "http://localhost/NAVSCMIntegrator/Service/NAVRouter.svc")]
    public interface INavInboundCustomers
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                       RequestFormat = WebMessageFormat.Json,
                       ResponseFormat = WebMessageFormat.Json,
                       BodyStyle = WebMessageBodyStyle.Wrapped,
                       UriTemplate = "NAVCustomers")]
        List<NavCustomer> NavCustomers();
        [OperationContract]
        NavCustomer getNavCustomerFiltered(string CustomerCode);
    }
    [ServiceContract(Namespace = "http://localhost/NAVSCMIntegrator/Service/NAVRouter.svc")]
    public interface INavProduct
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                       RequestFormat = WebMessageFormat.Json,
                       ResponseFormat = WebMessageFormat.Json,
                       BodyStyle = WebMessageBodyStyle.Wrapped,
                       UriTemplate = "Products")]
        List <NavProduct> getProductsAll();
        [OperationContract]
        NavProduct getProductFiltered(string productCode);
    }
}
