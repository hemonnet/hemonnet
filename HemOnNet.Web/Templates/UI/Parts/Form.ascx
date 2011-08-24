<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form.ascx.cs" Inherits="N2.Templates.UI.Parts.Form" %>
<asp:MultiView ID="mv" runat=server ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
		<n2:Display runat="server" PropertyName="Title" />
		<n2:Display runat="server" PropertyName="IntroText" />
        <div class="form-container">
            <div class="form-container-inner">
                <n2:Zone id="zq" runat="server" ZoneName="Questions" />
                <asp:Button Text="Skicka" ID="btnSubmit" runat="server" OnCommand="btnSubmit_Command" meta:resourcekey="btnSubmitResource1" />
            </div>
        </div>
        <div class="form-container-footer"></div>
    </asp:View>
    <asp:View ID="View2" runat="server" EnableViewState="false">
        <n2:Display runat="server" PropertyName="SubmitText" />
    </asp:View>
</asp:MultiView>