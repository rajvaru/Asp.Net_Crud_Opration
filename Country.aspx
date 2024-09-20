<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Country.aspx.cs" Inherits="Addressbook.Country" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Country</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Country Page</h2>
    <asp:GridView ID="GridViewCountry" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="CountryID" HeaderText="CountryID" />
            <asp:BoundField DataField="CountryName" HeaderText="CountryName" />
            <asp:BoundField DataField="CountryCode" HeaderText="CountryCode" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID") %>' />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-info" CommandName="EditRecord" CommandArgument='<%# Eval("CountryID") %>' />

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
