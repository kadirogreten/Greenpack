using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Greenpack.Web.Helpers
{
    public static class CkeditorHtmlHelpers
    {
        /// <summary>
        /// Returns html to render Ckeditor with the specified form name
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name"></param>
        /// <param name="config">A Ckeditor config object which can contain any setting mentioned here: http://docs.ckeditor.com/#!/api/CKEDITOR.config e.g. new { height = 500 }</param>
        /// <returns></returns>
        public static MvcHtmlString Ckeditor(this HtmlHelper htmlHelper, string name, object config = null)
        {
            return htmlHelper.Editor(name, "Ckeditor", new { Config = config });
        }

        /// <summary>
        /// Returns html to render Ckeditor for the specified model property
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="config">A Ckeditor config object which can contain any setting mentioned here: http://docs.ckeditor.com/#!/api/CKEDITOR.config e.g. new { height = 500 }</param>
        /// <returns></returns>
        public static MvcHtmlString CkeditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object config = null)
        {
            return htmlHelper.EditorFor(expression, "Ckeditor", new { Config = config });
        }
    }
}