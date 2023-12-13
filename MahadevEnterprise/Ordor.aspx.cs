using MahadevEnterprise.DATA;
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
    public partial class Ordor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindProduct();
                GridShowOrdor();
                //texBind();
            }
        }

        public void BindProduct()
        {
            DataTable dt = new DataTable();
            StockClass objstock = new StockClass();

            dt = objstock.GetProduct();

            ddlProduct.DataSource = dt;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "ProductId";
            ddlProduct.DataBind();


        }
        public void GridShowOrdor()
        {
            DataTable dt= new DataTable();
            OrderClass objc= new OrderClass();
            dt=objc.GetOrdor();

            GridOrdor.DataSource= dt;
            GridOrdor.DataBind();


        }
        //public void texBind()
        //{
        //    DataTable dt = new DataTable();
        //    OrderClass objc = new OrderClass();
        //    dt = objc.BindTax(Convert.ToInt32(ddlProduct.SelectedItem.Value));

        //    txtTotalPrice.Text = dt.Rows[0]["tPrice"].ToString();

        //}
        public void insertOrdorCustomer()
        {

            OrderClass objo = new OrderClass();
            int Result = 0;

            Result = objo.AddCustomerOrdor(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtMobile.Text, txtAddress.Text, Convert.ToInt32(ddlProduct.SelectedItem.Value), Convert.ToInt32(txtQuantity.Text), Convert.ToDecimal(txtTotalPrice.Text));


        }

        public void Cal()
        {
            ProductClass objp= new ProductClass();
            DataTable dt= new DataTable();

            dt=objp.GetProductPrice(Convert.ToInt32(ddlProduct.SelectedItem.Value));

            decimal price = Convert.ToDecimal(dt.Rows[0]["Price"]);
            int Quatity = 0;
            Quatity = Convert.ToInt32(txtQuantity.Text);


            decimal TotalPrice = price * Quatity;

            txtTotalPrice.Text=TotalPrice.ToString();



        }

        private long OrderID
        {
            get
            {
                if (ViewState["OrderId"] != null)
                {
                    return (long)ViewState["OrderId"];
                }
                return 0;

            }
            set
            {
                ViewState["OrderId"] = value;
            }


        }


        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ListPanel.Visible = false;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            insertOrdorCustomer();
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            Cal();
        }

        protected void txtTotalPrice_DataBinding(object sender, EventArgs e)
        {
            Cal();
        }

        protected void GridOrdor_RowCommand(object sender, GridViewCommandEventArgs e)
        {







            if (e.CommandName == "CategoryEdit")
            {
                OrderID= Convert.ToInt32(e.CommandArgument);
                Response.Redirect("InvoiceGenerate.aspx?OrderId=" + OrderID + " ");

            }
        }
    }
}