<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UrchinTracking.ascx.cs" Inherits="N2.Templates.UI.Parts.UrchinTracking" %>
<asp:PlaceHolder Visible="<%# Track %>" runat="server">
	<script type="text/javascript">
	var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
	document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
	</script>
	<script type="text/javascript">
	var pageTracker = _gat._getTracker("<%# CurrentItem.UACCT %>");
	pageTracker._initData();
	pageTracker._trackPageview();
	</script>
</asp:PlaceHolder>