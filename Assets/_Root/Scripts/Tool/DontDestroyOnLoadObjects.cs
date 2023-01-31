using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool
{
    internal class DontDestroyOnLoadObjects : MonoBehaviour
    {
        private void Awake()
        {
            if (enabled)
                DontDestroyOnLoad(gameObject);
        }
    }
}