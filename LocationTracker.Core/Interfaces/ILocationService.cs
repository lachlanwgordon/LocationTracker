using System;
namespace LocationTracker.Core.Interfaces
{
    public interface ILocationService
    {
        void Subscribe(object owner, string propertyName);
        void Unsubscribe(object owner);
    }
}
