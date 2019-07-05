using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorColorChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
