<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="FamilyConfiguration.aspx.cs" Inherits="Presentation_Configuration_FamilyConfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content-wrapper" id="bodyDiv">
        <section class="content-header">
            <h1>Family Configuration
    
            </h1>

            <ol class="breadcrumb">
            </ol>

        </section>
        <br />




        <div class="content-header box-header with-border">


            <div class="col-md-4">
                <asp:Label ID="Label4" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Enter Family Name:"></asp:Label>

                <asp:TextBox ID="txtFamilyName" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                <span>
                    <asp:RequiredFieldValidator ID="RequiredFamily" ErrorMessage="Please Enter Family Name" ForeColor="Red" ControlToValidate="txtFamilyName" runat="server" ValidationGroup="g1"></asp:RequiredFieldValidator>
                </span>
            </div>

            <div class="col-md-4">
                <asp:Label ID="Label5" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Select Table Mapping:"></asp:Label>
                <asp:DropDownList ID="ddlViews" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                </asp:DropDownList>
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="col-md-3">
                        <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="btn btn-primary" ValidationGroup="g1" Style="margin-top: 7%; width: 80%; font-family: Gotham; font-weight: 500" OnClick="btnAdd_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <section class="content">

                    <!-- Main row -->
                    <div class="row">
                        <!-- col -->
                        <section class="col-md-12">
                            <div id="FamilyInfo" class="box-body" style="width: 70%; margin-left: 15%; height: 350px; width: 617px; overflow: auto;">
                                <asp:GridView ID="gdvFamily" Style="text-align: center;" CssClass="table" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowEditing="gdvFamily_RowEditing" OnRowCancelingEdit="gdvFamily_RowCancelingEdit" OnRowUpdating="gdvFamily_RowUpdating">

                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="False">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("RowId") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("RowId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Family Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FamilyName") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("FamilyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Table Mapping">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="name" SelectedValue='<%# Bind("ViewName") %>'>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Castrol_DBConnectionString %>" SelectCommand="SELECT name FROM sys.views WHERE (name LIKE 'MINT_F%_CUM_RPT')"></asp:SqlDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ViewName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" CommandName="Update" CssClass="btn btn-warning" Style="padding: 0px 3px 0px 3px !important;" runat="server"><i class="glyphicon glyphicon-saved"></i></asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="LinkButton2" CommandName="Cancel" CssClass="btn btn-danger" Style="padding: 0px 3px 0px 3px !important;" runat="server"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton3" CommandName="Edit" CssClass="btn btn-success" Style="padding: 0px 3px 0px 3px !important;" runat="server"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />

                                </asp:GridView>
                            </div>
                        </section>
                    </div>
                    <!-- /.row (main row) -->

                </section>
                <!-- /.content -->
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

