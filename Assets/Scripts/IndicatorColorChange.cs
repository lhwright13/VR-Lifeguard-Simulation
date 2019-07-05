using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorColorChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            GetComponent<Renderer>().material.color = new Color(0,1,0,0.5f);
            Animator animator = GameObject.FindGameObjectWithTag("Drowning").GetComponent<Animator>();
            animator.SetBool("drowning", false);
        }
    }
}
