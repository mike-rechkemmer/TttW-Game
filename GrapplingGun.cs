using UnityEngine;
using UnityEngine.UI;
using Invector.vCharacterController;

public class GrapplingGun : MonoBehaviour {

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player, UpperArm;
    private float maxDistance = 50f;
    public float minDistanceLift;
    public float maxDistanceLift;
    private SpringJoint joint;
    public float Spring;
    public float Damper;
    public float Mass;
    public float SpringLift;
    public float DamperLift;
    public float MassLift;
    public Graphic GravityReticle;
    public Color ColorAim;
    public Color ColorDefault;
    public GameObject MaskParticle;
    private vThirdPersonController playerController;
    public GameObject playerObj;
    public GameObject GravityGrabber;
    public GameObject GravityObj;
    public bool Lifting;
    public float energyCost;

    void Awake() {
        lr = GetComponent<LineRenderer>();
        playerController = playerObj.GetComponent<vThirdPersonController>();
    }

    void Update() {
        RaycastHit hit;
        GravityReticle.color = ColorDefault;
        if (Physics.SphereCast(gunTip.position, 2f, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            GravityReticle.color = ColorAim;
        }

        if(Lifting == true && Input.GetMouseButton(0))
        {
            GravityObj.transform.position = GravityGrabber.transform.position;
        }

        if (Input.GetMouseButtonDown(0) && playerController.currentEnergy >= energyCost) {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0)) {
            StopGrapple();
            Lifting = false;
        }
    }

    //Called after Update
    void LateUpdate() {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple() {
        RaycastHit hit;
        if (Physics.SphereCast(gunTip.position, 2f, camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            if (hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic == false)
            {
                grapplePoint = gunTip.position;
                GravityObj = hit.transform.gameObject;
                
                if (Lifting == false)
                {
                    Vector3 Grabberpos = GravityGrabber.transform.position;
                    Vector3 Objpos = GravityObj.transform.position;
                    Grabberpos.z = Objpos.z;
                    Lifting = true;
                }
                //joint = hit.transform.gameObject.AddComponent<SpringJoint>();
                //joint.autoConfigureConnectedAnchor = false;
                //joint.connectedAnchor = grapplePoint;

                //float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

                //The distance grapple will try to keep from grapple point. 
                //joint.maxDistance = distanceFromPoint * 0.15f;
                //joint.minDistance = distanceFromPoint * 0.05f;

                //Adjust these values to fit your game.
                //joint.spring = SpringLift;
                //joint.damper = DamperLift;
                //joint.massScale = MassLift;


                lr.positionCount = 2;
                currentGrapplePosition = hit.transform.position;
                MaskParticle.SetActive(true);
                playerController.currentEnergy = playerController.currentEnergy - energyCost;
            }

            if (hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic == true)
            {
                grapplePoint = hit.point;
                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

                //The distance grapple will try to keep from grapple point. 
                joint.maxDistance = distanceFromPoint * 0.15f;
                joint.minDistance = distanceFromPoint * 0.05f;

                //Adjust these values to fit your game.
                joint.spring = Spring;
                joint.damper = Damper;
                joint.massScale = Mass;

                lr.positionCount = 2;
                currentGrapplePosition = gunTip.position;
                MaskParticle.SetActive(true);
                playerController.currentEnergy = playerController.currentEnergy - energyCost;
            }
        }
    }

    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple() {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;
    
    void DrawRope() {
        //If not grappling, don't draw rope
        if (!joint) return;

            currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

            lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling() {
        return joint != null;
    }

    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }
}
