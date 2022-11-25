<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authorization.aspx.cs" Inherits="TRADANET_BookingMgtSystem.Authorization" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="tabs" style="height: 100%">
        <asp:HiddenField ID="hdnSelectedTab" runat="server" Value="0" />
        <ul>
            <li><a href="#tabs-1">Approvals</a></li>
            <li><a href="#tabs-2">Close Request</a></li>
            <li><a href="#tabs-3">Archive</a></li>

        </ul>
        <div id="tabs-1">
            <asp:Panel ID="pnlContent" runat="server" BorderColor="SkyBlue" BorderWidth="1px" CssClass="alert-dark" BackColor="LightBlue">
                <div class="nav nav-tabs alert-success">
                    <h4 style="text-align: center;">Line Manager/HOD Approvals</h4>

                </div>
                <br />
                <%--  <div class="container">
                        <div class="row mt-5">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtSearchReference" autocomplete="off" runat="server" Width="550px"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchReference" runat="server" Text="🔍" UseSubmitBehavior="false" OnClick="btnSearchReference_Click" />
                            </div>

                        </div>
                    </div>--%>
                <%--    <div class="container">
                        <div class="row mt-1">
                            <div class="col-md-12 center-block">
                                <asp:ListBox ID="lstCustomers" runat="server" AutoPostBack="True" Visible="false" CssClass="col-md-12 center-block"></asp:ListBox>
                            </div>
                        </div>
                    </div>--%>
                <div class="container">
                    <div class="row mt-1">
                        <div class="col-md-12">
                            <asp:Label ID="lblNotification" CssClass="alert-danger" runat="server" Visible="false" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row mt-1">
                        <div class="col-md-12">

                            <asp:GridView ID="grdAuthorization" AutoGenerateColumns="False" HorizontalAlign="Center" runat="server" CellPadding="3" GridLines="Both" Caption="Approvals" CaptionAlign="Top" AllowPaging="True" PageSize="50" OnPageIndexChanging="grdAuthorization_PageIndexChanging" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="grdAuthorization_SelectedIndexChanged" OnRowEditing="grdAuthorization_RowEditing" OnRowCancelingEdit="grdAuthorization_RowCancelingEdit">
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <Columns>
                                    <asp:TemplateField HeaderText="#">

                                        <ItemTemplate>
                                            <asp:Label ID="lblIDEdit" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--    <asp:TemplateField HeaderText="Reference">

                                            <ItemTemplate>
                                                <asp:Label ID="lblReference" runat="server" Text='<%# Bind("Reference") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>


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
                                    <asp:TemplateField ShowHeader="False">

                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkBtnCancel" runat="server" CausesValidation="true"
                                                CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                            <asp:LinkButton ID="lnk" CommandArgument='<%# Eval("ID") %>' CommandName="Select" runat="server"><img src="assets/img/edit.jpg" style="height:15px;width:15px;" /></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkBtnEdit" runat="server" CausesValidation="true"
                                                CommandName="Edit"><img src="assets/img/edit.jpg" style="height:15px;width:15px;" /></asp:LinkButton>
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
                <br />
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
                        <div class="col-md-1">
                            <asp:Label ID="Label1" runat="server" Text="ID" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtID" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

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
                            <asp:TextBox ID="txtSurname" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

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
                            <asp:DropDownList ID="ddl_Destinations" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

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

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label10" runat="server" Text="End Date" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtEndDate" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label12" runat="server" Text="Total Days" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtTotalDays" autocomplete="off" CssClass="form-control" runat="server" Width="200px" TextMode="Number"></asp:TextBox>

                        </div>

                    </div>
                </div>
                <br />
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
                            <asp:DropDownList ID="ddl_ServiceProvider" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label15" runat="server" Text="Email" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtProviderEmail" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>


                    </div>
                </div>
                <br />
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
                            <asp:Label ID="Label17" runat="server" Text="Budget" CssClass="control-label"></asp:Label>

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
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm" Text="Authorize" OnClick="btnSave_Click" />
                            <asp:Button ID="btnReject" runat="server" CssClass="btn btn-primary btn-sm" Text="Reject" OnClick="btnReject_Click" />
                            <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary btn-sm" Text="Clear" OnClick="btnClear_Click" />

                        </div>

                    </div>
                </div>
                <br />
                <br />

            </asp:Panel>
        </div>
        <div id="tabs-2">
            <asp:Panel ID="pnlClose" runat="server" BorderColor="SkyBlue" BorderWidth="1px" CssClass="alert-dark" BackColor="LightBlue">
                <div class="nav nav-tabs alert-success">
                    <h4 style="text-align: center;">Close Request</h4>
                </div>

                <div class="container">
                    <div class="row mt-1">
                        <div class="col-md-12">
                            <asp:Label ID="lblClNotification" CssClass="alert-danger" runat="server" Visible="false" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="container">
                    <div class="row mt-1">
                        <div class="col-md-12">

                            <asp:GridView ID="grdCloseRequest" AutoGenerateColumns="False" HorizontalAlign="Center" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" Caption="Close Request" CaptionAlign="Top" AllowPaging="True" PageSize="20" OnPageIndexChanging="grdCloseRequest_PageIndexChanging" OnRowEditing="grdCloseRequest_RowEditing" OnSelectedIndexChanged="grdCloseRequest_SelectedIndexChanged" OnRowCancelingEdit="grdCloseRequest_RowCancelingEdit">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="#">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClIDEdit" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Name">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClFName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Surname">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClSurname" runat="server" Text='<%# Bind("Surname") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Destination">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClDest" runat="server" Text='<%# Bind("Destination") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Start Date">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClStartDate" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="End Date">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClEndDate" runat="server" Text='<%# Bind("EndDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Duration">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClDuration" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Service">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClService" runat="server" Text='<%# Bind("Service") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Provider">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClProvider" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClAmount" runat="server" Text='<%# Bind("AmountRequired") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Budget">

                                        <ItemTemplate>
                                            <asp:Label ID="lblClBudget" runat="server" Text='<%# Bind("Budget") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                           <asp:TemplateField ShowHeader="False">

                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkBtnCancel" runat="server" CausesValidation="true"
                                                CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                            <asp:LinkButton ID="lnk" CommandArgument='<%# Eval("ID") %>' CommandName="Select" runat="server"><img src="assets/img/edit.jpg" style="height:15px;width:15px;" /></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkBtnEdit" runat="server" CausesValidation="true"
                                                CommandName="Edit"><img src="assets/img/edit.jpg" style="height:15px;width:15px;" /></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>





                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <br />
                <div class="container">
                    <div class="row mt-1">
                        <div class="col-md-1">
                            <asp:Label ID="Label20" runat="server" Text="Reference" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClReference" autocomplete="off" CssClass="form-control" runat="server" Width="200px" ForeColor="Red" Font-Bold="true"></asp:TextBox>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label21" runat="server" Text="Date" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClDateCreated" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label22" runat="server" Text="ID" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClID" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <br />
                <div class="container">
                    <div class="row  mt-1">
                        <div class="col-md-1">
                            <asp:Label ID="Label23" runat="server" Text="Name" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClFName" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label24" runat="server" Text="Surname" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClSurname" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label25" runat="server" Text="Department" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddl_ClDepartment" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                        </div>

                    </div>
                </div>
                <br />
                <div class="container">
                    <div class="row  mt-1">
                        <div class="col-md-1">
                            <asp:Label ID="Label26" runat="server" Text="Section" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddl_ClSections" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label27" runat="server" Text="Destination" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddl_ClDestinations" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label28" runat="server" Text="Service" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddl_ClService" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                        </div>


                    </div>
                </div>
                <br />
                <div class="container">
                    <div class="row  mt-1">
                        <div class="col-md-1">
                            <asp:Label ID="Label29" runat="server" Text="Start Date" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClStartDate" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label30" runat="server" Text="End Date" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClEndDate" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label31" runat="server" Text="Total Days" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClTotalDays" autocomplete="off" CssClass="form-control" runat="server" Width="200px" TextMode="Number"></asp:TextBox>

                        </div>

                    </div>
                </div>
                <br />
                <div class="container">
                    <div class="row  mt-1">
                        <div class="col-md-1">
                            <asp:Label ID="Label32" runat="server" Text="Hours" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClTotalHours" autocomplete="off" PlaceHolder="if Conference..." CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label33" runat="server" Text="Provider" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddl_ClServiceProviders" runat="server" CssClass="form-control" AutoPostBack="true" Style="width: 200px;"></asp:DropDownList>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label34" runat="server" Text="Email" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClProviderEmail" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>


                    </div>
                </div>
                <br />
                <div class="container">
                    <div class="row  mt-1">
                        <div class="col-md-1">
                            <asp:Label ID="Label35" runat="server" Text="Email" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClUserEmail" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label36" runat="server" Text="Amount" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClAmount" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label37" runat="server" Text="Budget" CssClass="control-label"></asp:Label>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtClBudget" autocomplete="off" CssClass="form-control" runat="server" Width="200px"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <br />
                <hr />
                <div class="container">
                    <div class="row  mt-1">

                        <div style="padding-left: 450px;">
                            <asp:Button ID="btnCloseRequest" runat="server" CssClass="btn btn-primary btn-sm" Text="Close Request" OnClick="btnCloseRequest_Click" />
                   
                            <asp:Button ID="btnClClear" runat="server" CssClass="btn btn-primary btn-sm" Text="Clear" OnClick="btnClClear_Click" />

                        </div>

                    </div>
                </div>
                <br />
                <br />
                <asp:Label ID="lblAgree" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblEncAgree" runat="server" Visible="false"></asp:Label>
            </asp:Panel>
        </div>
        <div id="tabs-3">
            <asp:Panel ID="pnlArchive" runat="server" BorderColor="SkyBlue" BorderWidth="1px" CssClass="alert-dark" BackColor="LightBlue">
                <div class="nav nav-tabs alert-success">
                    <h4 style="text-align: center;">Archive</h4>

                </div>
                <br />

                <div class="container">
                    <div class="row mt-1">
                        <div class="col-md-12">
                            <asp:Label ID="lblArchNotification" CssClass="alert-danger" runat="server" Visible="false" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="row mt-1">
                        <div class="col-md-12">

                            <asp:GridView ID="grdArchive" AutoGenerateColumns="False" HorizontalAlign="Center" runat="server" CellPadding="3" GridLines="Both" Caption="Archive" CaptionAlign="Top" AllowPaging="True" PageSize="50" OnPageIndexChanging="grdAuthorization_PageIndexChanging" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"  >
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
                                      <asp:TemplateField HeaderText="Budget">

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

                <br />
                <br />

            </asp:Panel>
        </div>
    </div>

    <ajax:RoundedCornersExtender ID="RoundedCornersExtender1"
        runat="server" Enabled="True" TargetControlID="pnlContent" Radius="15"></ajax:RoundedCornersExtender>
    <ajax:RoundedCornersExtender ID="RoundedCornersExtender2"
        runat="server" Enabled="True" TargetControlID="pnlArchive" Radius="15"></ajax:RoundedCornersExtender>
    <ajax:RoundedCornersExtender ID="RoundedCornersExtender3"
        runat="server" Enabled="True" TargetControlID="pnlClose" Radius="15"></ajax:RoundedCornersExtender>
    <link href="../jquerytabs/styles/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="../jquerytabs/scripts/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs({
                activate: function () {
                    var selectedTab = $('#tabs').tabs('option', 'active');
                    $("#<%= hdnSelectedTab.ClientID %>").val(selectedTab);
                    },
                    active: document.getElementById('<%= hdnSelectedTab.ClientID %>').value
                });
            });

    </script>




</asp:Content>
