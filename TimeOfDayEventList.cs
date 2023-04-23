using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDayEventList : MonoBehaviour
{
    public GameObject Clock;
    public float CurrentHour;
    public float CurrentMinute;

    public GameObject EventAnnouncement;

    public float[] StartHour = new float[1];
    public float[] StartMinute = new float[1];

    public GameObject[] SpawnEventObject = new GameObject[1];
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

        for (int i = 0; i < StartHour.Length; i++)
        {
            if (CurrentHour == StartHour[i] && CurrentMinute == StartMinute[i])
            {
                SpawnEventObject[i].SetActive(true);
                if(EventAnnouncement.activeSelf == false) { EventAnnouncement.SetActive(true); }
            }
        }

       // if (CurrentHour == StartHour && CurrentMinute == StartMinute)
      //  {
       //     SpawnEventObject.SetActive(true);
        //}
    }
}
