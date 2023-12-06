<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Dosing.aspx.cs" Inherits="Presentation_StandardReports_Dosing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="content-wrapper" id="bodyDiv" style="height: 1170px;">
        <section class="content-header">
            <h1>Header Dosing Report
            </h1>
            <ol class="breadcrumb">
            </ol>

        </section>

        <div class="content-header box-header with-border">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>

                     <div class="col-md-3">
                        <b id="B4" runat="server">From Date : </b>
                        <asp:TextBox ID="txtDate" runat="server"    CssClass="form-control" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="Cal1_Extender" TargetControlID="txtDate" Format="yyyy-MM-dd" runat="server" ></asp:CalendarExtender>
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredFromDate" ErrorMessage="Please Select From Date" ForeColor="Red" ControlToValidate="txtDate" runat="server"></asp:RequiredFieldValidator>
                        </span>
                    </div>

                    <div class="col-md-3">
                        <b id="B5" runat="server">To Date : </b>
                        <asp:TextBox ID="txtEDate" runat="server"    CssClass="form-control" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtEDate" Format="yyyy-MM-dd" runat="server"  ></asp:CalendarExtender>
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Select To Date" ForeColor="Red" ControlToValidate="txtEDate" runat="server"></asp:RequiredFieldValidator>
                        </span>
                    </div>

                    
                    <div class="col-md-3">
                        <b id="B2" runat="server">Select Area : </b>
                        <asp:DropDownList ID="ddl_Area" runat="server" CssClass="form-control" AutoPostBack="true">
                            <asp:ListItem>Dosing Header 7</asp:ListItem>
                            <asp:ListItem>Dosing Header 8</asp:ListItem>
                        </asp:DropDownList>

                    </div>

                    <div class="col-md-3">

                        <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass=" btn btn-primary" Style="margin-top: 5%;" OnClick="btn_Submit_Click" />

                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>

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
                        <rsweb:ReportViewer ID="ReportViewer1" Style="width: auto; height: auto;" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ShowPrintButton="true" ShowToolBar="true" Height="900px">
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

