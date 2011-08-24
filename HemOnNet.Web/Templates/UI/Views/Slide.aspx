<%@ Page Language="C#"  MasterPageFile="../Layouts/TwoColumn.Master" AutoEventWireup="true" CodeBehind="Slide.aspx.cs" Inherits="N2.Templates.UI.Views.Slide" %>

<asp:Content ContentPlaceHolderID="InnerContent" runat="server">
    <ul class="image-list">
        <li class="first-of-line">
            <HON:A ID="hypImage" runat="server" rel="slideshow-lightbox">
                <h3><asp:Literal ID="ltrHeader" runat="server"></asp:Literal></h3>
                <HON:Img ID="imgSlide" runat="server" />
            </HON:A>
        </li>
    </ul>
</asp:Content>