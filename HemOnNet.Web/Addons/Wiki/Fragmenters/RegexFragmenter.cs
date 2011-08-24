﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace N2.Addons.Wiki.Fragmenters
{
    /// <summary>
    /// Base class implementing some common functionality for fragmenters.
    /// </summary>
    public abstract class RegexFragmenter : IFragmenter
    {
        public RegexFragmenter(string expression)
        {
            Expression = CreateExpression(expression);
        }

        protected virtual string Name
        {
            get { return GetType().Name.Replace("Fragmenter", ""); }
        }
        protected Regex Expression { get; set; }

        public virtual IEnumerable<Fragment> GetFragments(string text)
        {
            MatchCollection matches = Expression.Matches(text);
            foreach (Match m in matches)
            {
                if (!m.Success && m.Length > 0)
                    continue;

                yield return CreateFragment(m);
            }
        }

        public virtual void Add(Fragment fragment, IList<Fragment> fragments)
        {
            if (fragments.Count > 0)
            {
                Fragment previousFragment = fragments[fragments.Count - 1];
                fragment.Previous = previousFragment;
                previousFragment.Next = fragment;
            }
            fragments.Add(fragment);
        }

        protected virtual Fragment CreateFragment(Match m)
        {
            Fragment f = new Fragment
            {
                Name = this.Name,
                StartIndex = m.Index,
                Length = m.Length,
                InnerContents = m.Groups["Contents"].Success ? m.Groups["Contents"].Value : "",
                Value = m.Groups["Value"].Success ? m.Groups["Value"].Value : m.Value
            };

            return f;
        }

        protected Regex CreateExpression(string pattern)
        {
            return new Regex(pattern, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
        }
    }
}
