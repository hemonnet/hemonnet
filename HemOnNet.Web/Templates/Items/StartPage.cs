using System.Collections.Generic;
using N2;
using N2.Details;
using N2.Integrity;
using N2.Installation;
using N2.Edit.FileSystem;
using N2.Web;

namespace N2.Templates.Items
{
    /// <summary>
    /// The initial page of the site.
    /// </summary>
    [PageDefinition("Start Page", 
		Description = "A start page template. It displays a horizontal meny but no vertical menu.",
		SortOrder = 440,
		InstallerVisibility = InstallerHint.PreferredRootPage | InstallerHint.PreferredStartPage,
		IconUrl = "~/Templates/UI/Img/page_world.png")]
    [RestrictParents(typeof(RootPage))]
    [AvailableZone("Site Wide Top", Zones.SiteTop), AvailableZone("Site Wide Left", Zones.SiteLeft), AvailableZone("Site Wide Right", Zones.SiteRight)]
	public class StartPage : LanguageRoot, IFileSystemContainer, ISitesSource
    {
        public const string LayoutArea = "layoutArea";

        // site

        [EditableTextBox("Host Name", 72, ContainerName = MiscArea)]
        public virtual string HostName
        {
            get { return (string)(GetDetail("HostName") ?? string.Empty); }
            set { SetDetail("HostName", value); }
        }

        [EditableLink("Not Found Page (404)", 77, ContainerName = MiscArea, HelpText = "Display this page when the requested URL isn't found")]
        public virtual ContentItem NotFoundPage
        {
            get { return (ContentItem)GetDetail("NotFoundPage"); }
            set { SetDetail("NotFoundPage", value); }
        }

        [EditableLink("Error Page (500)", 78, ContainerName = MiscArea, HelpText = "Display this page when an unhandled exception occurs.")]
        public virtual ContentItem ErrorPage
        {
            get { return (ContentItem)GetDetail("ErrorPage"); }
            set { SetDetail("ErrorPage", value); }
        }

        [EditableLink("Login Page", 79, ContainerName = MiscArea, HelpText = "Page to display when authorization to a page fails.")]
        public virtual ContentItem LoginPage
        {
            get { return (ContentItem)GetDetail("LoginPage"); }
            set { SetDetail("LoginPage", value); }
        }

        [EditableCheckBox("Show Breadcrumb", 110, ContainerName = LayoutArea)]
        public virtual bool ShowBreadcrumb
        {
            get { return (bool)(GetDetail("ShowBreadcrumb") ?? true); }
            set { SetDetail("ShowBreadcrumb", value, true); }
        }

        public IEnumerable<Site> GetSites()
        {
            if (string.IsNullOrEmpty(HostName))
                return new Site[0];

            Site s = new Site((Parent ?? this).ID, ID, HostName);
            s.Wildcards = true;

            return new Site[] { s };
        }

        [EditableLink("Kitchen Page", 80, ContainerName = MiscArea, HelpText = "Länk till kök.")]
        public virtual ContentItem KitchenLink
        {
            get { return (ContentItem)GetDetail("KitchenLink"); }
            set { SetDetail("KitchenLink", value); }
        }

        [EditableLink("Bathroom Page", 80, ContainerName = MiscArea, HelpText = "Länk till badrum.")]
        public virtual ContentItem BathroomLink
        {
            get { return (ContentItem)GetDetail("BathroomLink"); }
            set { SetDetail("BathroomLink", value); }
        }

        [EditableLink("Search Page", 80, ContainerName = MiscArea, HelpText = "Länk till söksida.")]
        public virtual ContentItem SearchLink
        {
            get { return (ContentItem)GetDetail("SearchLink"); }
            set { SetDetail("SearchLink", value); }
        }
        
        [EditableLink("Footer Links", 80, ContainerName = MiscArea, HelpText = "Länk till sidor i foten.")]
        public virtual ContentItem FooterLink
        {
            get { return (ContentItem)GetDetail("FooterLink"); }
            set { SetDetail("FooterLink", value); }
        }

        // content

        [Details.ThemeSelector("Theme", 74, ContainerName = LayoutArea)]
        public string Theme
        {
            get { return (string)(GetDetail("Theme") ?? string.Empty); }
            set { SetDetail("Theme", value); }
        }

        public override string TemplateUrl
        {
            get { return "~/Templates/UI/Views/Start.aspx"; }
        }
    }
}