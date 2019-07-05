using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    private Vector3 lastFramePos, start, des;
    private GameObject victim;
    private bool attackMode, audioStarted;
    private float fraction, speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (!attackMode)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * 5f, 140) - 70, transform.position.y, transform.position.z);
            if (transform.position.x - lastFramePos.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }
            else if (transform.position.x - lastFramePos.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            lastFramePos = transform.position;
        }
        else
        {
            if(Vector3.Distance(transform.position, des) / speed < 1800 && !audioStarted)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
                audioStarted = true;
            }
            if (fraction < 0.95)
            {
                fraction += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(start, des, fraction);
            }
            else if (fraction > 0.95 && victim && victim.tag == "Drowning")
            {
                Destroy(victim);
                GetComponent<AudioSource>().Play();
                GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Stop();
            }
        }
    }
    public void EnableAttckMode()
    {
        if (GameObject.FindGameObjectWithTag("Drowning") && !attackMode)
        {
            victim = GameObject.FindGameObjectWithTag("Drowning");
            start = transform.position;
            des = new Vector3(victim.transform.position.x, transform.position.y, victim.transform.position.z);
            speed = Vector3.Distance(start, des) * 0.0004f;
            transform.LookAt(victim.transform);
            attackMode = true;
            print(speed);
        }
    }
}
