<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCommand.aspx.cs" Inherits="Presentation_Configuration_ViewCommand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper" id="bodyDiv">
        <section class="content-header">
            <h1>Command Configuration
            </h1>

            <ol class="breadcrumb">
            </ol>

        </section>

        <div class="content-header box-header with-border" style="margin-left: 20px;">
            <div id="Div1" class="panel panel-primary" runat="server" style="margin-left: 5%; width: 90%; margin-bottom: auto; margin-top: 0%;">
                <div class="panel-heading">
                    View Command
                    <div class="pull-right">
                        <asp:LinkButton ID="LinkButton1" Style="color: #FFFFFF" runat="server" OnClick="LinkButton1_Click">Create</asp:LinkButton>
                        | 
                        <asp:LinkButton ID="LinkButton2" Style="color: #FFFFFF" runat="server" OnClick="LinkButton2_Click">Edit</asp:LinkButton>
                    </div>
                </div>

                <div class="panel-body" style="margin-top: 5%; margin-bottom: 5%; padding-left: 12%;">
                    <div style="text-align: center; width: 100%; height: 350px; overflow: auto;">
                        <asp:GridView ID="gdViewCmd" CssClass="table" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="80%" Height="219px">
                            <Columns>
                                <asp:TemplateField HeaderText="Command No">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CMNDNo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CMNDNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Command Name">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CMNDName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CMNDName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit SP1">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CMNDUnitSP1") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CMNDUnitSP1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Unit SP2">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CMNDUnitSP2") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("CMNDUnitSP2") %>'></asp:Label>
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

