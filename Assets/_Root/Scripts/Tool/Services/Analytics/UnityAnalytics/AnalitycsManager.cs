using System.Collections;
using System.Collections.Generic;
using Tool.Analytics.UnityAnalytics;
using UnityEngine;

namespace Tool.Analytics
{
    internal class AnalitycsManager : MonoBehaviour
    {
        private IAnalyticsService[] _services;

        private void Awake()
        {
            _services = new IAnalyticsService[]
            {
                new UnityAnalyticsService(),
                new Dev2DevAnalyticsService()
            };
            DontDestroyOnLoad(gameObject);
        }

        public void SendMainMenuOpenedEvent()
        {
            SendEvent("MainMenuOpened");
        }

        private void SendEvent(string eventName)
        {
            foreach (IAnalyticsService service in _services)
            {
                service.SendEvent(eventName);
            }
        }

        private void SendEvent(string eventName, Dictionary<string, object> eventData)
        {
            foreach (IAnalyticsService service in _services)
            {
                service.SendEvent(eventName, eventData);
            }
        }
    }
}