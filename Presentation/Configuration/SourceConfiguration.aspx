<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="SourceConfiguration.aspx.cs" Inherits="Presentation_Configuration_SourceConfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content-wrapper" id="bodyDiv">
        <section class="content-header">
            <h1>Source Configuration</h1>

            <ol class="breadcrumb">
            </ol>

        </section>
        <br />

        <div id="Div1" class="panel panel-primary" runat="server" style="margin-left: 12%; width: 70%; margin-bottom: auto; margin-top: 5%;">
            <div class="panel-heading">Add Tank Source</div>

            <div class="content-header box-header with-border" style="margin-left: 5%">

                <div class="row" style="margin-top: 5%;">
                    <div class="col-md-4">
                        <asp:Label ID="Label4" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Enter Tank No :"></asp:Label>

                        <asp:TextBox ID="txtTankNo" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredTank" ErrorMessage="Please Enter Tank No " ForeColor="Red" ControlToValidate="txtTankNo" runat="server"></asp:RequiredFieldValidator>
                        </span>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-5">
                        <asp:Label ID="Label3" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Enter Tank Name :"></asp:Label>

                        <asp:TextBox ID="txtTankSource" runat="server" class="form-control"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Enter Tank Name " ForeColor="Red" ControlToValidate="txtTankSource" runat="server"></asp:RequiredFieldValidator>
                        </span>
                    </div>
                </div>

                <div class="col-md-3">
                    <asp:Button ID="btnAdd" runat="server" Text="ADD" CssClass="btn btn-primary" Style="margin-top: 10%; width: 80%; font-family: Gotham; font-weight: 500" OnClick="btnAdd_Click" />
                </div>

            </div>
        </div>

        <section class="content">
            
            <div class="row">
                
                <section class="col-md-12">
                </section>
            </div>

        </section>
        <!-- /.content -->
    </div>

</asp:Content>

