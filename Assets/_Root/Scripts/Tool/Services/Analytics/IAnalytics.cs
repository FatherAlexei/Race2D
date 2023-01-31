using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool.Analytics
{
    internal interface IAnalyticsService
    {
        void SendEvent(string eventName);
        void SendEvent(string eventName, Dictionary<string, object> eventData); 
    }
}
