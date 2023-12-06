﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="CumulativeFamilyWise.aspx.cs" Inherits="Presentation_StandardReports_CumulativeFamilyWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper" id="bodyDiv" style="height: 900px;">
        <section class="content-header">
            <h1>Family Wise Cumulative Report
            </h1>

            <ol class="breadcrumb">
            </ol>
        </section>

        <div class="content-header box-header with-border">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="col-md-3">
                        <b id="B2" runat="server">Product Family Name : </b>

                        <asp:DropDownList ID="ddl_FamilyName" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl_FamilyName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-3">
                        <b id="B1" runat="server">Batch No : </b>
                        <asp:DropDownList ID="ddl_BatchNo" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="col-md-4">
                <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass=" btn btn-primary" Style="margin-top: 4%;" OnClick="btn_Submit_Click" />
            </div>

        </div>

        <!-- Main content -->
        <section class="content" style="width: 70%;">
            <!-- col -->
            <section class="col-md-12">
                <div class="box">
                    <!-- Custom tabs (Charts with tabs)-->
                    <!-- Tabs within a box -->
                    <!-- /.row -->
                    <div id="d1" style="height: auto;">
                        <rsweb:ReportViewer ID="ReportViewer1" Style="width: auto; height: auto;" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ShowPrintButton="true" ShowToolBar="true" Height="675px">
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

