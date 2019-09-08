using System;
using Prism.Events;

namespace LocationTracker.Blazor.Helpers
{
    public class ButtonEvent : PubSubEvent<string>
    {
        public ButtonEvent()
        {
        }
    }
}
