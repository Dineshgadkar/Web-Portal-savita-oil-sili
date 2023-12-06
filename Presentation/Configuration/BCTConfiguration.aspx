<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="BCTConfiguration.aspx.cs" Inherits="Presentation_Configuration_BCTCOnfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content-wrapper" id="bodyDiv">
        <section class="content-header">
            <h1>BCT Configuration
    
            </h1>

            <ol class="breadcrumb">
            </ol>
            <br />
        </section>

        <div class="content-header box-header with-border" style="margin-left: 20px;">
            <div id="Div1" class="panel panel-primary" runat="server" style="margin-left: 15%; width: 70%; margin-bottom: auto; margin-top: 1%;">
                <div class="panel-heading">
                    BCT Configuration
                </div>

                <div class="panel-body" style="margin-top: 5%; margin-bottom: 5%; padding-left: 12%;">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                        <ContentTemplate>

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label6" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Select Family :"></asp:Label>
                                    <asp:DropDownList ID="ddlFamilyList" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlFamilyList_SelectedIndexChanged">
                                        <asp:ListItem>---Select Family---</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label4" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Select Product Code :"></asp:Label>
                                    <asp:DropDownList ID="ddlProduct" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                        <asp:ListItem>---Select Product Code---</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label5" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Product Description:"></asp:Label>
                                    <asp:TextBox ID="txtProductDescription" runat="server" CssClass="form-control" Text="" Enabled ="false"></asp:TextBox>
                                </div>
                            </div>

                            <br />

                            <div class="row" style="display:none">
                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Product Family:"></asp:Label>
                                    <asp:TextBox ID="txtProductFamily" runat="server" CssClass="form-control" Text="" Enabled ="false"></asp:TextBox>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label2" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Fixed BTC(Mins.):"></asp:Label>
                                    <asp:TextBox ID="txtFixedBCT" runat="server" placeholder="Fixed BTC(Mins.)" CssClass="form-control" Text=""></asp:TextBox>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label3" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Variable BTC(Mins.):"></asp:Label>
                                    <asp:TextBox ID="txtVariableBCT" runat="server" placeholder="Variable BTC(Mins.)" CssClass="form-control" Text=""></asp:TextBox>
                                </div>
                            </div>

                        </ContentTemplate>

                    </asp:UpdatePanel>


                    <div class="col-md-6">
                        <asp:Button ID="btnAdd" runat="server" Text="Insert" CssClass="btn btn-primary" Style="margin-top: 12%; width: 40%; font-family: Gotham; font-weight: 500" OnClick="btnAdd_Click" />

                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" Style="margin-top: 12%; margin-left:1%; width: 50%; font-family: Gotham; font-weight: 500" OnClick="btnUpdate_Click" />

                    </div>




                </div>
            </div>
        </div>

    </div>

</asp:Content>

