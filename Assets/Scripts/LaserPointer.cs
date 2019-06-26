using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [SerializeField]
    Material laserMaterial;
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = laserMaterial;
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100f))
        {
            //call the laser to be made
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

            //if get the click key down 
            if (hit.transform.gameObject.tag == "drowning")
            {
                //stuff
            }

        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward*100f);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
// 