<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="City.aspx.cs" Inherits="Addressbook.City" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>City</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>City Page</h2>
    <asp:GridView ID="GridViewCity" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="GridViewCity_RowCommand">
        <Columns>
            <asp:BoundField DataField="CityID" HeaderText="CityID" />
            <asp:BoundField DataField="CityName" HeaderText="CityName" />
            <asp:BoundField DataField="STDCode" HeaderText="STDCode" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID") %>' NavigateUrl="~/CityAddEdit.aspx" />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-info" CommandName="EditRecord" CommandArgument='<%# Eval("CityID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
