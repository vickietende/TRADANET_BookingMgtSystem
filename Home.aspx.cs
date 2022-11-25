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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                txtDateCreated.Text = DateTime.Today.ToString("dd/MM/yyyy");
                loadDepartments();
                loadSections();
                loadDestinations();
                loadServices();
                loadServiceProviders();
                generateReferenceNumber();
                loadApprovals(Session["UserId"].ToString());
                loadUserDetails(Session["UserId"].ToString());
            }

        }
        private void loadDepartments()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from tbl_Departments", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            ddl_Departments.DataSource = ds.Tables[0];
                            ddl_Departments.DataTextField = "Department";
                            ddl_Departments.DataValueField = "DeptCode";

                        }
                        else
                        {
                            ddl_Departments.DataSource = null;

                        }

                        ddl_Departments.DataBind();
                        ddl_Departments.Items.Insert(0, "-- Select Department --");

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
                    using (var cmd = new SqlCommand("Select * from tbl_Sections", con))
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
                        {
                            ddl_Sections.DataSource = null;

                        }

                        ddl_Sections.DataBind();
                        ddl_Sections.Items.Insert(0, "-- Select Section --");

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
                    using (var cmd = new SqlCommand("Select * from tbl_Destinations", con))
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
                        {
                            ddl_Destinations.DataSource = null;

                        }

                        ddl_Destinations.DataBind();
                        ddl_Destinations.Items.Insert(0, "-- Select Destination --");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void loadServices()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from tbl_Services", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            ddl_Services.DataSource = ds.Tables[0];
                            ddl_Services.DataTextField = "Service";
                            ddl_Services.DataValueField = "ServiceID";

                        }
                        else
                        {
                            ddl_Services.DataSource = null;

                        }

                        ddl_Services.DataBind();
                        ddl_Services.Items.Insert(0, "-- Select a Service --");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void loadServiceProviders()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from tbl_ServiceProviders", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            ddl_ServiceProvider.DataSource = ds.Tables[0];
                            ddl_ServiceProvider.DataTextField = "Name";
                            ddl_ServiceProvider.DataValueField = "Email";

                        }
                        else
                        {
                            ddl_ServiceProvider.DataSource = null;

                        }

                        ddl_ServiceProvider.DataBind();
                        ddl_ServiceProvider.Items.Insert(0, "-- Select Service Provider --");

                    }
                }
            }
            catch (Exception)
            {

            }

        }
        private void filterServiceProviders(string id)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select * from tbl_ServiceProviders where DestinationID='"+ id +"'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cou");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            ddl_ServiceProvider.DataSource = ds.Tables[0];
                            ddl_ServiceProvider.DataTextField = "Name";
                            ddl_ServiceProvider.DataValueField = "ID";

                        }
                        else
                        {
                            ddl_ServiceProvider.DataSource = null;

                        }

                        ddl_ServiceProvider.DataBind();
                        ddl_ServiceProvider.Items.Insert(0, "-- Select Service Provider --");

                    }
                }
            }
            catch (Exception)
            {

            }

        }

        protected void ddl_Destinations_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterServiceProviders(ddl_Destinations.SelectedValue);
        }

        protected void ddl_ServiceProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtProviderEmail.Text= getProviderEmail(ddl_ServiceProvider.SelectedValue).ToString();  
        }
        private string getProviderEmail(string id)
        {
            string email = "";
           
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select Email from [dbo].[tbl_ServiceProviders] where ID='" + id + "'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                             email = dt.Rows[0]["Email"].ToString();

                            return email;

                        }
                        else
                        {
                            string script = "alert(\"Error:404- User not found\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);

                        }
                    return email;
                }
                }
            
         
            
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("select UserID, isnull(FirstName,'')+' '+isnull(Surname,'')+' '+isnull(IDNO,'') as display from [dbo].[tbl_Users] where isnull(FirstName,'')+' '+isnull(Surname,'')+' '+isnull(IDNO,'') like '%" + txtSearchUser.Text + "%'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cust");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lstUsers.Visible = true;
                            lstUsers.DataSource = ds.Tables[0];
                            lstUsers.DataTextField = "display";
                            lstUsers.DataValueField = "UserID";
                        }
                        else
                        {
                            lstUsers.DataSource = null;
                            string script = "alert(\"Error:404- The searched name was not found\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }

                        lstUsers.DataBind();
                    }
                }
            }
            catch (Exception)
            {
            }

        }
        private void loadUserDetails(string userid)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select UserID,FirstName,Surname,email,Username,DeptID,SectionID,RoleID from tbl_Users where UserID='" + userid + "'", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {

                            txtUserID.Text = dt.Rows[0]["UserID"].ToString();
                            txtFName.Text = dt.Rows[0]["FirstName"].ToString();
                            txtSurname.Text = dt.Rows[0]["Surname"].ToString();
                            ddl_Departments.SelectedValue = dt.Rows[0]["DeptID"].ToString();
                            ddl_Sections.SelectedValue = dt.Rows[0]["SectionID"].ToString();
                            txtUserEmail.Text= dt.Rows[0]["email"].ToString();
                        


                        }
                        else
                        {
                            string script = "alert(\"Error:404- User not found\");";
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
        private void loadReferenceDetails(string id)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select Reference,u.FirstName,u.Surname,u.email,u.DeptID,u.SectionID,rq.DestinationID,convert(varchar,rq.StartDate,103)StartDate,convert(varchar,rq.EndDate,103)EndDate,rq.Duration,rq.ServiceID,rq.ServiceProviderID,sp.Name,u.UserID,convert(varchar,rq.DateCreated,103)DateCreated,rq.TotalHours,sp.Email ProviderEmail from tbl_RequestQuotations rq left join tbl_Users u ON rq.UserID=u.UserID left join tbl_ServiceProviders sp ON rq.ServiceProviderID=sp.ID where rq.Reference='" + id + "' ", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtReference.Text= dt.Rows[0]["Reference"].ToString();
                            txtDateCreated.Text= dt.Rows[0]["DateCreated"].ToString();
                            txtUserID.Text = dt.Rows[0]["UserID"].ToString();
                            txtFName.Text = dt.Rows[0]["FirstName"].ToString();
                            txtSurname.Text = dt.Rows[0]["Surname"].ToString();
                            ddl_Departments.SelectedValue = dt.Rows[0]["DeptID"].ToString();
                            ddl_Sections.SelectedValue = dt.Rows[0]["SectionID"].ToString();
                            txtUserEmail.Text = dt.Rows[0]["email"].ToString();
                            ddl_Destinations.SelectedValue= dt.Rows[0]["DestinationID"].ToString();
                            ddl_Services.SelectedValue= dt.Rows[0]["ServiceID"].ToString();
                            txtStartDate.Text= dt.Rows[0]["StartDate"].ToString();
                            txtEndDate.Text= dt.Rows[0]["EndDate"].ToString();
                            txtTotalDays.Text= dt.Rows[0]["Duration"].ToString();
                            txtTotalHours.Text= dt.Rows[0]["TotalHours"].ToString();
                            ddl_ServiceProvider.SelectedItem.Text= dt.Rows[0]["Name"].ToString();
                            txtProviderEmail.Text= dt.Rows[0]["ProviderEmail"].ToString();


                        }
                        else
                        {
                            string script = "alert(\"Error:404- User not found\");";
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
        protected void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUserDetails(lstUsers.SelectedValue);
        }
        private void generateReferenceNumber()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_GenerateReference]", con);
                cmd.CommandType = CommandType.StoredProcedure;
           
                DataTable dt = new DataTable();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    string reference= dt.Rows[0]["Reference"].ToString();
                    txtReference.Text=reference;
                }

            }
            catch (Exception)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtReference.Text == "")
            {
                msgbox("Reference is Required");
                return;
            }
        
            try
            {
                DateTime DateCreated = DateTime.ParseExact(txtDateCreated.Text, "dd/MM/yyyy", null);
                DateCreated = Convert.ToDateTime(DateCreated, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                DateTime StartDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", null);
                StartDate = Convert.ToDateTime(StartDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                DateTime EndDate = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", null);
                EndDate = Convert.ToDateTime(EndDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_SaveQuotationRequest]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Reference", txtReference.Text);
                cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(txtUserID.Text));
                cmd.Parameters.AddWithValue("@DestinationID",Convert.ToInt32(ddl_Destinations.SelectedValue));
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                cmd.Parameters.AddWithValue("@Duration",Convert.ToInt32(txtTotalDays.Text));
                cmd.Parameters.AddWithValue("@TotalHours", txtTotalHours.Text);
                cmd.Parameters.AddWithValue("@ServiceID", Convert.ToInt32(ddl_Services.SelectedValue));
                cmd.Parameters.AddWithValue("@ServiceProviderID", ddl_ServiceProvider.SelectedValue);
                cmd.Parameters.AddWithValue("@AmountRequired", txtAmount.Text);
                cmd.Parameters.AddWithValue("@Status", 0);
                cmd.Parameters.AddWithValue("@Budget", txtBudget.Text);
                cmd.Parameters.AddWithValue("@SendTo", "101");
                cmd.Parameters.AddWithValue("@Authorize", "Pending");
                cmd.Parameters.AddWithValue("@DateCreated", DateCreated);
                cmd.ExecuteNonQuery();
               
                    msgbox("Request for Quotation sent successfully");
                    ClearAll();
               
            

            }
            catch (Exception ex)
            {
                msgbox(ex.Message); 
            }

        }
        private void ClearAll()
        {
            txtFName.Text = "";
            txtUserID.Text = "";
            txtSurname.Text = "";
            ddl_Departments.SelectedIndex = 0;
            ddl_Sections.SelectedIndex = 0;
            ddl_Destinations.SelectedIndex = 0;
            ddl_Services.SelectedIndex = 0;
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            txtTotalDays.Text = "";
            txtTotalHours.Text = "";
            ddl_ServiceProvider.SelectedIndex = 0;
            txtProviderEmail.Text = "";
            txtUserEmail.Text = "";
            if (lstUsers.Visible == true)
            {
                lstUsers.Visible=false;
                lstUsers.DataSource = null;
            }
            if (lstReferences.Visible == true)
            {
                lstReferences.Visible = false;
                lstReferences.DataSource = null;
            }

        }

        public void msgbox(string strMessage)
        {
            // finishes server processing, returns to client.
            string strScript = "<script language=JavaScript>";
            strScript += "window.alert(\"" + strMessage + "\");";
            strScript += "</script>";
            System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
            lbl.Text = strScript;
            Page.Controls.Add(lbl);
        }

        protected void lstReferences_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadReferenceDetails(lstReferences.SelectedItem.Text);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select ID, Reference,UserID,DestinationID,StartDate,EndDate,Duration,ServiceID,ServiceProviderID  from [dbo].[tbl_RequestQuotations] where Reference='" + txtSearchReference.Text + "'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "cust");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lstReferences.Visible = true;
                            lstReferences.DataSource = ds.Tables[0];
                            lstReferences.DataTextField = "Reference";
                            lstReferences.DataValueField = "ID";
                        }
                        else
                        {
                            lstReferences.DataSource = null;
                            string script = "alert(\"Error:404- Reference was not found\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }

                        lstReferences.DataBind();
                    }
                }
            }
            catch (Exception)
            {
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtReference.Text == "")
            {
                msgbox("Reference is Required");
                return;
            }

            try
            {
               

                DateTime StartDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", null);
                StartDate = Convert.ToDateTime(StartDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                DateTime EndDate = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", null);
                EndDate = Convert.ToDateTime(EndDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_EditQuotationRequest]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", lstReferences.SelectedValue);
                cmd.Parameters.AddWithValue("@DestinationID", ddl_Destinations.SelectedValue);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                cmd.Parameters.AddWithValue("@Duration", txtTotalDays.Text);
                cmd.Parameters.AddWithValue("@TotalHours", txtTotalHours.Text);
                cmd.Parameters.AddWithValue("@ServiceID", ddl_Services.SelectedValue);
                cmd.Parameters.AddWithValue("@ServiceProviderID", ddl_ServiceProvider.SelectedValue);
                cmd.Parameters.AddWithValue("@AmountRequired", txtAmount.Text);
                cmd.Parameters.AddWithValue("@Budget", txtBudget.Text);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    msgbox("Details successfully updated");
                    ClearAll();
                }


            }
            catch (Exception)
            {

            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
                ClearAll(); 
        }
        protected void loadApprovals(string userid)
        {
            try
            {

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select rq.ID, rq.Reference,u.FirstName,u.Surname,d.Destination,convert(varchar,rq.StartDate,103)StartDate,convert(varchar,rq.EndDate,103)EndDate,rq.Duration,s.Service,sp.Name,cast(isnull(rq.AmountRequired,0 ) as decimal(10,2))AmountRequired,cast(isnull(rq.Budget,0 ) as decimal(10,2))Budget,Authorize from [dbo].[tbl_RequestQuotations] rq left join tbl_Users u ON rq.UserID=u.UserID left join tbl_Destinations d ON rq.DestinationID=d.ID left join tbl_Services s ON rq.ServiceID=s.ServiceID left join tbl_ServiceProviders sp ON rq.ServiceProviderID=sp.ID where rq.Status in (0,1) and SendTo in ('101','102') and Authorize in ('Pending','Line','Authorized','Declined') and u.UserID='" + userid + "' and rq.EndDate>GetDate()", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "QGM");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            grdApprovals.DataSource = ds.Tables[0];
                            grdApprovals.Visible = true;
                            grdApprovals.DataBind();


                        }
                        else
                        {
                            grdApprovals.DataSource = null;
                            lblNotification.Visible = true;
                            lblNotification.Text = "No Records!";

                        }

                    }
                }


            }
            catch (Exception)
            {


            }
        }

        protected void grdApprovals_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdApprovals.PageIndex = e.NewPageIndex;
            loadApprovals(Session["UserId"].ToString());
        }
    }
}