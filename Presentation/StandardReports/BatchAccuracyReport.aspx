<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="BatchAccuracyReport.aspx.cs" Inherits="Presentation_StandardReports_BatchAccuracyReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content-wrapper" id="bodyDiv" style="height: 1170px;">
        <section class="content-header">
            <h1>Batch Accuracy Report
            </h1>

            <ol class="breadcrumb">
            </ol>

        </section>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>

                <div class="content-header box-header with-border">

                    <div class="col-md-3">
                        <b id="B3" runat="server">Blender Name : </b>
                        <asp:DropDownList ID="ddl_Vessel" AutoPostBack="True" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_Vessel_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-3">
                        <b id="B2" runat="server">Product Code : </b>

                        <asp:DropDownList ID="ddl_ProdCode" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddl_ProdCode_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-3">
                        <b id="B1" runat="server">Batch No : </b>
                        <asp:DropDownList ID="ddl_BatchNo" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-3">
                        <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass=" btn btn-primary" Style="margin-top: 5%;" OnClick="btn_Submit_Click" />
                    </div>

                </div>

            </ContentTemplate>

        </asp:UpdatePanel>

        <!-- Main content -->
        <section class="content" style="width: 100%;">
            <!-- col -->
            <section class="col-md-12">
                <div class="box">
                    <!-- Custom tabs (Charts with tabs)-->
                    <!-- Tabs within a box -->
                    <!-- /.row -->
                    <div id="d1" style="height: auto;">
                        <rsweb:ReportViewer ID="ReportViewer1" Style="width: auto; height: auto;" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ShowPrintButton="true" ShowToolBar="true" Height="950px">
                        </rsweb:ReportViewer>
                    </div>

                </div>

                <div>
                    <div class="col-sm-5">
                    </div>
                    <div class="col-sm-6">
                        <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-primary form-control" Height="60px" Width="70px" OnClick="btnPrint_Click"><i class="glyphicon glyphicon-print fa-3x"></i></asp:LinkButton>
                    </div>
                </div>

            </section>

        </section>
        <!-- /.content -->
    </div>


</asp:Content>

