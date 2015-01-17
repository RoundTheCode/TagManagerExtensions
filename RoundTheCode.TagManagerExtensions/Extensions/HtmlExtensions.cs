using RoundTheCode.TagManagerExtensions.Exception;
using RoundTheCode.TagManagerExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RoundTheCode.TagManagerExtensions.Extensions
{
    public static class HtmlExtensions
    {
        const string DEFAULT_EXTENSION_CLASS = "TagManagerExtensions";

        private static string GetObjectPath(object path)
        {
            if (path != null)
            {
                if (path is string)
                {
                    return "'" + path.ToString().Escape() + "'";
                }
                else if (path is int)
                {                    
                    return ((int)path).ToString().Escape();
                }
                else if (path is float)
                {
                    return ((float)path).ToString().Escape();
                }
                else if (path is double)
                {
                    return ((double)path).ToString().Escape();
                }
                else if (path is decimal)
                {
                    return ((decimal)path).ToString().Escape();
                }
                else if (path is bool)
                {
                    var boolPath = (bool)path;

                    if (boolPath)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
            }
            return "undefined";
        }

        private static string Path(string path)
        {
            return path + "();";
        }

        private static string Path(string path, object T1) {
            return path + "(" + GetObjectPath(T1) + ");";
        }

        private static string Path(string path, object T1, object T2)
        {
            return path + "(" + GetObjectPath(T1) + "," + GetObjectPath(T2) + ");";
        }

        private static string Path(string path, object T1, object T2, object T3)
        {
            return path + "(" + GetObjectPath(T1) + "," + GetObjectPath(T2) + "," + GetObjectPath(T3) + ");";
        }

        private static string Path(string path, object T1, object T2, object T3, object T4)
        {
            return path + "(" + GetObjectPath(T1) + "," + GetObjectPath(T2) + "," + GetObjectPath(T3) + "," + GetObjectPath(T4) + ");";
        }

        private static string Path(string path, object T1, object T2, object T3, object T4, object T5)
        {
            return path + "(" + GetObjectPath(T1) + "," + GetObjectPath(T2) + "," + GetObjectPath(T3) + "," + GetObjectPath(T4) + "," + GetObjectPath(T5) + ");";
        }

        private static string Path(string path, object T1, object T2, object T3, object T4, object T5, object T6)
        {
            return path + "(" + GetObjectPath(T1) + "," + GetObjectPath(T2) + "," + GetObjectPath(T3) + "," + GetObjectPath(T4) + "," + GetObjectPath(T5) + "," + GetObjectPath(T6) + ");";
        }

        /// <summary>
        /// Sends a custom dimension into the data layer by parsing in the index and the value.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="keyIndex">The custom dimension index number. This would typically be a value from 1 to 20.</param>
        /// <param name="value">The value of the custom dimension.</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        public static MvcHtmlString TagManagerExtensions_SetCustomDimension(this HtmlHelper html, int keyIndex, string value, string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            if (keyIndex < 1)
                Debug.WriteLine(ErrorMessageEnum.CUSTOM_DIMENSION_INDEX_INVALID.ToErrorMessage());

            return new MvcHtmlString(Path(extensionClass + ".SetCustomDimension", keyIndex, value));
        }

        /// <summary>
        /// Sends a custom metric into the data layer by parsing in the index and the value.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="keyIndex">The custom metric index number. This would typically be a value from 1 to 20.</param>
        /// <param name="value">The value of the custom metric.</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        public static MvcHtmlString TagManagerExtensions_SetCustomMetric(this HtmlHelper html, int keyIndex, int value, string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            if (keyIndex < 1)
                Debug.WriteLine(ErrorMessageEnum.CUSTOM_METRIC_INDEX_INVALID.ToErrorMessage());

            return new MvcHtmlString(Path(extensionClass + ".SetCustomMetric", keyIndex, value));
        }

        /// <summary>
        /// Sends a custom metric into the data layer by parsing in the index and the value.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="keyIndex">The custom metric index number. This would typically be a value from 1 to 20.</param>
        /// <param name="value">The value of the custom metric.</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        public static MvcHtmlString TagManagerExtensions_SetCustomMetric(this HtmlHelper html, int keyIndex, double value, string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            if (keyIndex < 1)
                Debug.WriteLine(ErrorMessageEnum.CUSTOM_METRIC_INDEX_INVALID.ToErrorMessage());

            return new MvcHtmlString(Path(extensionClass + ".SetCustomMetric", keyIndex, value));
        }

        /// <summary>
        /// Sends a custom metric into the data layer by parsing in the index and the value.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="keyIndex">The custom metric index number. This would typically be a value from 1 to 20.</param>
        /// <param name="value">The value of the custom metric.</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        public static MvcHtmlString TagManagerExtensions_SetCustomMetric(this HtmlHelper html, int keyIndex, float value, string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            if (keyIndex < 1)
                Debug.WriteLine(ErrorMessageEnum.CUSTOM_METRIC_INDEX_INVALID.ToErrorMessage());

            return new MvcHtmlString(Path(extensionClass + ".SetCustomMetric", keyIndex, value));
        }

        /// <summary>
        /// Sends the web property ID into the data layer. Setting this up in Google Tag Manager should be the ID of the Google Analytics account where the tracking would be sent. 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="webPropertyIdValue">The ID of the Google Analytics account. e.g. UA-XXXXXX-1.</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        public static MvcHtmlString TagManagerExtensions_SetWebPropertyId(this HtmlHelper html, string webPropertyIdValue, string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            if (!Regex.IsMatch(webPropertyIdValue, @"^UA\-([0-9]+)\-([0-9]+)$", RegexOptions.IgnoreCase)) {
                Debug.WriteLine(ErrorMessageEnum.INVALID_GA_ID.ToErrorMessage());
            }

            return new MvcHtmlString(Path(extensionClass + ".SetWebPropertyId", webPropertyIdValue));
        }

        /// <summary>
        /// Sends the virtual page path into the data layer. Setting this up in Google Tag Manager should override the URL being tracked in Google Analytics for this page.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="virtualPagePath">The relative path of the URL. e.g. /b.htm</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        public static MvcHtmlString TagManagerExtensions_SetVirtualPagePath(this HtmlHelper html, string virtualPagePath, string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            if (!string.IsNullOrWhiteSpace(virtualPagePath) && (virtualPagePath.ToLower().StartsWith("http://") || virtualPagePath.ToLower().StartsWith("https://")))
            {
                Debug.WriteLine(ErrorMessageEnum.NON_RELATIVE_PAGE_PATH.ToErrorMessage());
            }

            return new MvcHtmlString(Path(extensionClass + ".SetVirtualPagePath", virtualPagePath));
        }
        /// <summary>
        /// Sends a page view into the data layer. Setting this up in Google Tag Manager should send a page view to Google Analytics. 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pagePath">The relative path of the URL. e.g. /b.htm</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        public static MvcHtmlString TagManagerExtensions_FirePageview(this HtmlHelper html, string pagePath = null, string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            if (!string.IsNullOrWhiteSpace(pagePath) && (pagePath.ToLower().StartsWith("http://") || pagePath.ToLower().StartsWith("https://")))
            {
                Debug.WriteLine(ErrorMessageEnum.NON_RELATIVE_PAGE_PATH.ToErrorMessage());
            }

            return new MvcHtmlString(Path(extensionClass + ".FirePageview", pagePath));
        }

        /// <summary>
        /// Sends an event into the data layer. Setting this up in Google Tag Manager should send a event to Google Analytics. 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="category">The event category.</param>
        /// <param name="action">The event action.</param>
        /// <param name="label">The event label. (optional)</param>
        /// <param name="value">The event value. This must be a whole number. (optional)</param>
        /// <param name="nonInteraction">Whether the event is caused by an interaction of the user. True = no interaction from the user. False = interaction from the user. (optional)</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        public static MvcHtmlString TagManagerExtensions_FireEvent(this HtmlHelper html, string category, string action, string label = null, int? value = null, bool? nonInteraction = null, string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            return new MvcHtmlString(Path(extensionClass + ".FireEvent", category, action, label, value, nonInteraction));
        }

        /// <summary>
        /// Sends social tracking into the data layer. Setting this up in Google Tag Manager should send social tracking to Google Analytics. 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="network">The social network e.g. Facebook.</param>
        /// <param name="action">The action. e.g. Like</param>
        /// <param name="target">The URL of the page that the user has triggered the social tracking.</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        public static MvcHtmlString TagManagerExtensions_FireSocial(this HtmlHelper html, string network, string action, string target, string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            return new MvcHtmlString(Path(extensionClass + ".FireSocial", network, action, target));
        }

        /// <summary>
        /// Adds a product as part of the transaction tracking. Products must be added before TagManagerExtensions_FireTransaction is called.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="name">The name of the product purchased.</param>
        /// <param name="sku">The sku of the product purchased.</param>
        /// <param name="category">The category of the product purchased.</param>
        /// <param name="price">The unit price of the product purchased.</param>
        /// <param name="quantity">The quantity of the product purchased.</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        public static MvcHtmlString TagManagerExtensions_AddTransactionProduct(this HtmlHelper html, string name, string sku, string category, double price, int quantity, string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            return new MvcHtmlString(Path(extensionClass + ".AddTransactionProduct", name, sku, category, price, quantity));
        }

        /// <summary>
        /// Sends transaction tracking into the data layer. Products must be added using TagManagerExtensions_AddTransactionProduct before this function is called. Setting this up in Google Tag Manager should send transaction tracking to Google Analytics. 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="transactionId">The ID of the transaction.</param>
        /// <param name="affiliation">The affiliation of the transaction.</param>
        /// <param name="total">The total amount of the transaction.</param>
        /// <param name="shipping">The shipping amount of the transaction. (optional)</param>
        /// <param name="tax">The tax amount of the transaction. (optional)</param>
        /// <param name="currency">The ISO-4217 name of the currency. e.g. GBP (optional)</param>
        /// <param name="extensionClass">The JavaScript class name used. The default is TagManagerExtensions. (optional)</param>
        /// <returns></returns>
        /// 

        public static MvcHtmlString TagManagerExtensions_FireTransaction(this HtmlHelper html, string transactionId, string affiliation, double total, double? shipping = null, double? tax = null, string currency = "", string extensionClass = DEFAULT_EXTENSION_CLASS)
        {
            if (!string.IsNullOrWhiteSpace(currency) && (!Regex.IsMatch(currency, @"^[A-Z]{3}$", RegexOptions.IgnoreCase)))
            {
                Debug.WriteLine(ErrorMessageEnum.INVALID_CURRENCY.ToErrorMessage());
            }

            return new MvcHtmlString(Path(extensionClass + ".FireTransaction", transactionId, affiliation, total, shipping, tax, currency));

        }

    }
}
