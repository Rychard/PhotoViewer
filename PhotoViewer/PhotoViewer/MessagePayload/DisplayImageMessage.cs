using System;

namespace PhotoViewer.MessagePayload
{
    public class DisplayImageMessage
    {
        public String ImagePath { get; set; }

        public DisplayImageMessage(String imagePath)
        {
            this.ImagePath = imagePath;
        }
    }
}
