using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFloat : MonoBehaviour
{
    public Rigidbody rb;
    public PhysicMaterial FrictionMaterial;
    public PhysicMaterial SlidingFriction;
    public float waterDrag;
    public float airDrag;
    public float inWaterTimer;
    public float outOfWaterTimer;
    public bool outOfWater;
    public bool isFloating;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FrictionMaterial = GetComponent<Collider>().material;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "WaterFloat")
        {
            if (isFloating == false)
            {
                rb.drag = waterDrag;
                transform.Translate(Vector3.up * Time.deltaTime, Space.World);
                inWaterTimer += Time.deltaTime;
                outOfWaterTimer = 15f;
                outOfWater = false;
                CheckObjectFloating();
            }
        }
    }

    private void CheckObjectFloating()
    {
        if (outOfWaterTimer >= 14.7f && inWaterTimer <= .1f)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            //rb.mass = 1;
            FrictionMaterial = SlidingFriction;
            isFloating = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            rb.drag = airDrag;
            inWaterTimer = 0;
            outOfWater = true;
            isFloating = false;
            rb.constraints = RigidbodyConstraints.None;
            FrictionMaterial = null;
            //rb.mass = 20;
            OutOfWater();
        }
    }

    private void OutOfWater()
    {
        if(outOfWater)
        outOfWaterTimer -= Time.deltaTime;
    }
}
