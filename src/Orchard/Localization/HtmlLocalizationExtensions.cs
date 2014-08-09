using System.Globalization;
using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.Mvc.Html;

namespace Orchard.Localization {
    public static class HtmlLocalizationExtensions {
        /// <summary>
        /// The dir attribute specifies the text direction of the element's content.
        /// 
        /// Returns rtl or ltr based on if your content has an ILocalizableAspect or not.
        /// </summary>
        /// <returns>Returns rtl or ltr</returns>
        public static string Directionality(this HtmlHelper html, IContent content) {
            var workContext = html.GetWorkContext();

            var culture = workContext.CurrentSite.SiteCulture;
            if (content.Has<ILocalizableAspect>()) {
                culture = content.As<ILocalizableAspect>().Culture;
            }

            return CultureInfo.GetCultureInfo(culture).TextInfo.IsRightToLeft ? "rtl" : "ltr";
        }
    }
}