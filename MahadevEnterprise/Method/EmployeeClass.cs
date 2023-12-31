﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MahadevEnterprise.Method
{
    public class EmployeeClass
    {
        General_New objg=new General_New();
        public int AddEmployee(string Fullname,string Emailid,string Mobile,string Address,int Dep , string Qualification)
        {
            int Result = 0;

            NameValueCollection nv= new NameValueCollection();
            nv.Add("@FullName",Fullname);
            nv.Add("@EmailId",Emailid);
            nv.Add("@MobileNo",Mobile);
            nv.Add("@Address",Address);
            nv.Add("@DepartmentId",Dep.ToString());
            nv.Add("@Qualification",Qualification);


            Result = objg.GetDataInsertORUpdate("Set_Employee", nv);


            return Result;


        }

        public DataTable GetDepartment()
        {
            
            DataTable dt = new DataTable();

            NameValueCollection nv = new NameValueCollection();
            

            dt = objg.GetDataTable("Get_Department", nv);


            return dt;


        }


    }
}