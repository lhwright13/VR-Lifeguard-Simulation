using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cannons;
    [SerializeField]
    private GameObject projectile;
    private bool cannonStarted;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject cannon in cannons)
        {
            cannon.transform.rotation = Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - cannon.transform.position + new Vector3(0, 15, 0));
        }
    }

    void FireCannons()
    {
        int cannonNumber = Random.Range(0, cannons.Length);
        GameObject ball = Instantiate(projectile, cannons[cannonNumber].transform.position, cannons[cannonNumber].transform.rotation);
        ball.GetComponent<Rigidbody>().AddForce(cannons[cannonNumber].transform.forward * 5000f);
        StartCoroutine(DestroyBall(ball));
    }

    IEnumerator LoadCannon()
    {
        FireCannons();
        yield return new WaitForSeconds(1f);
        StartCoroutine(LoadCannon());
    }

    IEnumerator DestroyBall(GameObject ball)
    {
        yield return new WaitForSeconds(5f);
        Destroy(ball);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && cannonStarted == false)
        {
            StartCoroutine(LoadCannon());
            cannonStarted = true;
        }
    }

}
