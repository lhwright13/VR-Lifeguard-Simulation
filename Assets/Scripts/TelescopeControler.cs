using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TelescopeControler : MonoBehaviour
{
    [SerializeField]
    GameObject TelescopePrefab, BeachBallPrefab;

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
            if (SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip").GetStateDown(GetComponent<SteamVR_Behaviour_Pose>().inputSource))
            {
                GameObject ball = Instantiate(BeachBallPrefab, transform.position - transform.up * 2, transform.rotation);
                ball.GetComponent<Rigidbody>().AddForce(-transform.up * 10000f);
                StartCoroutine(DestroyBall(ball));
            }
        }
        else
        { 
            // else Destroy it
            telescope.SetActive(false);
        }
    }

    IEnumerator DestroyBall(GameObject ball)
    {
        yield return new WaitForSeconds(5f);
        Destroy(ball);
    }
}
