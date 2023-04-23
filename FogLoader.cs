using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogLoader : MonoBehaviour
{
    public GameObject LightController;
    public TimeOfDaySunFade LightSystem;

    public bool ChangeLight;
    public float LightTimer;

    //----------------Fog Colors----------------//
    //New Colors
    public Color newFogDayLightColor; //Day Time
    public Color newFogNightLightColor; //Night Time

    //Lerp Colors
    private Color CurrentFogDayColor;
    private Color CurrentFogNightColor;

    //New Fog Density
    public float newFogDayDensity;
    public float newFogNightDensity;

    //Lerp Fog Density
    private float CurrentFogDayDensity;
    private float CurrentFogNightDensity;

    //----------------------------------------------------------------------//
    void Start()
    {
        LightController = RenderSettings.sun.gameObject;
        LightSystem = LightController.GetComponent<TimeOfDaySunFade>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LightTimer = 0f;

            CurrentFogDayColor = LightSystem.FogDayColor;
            CurrentFogNightColor = LightSystem.FogNightColor;

            CurrentFogDayDensity = LightSystem.FogDayDensity;
            CurrentFogNightDensity = LightSystem.FogNightDensity;

            ChangeLight = true;
        }
    }

    private void FixedUpdate()
    {
        if (LightTimer >= 1f) { ChangeLight = false; }

        if (ChangeLight)
        {
            LightTimer += .1f * Time.deltaTime;

            LightSystem.FogDayColor = Color.Lerp(CurrentFogDayColor, newFogDayLightColor, LightTimer);
            LightSystem.FogNightColor = Color.Lerp(CurrentFogNightColor, newFogNightLightColor, LightTimer);

            LightSystem.FogDayDensity = Mathf.Lerp(CurrentFogDayDensity, newFogDayDensity, LightTimer);
            LightSystem.FogNightDensity = Mathf.Lerp(CurrentFogNightDensity, newFogNightDensity, LightTimer);
        }
    }
}
