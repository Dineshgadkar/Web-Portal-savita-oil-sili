<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="ProductCodeWiseReport.aspx.cs" Inherits="Presentation_StandardReports_ProductCodeWiseReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="content-wrapper" id="bodyDiv" style="height:1170px;">
         <section class="content-header">
            <h1>Product Code Report
    
            </h1>

            <ol class="breadcrumb">

            </ol>

        </section>
     
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>


                <div class="content-header box-header with-border">

                        <div class="col-md-3">
                        <b id="B2" runat="server">Product Code : </b>

                                     <asp:DropDownList ID="ddl_ProdCode" AutoPostBack="true" runat="server"  CssClass="form-control" >
                       
                        </asp:DropDownList>

                    </div>

                    <div class="col-md-3">
                        <b id="B3" runat="server">From Date : </b>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="Cal1_Extender" TargetControlID="txtFromDate" Format="yyyy-MM-dd" runat="server"></asp:CalendarExtender>
                        <span>
                            <asp:RequiredFieldValidator Id="RequiredFromDate" ErrorMessage="Please Select From Date" ForeColor="Red" ControlToValidate="txtFromDate" runat="server"></asp:RequiredFieldValidator>
                        </span>
                    </div>

                

                    <div class="col-md-3">
                        <b id="B1" runat="server">To Date : </b>
                       <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="Cal2_Extender" TargetControlID="txtToDate" Format="yyyy-MM-dd" runat="server"></asp:CalendarExtender>
                        <span>
                            <asp:RequiredFieldValidator Id="RequiredToDate" ErrorMessage="Please Select To Date" ForeColor="Red" ControlToValidate="txtToDate" runat="server"></asp:RequiredFieldValidator>
                        </span>
                    </div>
                    
                    <div class="col-md-3">
                     
                        <asp:Button ID="btn_Submit" runat="server" Text="Submit"  CssClass=" btn btn-primary" style="margin-top:5%;" OnClick="btn_Submit_Click" />
                         
                    </div>
                    

                </div>             
                
         </ContentTemplate>

        </asp:UpdatePanel>
         
                <!-- Main content -->
                <section class="content">


                    <!-- Main row -->
                    <div class="row">
                        <!-- col -->
                        <section class="col-md-12">
                            <div class="box">
                                <!-- Custom tabs (Charts with tabs)-->
                            
                                    <!-- Tabs within a box -->

                                    <!-- /.row -->
                                    <div id="d1" style="height:600px;">
                                         <rsweb:ReportViewer ID="ReportViewer1" Style="width: auto; height: auto;" runat="server" Font-Names="Verdana" Font-Size="8pt"  WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="900px">

                                                <%--<LocalReport ReportPath="Presentation/StandardReports/MINT_V1Batch.rdlc">

                                                    <DataSources>
                                                        <rsweb:ReportDataSource Name="DataSet1"></rsweb:ReportDataSource>
                                                    </DataSources>
                                                </LocalReport>--%>

                                            </rsweb:ReportViewer>
                                        <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" ShowToolBar="False" Width="1076px" Height="404px" OnLoad="ReportViewer1_Load"></rsweb:ReportViewer>--%>
                                    </div>

                             
                            </div>


                        </section>


                    </div>
                    <!-- /.row (main row) -->

                </section>
                <!-- /.content -->
    </div>


</asp:Content>

