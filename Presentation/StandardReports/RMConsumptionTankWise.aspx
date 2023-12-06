﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="RMConsumptionTankWise.aspx.cs" Inherits="Presentation_StandardReports_RMConsumptionTankWise" %>

  <%@Register Assembly = "AjaxControlToolkit" Namespace = "AjaxControlToolkit" TagPrefix = "asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
 


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
         .multiselect {
        width: auto;
    }
            #checkboxes {
        display: none;
        border: 1px #dadada solid;
        height: 100px;
        overflow-y: scroll;
    }

    #checkboxes label {
        display: block;
    }

    #checkboxes label:hover {
        background-color: #1e90ff;
    }


        .auto-style1 {
            min-height: 250px;
            padding: 15px;
            margin-right: auto;
            margin-left: auto;
            width: 99%;
        }


    </style>
    <div class="content-wrapper" id="BodyDiv" style="height: 1170px;">
        <section class="content-header">
            <h1>Tank Wise Consumption Report</h1>
        </section>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="content-header box-header with-border">

                    <div class="col-md-3">
                        <b id="bTank" runat="server">Select Tank :</b>

                    <asp:listBox runat="server" id="ddlTank" CssClass="form-control" SelectionMode="Multiple" AutoPostBack="False" OnSelectedIndexChanged="ddlTank_SelectedIndexChanged">
                  
                        </asp:listBox>



                       
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

        <section class="auto-style1">
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

<%-- 
    <script src="javascripts/common.js"></script>
    <script src="plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="plugins/fastclick/fastclick.min.js"></script>
    <script src="plugins/sparkline/jquery.sparkline.min.js"></script>
    <script src="plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <script src="plugins/slimScroll/jquery.slimscroll.min.js"></script>
    
    <script src="plugins/moment.js/moment.js"></script>--%>
   <link href="../Design/dist/css/sumoselect.css" rel="stylesheet" />
    <link href="../Design/dist/css/sumoselect.min.css" rel="stylesheet" />

   <script src="../Design/dist/js/jquery.sumoselect.js"></script>
<script src="../Design/dist/js/jquery.sumoselect.min.js"></script>
     <script src="../Design/dist/js/global_Script.js"></script>
  <script src="../Design/dist/js/jquery-ui.min.js"></script>

    <script type="text/javascript">    
   


        $(document).ready(function () {

            $(<%=ddlTank.ClientID%>).SumoSelect({ selectAll: true });

       });
 
      

    </script>
  
   
</asp:Content>

