using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//namespace UnityStandardAssets.DayNight
//{
    public class TimeOfDaySunFade : MonoBehaviour
    {
        public int Hour;
        public float Minute;
        public int MinuteInt;
        public bool PM;
        public float timeSpeed = 1;
        public float MilitaryTime;
        public int MilitaryHour;
        public float MilitaryMinute;
        public float timeToIntensity;

        public int MilitaryTimeForLight;
        public int HourForLight;
        public bool PMForLight;

        float tweleveHours = 1.2f;
        public bool TimePaused;
        public float daySpeed;
        public float DayLightIntensity = 4;
        public float NightDarknessIntensity = 1;

        public bool isNight;
        public Image iconSun;
        public Image iconMoon;

        public Text HourNum;
        public Text MinNum;
        public GameObject AMNum;
        public GameObject PMNum;

        public Light lt;
        public Color DayLightColor;
        public Color NightLightColor;
        public Color lerpedColor;

        public Color lerpedEquatorColor;
        public Color lerpedGroundColor;

        public Material DaySkyBox;
        public Color DayEquatorColor;
        public Color DayGroundColor;

        public Material NightSkyBox;
        public Color NightEquatorColor;
        public Color NightGroundColor;

        public Color FogColor;
        public Color FogDayColor;
        public Color FogNightColor;

        public float FogDensity;
        public float FogDayDensity;
        public float FogNightDensity;

        public GameObject SpeedUpCamera;

        void Start()
        {
            lt = GetComponent<Light>();
            RenderSettings.skybox.SetFloat("_Blend", 0);
        }

        public void PauseTime()
        {
             TimePaused = true;
        }

        public void SetHour(int SetHour)
        {
            Hour = SetHour;
        }

    public void SpeedTimeUntilTime(int SetMilitaryHour)
    {
        if (MilitaryHour != SetMilitaryHour){
            Debug.Log("SpeedTimeUntil, Set Speed Up -- Hour speed up to : " + SetMilitaryHour);
            timeSpeed = 50;
            
            StartCoroutine("SpeedyTime", SetMilitaryHour);
        }

        if (MilitaryHour == SetMilitaryHour)
        {
            Debug.Log("SpeedTimeUntil, Met Current Time");
            timeSpeed = .1f;
            Minute = 0f;
            TimePaused = true;
        }
    }

    IEnumerator SpeedyTime(int SetMilitaryHour)
    {
        Debug.Log("SpeedyTime, SetMilHour -- Hour speed up to: " + SetMilitaryHour);
        while (MilitaryHour != SetMilitaryHour)
        {
            Debug.Log("SpeedyTime, Working");
            yield return null;
        }
        Debug.Log("SpeedyTime, Finished");
        SpeedTimeUntilTime(SetMilitaryHour);
    }

    public void TimeWarpCamera(bool EnableTimeWarpCam)
    {
        SpeedUpCamera.SetActive(EnableTimeWarpCam);
    }

public void SetMinute(int SetMin)
        {
            Minute = SetMin;
        }

    public void ResumeTime()
        {
            TimePaused = false;

        }

    // Update is called once per frame
    void FixedUpdate() 
        {
            if (!TimePaused)
            {


                Minute += timeSpeed * Time.deltaTime;

                if (Minute > 59)
                {
                    Hour += 1;
                    Minute = 0;
                }

                if (Hour > 12 && PM == false)
                {
                        Hour = 1;
                        PM = true;
                }

                if (Hour > 12 && PM == true)
                {
                    Hour = 1;
                    PM = false;
                }

                if (PM == true)
                {
                    MilitaryHour = Hour + 12;
                }
                if (PM == false)
                {
                    MilitaryHour = Hour;
                }


                MinuteInt = Mathf.RoundToInt(Minute);
                MinNum.text = MinuteInt.ToString("00");

                MilitaryMinute = Minute / 60f; //May need to convert int to float.. 15/60 = .25

                MilitaryTime = MilitaryHour + MilitaryMinute; //12.25 = 12:15pm

                //Adjust Normal Time to be 3 Hours Ahead
                MilitaryTimeForLight = MilitaryHour + 3;
                if (MilitaryTimeForLight > 24)
                {
                    MilitaryTimeForLight = (MilitaryHour - 24) + 3;
                }

                if (MilitaryTimeForLight > 12)
                {
                    HourForLight = MilitaryTimeForLight - 12;
                }

                if (MilitaryTimeForLight < 13)
                {
                    HourForLight = MilitaryTimeForLight;
                }

                if (MilitaryTimeForLight > 11)
                {
                    PMForLight = true;
                    PMNum.SetActive(true);
                    AMNum.SetActive(false);
                }

                if (MilitaryTimeForLight < 12)
                {
                    PMForLight = false;
                    AMNum.SetActive(true);
                    PMNum.SetActive(false);
                }

                //Is it Night? Make bad things happen
                if (MilitaryTimeForLight > 21 || MilitaryTimeForLight < 7)
                {
                    isNight = true;
                    iconMoon.enabled = true;
                    iconSun.enabled = false;
                }

                if (MilitaryTimeForLight < 22 && MilitaryTimeForLight > 6)
                {
                    isNight = false;
                    iconSun.enabled = true;
                    iconMoon.enabled = false;
                }
                HourNum.text = HourForLight.ToString();
                
                //Adjust Lights, Equator Color, Ground Color, Sky Blend
                if (MilitaryTime < 12f)
                { //Sunrise
                    lerpedColor = Color.Lerp(DayLightColor, NightLightColor, 1f - (MilitaryTime / 12f));
                    lt.color = lerpedColor;

                    lerpedEquatorColor = Color.Lerp(DayEquatorColor, NightEquatorColor, 1f - (MilitaryTime / 12f));
                    RenderSettings.ambientEquatorColor = lerpedEquatorColor;

                    RenderSettings.ambientLight = lerpedEquatorColor;

                    lerpedGroundColor = Color.Lerp(DayGroundColor, NightGroundColor, 1f - (MilitaryTime / 12f));
                    RenderSettings.ambientGroundColor = lerpedGroundColor;

                    FogColor = Color.Lerp(FogDayColor, FogNightColor, 1f - (MilitaryTime / 12f));
                    RenderSettings.fogColor = FogColor;

                    FogDensity = Mathf.Lerp(FogDayDensity, FogNightDensity, 1f - (MilitaryTime / 12f));
                    RenderSettings.fogDensity = FogDensity;

                    RenderSettings.skybox.SetFloat("_Blend", 1f - (MilitaryTime / 12f));

                    timeToIntensity = (MilitaryTime / 11f) * DayLightIntensity;
                    if (timeToIntensity <= NightDarknessIntensity)
                    {
                        lt.intensity = NightDarknessIntensity;
                    }
                    if (timeToIntensity > NightDarknessIntensity && timeToIntensity < DayLightIntensity)
                    {
                        lt.intensity = timeToIntensity;
                    }
                    if (timeToIntensity > DayLightIntensity)
                    {
                        lt.intensity = DayLightIntensity;
                    }
                }

                if (MilitaryTime > 12f)
                { //Sunset
                    lerpedColor = Color.Lerp(DayLightColor, NightLightColor, ((MilitaryTime - 12f) / 12f));
                    lt.color = lerpedColor;

                    lerpedEquatorColor = Color.Lerp(DayEquatorColor, NightEquatorColor, ((MilitaryTime - 12f) / 12f));
                    RenderSettings.ambientEquatorColor = lerpedEquatorColor;

                    RenderSettings.ambientLight = lerpedEquatorColor;

                    lerpedGroundColor = Color.Lerp(DayGroundColor, NightGroundColor, ((MilitaryTime - 12f) / 12f));
                    RenderSettings.ambientGroundColor = lerpedGroundColor;

                    FogColor = Color.Lerp(FogDayColor, FogNightColor, ((MilitaryTime - 12f) / 12f));
                    RenderSettings.fogColor = FogColor;

                    FogDensity = Mathf.Lerp(FogDayDensity, FogNightDensity, ((MilitaryTime - 12f) / 12f));
                    RenderSettings.fogDensity = FogDensity;

                    RenderSettings.skybox.SetFloat("_Blend", ((MilitaryTime - 12f) / 12f));

                    timeToIntensity = ((11f - (MilitaryTime - 12f)) / 11f) * DayLightIntensity; //11 - 1 = 10 / 11 = .9 * 4 = 3.6 -- 11 - 6 = 5 / 11 = .45 * 4 = 1.8
                    if (timeToIntensity <= NightDarknessIntensity)
                    {
                        lt.intensity = NightDarknessIntensity;
                    }
                    if (timeToIntensity > NightDarknessIntensity)
                    {
                        lt.intensity = timeToIntensity;
                    }

                }


            //Rotate Sun
            transform.Rotate((48f / 180f) * Time.deltaTime * timeSpeed, 0, 0);
        }

        }


    }
//}
