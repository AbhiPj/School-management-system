<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModuleAssignment.aspx.cs" Inherits="_19030690_Abhinav_Parajuli.ModuleAssignment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtStudentId" runat="server" visible="false"></asp:TextBox>
    <asp:TextBox ID="txtAssignmentId" runat="server" visible="false"></asp:TextBox>
    <asp:TextBox ID="txtModuleCode" runat="server" visible="false"></asp:TextBox>



        <asp:DropDownList ID="AssignmentDropdown" runat="server" DataSourceID="SqlDataSource1" DataTextField="ASSIGNMENT_TYPE" DataValueField="ASSIGNMENT_ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;ASSIGNMENT_ID&quot;, &quot;ASSIGNMENT_TYPE&quot; FROM &quot;ASSIGNMENT&quot;"></asp:SqlDataSource>
        <asp:DropDownList ID="ModuleDropdown" runat="server" DataSourceID="ModuleDatasource" DataTextField="MODULE_NAME" DataValueField="MODULE_CODE">
        </asp:DropDownList>
        <asp:SqlDataSource ID="ModuleDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;MODULE_CODE&quot;, &quot;MODULE_NAME&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>
        <asp:DropDownList ID="StudentDropdown" runat="server" DataSourceID="StudentDatasource" DataTextField="STUDENT_NAME" DataValueField="STUDENT_ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="StudentDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;STUDENT_ID&quot;, &quot;STUDENT_NAME&quot; FROM &quot;STUDENT&quot;"></asp:SqlDataSource>


        <asp:DropDownList ID="GradeDropdown" runat="server">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
            <asp:ListItem>D</asp:ListItem>
            <asp:ListItem>E</asp:ListItem>
            <asp:ListItem>F</asp:ListItem>
    </asp:DropDownList>

                <asp:GridView ID="mdGridview" runat="server" DataKeyNames="STUDENT_ID,STUDENT_NAME, MODULE_CODE,MODULE_NAME,ASSIGNMENT_ID, ASSIGNMENT_TYPE,GRADE,STATUS" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%"  OnRowDataBound="OnRowDataBound">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
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
</asp:Content>

