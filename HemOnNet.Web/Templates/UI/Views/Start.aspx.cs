using System.Collections.Generic;
using HemOnNet.Core.WebControls;
using N2.Collections;
using N2.Templates.Items;
using N2.Templates.Web.UI;
using N2.Templates.UI.Layouts;

namespace N2.Templates.UI.Views
{
	public partial class Start : TemplatePage<LanguageRoot>
	{
        protected override void OnLoad(System.EventArgs e)
        {
            ((Default)Master).BodyId = "start-page";
            StartPage startpage = (StartPage) CurrentPage;
            if (startpage.KitchenLink != null){
                List<TextPage> items = LoadRepeater(startpage.KitchenLink);
                if (items.Count > 0)
                {
                    rptKitchen.DataSource = items;
                    rptKitchen.DataBind();
                }
            }
            if (startpage.BathroomLink != null)
            {
                List<TextPage> items = LoadRepeater(startpage.BathroomLink);
                if (items.Count > 0)
                {
                    rptBathroom.DataSource = items;
                    rptBathroom.DataBind();
                }
            }
            base.OnLoad(e);
        }

        protected override void OnInit(System.EventArgs e)
        {
            rptKitchen.ItemDataBound += rptKitchen_ItemDataBound;
            rptBathroom.ItemDataBound += rptKitchen_ItemDataBound;
            base.OnInit(e);
        }

        private List<TextPage> LoadRepeater(ContentItem contentItem)
        {
            ItemFilter filter = new ParentFilter(contentItem);

            IList<TextPage> items = N2.Find.Items
                .Where.Type.Eq(typeof (TextPage))
                .Filters(filter)
                .OrderBy.Updated.Desc
                .Select<TextPage>();

            List<TextPage> itemList = new List<TextPage>(items);
            if (itemList.Count > 4)
                itemList = itemList.GetRange(0, 4);
            return itemList;
        }

        void rptKitchen_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            TextPage item = e.Item.DataItem as TextPage;
            if (item == null)
                return;

            DynamicControl ctrlSpan = e.Item.FindControl("ctrlSpan") as DynamicControl;
            A hypKitchen = e.Item.FindControl("hypKitchen") as A;
            Img imgKitchen = e.Item.FindControl("imgKitchen") as Img;

            hypKitchen.NavigateUrl = item.Url;
            imgKitchen.ImageUrl = item.Image;
            imgKitchen.MaxWidth = 217;
            ctrlSpan.InnerText = item.Title;

        }
	}
}
