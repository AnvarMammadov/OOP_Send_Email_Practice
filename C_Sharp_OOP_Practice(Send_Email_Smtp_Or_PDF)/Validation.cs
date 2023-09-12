using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_OOP_Practice_Send_Email_Smtp_Or_PDF_
{
    public static class Validation
    {
        public static bool FlagNull(dynamic temp)
        {
            if (temp != null) return true;
            throw new NullReferenceException("This list is null...Please initialaze..");
        }
    }
}
