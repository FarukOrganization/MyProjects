using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Utility
{
   public class CSessionUtil
    {
       public CSessionUtil()
       {

       }


       public static void SetSesstion(string sSessionKey,object value)
       {
           HttpContext.Current.Session[sSessionKey] = value;
       }

       public static object GetSesstion(string sSessionKey)
       {
           object objValue = null;

           objValue = HttpContext.Current.Session[sSessionKey];

           return objValue;
       }

       public static void RemoveSesstion(string sSessionKey)
       {
           HttpContext.Current.Session.Remove(sSessionKey);
       }
    }
}
