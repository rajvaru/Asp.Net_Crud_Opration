<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="CountryAddEdit.aspx.cs" Inherits="Addressbook.CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Country Page</h2>
    <div class="container">
        <div class="col-5 pt-5">
            
            <div class="form-group">
                <label for="txtID">Enter Country ID: </label>
                <asp:TextBox runat="server" class="form-control" ID="txtCountryID" placeholder="Enter Country ID" EnableViewCountry="False"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvCountryID" ControlToValidate="txtCountryID" ErrorMessage="Enter Country Id" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="txtName">Enter Country Name: </label>
                <asp:TextBox runat="server" class="form-control" ID="txtCountryName" placeholder="Enter Country Name" EnableViewCountry="False"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvCountryName" ControlToValidate="txtCountryName" ErrorMessage="Enter Country Name" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="txtCode">Enter Country Code: </label>
                <asp:TextBox runat="server" class="form-control" ID="txtCountryCode" placeholder="Enter Country Code"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvCountryCode" ControlToValidate="txtCountryCode" ErrorMessage="Enter Country Code" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Button runat="server" ID="btnAdd" Text="AddCountry" OnClick="btnAdd_Click" CssClass="btn btn-success" />

                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                <asp:HyperLink runat="server" ID="hlCancle" NavigateUrl="~/Country.aspx" Text="Cancle" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
