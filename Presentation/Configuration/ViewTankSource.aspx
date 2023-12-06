<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="ViewTankSource.aspx.cs" Inherits="Presentation_Configuration_ViewTankSource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style>
        th {

            text-align:center!important;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="content-wrapper" id="bodyDiv">
        <section class="content-header">
            <h1>View Source Tank Configuration
            </h1>

            <ol class="breadcrumb">
            </ol>
            <br />
        </section>

        <div class="content-header box-header with-border" style="margin-left: 20px;">
            <div id="Div1" class="panel panel-primary" runat="server" style="margin-left: 5%; width: 75%; margin-bottom: auto; margin-top: 0%;">
                <div class="panel-heading">
                    View Tank Source
                    <div class="pull-right">
                        <asp:LinkButton ID="LinkButton1" Style="color: #FFFFFF" runat="server" OnClick="LinkButton1_Click">Create</asp:LinkButton>
                        | 
                        <asp:LinkButton ID="LinkButton2" Style="color: #FFFFFF" runat="server" OnClick="LinkButton2_Click">Edit</asp:LinkButton>
                    </div>
                </div>

                <div class="panel-body" style="margin-top: 5%; margin-bottom: 1%; padding-left: 12%;">
                    <div style="text-align: center; width: 100%; height: 350px; overflow: auto;">
                        <asp:GridView ID="gvViewTankSource" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Width="389px">
                            <Columns>
                                <asp:TemplateField HeaderText="Tank No">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TankNo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("TankNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tank Description">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TankDescription") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("TankDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

