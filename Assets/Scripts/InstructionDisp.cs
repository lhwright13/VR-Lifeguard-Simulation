using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionDisp : MonoBehaviour
{
    public TextMesh textMesh;
    [SerializeField]
    private Text directionsText;

    // Start is called before the first frame update
    void Start()
    {
       // directionsText.text
        //textMesh = GetComponent<TextMesh>();
        //textMesh.text = "Welcome to the VBP";
    }

    // Update is called once per frame
    public IEnumerator TextDisplay(string text)
    {
        textMesh.text = text;
        yield return new WaitForSeconds(10);
        textMesh.text = "";
    }
}
