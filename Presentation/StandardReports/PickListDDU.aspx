<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="PickListDDU.aspx.cs" Inherits="Presentation_StandardReports_PickListDDU" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="content-wrapper" id="bodyDiv" style="height: 1170px;">
        <section class="content-header">
            <h1>Pick List DDU Report
    
            </h1>
            <br />
            <ol class="breadcrumb">
            </ol>

        </section>

        <div class="content-header box-header with-border" style="padding-left:150px;">

            <div class="col-md-2">
                
            </div>
            <div class="col-md-3">
                
            </div>

            <div class="col-md-3">
                
            </div>

        
        </div>

        <!-- Main content -->
        <section class="content" style="width: 95%;">

            <!-- col -->
            <section class="col-md-12">
                <div class="box">
                    <!-- Custom tabs (Charts with tabs)-->

                    <!-- Tabs within a box -->


                    <!-- /.row -->
                    <div id="d1" style="height: auto;">
                        <rsweb:ReportViewer ID="ReportViewer1" Style="width: auto; height: auto;" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ShowPrintButton="true" ShowToolBar="true" Height="1000px">
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

