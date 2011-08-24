using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using HemOnNet.Core.Constants;
using N2.Templates;
using N2.Templates.Items;
using N2;
using N2.Engine.Globalization;
using Find=N2.Templates.Find;

namespace N2.Templates.UI.Layouts
{
    public partial class Default : Templates.Web.UI.TemplateMasterPage<ContentItem>
    {
        protected ILanguageGateway languages;
        public string BodyId { get; set; }
        private string _searchPageUrl;

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (Request.Browser.Browser == "IE")
                HTML5Replace(writer);
            else
                base.Render(writer);
        }

        private void HTML5Replace(HtmlTextWriter writer)
        {
            MemoryStream memoryStream = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter(memoryStream);
            HtmlTextWriter memoryWriter = new HtmlTextWriter(streamWriter);
            base.Render(memoryWriter);
            memoryWriter.Flush();
            memoryStream.Position = 0;
            TextReader reader = new StreamReader(memoryStream);
            string output = reader.ReadToEnd();
            output = Regex.Replace(output, RegExStrings.HTML5_BLOCK_ELEMENTS, RegExStrings.HTML5_BLOCK_ELEMENTS_REPLACEMENT);
            writer.Write(output);
        }
        
        protected override void OnInit(EventArgs e)
        {
            if (CurrentPage != null)
            {
                languages = N2.Context.Current.Resolve<ILanguageGateway>();
                ltrTitle.Text = CurrentPage.Title + " - HemOnNet inspirationskällan i bilder";
            }
            EnableViewState = false;

            StartPage start = Find.StartPage;
            if (start != null)
                hypHome.NavigateUrl = start.Url;


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

        /// <summary>
        /// Gets or sets the search page url
        /// </summary>
        /// <remarks>By default the search page url is intialized using the dynamic 
        /// property SearchPage which should point to the PageReference of the search page</remarks>
        public string SearchPageUrl
        {
            get
            {
                if (_searchPageUrl == null)
                {
                    StartPage start = Find.StartPage;

                    
                    if (start != null && start.SearchLink != null)
                    {

                        _searchPageUrl = start.SearchLink.Url;
                    }
                }
                return _searchPageUrl;
            }
            set { _searchPageUrl = value; }
        }
    }
}
