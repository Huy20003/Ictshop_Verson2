using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.Common
{
    public class Helper
    {

        public static string HtmlRate(int rate)
        {
            var str = "";
            if (rate == 1)
            {
                str = @"<li><i class='fa fa-star' aria-hidden='true'></i></li>
                       <li><i class='fa fa-star-0' aria-hidden='true'></i></li>
 <li><i class='fa fa-star-0' aria-hidden='true'></i></li>
 <li><i class='fa fa-star-0' aria-hidden='true'></i></li>
 <li><i class='fa fa-star-0' aria-hidden='true'></i></li>";

            }
            if (rate == 2)
            {
                str = @"<li><i class='fa fa-star' aria-hidden='true'></i></li>
                       <li><i class='fa fa-star' aria-hidden='true'></i></li>
 <li><i class='fa fa-star-0' aria-hidden='true'></i></li>
 <li><i class='fa fa-star-0' aria-hidden='true'></i></li>
 <li><i class='fa fa-star-0' aria-hidden='true'></i></li>";

            }
            if (rate == 3)
            {
                str = @"<li><i class='fa fa-star' aria-hidden='true'></i></li>
                       <li><i class='fa fa-star' aria-hidden='true'></i></li>
 <li><i class='fa fa-star' aria-hidden='true'></i></li>
 <li><i class='fa fa-star-0' aria-hidden='true'></i></li>
 <li><i class='fa fa-star-0' aria-hidden='true'></i></li>";

            }
            if (rate == 4)
            {
                str = @"<li><i class='fa fa-star' aria-hidden='true'></i></li>
                       <li><i class='fa fa-star' aria-hidden='true'></i></li>
 <li><i class='fa fa-star' aria-hidden='true'></i></li>
 <li><i class='fa fa-star' aria-hidden='true'></i></li>
 <li><i class='fa fa-star-0' aria-hidden='true'></i></li>";

            }
            if (rate == 5)
            {
                str = @"<li><i class='fa fa-star' aria-hidden='true'></i></li>
                       <li><i class='fa fa-star' aria-hidden='true'></i></li>
 <li><i class='fa fa-star' aria-hidden='true'></i></li>
 <li><i class='fa fa-star' aria-hidden='true'></i></li>
 <li><i class='fa fa-star' aria-hidden='true'></i></li>";

            }
            return str;
        }
    }
}