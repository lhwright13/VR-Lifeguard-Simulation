using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmerController : MonoBehaviour
{
    public bool submerged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            submerged = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            submerged = false;
        }
    }
}
