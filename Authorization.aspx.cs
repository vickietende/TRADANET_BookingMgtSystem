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
    public partial class Authorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx", true);
                }
                if (Session["RoleID"].ToString() == "100")
                {
                    msgbox("You are not Authorized to view this Page");
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception)
            {

            }
       
            if (!IsPostBack)
            {
                loadAuthorizations();
                loadCloseRequest();
                loadArchive();
                loadDepartments();
                loadSections();
                loadDestinations();
                loadServices();
                loadServiceProviders();
            }

        }

        protected void grdAuthorization_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAuthorization.PageIndex = e.NewPageIndex;
            loadAuthorizations();
        }

        protected void grdAuthorization_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridView grdArchive = Master.FindControl("MainContent").FindControl("grdAuthorization") as GridView;

                Label lblIDEdit = grdAuthorization.SelectedRow.FindControl("lblIDEdit") as Label;
                string IDEdit = lblIDEdit.Text;
                loadDetails(IDEdit);
            }
            catch (Exception)
            {

            }

        }
        private void loadDetails(string id)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select rq.ID,Reference,u.FirstName,u.Surname,u.email,u.DeptID,u.SectionID,rq.DestinationID,convert(varchar,rq.StartDate,103)StartDate,convert(varchar,rq.EndDate,103)EndDate,rq.Duration,rq.ServiceID,rq.ServiceProviderID,sp.Name,u.UserID,convert(varchar,rq.DateCreated,103)DateCreated,rq.TotalHours,sp.Email ProviderEmail,cast(isnull(rq.AmountRequired,0 ) as decimal(10,2))AmountRequired,cast(isnull(rq.Budget,0 ) as decimal(10,2))Budget   from tbl_RequestQuotations rq left join tbl_Users u ON rq.UserID=u.UserID left join tbl_ServiceProviders sp ON rq.ServiceProviderID=sp.ID where rq.ID='" + id + "' ", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtReference.Text = dt.Rows[0]["Reference"].ToString();
                            txtDateCreated.Text = dt.Rows[0]["DateCreated"].ToString();
                            txtID.Text= dt.Rows[0]["ID"].ToString();
                            txtFName.Text = dt.Rows[0]["FirstName"].ToString();
                            txtSurname.Text = dt.Rows[0]["Surname"].ToString();
                            ddl_Departments.SelectedValue = dt.Rows[0]["DeptID"].ToString();
                            ddl_Sections.SelectedValue = dt.Rows[0]["SectionID"].ToString();
                            txtUserEmail.Text = dt.Rows[0]["email"].ToString();
                            ddl_Destinations.SelectedValue = dt.Rows[0]["DestinationID"].ToString();
                            ddl_Services.SelectedValue = dt.Rows[0]["ServiceID"].ToString();
                            txtStartDate.Text = dt.Rows[0]["StartDate"].ToString();
                            txtEndDate.Text = dt.Rows[0]["EndDate"].ToString();
                            txtTotalDays.Text = dt.Rows[0]["Duration"].ToString();
                            txtTotalHours.Text = dt.Rows[0]["TotalHours"].ToString();
                            ddl_ServiceProvider.SelectedValue = dt.Rows[0]["ServiceProviderID"].ToString();
                            txtProviderEmail.Text = dt.Rows[0]["ProviderEmail"].ToString();
                            txtAmount.Text= dt.Rows[0]["AmountRequired"].ToString();
                            txtBudget.Text = dt.Rows[0]["Budget"].ToString();

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

        protected void grdAuthorization_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView grdArchive = Master.FindControl("MainContent").FindControl("grdAuthorization") as GridView;

                Label lblIDEdit = grdAuthorization.Rows[e.NewEditIndex].FindControl("lblIDEdit") as Label;
                string IDEdit = lblIDEdit.Text;


                grdAuthorization.EditIndex = e.NewEditIndex;

                loadAuthorizations();

            }
            catch (Exception)
            {
            }

        }

        protected void grdAuthorization_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdAuthorization.EditIndex = -1;

            Label lblIDEdit = grdAuthorization.Rows[e.RowIndex].FindControl("lblIDEdit") as Label;
            string IDEdit = lblIDEdit.Text;
            loadAuthorizations();

        }
        protected void loadAuthorizations()
        {
            try
            {
                //ListBox lstServices = lvPendingResults.FindControl("lstServices") as ListBox;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select rq.ID, rq.Reference,u.FirstName,u.Surname,d.Destination,convert(varchar,rq.StartDate,103)StartDate,convert(varchar,rq.EndDate,103)EndDate,rq.Duration,s.Service,sp.Name,cast(isnull(rq.AmountRequired,0 ) as decimal(10,2))AmountRequired,cast(isnull(rq.Budget,0 ) as decimal(10,2))Budget from [dbo].[tbl_RequestQuotations] rq left join tbl_Users u ON rq.UserID=u.UserID left join tbl_Destinations d ON rq.DestinationID=d.ID left join tbl_Services s ON rq.ServiceID=s.ServiceID left join tbl_ServiceProviders sp ON rq.ServiceProviderID=sp.ID where rq.Status=0 and SendTo='101' or SendTo='102'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "QGM");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            grdAuthorization.DataSource = ds.Tables[0];
                            grdAuthorization.Visible = true;
                            grdAuthorization.DataBind();


                        }
                        else
                        {
                            grdAuthorization.DataSource = null;
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
        protected void loadCloseRequest()
        {
            try
            {
                //ListBox lstServices = lvPendingResults.FindControl("lstServices") as ListBox;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select rq.ID, rq.Reference,u.FirstName,u.Surname,d.Destination,convert(varchar,rq.StartDate,103)StartDate,convert(varchar,rq.EndDate,103)EndDate,rq.Duration,s.Service,sp.Name,cast(isnull(rq.AmountRequired,0 ) as decimal(10,2))AmountRequired,cast(isnull(rq.Budget,0 ) as decimal(10,2))Budget from [dbo].[tbl_RequestQuotations] rq left join tbl_Users u ON rq.UserID=u.UserID left join tbl_Destinations d ON rq.DestinationID=d.ID left join tbl_Services s ON rq.ServiceID=s.ServiceID left join tbl_ServiceProviders sp ON rq.ServiceProviderID=sp.ID where rq.Status=1 and SendTo='102' and Authorize in ('Declined','Authorized')", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "QGM");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            grdCloseRequest.DataSource = ds.Tables[0];
                            grdCloseRequest.Visible = true;
                            grdCloseRequest.DataBind();


                        }
                        else
                        {
                            grdCloseRequest.DataSource = null;
                            lblClNotification.Visible = true;
                            lblClNotification.Text = "No Records!";

                        }

                    }
                }


            }
            catch (Exception)
            {


            }
        }

        protected void grdArchive_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAuthorization.PageIndex = e.NewPageIndex;
            loadArchive();

        }

      
        protected void loadArchive()
        {
            try
            {
                
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select rq.ID, rq.Reference,u.FirstName,u.Surname,d.Destination,convert(varchar,rq.StartDate,103)StartDate,convert(varchar,rq.EndDate,103)EndDate,rq.Duration,s.Service,sp.Name,isnull(rq.AmountRequired,0 )AmountRequired,isnull(rq.Budget,0 )Budget,Authorize from [dbo].[tbl_RequestQuotations] rq left join tbl_Users u ON rq.UserID=u.UserID left join tbl_Destinations d ON rq.DestinationID=d.ID left join tbl_Services s ON rq.ServiceID=s.ServiceID left join tbl_ServiceProviders sp ON rq.ServiceProviderID=sp.ID where rq.Status=1 and SendTo='102' and Authorize='Closed'", con))
                    {
                        DataSet ds = new DataSet();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(ds, "QGM");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            grdArchive.DataSource = ds.Tables[0];
                            grdArchive.Visible = true;
                            grdArchive.DataBind();


                        }
                        else
                        {
                            grdArchive.DataSource = null;
                            lblArchNotification.Visible = true;
                            lblArchNotification.Text = "No Records!";

                        }

                    }
                }


            }
            catch (Exception)
            {


            }
        }

        //protected void btnSearchReference_Click(object sender, EventArgs e)
        //{
        //    filterList(txtSearchReference.Text);
        //}
        //private void filterList(string searchref)
        //{
        //    try
        //    {
                
        //        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
        //        {
        //            using (var cmd = new SqlCommand("Select rq.ID, rq.Reference,u.FirstName,u.Surname,d.Destination,convert(varchar,rq.StartDate,103)StartDate,convert(varchar,rq.EndDate,103)EndDate,rq.Duration,s.Service,sp.Name,isnull(rq.AmountRequired,0 )AmountRequired from [dbo].[tbl_RequestQuotations] rq left join tbl_Users u ON rq.UserID=u.UserID left join tbl_Destinations d ON rq.DestinationID=d.ID left join tbl_Services s ON rq.ServiceID=s.ServiceID left join tbl_ServiceProviders sp ON rq.ServiceProviderID=sp.ID where rq.Status=0 and SendTo='101' or SendTo='102' and rq.Reference='"+ searchref +"' and Authorize='Pending'", con))
        //            {
        //                DataSet ds = new DataSet();
        //                var adp = new SqlDataAdapter(cmd);
        //                adp.Fill(ds, "QGM");
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    //grdAuthorization.Visible = true;
        //                    lblNotification.Visible = false;
        //                    grdAuthorization.DataBind();


        //                }
        //                else
        //                {
        //                    grdAuthorization.DataSource = null;
        //                    lblNotification.Visible = true;
        //                    lblNotification.Text = "No Records!";

        //                }

        //            }
        //        }


        //    }
        //    catch (Exception)
        //    {


        //    }
        //}

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            txtFName.Text = "";
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
            //txtSearchReference.Text = "";
            loadAuthorizations();
            loadArchive();

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

                            ddl_ClDepartment.DataSource = ds.Tables[0];
                            ddl_ClDepartment.DataTextField = "Department";
                            ddl_ClDepartment.DataValueField = "DeptCode";

                        }
                        else
                        {
                            ddl_Departments.DataSource = null;
                            ddl_ClDepartment.DataSource = null;
                        }

                        ddl_Departments.DataBind();
                        ddl_Departments.Items.Insert(0, "-- Select Department --");

                        ddl_ClDepartment.DataBind();
                        ddl_ClDepartment.Items.Insert(0, "-- Select Department --");
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


                            ddl_ClSections.DataSource = ds.Tables[0];
                            ddl_ClSections.DataTextField = "SectionName";
                            ddl_ClSections.DataValueField = "SectionID";

                        }
                        else
                        {
                            ddl_Sections.DataSource = null;

                            ddl_ClSections.DataSource = null;

                        }

                        ddl_Sections.DataBind();
                        ddl_Sections.Items.Insert(0, "-- Select Section --");

                        ddl_ClSections.DataBind();
                        ddl_ClSections.Items.Insert(0, "-- Select Section --");

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

                            ddl_ClDestinations.DataSource = ds.Tables[0];
                            ddl_ClDestinations.DataTextField = "Destination";
                            ddl_ClDestinations.DataValueField = "ID";
                        }
                        else
                        {
                            ddl_Destinations.DataSource = null;
                            ddl_ClDestinations.DataSource = null;
                        }

                        ddl_Destinations.DataBind();
                        ddl_Destinations.Items.Insert(0, "-- Select Destination --");

                        ddl_ClDestinations.DataBind();
                        ddl_ClDestinations.Items.Insert(0, "-- Select Destination --");
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

                            ddl_ClService.DataSource = ds.Tables[0];
                            ddl_ClService.DataTextField = "Service";
                            ddl_ClService.DataValueField = "ServiceID";

                        }
                        else
                        {
                            ddl_Services.DataSource = null;
                            ddl_ClService.DataSource = null;
                        }

                        ddl_Services.DataBind();
                        ddl_Services.Items.Insert(0, "-- Select a Service --");

                        ddl_ClService.DataBind();
                        ddl_ClService.Items.Insert(0, "-- Select a Service --");

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


                            ddl_ClServiceProviders.DataSource = ds.Tables[0];
                            ddl_ClServiceProviders.DataTextField = "Name";
                            ddl_ClServiceProviders.DataValueField = "Email";

                        }
                        else
                        {
                            ddl_ServiceProvider.DataSource = null;
                            ddl_ClServiceProviders.DataSource = null;

                        }

                        ddl_ServiceProvider.DataBind();
                        ddl_ServiceProvider.Items.Insert(0, "-- Select Service Provider --");


                        ddl_ClServiceProviders.DataBind();
                        ddl_ClServiceProviders.Items.Insert(0, "-- Select Service Provider --");

                    }
                }
            }
            catch (Exception)
            {

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["RoleID"].ToString() == "101")
            {
                try
                {


                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[SP_AuthorizeRequestLineManager]", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", txtID.Text);
                    cmd.Parameters.AddWithValue("@SendTo", "102");
                    cmd.Parameters.AddWithValue("@Authorize", "Line");
                    cmd.Parameters.AddWithValue("@AmountRequired", txtAmount.Text);


                    cmd.ExecuteNonQuery();
                    
                        msgbox("Authorization successful");
                        ClearAll();
                    


                }
                catch (Exception)
                {

                }

            }
            else if(Session["RoleID"].ToString() == "102")
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[SP_AuthorizeRequestHOD]", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", txtID.Text);
                    cmd.Parameters.AddWithValue("@SendTo", "102");
                    cmd.Parameters.AddWithValue("@Authorize", "Authorized");
                    cmd.Parameters.AddWithValue("@Status", 1);


                    cmd.ExecuteNonQuery();
                    
                        msgbox("Authorization successful");
                        ClearAll();
                    
                }
                catch (Exception)
                {

                }

            }
          

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_RejectRequest]", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.Parameters.AddWithValue("@Authorize", "Declined");



                cmd.ExecuteNonQuery();
                
                    msgbox("Authorization successfully Declined!");
                    ClearAll();
                
            }
            catch (Exception)
            {

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

        protected void grdCloseRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridView grdCloseRequest = Master.FindControl("MainContent").FindControl("grdCloseRequest") as GridView;

                Label lblClIDEdit = grdCloseRequest.SelectedRow.FindControl("lblClIDEdit") as Label;
                string IDEdit = lblClIDEdit.Text;
                loadCloseRequestDetails(IDEdit);
            }
            catch (Exception)
            {

            }

        }
        private void loadCloseRequestDetails(string id)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("Select rq.ID,Reference,u.FirstName,u.Surname,u.email,u.DeptID,u.SectionID,rq.DestinationID,convert(varchar,rq.StartDate,103)StartDate,convert(varchar,rq.EndDate,103)EndDate,rq.Duration,rq.ServiceID,rq.ServiceProviderID,sp.Name,u.UserID,convert(varchar,rq.DateCreated,103)DateCreated,rq.TotalHours,sp.Email ProviderEmail,cast(isnull(rq.AmountRequired,0 ) as decimal(10,2))AmountRequired,cast(isnull(rq.Budget,0 ) as decimal(10,2))Budget   from tbl_RequestQuotations rq left join tbl_Users u ON rq.UserID=u.UserID left join tbl_ServiceProviders sp ON rq.ServiceProviderID=sp.ID where rq.ID='" + id + "' ", con))
                    {
                        DataTable dt = new DataTable();
                        var adp = new SqlDataAdapter(cmd);
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtClReference.Text = dt.Rows[0]["Reference"].ToString();
                            txtClDateCreated.Text = dt.Rows[0]["DateCreated"].ToString();
                            txtClID.Text = dt.Rows[0]["ID"].ToString();
                            txtClFName.Text = dt.Rows[0]["FirstName"].ToString();
                            txtClSurname.Text = dt.Rows[0]["Surname"].ToString();
                            ddl_ClDepartment.SelectedValue = dt.Rows[0]["DeptID"].ToString();
                            ddl_ClSections.SelectedValue = dt.Rows[0]["SectionID"].ToString();
                            txtClUserEmail.Text = dt.Rows[0]["email"].ToString();
                            ddl_ClDestinations.SelectedValue = dt.Rows[0]["DestinationID"].ToString();
                            ddl_ClService.SelectedValue = dt.Rows[0]["ServiceID"].ToString();
                            txtClStartDate.Text = dt.Rows[0]["StartDate"].ToString();
                            txtClEndDate.Text = dt.Rows[0]["EndDate"].ToString();
                            txtClTotalDays.Text = dt.Rows[0]["Duration"].ToString();
                            txtClTotalHours.Text = dt.Rows[0]["TotalHours"].ToString();
                            ddl_ClServiceProviders.SelectedValue = dt.Rows[0]["ServiceProviderID"].ToString();
                            txtClProviderEmail.Text = dt.Rows[0]["ProviderEmail"].ToString();
                            txtClAmount.Text = dt.Rows[0]["AmountRequired"].ToString();
                            txtClBudget.Text = dt.Rows[0]["Budget"].ToString();


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

        protected void grdCloseRequest_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView grdCloseRequest = Master.FindControl("MainContent").FindControl("grdCloseRequest") as GridView;

                Label lblClIDEdit = grdCloseRequest.Rows[e.NewEditIndex].FindControl("lblClIDEdit") as Label;
                string IDEdit = lblClIDEdit.Text;


                grdCloseRequest.EditIndex = e.NewEditIndex;

               loadCloseRequest();

            }
            catch (Exception)
            {
            }

        }

        protected void grdCloseRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCloseRequest.PageIndex = e.NewPageIndex;
            loadCloseRequest();
        }

        protected void grdCloseRequest_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCloseRequest.EditIndex = -1;

            Label lblClIDEdit = grdAuthorization.Rows[e.RowIndex].FindControl("lblClIDEdit") as Label;
            string IDEdit = lblClIDEdit.Text;
           loadCloseRequest();
        }

        protected void btnCloseRequest_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_CloseRequest]", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@ID", txtClID.Text);
                cmd.Parameters.AddWithValue("@Authorize", "Closed");



                cmd.ExecuteNonQuery();
                
                    msgbox("Request successfully Closed!");
                    ClearAll();
                
            }
            catch (Exception)
            {

            }


        }

        protected void btnClClear_Click(object sender, EventArgs e)
        {
            txtClReference.Text = "";
            txtClDateCreated.Text = "";
            txtClID.Text = "";
            txtClFName.Text = "";
            txtClSurname.Text = "";
            ddl_ClDepartment.SelectedIndex = 0;
            ddl_ClSections.SelectedIndex = 0;
            txtClUserEmail.Text = "";
            ddl_ClDestinations.SelectedIndex = 0;
            ddl_ClService.SelectedIndex = 0;
            txtClStartDate.Text = "";
            txtClEndDate.Text = "";
            txtClTotalDays.Text = "";
            txtClTotalHours.Text = "";
            ddl_ClServiceProviders.SelectedIndex = 0;
            txtClProviderEmail.Text = "";
            txtClAmount.Text = "";
            txtClBudget.Text = "";

        }
    }
}   