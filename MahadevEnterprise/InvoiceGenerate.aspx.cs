using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System;
using System.IO;
using MahadevEnterprise.Method;
using System.Data;

namespace MahadevEnterprise
{
    public partial class InvoiceGenerate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOrderId.Text = Request.QueryString["OrderId"];
            BindInvoice();
        }

        public void BindInvoice()
        {
            OrderClass objo= new OrderClass();  
            DataTable dt= new DataTable();


            dt = objo.GetInvoice(Convert.ToInt32(lblOrderId.Text));

            if (dt != null && dt.Rows.Count > 0)
            {
                lblQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                lblProductName.Text = dt.Rows[0]["ProductName"].ToString();
                Labelid.Text = dt.Rows[0]["ProductId"].ToString();
                lblDescription.Text= dt.Rows[0]["Description"].ToString();
                lblSubTotal.Text= dt.Rows[0]["TotalPrice"].ToString();
                lblInvoiceId.Text= dt.Rows[0]["InvoiceId"].ToString();
                lblCoustumerId.Text= dt.Rows[0]["CustomerId"].ToString();
                lblSubtotalLower.Text = dt.Rows[0]["TotalPrice"].ToString();
                lblTax.Text= dt.Rows[0]["TAX"].ToString();
                lblGst.Text= dt.Rows[0]["GST"].ToString();
                lblCGST.Text= dt.Rows[0]["CGST"].ToString();
                lblTotal.Text= dt.Rows[0]["TotalAmount"].ToString();
                lbldate.Text = DateTime.Now.ToString();
                lblName.Text= dt.Rows[0]["FirstName"].ToString();
                lblAdress.Text= dt.Rows[0]["Address"].ToString();
                lblMobileNumber.Text = dt.Rows[0]["Mobile"].ToString();
                lblEmail.Text = dt.Rows[0]["Email"].ToString();
            }
        }
        
    }
}