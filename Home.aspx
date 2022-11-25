<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TRADANET_BookingMgtSystem.Home" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlContent" runat="server" BorderColor="SkyBlue" BorderWidth="1px" CssClass="alert-success" BackColor="LightBlue">

        <div class="nav nav-tabs alert-success">
            <h4 style="text-align:center;">Booking Request</h4>
        </div>
        <br/>
         <div class="container">
            <div class="row mt-5">
                <div class="col-md-1">
                    <asp:Label ID="Label17" runat="server" Text="Search by Reference" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtSearchReference" autocomplete="off" CssClass="form-control" runat="server" Width="550px"></asp:TextBox>

                </div>
                <div class="col-md-2">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearch" runat="server" Text="🔍" UseSubmitBehavior="false" OnClick="btnSearch_Click" />
                </div>
            
            </div>
        </div>
           <br />
        <div class="container">
            <div class="row mt-1">
                <div class="col-md-12 center-block">
                    <asp:ListBox ID="lstReferences" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstReferences_SelectedIndexChanged" Visible="false" CssClass="col-md-12 center-block"></asp:ListBox>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row mt-5">
                <div class="col-md-1">
                    <asp:Label ID="Label1" runat="server" Text="Search by Name" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtSearchUser" autocomplete="off" CssClass="form-control" runat="server" Width="550px"></asp:TextBox>

                </div>
                <div class="col-md-2">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchUser" runat="server" Text="🔍" UseSubmitBehavior="false" OnClick="btnSearchUser_Click"/>
                </div>
                <div class="col-md-1">
                    <asp:Label ID="Label19" runat="server" Text="User ID" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtUserID" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row mt-1">
                <div class="col-md-12 center-block">
                    <asp:ListBox ID="lstUsers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstUsers_SelectedIndexChanged" Visible="false" CssClass="col-md-12 center-block"></asp:ListBox>
                </div>
            </div>
        </div>
        <br/>
        <div class="container">
            <div class="row mt-1">
                <div class="col-md-1">
                    <asp:Label ID="Label2" runat="server" Text="Reference" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtReference" autocomplete="off" CssClass="form-control" runat="server" Width="200px" ForeColor="Red" Font-Bold="true"></asp:TextBox>

                </div>
                <div class="col-md-1">
                    <asp:Label ID="Label5" runat="server" Text="Date" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtDateCreated" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row  mt-1">
                <div class="col-md-1">
                    <asp:Label ID="Label3" runat="server" Text="Name" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtFName" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                </div>
                <div class="col-md-1">
                    <asp:Label ID="Label4" runat="server" Text="Surname" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtSurname" autocomplete="off" CssClass="form-control" runat="server" Width="200px" ></asp:TextBox>

                </div>
                <div class="col-md-1">
                    <asp:Label ID="Label11" runat="server" Text="Department" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddl_Departments" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                </div>

            </div>
        </div>
        <br />
        <div class="container">
            <div class="row  mt-1">
                <div class="col-md-1">
                    <asp:Label ID="Label6" runat="server" Text="Section" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddl_Sections" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                </div>
                <div class="col-md-1">
                    <asp:Label ID="Label7" runat="server" Text="Destination" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddl_Destinations" OnSelectedIndexChanged="ddl_Destinations_SelectedIndexChanged" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                </div>
                <div class="col-md-1">
                    <asp:Label ID="Label8" runat="server" Text="Service" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddl_Services" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                </div>
               

            </div>
        </div>
        <br />
        <div class="container">
            <div class="row  mt-1">
                <div class="col-md-1">
                    <asp:Label ID="Label9" runat="server" Text="Start Date" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtStartDate" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>
                     <asp:Image ID="Image1" runat="server" ImageUrl="assets/img/calendar.jpg"  Height="24px" Width="23px" Align="Top"/>
                          <ajax:CalendarExtender ID="CalendarExtender1" PopupButtonID="Image1" runat="server" TargetControlID="txtStartDate"  
                        Format="dd/MM/yyyy">  
                    </ajax:CalendarExtender> 
                </div>
                <div class="col-md-1">
                    <asp:Label ID="Label10" runat="server" Text="End Date" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtEndDate" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>
                        <asp:Image ID="Image2" runat="server" ImageUrl="assets/img/calendar.jpg"  Height="24px" Width="23px" Align="Top"/>
                          <ajax:CalendarExtender ID="CalendarExtender2" PopupButtonID="Image2" runat="server" TargetControlID="txtEndDate"  
                        Format="dd/MM/yyyy">  
                    </ajax:CalendarExtender> 
                </div>
                <div class="col-md-1">
                    <asp:Label ID="Label12" runat="server" Text="Total Days" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtTotalDays" autocomplete="off" CssClass="form-control" runat="server" Width="200px" TextMode="Number"></asp:TextBox>

                </div>

            </div>
        </div>
        <br/>
        <div class="container">
            <div class="row  mt-1">
                <div class="col-md-1">
                    <asp:Label ID="Label13" runat="server" Text="Hours" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtTotalHours" autocomplete="off" PlaceHolder="if Conference..." CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                </div>
                <div class="col-md-1">
                    <asp:Label ID="Label14" runat="server" Text="Provider" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddl_ServiceProvider" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_ServiceProvider_SelectedIndexChanged" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                </div>
                     <div class="col-md-1">
                    <asp:Label ID="Label15" runat="server" Text="Email" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
               <asp:TextBox ID="txtProviderEmail" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                </div>


            </div>
        </div>
        <br/>
         <div class="container">
            <div class="row  mt-1">
                <div class="col-md-1">
                    <asp:Label ID="Label16" runat="server" Text="Email" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtUserEmail" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                </div>
                   <div class="col-md-1">
                    <asp:Label ID="Label18" runat="server" Text="Amount" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtAmount" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                </div>
                      <div class="col-md-1">
                    <asp:Label ID="Label20" runat="server" Text="Budget" CssClass="control-label"></asp:Label>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtBudget" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                </div>
          
            </div>
        </div>
        <br />
        <hr />
        <div class="container">
            <div class="row  mt-1">

                <div style="padding-left: 450px;">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm" Text="Request Quotation" OnClick="btnSave_Click"/>
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary btn-sm" Text="Save" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary btn-sm" Text="Clear" OnClick="btnClear_Click"/>

                </div>

            </div>
        </div>
        <br/><br/>
          <div class="container">
                    <div class="row mt-1">
                        <div class="col-md-12">
                            <asp:Label ID="lblNotification" CssClass="alert-danger" runat="server" Visible="false" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
        <br/>
              <div class="container">
                    <div class="row mt-1">
                        <div class="col-md-12">

                            <asp:GridView ID="grdApprovals" AutoGenerateColumns="False" HorizontalAlign="Center" runat="server" CellPadding="3" GridLines="Both" Caption="Approvals" CaptionAlign="Top" AllowPaging="True" PageSize="50" OnPageIndexChanging="grdApprovals_PageIndexChanging" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"  >
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <Columns>
                                    <asp:TemplateField HeaderText="#">

                                        <ItemTemplate>
                                            <asp:Label ID="lblIDEdit" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Name">

                                        <ItemTemplate>
                                            <asp:Label ID="lblFName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Surname">

                                        <ItemTemplate>
                                            <asp:Label ID="lblSurname" runat="server" Text='<%# Bind("Surname") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Destination">

                                        <ItemTemplate>
                                            <asp:Label ID="lblDest" runat="server" Text='<%# Bind("Destination") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Start Date">

                                        <ItemTemplate>
                                            <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="End Date">

                                        <ItemTemplate>
                                            <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("EndDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Duration">

                                        <ItemTemplate>
                                            <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Service">

                                        <ItemTemplate>
                                            <asp:Label ID="lblService" runat="server" Text='<%# Bind("Service") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Provider">

                                        <ItemTemplate>
                                            <asp:Label ID="lblProvider" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">

                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("AmountRequired") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Budget">

                                        <ItemTemplate>
                                            <asp:Label ID="lblBudget" runat="server" Text='<%# Bind("Budget") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Approval">

                                        <ItemTemplate>
                                            <asp:Label ID="lblAuthorize" runat="server" Text='<%# Bind("Authorize") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             


                                </Columns>
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                <SortedDescendingHeaderStyle BackColor="#3E3277" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
         <br/><br/>
    </asp:Panel>
    <ajax:RoundedCornersExtender ID="Panel1_RoundedCornersExtender"
        runat="server" Enabled="True" TargetControlID="pnlContent" Radius="15"></ajax:RoundedCornersExtender>
</asp:Content>
