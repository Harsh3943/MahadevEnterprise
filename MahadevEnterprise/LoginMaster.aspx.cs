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
    public partial class LoginMaster : System.Web.UI.Page
    {
        LoginClass objl=new LoginClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetLoginDetail()
        {

            DataTable dt= new DataTable();

            dt = objl.GetLogin(txtUserName.Text, txtPassword.Text);

            if (dt != null && dt.Rows.Count > 0)
            {

                int Roleid = Convert.ToInt32(dt.Rows[0]["RoleId"]);

                if (Roleid == 1)
                {
                    Response.Redirect("Category.aspx");
                }
            }
            else
            {
                lblmessage.Text = "Username or Password Inccorect";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            GetLoginDetail();
        }
    }
}