using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TRADANET_BookingMgtSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string md5Pwd = Basic.EncodePassword(txtpwd.Value);
                //string md5Pwd = "";
                string username = txtUserName.Value;
                string userid = "";
                string userrole = "";
                string DeptName = "";
              
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select UserID,Username,userpwd,RoleID,DeptID,td.Department from tbl_Users tu left join tbl_Departments td ON tu.DeptID=td.DeptCode   where Username='" + username + "' and userpwd='" + md5Pwd + "' and [Activate]=1", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            userid = dt.Rows[0]["UserID"].ToString();
                            userrole = dt.Rows[0]["RoleID"].ToString();
                            DeptName = dt.Rows[0]["Department"].ToString();
                         
                            Session["UserId"] = userid;
                            Session["RoleID"] = userrole;
                            Session["Username"] = username;
                            Session["DeptName"] = DeptName;
                          

                            Response.Redirect("Home.aspx", true);

                        }
                        else
                        {
                            InvalidCredentials.Visible = true;
                        }




                    }
                }


            }
            catch (Exception ex)
            {
                InvalidCredentials.Visible = true;
                InvalidCredentials.Text = ex.Message;
            }

        }
    }
}