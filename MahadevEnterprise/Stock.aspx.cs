using MahadevEnterprise.DATA;
using MahadevEnterprise.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MahadevEnterprise
{
    public partial class Stock : System.Web.UI.Page
    {
        MahadevEnterpriseEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                GridShowStock();
                BindProduct();
                BindSupplier();
                BindUnit();
            }
            
        }

        public void GridShowStock()
        {

            DataTable dt = new DataTable();
            StockClass objstock = new StockClass();

            dt = objstock.GetStock();

            GridStock.DataSource = dt;
            GridStock.DataBind();


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

        public void BindSupplier()
        {

            DataTable dt = new DataTable();
            StockClass objstock = new StockClass();

            dt = objstock.GetSupplier();

            ddlSupplier.DataSource = dt;
            ddlSupplier.DataTextField = "CompanyName";
            ddlSupplier.DataValueField = "SupplierId";
            ddlSupplier.DataBind();


        }

        public void BindUnit()
        {

            DataTable dt = new DataTable();
            StockClass objstock = new StockClass();

            dt = objstock.GetUnit();

            ddlUnit.DataSource = dt;
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataValueField = "UnitId";
            ddlUnit.DataBind();

        }

        public void InsertStock()
        {
            int Result = 0;
            StockClass objstock = new StockClass();

            Result = objstock.SETStock(Convert.ToInt32(ddlProduct.SelectedItem.Value), Convert.ToInt32(ddlSupplier.SelectedItem.Value), Convert.ToInt32(txtQuantity.Text), Convert.ToInt32(ddlUnit.SelectedItem.Value));


        }
       
        public void Cal()
        {
            DataTable dt = new DataTable();
            DataTable drs = new DataTable();
            StockClass objs = new StockClass();
            dt = objs.GetStock();
            drs = objs.getOrderQuntity();

            for (int i = 0; i < GridStock.Rows.Count; i++)
            {
                GridViewRow row = GridStock.Rows[i];
                if (row.RowType == DataControlRowType.DataRow)

                {
                    // Get the corresponding rows in dt and drs
                    DataRow dtRow = dt.Rows[i];

                    // Check if drs has a corresponding row for the current index
                    DataRow drsRow = i < drs.Rows.Count ? drs.Rows[i] : null;

                    decimal SQ = Convert.ToDecimal(dtRow["SQ"]);
                    string UN = dtRow["UnitName"].ToString();
                    decimal P= Convert.ToDecimal(dtRow["Price"]);
                    decimal OQ = drsRow != null ? Convert.ToDecimal(drsRow["OQ"]) : 0;
                    string TQ = (SQ - OQ)+UN;
                   decimal TP= (SQ - OQ)*P; 
                    Label lblTS = row.FindControl("lblTS") as Label;
                    if (lblTS != null)
                    {
                        lblTS.Text = TQ.ToString();
                    }
                    Label lblTP = row.FindControl("lblTP") as Label;
                    if (lblTP != null)
                    {
                        lblTP.Text = TP.ToString()+"₹";
                    }
                }
            }
        }
       

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            InsertStock();
        }

        protected void GridStock_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Cal();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ListPanel.Visible = false;
        }
    }
}