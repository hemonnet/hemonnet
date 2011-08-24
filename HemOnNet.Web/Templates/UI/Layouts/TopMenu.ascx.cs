using System;
using System.Collections.Generic;
using HemOnNet.Core.WebControls;
using N2.Templates.Items;
using N2;
using N2.Engine.Globalization;
using N2.Templates.Layouts;
using N2.Collections;

namespace N2.Templates.UI.Layouts
{
    public partial class TopMenu : Web.UI.TemplateUserControl<ContentItem>
    {

        protected ILanguageGateway languages;

        protected override void OnLoad(EventArgs e)
        {
            StartPage startPage = Find.ClosestStartPage;
            if (startPage != null)
                LoadMenu(startPage);
            base.OnLoad(e);
        }

        private void LoadMenu(StartPage page)
        {
            rptMenu.DataSource = page.GetChildren(new NavigationFilter());
            rptMenu.DataBind();

        }

        protected override void OnInit(EventArgs e)
        {
            languages = Engine.Resolve<ILanguageGateway>();

            rptMenu.ItemDataBound += rptMenu_ItemDataBound;
            base.OnInit(e);
        }

        void rptMenu_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            ContentItem item = e.Item.DataItem as ContentItem;
            if(item == null || !item.IsPage)
                return;

            DynamicControl ctrlLi = e.Item.FindControl("ctrlLi") as DynamicControl;
            A hypPage = e.Item.FindControl("hypPage") as A;

            if (IsCurrent(item, CurrentItem))
                ctrlLi.CssClass = "selected";

            ctrlLi.Visible = true;
            hypPage.Text = item.Title;
            hypPage.NavigateUrl = item.Url;

        }

        private bool IsCurrent(ContentItem item, ContentItem currentItem)
        {
            if (item.Url == currentItem.Url)
                return true;
            if (currentItem.Parent.ID != N2.Find.RootItem.ID && currentItem.Parent.ID != N2.Find.StartPage.ID)
                return IsCurrent(item, currentItem.Parent);
            return false;
        }

        private IEnumerable<Translation> GetTranslations()
        {
        	ItemFilter languageFilter = new CompositeFilter(new AccessFilter(), new PublishedFilter());
        	IEnumerable<ContentItem> translations = languages.FindTranslations(CurrentPage);
			foreach (ContentItem translation in languageFilter.Pipe(translations))
			{
				ILanguage language = languages.GetLanguage(translation);
				
				// Hide translations when filtered access to their language
				ContentItem languageItem = language as ContentItem;
				if(languageItem == null || languageFilter.Match(languageItem))
					yield return new Translation(translation, language);
			}
        }
    }
}