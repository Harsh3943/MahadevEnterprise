using MahadevEnterprise.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MahadevEnterprise
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCategory();
                BindUnit();
                GridShowProduct();
            }
        }
        public void BindCategory()
        {
            ProductClass objp = new ProductClass();
            DataTable dt = new DataTable();
            dt=objp.GetCategory();

            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField="CategoryName";
            ddlCategory.DataValueField="CategoryId";
            ddlCategory.DataBind();


        }
        public void BindUnit()
        {
            ProductClass objp = new ProductClass();
            DataTable dt = new DataTable();
            dt = objp.GetUnit();

            ddlUnit.DataSource = dt;
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataValueField = "UnitId";
            ddlUnit.DataBind();


        }

        public void InsertCategory()
        {
            ProductClass objp = new ProductClass();
            int Result = 0;
            Result = objp.AddProduct(txtProductName.Text, txtDescription.Text, Convert.ToInt32(ddlCategory.SelectedItem.Value), Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(txtQuantity.Text), Convert.ToInt32(ddlUnit.SelectedItem.Value));


        }
        public  void GridShowProduct()
        {
            ProductClass objp = new ProductClass();
            DataTable dt = new DataTable();
            dt = objp.GetProduct();

            GridProduct.DataSource = dt;
            GridProduct.DataBind();

        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ListPanel.Visible = false;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            InsertCategory();
        }
    }
}