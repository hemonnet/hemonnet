using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HemOnNet.Core.WebControls;
using N2.Templates.Items;
using N2;
using N2.Collections;

namespace N2.Templates.UI.Parts
{
    public partial class ImageListing : Web.UI.TemplateUserControl<ContentItem, ImageListingItem>
    {
        private int m_totalHits;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadImages();
        }

        private void LoadImages()
        {
            ItemFilter filter = new TypeFilter(typeof(Items.Slide));
            ItemList items = CurrentPage.GetChildren(filter);   
            if(items.Count == 0)
                return;
            m_totalHits = items.Count;
            rptPressImageList.DataSource = items;
            rptPressImageList.DataBind();

        }

        protected override void OnInit(EventArgs e)
        {
            rptPressImageList.ItemDataBound += rptPressImageList_ItemDataBound;
            base.OnInit(e);
        }

        void rptPressImageList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Items.Slide item = e.Item.DataItem as Items.Slide;
            if(item == null)
                return;

            PlaceHolder ctrlLineStart = e.Item.FindControl("ctrlLineStart") as PlaceHolder;
            PlaceHolder ctrlLineEnd = e.Item.FindControl("ctrlLineEnd") as PlaceHolder;

            if (e.Item.ItemIndex % 3 == 0)
                ctrlLineStart.Visible = true;

            if ((e.Item.ItemIndex + 1) == m_totalHits || e.Item.ItemIndex % 3 == 2)
                ctrlLineEnd.Visible = true;

            A hypLink = e.Item.FindControl("hypLink") as A;
            Literal ltrImageHead = e.Item.FindControl("ltrImageHead") as Literal;
            Literal ltrImageText = e.Item.FindControl("ltrImageText") as Literal;
            Img imgPress = e.Item.FindControl("imgPress") as Img;

            ltrImageHead.Text = item.Title;
            ltrImageText.Text = item.Text.Replace("<p>","").Replace("</p>","");
            imgPress.ImageUrl = item.Image;
            hypLink.NavigateUrl = item.Image;
        }
    }
}