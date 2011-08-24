using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N2;
using N2.Details;
using N2.Integrity;

namespace N2.Templates.Items
{
    [PartDefinition("Kitchenlisting",
        Name = "KitchenListing",
        IconUrl = "~/Templates/UI/Img/application_view_columns.png")]
    [AllowedZones(Zones.RecursiveBelow,Zones.RecursiveAbove)]
    [WithEditableTitle]
    public class KitchenListingItem : AbstractItem
    {
        protected override string TemplateName
        {
            get { return "KitchenListing"; }
        }
    }
}
