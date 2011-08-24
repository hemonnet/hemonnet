﻿using System;
using N2.Engine.Globalization;
using N2.Templates.Items;

namespace N2.Templates.UI.Layouts
{
    public partial class Top_SubMenu : Web.UI.TemplateMasterPage<ContentItem>
    {
        protected ILanguageGateway languages;

        protected override void OnInit(EventArgs e)
        {
            if (CurrentPage != null)
            {
                languages = N2.Context.Current.Resolve<ILanguageGateway>();

                ContentItem language = languages.GetLanguage(CurrentPage) as ContentItem;

                StartPage start = Find.ClosestStartPage;

                if (p != null) p.Visible = (start != null) && start.ShowBreadcrumb;
                if (dti != null) dti.Visible = CurrentPage["ShowTitle"] != null && (bool) CurrentPage["ShowTitle"];
                if (dh != null) dh.CurrentItem = language;

                if (zsl != null)
                {
                    zsl.CurrentItem = language;
                    dft.CurrentItem = language;
                }
            }

            base.OnInit(e);
        }

        protected string GetBodyClass()
        {
            if (CurrentPage != null)
            {
                string className = CurrentPage.GetType().Name;
                return className.Substring(0, 1).ToLower() + className.Substring(1);
            }
            return null;
        }
    }
}