using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] swimmerPrefabs, landPeoplePrefabs;
    [SerializeField]
    private Vector2 waterRangeX, waterRangeY, landRangeX, landRangeY;
    [SerializeField]
    private int numberLand, numberWater;

    // Start is called before the first frame update
    void Start()
    {
        PeopleSpawn(numberLand, landRangeX, landRangeY, landPeoplePrefabs);
        PeopleSpawn(numberWater, waterRangeX, waterRangeY, swimmerPrefabs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PeopleSpawn(int number, Vector2 xRange, Vector2 yRange, GameObject[] peoplePrefabs)
    {
        for(int i = 0; i < number; i++)
        {
            int personChoice = Random.Range(0, peoplePrefabs.Length - 1);
            Vector3 spawnPos = new Vector3(Random.Range(xRange.x, xRange.y), 1, Random.Range(yRange.x, yRange.y));
            Vector3 rot = new Vector3(0, Random.Range(0, 359),0);
            float sphereRadius = 1.2f;

            if (Physics.CheckSphere(spawnPos, sphereRadius))
            {
                i--;
            }
            else
            {
                Instantiate(peoplePrefabs[personChoice], spawnPos + new Vector3 (0,-0.4f,0), Quaternion.Euler(rot));
            }
        }
    }
}
