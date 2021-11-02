using System;
using System.Collections.Generic;
using System.Text;

namespace RssFeederGp38
{
    class Validation
    {

        public bool Validate(string text, string url)
        {
            if (text != null && text != String.Empty && url != null && url != String.Empty)
            {
                return true;
            }

            return false;
        }
    }
}
