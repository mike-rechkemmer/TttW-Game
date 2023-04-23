using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTreeCut : MonoBehaviour {
    public float Health;
    public GameObject FallingTree;
    public GameObject HitParticle;
    public bool InvinsibilityTree;
    private float incSize = 70.0f;

    SkinnedMeshRenderer skinnedMeshRenderer;
    Mesh skinnedMesh;
    // Use this for initialization

    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        skinnedMeshRenderer.SetBlendShapeWeight(0, incSize);
    }

    // Update is called once per frame
    void Update () {

        if (Health <= 0)
        {
            GameObject DeadTreeSpawn = Instantiate(FallingTree, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            Destroy(gameObject);
        }

        

        Invoke("Delay", .3f);

    }

    void Delay()
    {
        InvinsibilityTree = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Axe")
        {
            if (InvinsibilityTree == false)
            {
                incSize -= 30;
                GameObject HitParticleSpawn = Instantiate(HitParticle, (transform.position + new Vector3(0f, 1.2f, 0f)), Quaternion.Euler(0, 0, 0)) as GameObject;
                skinnedMeshRenderer.SetBlendShapeWeight(0, incSize);
                Health -= 30;
            }
        }
    }

}
