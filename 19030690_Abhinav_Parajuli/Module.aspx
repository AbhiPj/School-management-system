<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Module.aspx.cs" Inherits="_19030690_Abhinav_Parajuli.Module" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div>
    <asp:TextBox ID="txtID" runat="server" visible="false"></asp:TextBox>
    <asp:TextBox placeholder="Module Name" ID="txtModuleName" runat="server" ></asp:TextBox>
    <asp:TextBox placeholder="Credit Hour" ID="txtCreditHour" runat="server" ></asp:TextBox>
</div>

<div>
    <asp:GridView ID="moduleGridView" runat="server" DataKeyNames="MODULE_CODE,MODULE_NAME,CREDIT_HOUR"  OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit ="OnRowCancelingEdit"  OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" width="100%">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
            <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Button" />
</div>
</asp:Content>
