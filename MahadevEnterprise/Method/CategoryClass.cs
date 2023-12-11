using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MahadevEnterprise;

namespace MahadevEnterprise.Method
{

    public class CategoryClass
    {

        General objg = new General();
        string str = string.Empty;
        DataTable dt = new DataTable();
        int Result = 0;
        public int AddCategory(string CategoryName, string Detail)
        {
            General objg = new General();
            string str = string.Empty;
            int Result = 0;

            str = "insert into Category(CategoryName,Detail,IsActive) values('" + CategoryName + "','" + Detail + "',1)";

            Result = objg.GetExecuteNonQueryByCommand(str);

            return Result;
        }

        public DataTable GetCategories()
        {
            str = "select * from Category where IsActive=1";
            dt = objg.GetDatasetByCommand(str);
            return dt;

        }

        public int DeleteCategory(int CategoryId)
        {

            str = "update Category set IsActive =0 where  CategoryId='" + CategoryId + "'";
            Result = objg.GetExecuteNonQueryByCommand(str);

            return Result;

        }
        public int UpdateAndInsertCategory(int CategoryId, string CategoryName, string Detail)
        {
            if (CategoryId == 0)
            {
                str = "insert into Category(CategoryName,Detail,IsActive) values('" + CategoryName + "','" + Detail + "',1)";

            }
            else
            {
                str = "update Category set CategoryName='"+ CategoryName + "',Detail='"+ Detail + "' where  CategoryId='" + CategoryId + "'";
            }
            Result = objg.GetExecuteNonQueryByCommand(str);
            return Result;
        }
        public int EditCategory(string CategoryName,string Detail,int CategoryId)
        {
            str = "update Category set CategoryName='" + CategoryName + "',Detail='" + Detail + "' where  CategoryId='" + CategoryId + "'";
            Result=objg.GetExecuteNonQueryByCommand(str); 
            return Result;

        }
    }
}