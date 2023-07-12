using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyButton : MonoBehaviour
{
    public void Copy()
    {
        GUIUtility.systemCopyBuffer = "austin.williambrooks@gmail.com";
    }
}
