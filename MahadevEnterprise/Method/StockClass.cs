using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MahadevEnterprise.Method
{
    public class StockClass
    {

        public DataTable GetStock()
        {
            General_New objg = new General_New();
            DataTable dt = new DataTable();

            NameValueCollection nv=new NameValueCollection();

            dt = objg.GetDataTable("SP_GETStock", nv);

            return dt;

        }

        public DataTable GetProduct() 
        {
            General_New objg = new General_New();
            DataTable dt = new DataTable();


            NameValueCollection nv = new NameValueCollection();

            dt = objg.GetDataTable("SP_GetProduct", nv);

            return dt;


        }

        public DataTable GetSupplier()
        {
            General_New objg = new General_New();
            DataTable dt = new DataTable();


            NameValueCollection nv = new NameValueCollection();

            dt = objg.GetDataTable("SP_GetSupplier", nv);

            return dt;


        }

        public DataTable GetUnit()
        {
            General_New objg = new General_New();
            DataTable dt = new DataTable();


            NameValueCollection nv = new NameValueCollection();

            dt = objg.GetDataTable("SP_GetUnit", nv);

            return dt;


        }

        public int SETStock( int ProductId , int SupplierId, int StockQuantity, int UnitId)
        {

            General_New objg= new General_New();
            int Result = 0;

            NameValueCollection nv= new NameValueCollection();
            
            nv.Add("@ProductId", ProductId.ToString());
            nv.Add("@SupplierId", SupplierId.ToString());
            nv.Add("@StockQuantity", StockQuantity.ToString());
            nv.Add("@UnitId", UnitId.ToString());

            Result = objg.GetDataInsertORUpdate("SP_SETStock", nv);

            return Result;



        }

        public DataTable getStockQuntity()
        {
            General objg=new General();
            DataTable dt = new DataTable();
            string str = string.Empty;
            str = "select ProductId,sum(StockQuantity)[SQ] from StockMaster group by ProductId";
            dt = objg.GetDatasetByCommand(str);
            return dt;

        }
        public DataTable getOrderQuntity()
        {
            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;
            str = "select ProductId,sum(Quantity)[OQ] from OrderMaster group by ProductId";
            dt = objg.GetDatasetByCommand(str);
            return dt;

        }

    }
}