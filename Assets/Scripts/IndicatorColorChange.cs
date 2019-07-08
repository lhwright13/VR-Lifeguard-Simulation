using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorColorChange : MonoBehaviour
{
    public TimeManager timers;
    public bool saved = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !saved)
        {
            GetComponent<Renderer>().material.color = new Color(0,1,0,0.5f);
            StartCoroutine(Fade());
            GameObject drowner = GameObject.FindGameObjectWithTag("Drowning");
            Animator animator = drowner.GetComponent<Animator>();
            animator.SetBool("drowning", false);
            drowner.tag = "Swimmers";
            saved = true;

            GameObject Manager = GameObject.Find("Managers");
            TimeManager time = (TimeManager)Manager.GetComponent(typeof(TimeManager));
            time.StopTimerToSave();
        }
    }

    IEnumerator Fade()
    {
        for (float f = 2f; f >= 0; f -= 0.1f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f-1.5f;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(.1f);
        }
        transform.gameObject.SetActive(false);
    }
}
