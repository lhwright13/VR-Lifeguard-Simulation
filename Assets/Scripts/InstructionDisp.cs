using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionDisp : MonoBehaviour
{
    [SerializeField]
    private Text directionsText;

    // Start is called before the first frame update
    void Awake()
    {
        directionsText.text = "Welcome to the VBP";
    }

    // Update is called once per frame
    public IEnumerator TextDisplay(string text)
    {
        directionsText.gameObject.transform.parent.parent.gameObject.SetActive(true);
        directionsText.text = text;
        yield return new WaitForSeconds(10f);
        directionsText.gameObject.transform.parent.parent.gameObject.SetActive(false);
    }
}
