using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    private float timeToFind;
    private float timeToSave;
    private float beginTimeToFind;
    private float beginTimeToSave;
    private float endTimeToFind;
    private float endTimeToSave;

    [SerializeField]
    private Text endText;

    float runDistance;
    float swimDistance;
    float runTimeEst;
    float swimTimeEst;
    float totalTimeEst;
    // Start is called before the first frame update
    void Start()
    {
        endText.gameObject.transform.parent.parent.gameObject.SetActive(false);
    }

    public void StartTimeToFind()
    {
        beginTimeToFind = Time.time;
        GameObject player = GameObject.FindGameObjectWithTag("Head");
        GameObject victim = GameObject.FindGameObjectWithTag("Drowning");
        Vector3 distance = (player.transform.position - victim.transform.position);
        runDistance = Mathf.Abs(distance.x);
        swimDistance = Mathf.Abs(distance.y);
        runTimeEst = runDistance * 5 / 20 + 2;
        swimTimeEst = swimDistance * 17 / 20 + 3;
        totalTimeEst = runTimeEst + swimTimeEst; 
    }
    public void StartTimeToSave()
    {
        beginTimeToSave = Time.time;
    }
    public void StopTimerToFind()
    {
        endTimeToFind = Time.time;
        timeToFind = endTimeToFind - beginTimeToFind;
    }
    public void StopTimerToSave()
    {
        endTimeToSave = Time.time;
        timeToSave = endTimeToSave - beginTimeToSave;
        DisplayTime();
    }
    private void DisplayTime()
    {
        endText.gameObject.transform.parent.parent.gameObject.SetActive(true);
        //endText.text = "It took you " + timeToFind.ToString("f3") + "seconds to find the victim and " + timeToSave.ToString("f3") + "seconds to save the victim";
        if (timeToFind < 20 && timeToSave < totalTimeEst)
        {
            endText.text = "It took you " + timeToFind.ToString("f1") + "sec to find the victim and " + timeToSave.ToString("f1") + "sec to save the victim. Well done!";
        }
        else if (timeToFind < 20 && timeToSave > totalTimeEst)
        {
            endText.text = "It took you " + timeToFind.ToString("f1") + "sec to find the victim and " + timeToSave.ToString("f1") + "sec to save the victim. You need to swim faster!";

        }
        else if (timeToFind > 20 && timeToSave < totalTimeEst)
        {
            endText.text = "It took you " + timeToFind.ToString("f1") + "sec to find the victim and " + timeToSave.ToString("f1") + "sec to save the victim. You need to search better!";

        }
        else if (timeToFind > 20 && timeToSave > totalTimeEst)
        {
            endText.text = "It took you " + timeToFind.ToString("f1") + "sec to find the victim and " + timeToSave.ToString("f1") + "sec to save the victim. Horrible job!";

        }

        GameObject player = GameObject.FindGameObjectWithTag("Head");

        //endText.gameObject.transform.parent.parent.gameObject.transform.position = player.transform.position + player.transform.forward * 3 + player.transform.up *2;
        endText.gameObject.transform.parent.parent.gameObject.transform.position = new Vector3(player.transform.forward.x*3 + player.transform.position.x, 1f,player.transform.forward.z*3 + player.transform.position.z);

        endText.gameObject.transform.parent.parent.gameObject.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, 0);
    }
}
