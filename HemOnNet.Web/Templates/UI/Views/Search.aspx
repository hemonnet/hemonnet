<%@ Page Language="C#" MasterPageFile="../Layouts/TwoColumn.master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="N2.Templates.UI.Views.Search" Title="Untitled Page" %>
<asp:Content ID="c" ContentPlaceHolderID="InnerContent" runat="server">
    <div class="form-container">
        <div class="form-container-inner">
            <span class="main-search-box">
                <input type="text" id="txtSearchText" name="q" runat="server" />
                <input type="submit" value="Sök"  />
            </span>
        </div>
    </div>
    <div class="form-container-footer"></div>
    
   <asp:Repeater ID="rptResult" runat="server">
        <HeaderTemplate>
            <ul class="regular-listing">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <h2>
                    <HON:A ID="hypResult" runat="server" /></h2>
                <p>
                    <asp:Literal ID="ltrResult" runat="server" /></p>
                <HON:DynamicControl id="ctrlPath" runat="server" TagName="ol" CssClass="path" />
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
