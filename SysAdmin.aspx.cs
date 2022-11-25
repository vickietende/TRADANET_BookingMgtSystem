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
    public partial class SysAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadRoles();
                loadDepartments();
                loadDestinations();
                loadSections();
                txtDateCreated.Text = DateTime.Today.ToString("dd/MM/yyyy");

            }


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtuserSurname.Text == "")
            {
                string script = "alert(\"Surname is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtuserfname.Text == "")
            {
                string script = "alert(\"First Name is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtuserIDNO.Text == "")
            {
                string script = "alert(\"IDNO is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_Departments.SelectedIndex == 0)
            {
                string script = "alert(\"Department is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_Sections.SelectedIndex == 0)
            {
                string script = "alert(\"Section is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
         
            if (txtusername.Text == "")
            {
                string script = "alert(\"Username is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtpwd.Text == "")
            {
                string script = "alert(\"Password is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }

            if (txtuserEmail.Text == "")
            {
                string script = "alert(\"Email is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
          
            if (ddl_Roles.SelectedIndex == 0)
            {
                string script = "alert(\"Please specify user's Role\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
          


            string md5Pwd = Basic.EncodePassword(txtpwd.Text);
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SaveUsers]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", txtuserfname.Text);
                cmd.Parameters.AddWithValue("@Surname", txtuserSurname.Text);
                cmd.Parameters.AddWithValue("@IDNO", txtuserIDNO.Text);
                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                cmd.Parameters.AddWithValue("@userpwd", md5Pwd);
                cmd.Parameters.AddWithValue("@email", txtuserEmail.Text);
                cmd.Parameters.AddWithValue("@RoleID", ddl_Roles.SelectedValue);
                cmd.Parameters.AddWithValue("@DeptID", ddl_Departments.SelectedValue);
                cmd.Parameters.AddWithValue("@SectionID", ddl_Sections.SelectedValue);
                cmd.Parameters.AddWithValue("@Activate", 1);
                

                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"New User successfully added\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                ClearAll();






            }
            catch (Exception)
            {

            }

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

            if (txtuserSurname.Text == "")
            {
                string script = "alert(\"Surname is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtuserfname.Text == "")
            {
                string script = "alert(\"First Name is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtuserIDNO.Text == "")
            {
                string script = "alert(\"IDNO is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_Departments.SelectedIndex == 0)
            {
                string script = "alert(\"Department is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_Sections.SelectedIndex == 0)
            {
                string script = "alert(\"Section is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
        
            if (txtusername.Text == "")
            {
                string script = "alert(\"Username is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtpwd.Text == "")
            {
                string script = "alert(\"Password is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }

            if (txtuserEmail.Text == "")
            {
                string script = "alert(\"Email is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
           
            if (ddl_Roles.SelectedIndex == 0)
            {
                string script = "alert(\"Please specify user's Role\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
        
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[EditUsers]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtuserfname.Text);
                cmd.Parameters.AddWithValue("@Surname", txtuserSurname.Text);
                cmd.Parameters.AddWithValue("@IDNO", txtuserIDNO.Text);
                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                cmd.Parameters.AddWithValue("@email", txtuserEmail.Text);
                cmd.Parameters.AddWithValue("@RoleID", ddl_Roles.SelectedValue);
                cmd.Parameters.AddWithValue("@DeptID", ddl_Departments.SelectedValue);
                cmd.Parameters.AddWithValue("@SectionID", ddl_Sections.SelectedValue);
                
                

                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"User's Details successfully updated!!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                ClearAll();






            }
            catch (Exception)
            {

            }

        }

        private void loadRoles()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Roles]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddl_AvailableRoles.DataSource = ds.Tables[0];
                            ddl_AvailableRoles.DataTextField = "RoleName";
                            ddl_AvailableRoles.DataValueField = "RoleID";

                            ddl_Roles.DataSource = ds.Tables[0];
                            ddl_Roles.DataTextField = "RoleName";
                            ddl_Roles.DataValueField = "RoleID";

                        }
                        else
                            ddl_AvailableRoles.DataSource = null;


                        ddl_AvailableRoles.DataBind();
                        ddl_Roles.DataBind();

                        ddl_AvailableRoles.Items.Insert(0, "--Select Role--");
                        ddl_Roles.Items.Insert(0, "--Select Role--");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void loadDepartments()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Departments]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddl_AvailableDepts.DataSource = ds.Tables[0];
                            ddl_AvailableDepts.DataTextField = "Department";
                            ddl_AvailableDepts.DataValueField = "DeptCode";

                            ddl_Departments.DataSource = ds.Tables[0];
                            ddl_Departments.DataTextField = "Department";
                            ddl_Departments.DataValueField = "DeptCode";

                        }
                        else
                            ddl_AvailableDepts.DataSource = null;


                        ddl_AvailableDepts.DataBind();
                        ddl_Departments.DataBind();


                        ddl_AvailableDepts.Items.Insert(0, "-Select Department-");
                        ddl_Departments.Items.Insert(0, "-Select Department-");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
      
        private void loadSections()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Sections]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddl_Sections.DataSource = ds.Tables[0];
                            ddl_Sections.DataTextField = "SectionName";
                            ddl_Sections.DataValueField = "SectionID";



                        }
                        else
                            ddl_Sections.DataSource = null;


                        ddl_Sections.DataBind();


                        ddl_Sections.Items.Insert(0, "--Select Section--");


                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void loadDestinations()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Destinations]", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ddl_Destinations.DataSource = ds.Tables[0];
                            ddl_Destinations.DataTextField = "Destination";
                            ddl_Destinations.DataValueField = "ID";



                        }
                        else
                            ddl_Destinations.DataSource = null;


                        ddl_Destinations.DataBind();


                        ddl_Destinations.Items.Insert(0, "--Select Destination--");


                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void ClearAll()
        {
            txtuserSurname.Text = "";
            txtuserfname.Text = "";
            txtuserIDNO.Text = "";
            ddl_Departments.SelectedIndex = 0;
            ddl_Sections.SelectedIndex = 0;
            if (lstSurnames.Visible == true)
            {
                lstSurnames.Visible = false;
            }
            txtusername.Text = "";
            txtpwd.Text = "";
            txtuserEmail.Text = "";
            
            ddl_Roles.SelectedIndex = 0;
            

        }

        protected void btnSearchSurname_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("select UserID, isnull(Surname,'')+' '+isnull(FirstName,'')+' --- '+isnull(convert(varchar,UserID),'')+' --- '+isnull(IDNO,'') as display from[dbo].[tbl_Users]  where isnull(Surname,'')+'---'+isnull(FirstName,'')+' --- '+isnull(convert(varchar,UserID),'')+' --- '+isnull(IDNO,'') like '%" + txtSearchSurname.Text + "%'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cust");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lstSurnames.Visible = true;
                            lstSurnames.DataSource = ds.Tables[0];
                            lstSurnames.DataTextField = "display";
                            lstSurnames.DataValueField = "UserID";
                        }
                        else
                        {
                            lstSurnames.DataSource = null;
                            string script = "alert(\"The searched name was not found!\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }

                        lstSurnames.DataBind();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void lstSurnames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAll();
            getUserDetails(lstSurnames.SelectedValue);

        }
        protected void getUserDetails(string ID)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select  UserID,Surname,FirstName,IDNO, DeptID,SectionID,Username,email,RoleID from [dbo].[tbl_Users] where UserID='" + ID + "'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtUserID.Text = dt.Rows[0]["UserID"].ToString();
                            txtuserSurname.Text = dt.Rows[0]["Surname"].ToString();
                            txtuserfname.Text = dt.Rows[0]["FirstName"].ToString();
                            txtuserIDNO.Text = dt.Rows[0]["IDNO"].ToString();
                            ddl_Departments.SelectedValue = dt.Rows[0]["DeptID"].ToString();
                            ddl_Sections.SelectedValue = dt.Rows[0]["SectionID"].ToString();
                            txtusername.Text = dt.Rows[0]["Username"].ToString();
                            txtpwd.Text = "";
                            txtuserEmail.Text = dt.Rows[0]["email"].ToString();
                            ddl_Roles.SelectedValue = dt.Rows[0]["RoleID"].ToString();
                            


                        }
                        else
                        {
                            string script = "alert(\"User record not found!\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }


        }

        protected void btnLock_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update tbl_Users set Activate=0 where UserID='" + txtUserID.Text + "'", con);


                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"User successfully locked!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                ClearAll();


            }
            catch (Exception)
            {

            }
        }

        protected void btnUnlockUser_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update tbl_Users set Activate=1 where UserID='" + txtUserID.Text + "'", con);


                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"User is successfully unlocked!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                ClearAll();

            }
            catch (Exception)
            {

            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveRoles]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Role", txtNewRole.Text);


             
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Role details successfully saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                txtNewRole.Text = "";
                loadRoles();

            }
            catch (Exception)
            {

            }
        }
        private void ClearAllOnRoles()
        {
            txtNewRole.Text = "";
            txtRoleID.Text = "";
            txtSearchUsers.Text = "";
            txtUserIDonRoles.Text = "";
            txtUsernameOnRoles.Text = "";
            txtUserIDNOonRoles.Text = "";
            ddl_AvailableRoles.SelectedIndex = 0;
            lstUsersOnRoles.Visible = false;
        }

        protected void btnSearchUserforRoles_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("select UserID, isnull(Surname,'')+' '+isnull(FirstName,'')+' --- '+isnull(convert(varchar,UserID),'')+' --- '+isnull(IDNO,'') as display from[dbo].[tbl_Users]  where isnull(Surname,'')+'---'+isnull(FirstName,'')+' --- '+isnull(convert(varchar,UserID),'')+' --- '+isnull(IDNO,'') like '%" + txtSearchUsers.Text + "%'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cust");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lstUsersOnRoles.Visible = true;
                            lstUsersOnRoles.DataSource = ds.Tables[0];
                            lstUsersOnRoles.DataTextField = "display";
                            lstUsersOnRoles.DataValueField = "UserID";
                        }
                        else
                        {
                            lstUsersOnRoles.DataSource = null;
                            string script = "alert(\"The searched name was not found\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }

                        lstUsersOnRoles.DataBind();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void lstUsersOnRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllOnRoles();
            getmyUserDetailsforRoles(lstUsersOnRoles.SelectedValue);
        }
        protected void getmyUserDetailsforRoles(string userID)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select  UserID, Surname, FirstName,IDNO, DeptID,SectionID,Username,userpwd,email,RoleID, from [dbo].[tbl_Users] where UserID='" + userID + "'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtUserID.Text = dt.Rows[0]["UserID"].ToString();

                            txtRoleID.Text = dt.Rows[0]["RoleID"].ToString();

                            txtUserIDonRoles.Text = dt.Rows[0]["UserID"].ToString();
                            txtUsernameOnRoles.Text = dt.Rows[0]["Surname"].ToString();
                            txtUserIDNOonRoles.Text = dt.Rows[0]["IDNO"].ToString();
                            ddl_AvailableRoles.SelectedValue = dt.Rows[0]["RoleID"].ToString();


                        }
                        else
                        {
                            string script = "alert(\"User record not found\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }

                    }
                }
            }
            catch (Exception)
            {

            }

        }

        protected void ddl_AvailableRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoleID.Text = ddl_AvailableRoles.SelectedValue;
        }

        protected void btnAssignRole_Click(object sender, EventArgs e)
        {
            if (txtUserIDonRoles.Text == "")
            {
                string script = "alert(\"Select a user\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update [dbo].[tbl_Users] set [RoleID]='" + ddl_AvailableRoles.SelectedValue + "' where UserID='" + txtUserIDonRoles.Text + "'", con);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"User role successfully assigned\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                ClearAllOnRoles();

            }
            catch (Exception)
            {

            }
        }

        protected void btnAddDept_Click(object sender, EventArgs e)
        {
            if (txtDept.Text == "")
            {
                string script = "alert(\"Provide name\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveDepartment]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Department", txtDept.Text);


               
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Dept successfully saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                txtDept.Text = "";
                loadDepartments();

            }
            catch (Exception)
            {

            }
        }

   

        protected void ddl_AvailableDepts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from [dbo].[tbl_Department]", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtDeptID.Text = dt.Rows[0]["ID"].ToString();

                        }
                        else
                        {
                            string script = "alert(\"Record not found\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);

                        }

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnAddBranch_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnAddSection_Click(object sender, EventArgs e)
        {
            if (txtSection.Text == "")
            {
                string script = "alert(\"Enter New Section name\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_AvailableDepts.SelectedIndex == 0)
            {
                string script = "alert(\"Specify the Dept of the new section\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveSection]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SectionName", txtSection.Text);
                cmd.Parameters.AddWithValue("@DeptID", ddl_AvailableDepts.SelectedValue);


             
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Section details successfully saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                txtSection.Text = "";
                ddl_AvailableDepts.SelectedIndex = 0;


            }
            catch (Exception)
            {

            }

        }

        protected void btnAddService_Click(object sender, EventArgs e)
        {
            if (txtSection.Text == "")
            {
                string script = "alert(\"Enter new Section name\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveService]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Service", txtSection.Text);


                cmd.Parameters.AddWithValue("@Budget", txtBudget.Text);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Section details successully saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();
                


            }
            catch (Exception)
            {

            }

        }

        protected void btnAddServiceProvider_Click(object sender, EventArgs e)
        {
            if (txtProviderName.Text == "")
            {
                string script = "alert(\"Service Provider name is Required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (txtProviderEmail.Text == "")
            {
                string script = "alert(\"Email is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            if (ddl_Destinations.SelectedIndex==0)
            {
                string script = "alert(\"Destination is required\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveServiceProvider]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", txtProviderName.Text);
                cmd.Parameters.AddWithValue("@Email", txtProviderEmail.Text);
                cmd.Parameters.AddWithValue("@Contact", txtPhone.Text);
                cmd.Parameters.AddWithValue("@DestinationID", ddl_Destinations.SelectedValue);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Service Provider successully saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();



            }
            catch (Exception)
            {

            }

        }

        protected void btnAddDestination_Click(object sender, EventArgs e)
        {
            if (txtDestination.Text == "")
            {
                string script = "alert(\"Enter new Destination name\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveDestination]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Destination", txtSection.Text);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }

                cmd.ExecuteNonQuery();

                string script = "alert(\"Destination successully saved\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                con.Close();



            }
            catch (Exception)
            {

            }

        }
    }
}