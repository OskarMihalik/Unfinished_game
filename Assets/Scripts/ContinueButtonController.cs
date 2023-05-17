using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButtonController : MonoBehaviour
{
    public DialogManager dialogManager;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogManager.NextSentence();
        }       
    }
}
