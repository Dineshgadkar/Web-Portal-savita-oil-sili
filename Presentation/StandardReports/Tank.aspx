<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Tank.aspx.cs" Inherits="Presentation_StandardReports_Tank" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <style>
    
               div.multiselect,
        select#meal,
        button {
            margin: 5px;
        }

        .multiselect {
            width: 200px;
        }

        .selectBox {
            position: relative;
        }

        .selectBox select {
            width: 100%;
            font-weight: bold;
        }

        .overSelect {
            position: absolute;
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
        }

        #checkboxes {
            display: none;
      border: 1px #b5bac5  solid;
      height: 120px;
      overflow-y: auto;
      background: white;
      width: 200px;
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
                width: 92%;
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
                       
                       <%-- <asp:HiddenField ID="Hidden1" runat="server" />    
                            <asp:Label ID="Label1" runat="server" Text="Label" type="hidden"></asp:Label>--%>
                        <input id="Label1" value="" type="hidden" runat="server" />

                         <%--  <asp:Lable id="lblName" runat="server"></asp:Lable>--%>
                        
                             <div class="multiselect">
                             <div class="selectBox"  onclick="showCheckboxes()">
                            <select name="ddl_Machine1" id="ddl_Machine1" Style="width: 200px;" class="machine form-control" runat="server" >
                            <option id="defaultCategory"  runat="server" style="font-size: 15px;">Select an option</option>
                            </select>
                        <div class="overSelect"></div>
                    </div>
                    <div id="checkboxes"></div>
                </div>
                       <%-- </select>--%>




                    </div>

                     <div class="col-md-2">
                                        <b style="font-size: 12px;font-weight: bold" id="B2">From Date :- </b>
                                        <!-- <label id="date_from1" style="font-size: 15px;font-weight: bold"></label> -->
                                        <input type="date" id="txtFromDate" class="form-control" runat="server"
                                            style="font-size: 12px;font-weight: bold;width:100%"
                                            onchange="getName()" />
                                    </div>
                                    <div class="col-md-2">
                                        <b style="font-size: 12px;font-weight: bold" id="B2">To Date :- </b>
                                        <!-- <label id="date_from1" style="font-size: 15px;font-weight: bold"></label> -->
                                        <input type="date" id="txtToDate" class="form-control" runat="server"
                                            style="font-size: 12px;font-weight: bold;width:100%"
                                            onchange="getName()" />
                                    </div>


<%--                    <div class="col-md-3">
                        <b id="B2" runat="server">From Date : </b>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:CalendarExtender ID="Cal1_Extender" TargetControlID="txtFromDate" Format="yyyy-MM-dd" runat="server" ></asp:CalendarExtender>
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredFromDate" ErrorMessage="Please Select From Date" ForeColor="Red" ControlToValidate="txtFromDate" runat="server"></asp:RequiredFieldValidator>
                        </span>
                    </div>

                    <div class="col-md-3">
                        <b id="B1" runat="server">To Date : </b>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:CalendarExtender ID="Cal2_Extender" TargetControlID="txtToDate" Format="yyyy-MM-dd" runat="server"></asp:CalendarExtender>
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredToDate" ErrorMessage="Please Select To Date" ForeColor="Red" ControlToValidate="txtToDate" runat="server"></asp:RequiredFieldValidator>
                        </span>
                    </div>--%>

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

    <script src="https://code.jquery.com/jquery-2.1.4.js" integrity="sha256-siFczlgw4jULnUICcdm9gjQPZkw/YPDqhQ9+nAOScE4=" crossorigin="anonymous"></script>



    <script type="text/javascript" language="javascript">    

        $(document).ready(function () {
            getTankName()

        });
        var selectedvalue = ""
        var selectedText = ""
        function myFunction() {
            debugger;
            els = document.getElementsByName('categories');
            var qtChecks = 0;
            selectedvalue = "";
            if (els[0].checked) {
                for (var ii = 1; ii < els.length; ii++) {
                    els[ii].checked = true;
                }
            }
            if (!els[0].checked) {
                for (var ii = 1; ii < els.length; ii++) {

                    els[ii].checked = false;
                }
            }

            for (i = 1; i < els.length; i++) {
                if (els[i].checked) {
                    if (qtChecks > 0) {
                        selectedvalue += ", "

                    }
                    selectedvalue += els[i].value;
                    qtChecks++;
                }
            }

            document.getElementById('<%=Label1.ClientID %>').value = selectedvalue;

            console.log(selectedvalue);
        }

        var expanded = false;

        function showCheckboxes() {
            var checkboxes = document.getElementById("checkboxes");
            if (!expanded) {
                checkboxes.style.display = "block";
                expanded = true;
                getTankName();
            } else {
                checkboxes.style.display = "none";
                expanded = false;
            }
        }

       
        function checkOptions() {
            debugger;
            els = document.getElementsByName('categories');
            var qtChecks = 0;
            selectedvalue = "";       
            if (els[0].checked) {
                for (var ii = 1; ii < els.length; ii++) {           
                    els[ii].checked = true;
                }
            }
            if (!els[0].checked) {
                for (var ii = 1; ii < els.length; ii++) {

                    els[ii].checked = false;
                }
            }

            for (i = 1; i < els.length; i++) {
                if (els[i].checked) {
                    if (qtChecks > 0) {
                        selectedvalue += ", "
                     
                    }
                    selectedvalue += els[i].value;
                  qtChecks++;
                }
            }
    
            document.getElementById('<%=Label1.ClientID %>').value = selectedvalue;
      
            console.log(selectedvalue);
       
        }

        function getName() {
            debugger;
            var SelectedColumnValue = "";
            var SelectedColumnName = "";
            els = document.getElementsByName('categories');
            var qtChecks = 0;
            SelectedColumnValue = "";
            SelectedColumnName += "";
            for (i = 1; i < els.length; i++) {
                if (els[i].checked) {
                  //  lbl = document.getElementById('labl' + (i - 1)).innerText;
                    if (qtChecks > 0) {

                      
                        SelectedColumnValue += "','"
                        SelectedColumnName += "'";
                        SelectedColumnName += ","
                        SelectedColumnName += "'";
                      
                    }
                    SelectedColumnValue += els[i].value;
               
                 
                    qtChecks++;
                }
            }
            var Tank = '';
            Tank = "'" + SelectedColumnValue.replace(/^"*|"*$/g, '') + "'"
            console.log(Tank);
            
            document.getElementById('<%=Label1.ClientID %>').value = Tank;

           
        }


      
        function getTankName() {

            debugger;

            $.ajax({
                type: "GET",
                url: "Tank.aspx/GetTank",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                async: false,
                success: function (data) {
                    if (data != null) {


                        if (data["d"].indexOf('"')) {
                            var data1 = data["d"].replace(/"/g, "");
                             data1 = data1.replace('[', "");
                             data1 = data1.replace(']' , "");
                            data["d"] = data1;
                        } else {
                            var data1 = data["d"];
                        }

                        var value = data1.split(",")
                      //  if (data.length > 0) {

                            var options = '';
                            var catOptions = "";
                            var row = '';
                            row = '<table class="table table-hover">';
                            row += '<tr>';
                            // row += '<td>' + "<label style='font-size: 15px;' id='labl'><input type='checkbox'  name='categories' value='0'  onclick='checkOptions()'>" + '</td>';
                            row += '<td>' + "<input type='checkbox'  name='categories' value='0'  onclick='checkOptions()'>" + '</td>';

                            row += '<td>' + 'Select All' + '</td>';

                            row += '</tr>';


                          

                        for (var d = 0; d < value.length; d++) {


                            row += '<tr>';
                          //  row += '<td>' + "<label style='font-size: 15px;' id='labl" + d + "'><input type='checkbox'  name='categories' value='" + d + "' >" + '</td>';
                            row += '<td>' + "<input type='checkbox'  name='categories' value='" + value[d] + "' >" + '</td>';

                            row += '<td>' + value[d] + '</td>';

                            row += '</tr>';


                        }

                           // });
                            row += '</table>';

                            document.getElementById("checkboxes").innerHTML = row;

                       
                           // $('.machine').html(options);
                     

                        }
                    //}
                }
            });
        }




    </script>

</asp:Content>

