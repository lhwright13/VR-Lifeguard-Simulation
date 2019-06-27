using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleController : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("this works");
            rb.isKinematic = false;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("this works");
            rb.isKinematic = true;
        }
    }
    private void Ontriggerstay(Collision collision)
    {
        Debug.Log("collison");
    }
    private void OntriggerExit(Collision collision)
    {
        Debug.Log("collison done");
        rb.isKinematic = true;
    }
}