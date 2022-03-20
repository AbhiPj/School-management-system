<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Assignment.aspx.cs" Inherits="_19030690_Abhinav_Parajuli.Assignment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox ID="AssignmentType" placeholder="Assignment Type" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DepartmentDropdown" runat="server" DataSourceID="DepartmentDatasource" DataTextField="DEPARTMENT_NAME" DataValueField="DEPARTMENT_ID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="DepartmentDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;DEPARTMENT_ID&quot;, &quot;DEPARTMENT_NAME&quot; FROM &quot;DEPARTMENT&quot;"></asp:SqlDataSource>
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Button" Width="78px" />

</asp:Content>
