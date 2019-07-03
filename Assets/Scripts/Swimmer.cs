using UnityEngine;
using Valve.VR;

public class Swimmer : MonoBehaviour
{
    public GameObject RightHand, LeftHand;
    public float gain = 1;

    private bool swimming;
    private GameObject activeHand;
    private Vector3 initSwim, initPos;

    void Update()
    {
        StartSwim(RightHand);
        StartSwim(LeftHand);

        StopSwim();

        if (swimming)
        {
            transform.position = initPos + (initSwim - activeHand.transform.localPosition) * gain;
        }
    }

    void StartSwim(GameObject Hand)
    {
        if (SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip").GetStateDown(Hand.GetComponent<SteamVR_Behaviour_Pose>().inputSource) && Hand.GetComponent<SwimmerController>().submerged)
        {
            initSwim = Hand.transform.localPosition;
            initPos = transform.position;
            activeHand = Hand;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            swimming = true;
        }
    }

    void StopSwim()
    {
        if (swimming)
        {
            if (SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip").GetStateUp(activeHand.GetComponent<SteamVR_Behaviour_Pose>().inputSource))
            {
                swimming = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}