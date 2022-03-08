using System;
using UnityEngine;
using UnityEngine.Events;

namespace Groups
{
    /// <summary>
    /// Serializable UnityEvent with GameObject payload.
    /// </summary>
    [Serializable]
    public class GroupEvent : UnityEvent<GameObject>
    {
        
    }
}