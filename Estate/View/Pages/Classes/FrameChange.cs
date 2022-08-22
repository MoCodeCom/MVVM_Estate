using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Estate.View.Pages.Classes
{
    public class FrameChange
    {
        public FrameChange(Page pageName, Frame frameName, bool b=true)
        {
            if (frameName.Content != null)
            {
                frameName.Content = null;
            }
            frameName.Content = pageName;
        }
    }
}
