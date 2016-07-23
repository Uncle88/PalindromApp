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
        public static bool Palindromtest(string str)
        {
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)

                if (str[i] != str[j])
                    return false;
            return true;

        }
    }
}