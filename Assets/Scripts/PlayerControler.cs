using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class PlayerControler : MonoBehaviour
{
    public bool drawnerFound = false;
    public float Speed = 6.5f;
    [SerializeField]
    private GameObject VRcam, hand;
    private bool submerged;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if button pressed and bool is true
        if (SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport").GetState(hand.GetComponent<SteamVR_Behaviour_Pose>().inputSource) && drawnerFound && !submerged)
        {
            transform.Translate(Vector3.Scale(VRcam.transform.forward, new Vector3(Speed * Time.deltaTime, 0, Speed * Time.deltaTime)));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            submerged = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            submerged = false;
        }
    }
}
