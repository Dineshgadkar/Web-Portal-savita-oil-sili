<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="RMConsumptionBlenderWise.aspx.cs" Inherits="Presentation_StandardReports_RMConsumptionBlenderWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="content-wrapper" id="BodyDiv" style="height: 1170px;">
        <section class="content-header">
            <h1>Blender Wise Consumption Report</h1>
        </section>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="content-header box-header with-border">

                    <div class="col-md-3">
                        <b id="bBlender" runat="server">Select Blender :</b>
                        <asp:DropDownList ID="ddlBlender" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-3">
                        <b id="B2" runat="server">From Date : </b>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="Cal1_Extender" TargetControlID="txtFromDate" Format="yyyy-MM-dd" runat="server"></asp:CalendarExtender>
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredFromDate" ErrorMessage="Please Select From Date" ForeColor="Red" ControlToValidate="txtFromDate" runat="server"></asp:RequiredFieldValidator>
                        </span>
                    </div>

                    <div class="col-md-3">
                        <b id="B1" runat="server">To Date : </b>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="Cal2_Extender" TargetControlID="txtToDate" Format="yyyy-MM-dd" runat="server"></asp:CalendarExtender>
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredToDate" ErrorMessage="Please Select To Date" ForeColor="Red" ControlToValidate="txtToDate" runat="server"></asp:RequiredFieldValidator>
                        </span>
                    </div>

                    <div class="col-md-3">
                        <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass=" btn btn-primary" Style="margin-top: 4%;" OnClick="btn_Submit_Click" />
                    </div>

                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        <section class="content" style="width: 80%;">
            <!-- col -->
            <section class="col-md-12">

                <div class="box">

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

    </div>

</asp:Content>

