using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
    // Start is called before the first frame update
    private GameObject[] people;

    void Start()
    {
        people = GameObject.FindGameObjectsWithTag("Swimmers");
        //init player location
        //start coroutine for drowning player
        Invoke("Drown", Random.Range(2f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Drown()
    {
        people[Random.Range(0, people.Length - 1)].tag = "Drowning";
    }

}
