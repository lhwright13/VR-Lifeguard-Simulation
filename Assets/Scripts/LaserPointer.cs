﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [SerializeField]
    Material laserMaterial;

    [SerializeField]
    GameObject laserPointPrefab, indicatorPrefab;



    private GameObject laserPoint;
    private GameObject indicator;
    private bool notFound = true;
    
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = laserMaterial;
        lineRenderer.widthMultiplier = 0.02f;
        lineRenderer.positionCount = 2;

        laserPoint = Instantiate(laserPointPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100f))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

            //call the Laser point to be made
            laserPoint.transform.position = hit.point;

            //if get the click key down 
            if (hit.transform.gameObject.tag == "Drowning" && notFound)
            {
                indicator = Instantiate(indicatorPrefab);
                indicator.transform.position = hit.transform.position + new Vector3(0,1,0);
                //call coroutine in game manager after hit.
                notFound = false;
            }
            

        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward*100f);
            lineRenderer.material = laserMaterial;
            lineRenderer.widthMultiplier = 0.02f;
            lineRenderer.positionCount = 2;
            laserPoint.transform.position = transform.position + transform.forward * 100f;
        }
    }
}
// 