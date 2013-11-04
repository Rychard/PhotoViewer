using PhotoViewer.Helpers;

namespace PhotoViewer.MessagePayload
{
    public class NavigateDirectionMessage
    {
        public NavigationDirection Direction { get; set; }

        public NavigateDirectionMessage(NavigationDirection direction)
        {
            Direction = direction;
        }

    }
}
