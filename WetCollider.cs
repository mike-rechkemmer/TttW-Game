using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetCollider : MonoBehaviour
{
    public Material DryMaterial;
    public Color DryColor;
    public Color WetColor;
    public Color LerpColor;
    public float t = 0f;
    public float duration = 5f; 

    private void Start()
    {
        DryMaterial.SetColor("Color_7594B6CA", DryColor);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Water")
        {
            DryMaterial.SetColor("Color_7594B6CA", WetColor);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            t = 0;
        }
    }

    private void FixedUpdate()
    {
        if (t < 1)
        {
            t += Time.deltaTime / duration;
            LerpColor = Color.Lerp(WetColor, DryColor, t);
            DryMaterial.SetColor("Color_7594B6CA", LerpColor);
        }
    }

}
