﻿using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Microsoft.AspNet.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MVCSampleApp.Extensions
{
    // You may need to install the Microsoft.AspNet.Razor.Runtime package into your project
    [HtmlTargetElement("table", Attributes = ItemsAttributeName)]
    public class TableTagHelper : TagHelper
    {
        public TableTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        protected IHtmlGenerator Generator { get; } 

        private const string ItemsAttributeName = "items";

        [HtmlAttributeName(ItemsAttributeName)]
        public IEnumerable<object> Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder table = new TagBuilder("table");
            table.GenerateId(context.UniqueId, "id");
            var attributes = context.AllAttributes.Where(a => a.Name != ItemsAttributeName).ToDictionary(a => a.Name);
            table.MergeAttributes(attributes);

            var tr = new TagBuilder("tr");
            var heading = Items.First();
            PropertyInfo[] properties = heading.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var th = new TagBuilder("th");
                th.InnerHtml.Append(prop.Name);
              
                tr.InnerHtml.Append(th);
            }
            table.InnerHtml.Append(tr);
          
            foreach (var item in Items)
            {

                tr = new TagBuilder("tr");
                foreach (var prop in properties)
                {
                    var td = new TagBuilder("td");
                    td.InnerHtml.Append(prop.GetValue(item).ToString());
                    tr.InnerHtml.Append(td);
                }
                table.InnerHtml.Append(tr);
            }
            
            output.Content.Append(table.InnerHtml);
        }
    }
}
