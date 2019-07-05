using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TelescopeControler : MonoBehaviour
{
    [SerializeField]
    GameObject TelescopePrefab;

    private GameObject telescope;

    // Start is called before the first frame update
    void Start()
    {

        telescope = Instantiate(TelescopePrefab, transform.position, transform.rotation, transform);
    }
    // Update is called once per frame
    void Update()
    {

        if (SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch").GetState(GetComponent<SteamVR_Behaviour_Pose>().inputSource))
        {
            //if left trigger is hit then build the telescope
            telescope.SetActive(true);
        }
        else
        { 
            // else Destroy it
            telescope.SetActive(false);
        }
    }
}
