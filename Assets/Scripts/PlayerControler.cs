using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class PlayerControler : MonoBehaviour
{
    public bool drawnerFound = false;
    public float Speed = 5;
    [SerializeField]
    private GameObject VRcam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if button pressed and bool is true
        if (SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport").GetState(GetComponent<Valve.VR.InteractionSystem.Hand>().handType) && drawnerFound)
        {
            transform.parent.parent.Translate(Vector3.Scale(VRcam.transform.forward, new Vector3(Speed * Time.deltaTime, 0, Speed * Time.deltaTime)));
        }
    }
}
