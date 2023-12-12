﻿using MahadevEnterprise.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MahadevEnterprise
{
    public partial class Employee : System.Web.UI.Page
    {
        EmployeeClass obje=new EmployeeClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ListPanel.Visible = false;
        }

        public void AddEmployee()
        {
            int Result = 0;
            Result=obje.AddEmployee(txtFullName.Text, txtEmail.Text, txtMobile.Text, txtAddress.Text, Convert.ToInt32(ddlDepartment.SelectedItem.Value), txtQualification.Text);


        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }
    }
}