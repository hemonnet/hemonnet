using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2;
using N2.Details;
using N2.Integrity;

namespace N2.Templates.Items
{
    [PartDefinition("Imagelisting",
        Name = "ImageListing",
        IconUrl = "~/Templates/UI/Img/application_view_columns.png")]
    [AllowedZones(Zones.RecursiveBelow)]
    [WithEditableTitle]
    public class ImageListingItem : AbstractItem
    {
        protected override string TemplateName
        {
            get { return "ImageListing"; }
        }
    }
}
