using System;
using System.Web;
using System.Web.UI;
using N2.Collections;
using N2.Definitions;
using N2.Integrity;
using N2.Persistence;
using N2.Templates.Items;
using N2.Web.Parts;
using N2.Web.UI;

namespace N2.Templates.Items
{
	[PartDefinition("Poll",
		IconUrl = "~/Templates/UI/Img/chart_pie.png")]
    [AllowedZones(Zones.Left, Zones.Right, Zones.RecursiveRight, Zones.RecursiveLeft, Zones.SiteLeft, Zones.SiteRight)]
    [RestrictParents(typeof (AbstractContentPage))]
    [AllowedChildren(typeof(SingleSelect))]
    [FieldSetContainer("questionContainer", "Question", 100)]
    public class Poll : SidebarItem, IAddablePart
    {
        [Details.PollCreatorDetail(QuestionText = "Question", CreateNewText = "Create as new question", Title = "Alternatives", SortOrder = 100, ContainerName = "questionContainer")]
        public virtual SingleSelect Question
        {
            get
            {
                ItemList children = GetChildren();
                if (children.Count > 0)
                {
                    return children[children.Count - 1] as SingleSelect;
                }
                return null;
            }
        }

        public virtual Control AddTo(Control container)
        {
            Control c;
            if (DisplayResult(container.Page.Request))
                c = container.Page.LoadControl("~/Templates/UI/Parts/Result.ascx");
            else
                c = container.Page.LoadControl(TemplateUrl);
            (c as IContentTemplate).CurrentItem = this;
            container.Controls.Add(c);
            return c;
        }

        public virtual void AddAnswer(IPersister persister, int selectedItem)
        {
            Option o = persister.Get<Option>(selectedItem);
            o.Answers++;
            persister.Save(o);
        }

        public virtual HttpCookie GetAnsweredCookie(int selectedItem)
        {
            HttpCookie c = new HttpCookie("p" + Question.ID, selectedItem.ToString());
            c.Expires = DateTime.Now.AddMonths(1);
            return c;
        }

        private bool DisplayResult(HttpRequest request)
        {
            return Question != null && request["p" + Question.ID] != null;
        }

        protected override string TemplateName
        {
            get { return "Poll"; }
        }
    }
}