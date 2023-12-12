using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MahadevEnterprise.Method
{
    public class ProductClass
    {


        public DataTable GetCategory()
        {

            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;

            str = "Select * From Category where IsActive=1";

            dt = objg.GetDatasetByCommand(str);

            return dt;

        }

        public DataTable GetUnit()
        {
            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;

            str = "Select * From UnitMaster";

            dt = objg.GetDatasetByCommand(str);

            return dt;
        }
        public int AddProduct(string ProductName, string Description, int CategoryId, decimal Price, int Quantity, int UnitId)
        {
            General objg = new General();
            string str = string.Empty;
            int Result = 0;
            str = "insert into Product(ProductName,Description,CategoryId,Price,Quantity,UnitId,IsActive) values('" + ProductName + "','" + Description + "','" + CategoryId + "','" + Price + "','" + Quantity + "','" + UnitId + "',1)";
            Result = objg.GetExecuteNonQueryByCommand(str);
            return Result;


        }
        public DataTable GetProduct()
        {

            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;

            str = "select convert(nvarchar(100),Product.Quantity)+''+UnitMaster.UnitName[unitQuantity],*from Product inner join UnitMaster on Product.UnitId=UnitMaster.UnitId inner join Category on Product.CategoryId=Category.CategoryId";

            dt = objg.GetDatasetByCommand(str);
            DataTable dr = new DataTable();

            return dt;

        }

        public DataTable GetProductPrice(int ProductId)
        {
            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;

            str = "select * from product where ProductId='" + ProductId + "'";

            dt = objg.GetDatasetByCommand(str);

            return dt;


        }




    }
}