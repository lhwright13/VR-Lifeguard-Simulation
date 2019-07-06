using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] people;
    public PlayerControler landNav;
    public InstructionDisp display;
    public  TimeManager timers;
    private GameObject[] smokes;
    bool smokeOn = false;


    void Start()
    {
        StartCoroutine(display.TextDisplay("Use the trigger to highlight the people in distress."));

        //start coroutine for drowning player between 2 and 10 seconds
        Invoke("Drown", Random.Range(2f, 10f));
        //turn the smoke off by default:
        smokes = GameObject.FindGameObjectsWithTag("Smoke");
        foreach(GameObject smoke in smokes)
        {
            smoke.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !smokeOn)
        {
            foreach (GameObject smoke in smokes)
            {
                smoke.SetActive(true);
                smokeOn = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) && smokeOn)
        {
            foreach (GameObject smoke in smokes)
            {
                smoke.SetActive(false);
                smokeOn = false;
            }
        }
    }
    private void Drown()
    {
        //getting the array here because if we get it at the start,
        //no swimmers have been made yet and we get empty array.
        people = GameObject.FindGameObjectsWithTag("Swimmers");

        //getting a random index in the array range
        int personIndex = Random.Range(0, people.Length - 1);
        //changing that swimmers tag to drawning
        people[personIndex].tag = "Drowning";

        //turning them green for testing.
        Animator animator = people[personIndex].GetComponent<Animator>();
        animator.SetBool("drowning", true);

        //turn drowning person toward LG;
        people[personIndex].transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);

        //this will call the timer for how long it takes to spot the person
        timers.StartTimeToFind();
    }
    public void DrawnerFound()
    {
        //lets the player move.
        landNav.drawnerFound = true;
        timers.StopTimerToFind();
        timers.StartTimeToSave();
        StartCoroutine(display.TextDisplay("Use the button below your thumb to run to the victim."));
    }
}
