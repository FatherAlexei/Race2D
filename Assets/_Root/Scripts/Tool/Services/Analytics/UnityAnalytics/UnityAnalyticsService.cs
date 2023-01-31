using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool.Analytics.UnityAnalytics
{
    public class UnityAnalyticsService : IAnalyticsService
    {
        public void SendEvent(string eventName)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(eventName);
        }

        public void SendEvent(string eventName, Dictionary<string, object> eventData)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(eventName, eventData);
        }

    }
}
