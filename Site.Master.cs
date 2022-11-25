using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TRADANET_BookingMgtSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx", true);
                }
                else
                {
                    string username = Session["Username"].ToString();
                    string role = Session["RoleID"].ToString();
                    string userid = Session["UserId"].ToString();
                    string DeptName = Session["DeptName"].ToString();
                    lblDept.Text = Session["DeptName"].ToString();
                    lblUserName.Text = Session["Username"].ToString();

                }

            }
        }
    }
}