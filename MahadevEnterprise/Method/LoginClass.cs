using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;

namespace MahadevEnterprise.Method
{
    
    public class LoginClass
    {
        General_New objg=new General_New();


        public DataTable GetLogin(string username , string password)
        {
            DataTable dt = new DataTable();

            NameValueCollection nv=new NameValueCollection();
            nv.Add("@UserName", username);
            nv.Add("@Password", password);

            dt = objg.GetDataTable("Get_Login", nv);

            return dt;
        }

    }
}