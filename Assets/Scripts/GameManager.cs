using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] people;

    void Start()
    {
        //start coroutine for drowning player between 2 and 10 seconds
        Invoke("Drown", Random.Range(2f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Renderer rend = people[personIndex].GetComponent<Renderer>();
        //rend.material.SetColor("_Color", Color.green);
    }

}
