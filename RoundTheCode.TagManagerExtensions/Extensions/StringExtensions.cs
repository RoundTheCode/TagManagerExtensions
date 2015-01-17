using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoundTheCode.TagManagerExtensions.Extensions
{
    public static class StringExtensions
    {
        public static string Escape(this string text)
        {
            return text.Replace(@"\",@"\\").Replace(@"'", @"\'");
        }
    }
}
