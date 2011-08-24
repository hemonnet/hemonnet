using System.Diagnostics;
using N2.Web;
using N2.Engine;

namespace N2.Addons.UITests.Items
{
	[Adapts(typeof(AdaptiveItemPage))]
	public class AdaptiveRequestAdapter : RequestAdapter
	{
		public override void AuthorizeRequest(PathData path, System.Security.Principal.IPrincipal user)
		{
			Debug.WriteLine("AuthorizeRequest");
			base.AuthorizeRequest(path, user);
		}
		protected override string GetHandlerPath(PathData path)
		{
			Debug.WriteLine("GetHandlerPath");
			return base.GetHandlerPath(path);
		}
		public override void InjectCurrentPage(PathData path, System.Web.IHttpHandler handler)
		{
			Debug.WriteLine("InjectCurrentPage");
			base.InjectCurrentPage(path, handler);
		}
		public override void RewriteRequest(PathData path, N2.Configuration.RewriteMethod rewriteMethod)
		{
			Debug.WriteLine("RewriteRequest");
			base.RewriteRequest(path, rewriteMethod);
		}
	}

	[Adapts(typeof(AdaptiveItemPage))]
	public class AdaptiveZoneAdapter : N2.Web.Parts.PartsAdapter
	{
		public override N2.Collections.ItemList GetItemsInZone(ContentItem parentItem, string zoneName)
		{
			var items = base.GetItemsInZone(parentItem, zoneName);

			if (zoneName == "AutoZone1")
			{
				items.Add(new UITestItemItem());
			}
			if (zoneName == "AutoZone2")
			{
				items.Add(new UITestItemItem());
				items.Add(new UITestItemItem());
			}
			if (zoneName == "AutoZone3")
			{
				items.Add(new UITestItemItem());
				items.Add(new UITestItemItem());
				items.Add(new UITestItemItem());
			}

			return items;
		}
	}
}