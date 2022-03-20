<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Add_teacher_module.aspx.cs" Inherits="_19030690_Abhinav_Parajuli.Add_teacher_module" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:DropDownList ID="TeacherDropdown" runat="server" DataSourceID="TeacherDatasource" DataTextField="TEACHER_NAME" DataValueField="TEACHER_ID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="TeacherDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;TEACHER_ID&quot;, &quot;TEACHER_NAME&quot; FROM &quot;TEACHER&quot;"></asp:SqlDataSource>
    <asp:DropDownList ID="ModuleDropdown" runat="server" DataSourceID="ModuleDatasource" DataTextField="MODULE_NAME" DataValueField="MODULE_CODE">
    </asp:DropDownList>
    <asp:SqlDataSource ID="ModuleDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;MODULE_NAME&quot;, &quot;MODULE_CODE&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>
    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Button" />

    <div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="TeacherModuleDatasource">
            <Columns>
                <asp:BoundField DataField="TEACHER_ID" HeaderText="TEACHER_ID" SortExpression="TEACHER_ID" />
                <asp:BoundField DataField="TEACHER_NAME" HeaderText="TEACHER_NAME" SortExpression="TEACHER_NAME" />
                <asp:BoundField DataField="MODULE_NAME" HeaderText="MODULE_NAME" SortExpression="MODULE_NAME" />
                <asp:BoundField DataField="CREDIT_HOUR" HeaderText="CREDIT_HOUR" SortExpression="CREDIT_HOUR" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="TeacherModuleDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT BERKELEY_COLLEGE.TEACHER.TEACHER_ID, BERKELEY_COLLEGE.TEACHER.TEACHER_NAME, BERKELEY_COLLEGE.MODULE.MODULE_NAME, BERKELEY_COLLEGE.MODULE.CREDIT_HOUR FROM BERKELEY_COLLEGE.TEACHER INNER JOIN BERKELEY_COLLEGE.TEACHER_MODULE ON BERKELEY_COLLEGE.TEACHER.TEACHER_ID = BERKELEY_COLLEGE.TEACHER_MODULE.TEACHER_ID INNER JOIN BERKELEY_COLLEGE.MODULE ON BERKELEY_COLLEGE.TEACHER_MODULE.MODULE_CODE = BERKELEY_COLLEGE.MODULE.MODULE_CODE"></asp:SqlDataSource>

    </div>
</asp:Content>
