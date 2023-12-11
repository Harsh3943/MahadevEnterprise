using MahadevEnterprise.DATA;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;

namespace MahadevEnterprise.Method
{
    public class OrderClass
    {
        public int AddCustomerOrdor( string FirstName, string LastName, string Email ,string Mobile , string Address,int  ProductId , int Quantity, decimal TotalPrice)
        {

            General_New objg = new General_New();
            int Result = 0;

            NameValueCollection nv = new NameValueCollection();
            nv.Add("@FirstName",FirstName);
            nv.Add("@LastName",LastName);
            nv.Add("@Email", Email);
            nv.Add("@Mobile", Mobile);
            nv.Add("@Address",Address);
            nv.Add("@ProductId",ProductId.ToString());
            nv.Add("@Quantity",Quantity.ToString());
            nv.Add("@TotalPrice",TotalPrice.ToString());

            Result = objg.GetDataInsertORUpdate("SP_SETOrdorCustomer", nv);
            return Result;

        }

        public DataTable GetOrdor()
        {
            DataTable dt = new DataTable();
            string str = string.Empty;
            General_New objg= new General_New();
            NameValueCollection nv = new NameValueCollection();
            dt = objg.GetDataTable("SP_GETOrdorCustomer", nv);

            return dt;

        }

        public DataTable BindTax(int ProductId)
        {

            DataTable dt = new DataTable();
            string str = string.Empty;
            General objg=new General();

            str = "select Product.Price*OrderMaster.Quantity[tPrice],Product.ProductId from OrderMaster inner join Product on OrderMaster.ProductId=Product.ProductId where Product.ProductId='"+ProductId+"'";

            dt = objg.GetDatasetByCommand(str);
            return dt;
        }

        public int AddInvoice(int id, int pid)
        {


            General_New objg = new General_New();
            int Result = 0;

            NameValueCollection nv = new NameValueCollection();
            nv.Add("@Id", id.ToString());
            nv.Add("@Pid", pid.ToString());
           

            Result = objg.GetDataInsertORUpdate("SET_InvoiceDetail", nv);
            return Result;

        }

        public DataTable GetInvoice(int OrderId)
        {

            General_New objg = new General_New();
            DataTable dt=new DataTable();

            NameValueCollection nv = new NameValueCollection();
            nv.Add("@OrderId", OrderId.ToString());
           
            dt = objg.GetDataTable("GET_invoiceData", nv);
            return dt;

        }
    }
}