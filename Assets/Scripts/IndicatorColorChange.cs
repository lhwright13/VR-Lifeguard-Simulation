using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorColorChange : MonoBehaviour
{
    private bool saved = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !saved)
        {
            GetComponent<Renderer>().material.color = new Color(0,1,0,0.5f);
            GameObject drowner = GameObject.FindGameObjectWithTag("Drowning");
            Animator animator = drowner.GetComponent<Animator>();
            animator.SetBool("drowning", false);
            drowner.tag = "Swimmers";
            saved = true;
        }
    }
}
