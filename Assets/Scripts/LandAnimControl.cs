using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAnimControl : MonoBehaviour
{
    private Animator anim;
    private int choice = 0;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Invoke("FirstAnim", Random.Range(0, 6));
    }

    void FirstAnim()
    {
        choice = Random.Range(1, 5);
        StartAnimation(choice);
        StartCoroutine(RandomNum());
    }

    IEnumerator RandomNum()
    {
        choice = Random.Range(1, 5);
        StartAnimation(choice);
        yield return new WaitForSeconds(3f);
        StartCoroutine(RandomNum());
    }

    void StartAnimation(int DanceChoice)
    {
        anim.SetInteger("choice", DanceChoice);
    }
}
