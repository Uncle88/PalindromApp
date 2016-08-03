using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PalindromTestApp
{
 public class PalindromClass
    {
        public static bool IsStringPalindrom(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
              return false;
            }

            for (int i = 0, j = value.Length - 1; i < j; i++, j--)
            {
                if (value[i] != value[j])
                    return false;
            }
            return true;
        }
    }
}