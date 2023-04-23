using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector;

public class VelocityDamage : MonoBehaviour
{
    private Vector3 lastPosition;
    private Vector3 lastVelocity;
    private Vector3 lastAcceleration;
    public vObjectDamage DamageScriptEnemy;
    public vObjectDamage DamageScriptPlayer;
    private float ObjectMass;
    public int ObjectDamage;
    public int EnemyDamage;
    public int EnemyDamageMultiplier = 10;
    private void Awake()
    {
        Vector3 position = transform.position;
        Vector3 velocity = Vector3.zero;
        Vector3 acceleration = Vector3.zero;
        ObjectMass = gameObject.GetComponent<Rigidbody>().mass;
    }
    private void Update()
    {
        Vector3 position = transform.position;
        Vector3 velocity = (position - lastPosition) / Time.deltaTime;
        Vector3 acceleration = (velocity - lastVelocity) / Time.deltaTime;
        if (Mathf.Abs(acceleration.magnitude - lastAcceleration.magnitude) < 0.01f)
        {
            // Still
            DamageScriptPlayer.enabled = false;
            DamageScriptEnemy.enabled = false;
        }
        else if (acceleration.magnitude > lastAcceleration.magnitude)
        {
            // Accelerating
            if (DamageScriptPlayer.enabled == false){ DamageScriptPlayer.enabled = true;  }
            if (DamageScriptEnemy.enabled == false) { DamageScriptEnemy.enabled = true; }
            ObjectDamage = Mathf.RoundToInt(ObjectMass * (acceleration.magnitude * .0005f));
            EnemyDamage = ObjectDamage * EnemyDamageMultiplier;
            DamageScriptEnemy.damage = (new vDamage(EnemyDamage));
            DamageScriptPlayer.damage = (new vDamage(ObjectDamage));
        }
        else
        {
            // Decelerating
            if (DamageScriptPlayer.enabled == false) { DamageScriptPlayer.enabled = true; }
            if (DamageScriptEnemy.enabled == false) { DamageScriptEnemy.enabled = true; }
            ObjectDamage = Mathf.RoundToInt(ObjectMass * (acceleration.magnitude * .0005f));
            EnemyDamage = ObjectDamage * EnemyDamageMultiplier;
            DamageScriptEnemy.damage = (new vDamage(EnemyDamage));
            DamageScriptPlayer.damage = (new vDamage(ObjectDamage));
        }
        if(ObjectDamage == 0){
            DamageScriptPlayer.enabled = false;
            DamageScriptEnemy.enabled = false;
        }
        lastAcceleration = acceleration;
        lastVelocity = velocity;
        lastPosition = position;
    }
}