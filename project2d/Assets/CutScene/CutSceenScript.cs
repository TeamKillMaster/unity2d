using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceenScript : MonoBehaviour
{
    int CutSceenProcess = 0;

    public bool CutSceenNow = false;
    public CutSceenText CutSceenText;
    // Start is called before the first frame update
    void Start()
    {
        CutSceenText.StartDialogue(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CutSceenText.StartDialogue(1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            CutSceenText.StartDialogue(2);
        }

    }
}
