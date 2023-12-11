using MahadevEnterprise.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MahadevEnterprise
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowGridCategory();
            }
        }

        public void InsertCategory()
        {
            CategoryClass objc = new CategoryClass();
            int Result = 0;

            Result = objc.AddCategory(txtCategoryName.Text, txtDetail.Text);

        }

        public void ShowGridCategory()
        {
            DataTable dt = new DataTable();
            CategoryClass objc = new CategoryClass();
            dt = objc.GetCategories();

            GridCategory.DataSource = dt;
            GridCategory.DataBind();


        }
        private long CategoryId
        {
            get
            {
                if (ViewState["CategoryId"] != null)
                {
                    return (long)ViewState["CategoryId"];
                }
                return 0;

            }
            set
            {
                ViewState["CategoryId"] = value;
            }
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

        protected void GridCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int CategoryID = 0;
            CategoryID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "CategoryDelete")
            {
                CategoryClass objc = new CategoryClass();
                int Result = 0;
                Result = objc.DeleteCategory(CategoryID);
                ShowGridCategory();

            }
            
        }
    }
}