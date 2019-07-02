using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionDisp : MonoBehaviour
{
    private TextMeshPro textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshPro>();
        textMesh.text = "Welcome to the VBP";
    }

    // Update is called once per frame
    public IEnumerator TextDisplay(string text)
    {
        textMesh.text = text;
        yield return new WaitForSeconds(10);
        textMesh.text = "";
    }
}
