using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SetEventTriggers : MonoBehaviour
{
    [SerializeField] EventTrigger eventTrigger;

    void Start()
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventData) => { Foo(); });

    }

    void Foo()
    {
        print("nah");
    }
}
