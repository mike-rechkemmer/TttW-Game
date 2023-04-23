using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDayEvent : MonoBehaviour
{
    public GameObject Clock;
    public float CurrentHour;
    public float CurrentMinute;

    public float StartHour;
    public float StartMinute;

    public GameObject SpawnEventObject;
    // Start is called before the first frame update
    void Start()
    {
        Clock = RenderSettings.sun.gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CurrentHour = Clock.GetComponent<TimeOfDaySunFade>().MilitaryHour;
        CurrentMinute = Clock.GetComponent<TimeOfDaySunFade>().MinuteInt;

        if(CurrentHour == StartHour && CurrentMinute == StartMinute)
        {
            SpawnEventObject.SetActive(true);
        }
    }
}
