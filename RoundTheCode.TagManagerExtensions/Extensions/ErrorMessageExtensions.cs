using RoundTheCode.TagManagerExtensions.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoundTheCode.TagManagerExtensions.Extensions
{
    public static class ErrorMessageExtensions
    {
        public static string ToErrorMessage(this ErrorMessageEnum error) {            
            switch (error)
            {
                case ErrorMessageEnum.CUSTOM_DIMENSION_INDEX_INVALID:
                    return GetFullErrorMessage("The custom dimension index is invalid. Please ensure that the index is 1 or greater.");
                case ErrorMessageEnum.CUSTOM_METRIC_INDEX_INVALID:
                    return GetFullErrorMessage("The custom metric index is invalid. Please ensure that the index is 1 or greater.");
                case ErrorMessageEnum.INVALID_GA_ID:
                    return GetFullErrorMessage("The web property ID for Google Analytics is invalid. It should be something like UA-000000-11.");
                case ErrorMessageEnum.NON_RELATIVE_PAGE_PATH:
                    return GetFullErrorMessage("The page path provided is an absolute path. The page path needs to be a relative path e.g. /b.htm.");
                case ErrorMessageEnum.INVALID_CURRENCY:
                    return GetFullErrorMessage("The currency must be in the ISO-4217 format e.g. GBP");


            }
            return "";
        }

        public static string GetFullErrorMessage(string message) {
            return "Tag Manager Extensions - " + message;
        }
    }
}
