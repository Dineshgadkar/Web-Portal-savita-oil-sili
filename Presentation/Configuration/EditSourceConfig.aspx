<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="EditSourceConfig.aspx.cs" Inherits="Presentation_Configuration_EditSourceConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper" id="bodyDiv">
        <section class="content-header">
            <h1>Tank Source Configuration
    
            </h1>

            <ol class="breadcrumb">
            </ol>
            <br />
        </section>

        <div class="content-header box-header with-border" style="margin-left: 20px;">
            <div id="Div1" class="panel panel-primary" runat="server" style="margin-left: 15%; width: 70%; margin-bottom: auto; margin-top: 1%;">
                <div class="panel-heading">
                    Edit Tank Source
                </div>

                  <div class="panel-body" style="margin-top: 5%; margin-bottom: 5%; padding-left: 12%;">

                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="Label4" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Enter Tank No :"></asp:Label>
                            <asp:DropDownList ID="ddlTankNo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTankNo_SelectedIndexChanged">
                                <asp:ListItem>---Select Tank No---</asp:ListItem>
                             </asp:DropDownList>
                        </div>
                    </div>
                                              <br />

                    <div class="row">
                        <div class="col-md-8">
                            <asp:Label ID="Label3" runat="server" Style="font-family: Gotham; font-size: medium;" Text="Enter Tank Description :"></asp:Label>

                            <asp:TextBox ID="txtTankDesc" runat="server" class="form-control" style="height: 35px; width: 80%"></asp:TextBox>
                            <span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please Enter Tank Description " ForeColor="Red" ControlToValidate="txtTankDesc" runat="server"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                    </div>


                    <div class="col-md-3">
                        <asp:Button ID="btnAdd" runat="server" Text="Update" CssClass="btn btn-primary" Style="margin-top: 12%; width: 100%; font-family: Gotham; font-weight: 500" OnClick="btnAdd_Click" />
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

