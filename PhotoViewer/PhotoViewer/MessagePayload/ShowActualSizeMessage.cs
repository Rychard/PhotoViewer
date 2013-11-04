using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoViewer.MessagePayload
{
    public class ShowActualSizeMessage
    {
        public Boolean ShowActualSize { get; set; }

        public ShowActualSizeMessage(Boolean showActualSize)
        {
            ShowActualSize = showActualSize;
        }
    }
}
