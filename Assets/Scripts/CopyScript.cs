using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyScript : MonoBehaviour
{
    public InputField inputField;

    public void CopyToClipboard()
    {
        TextEditor textEditor = new TextEditor();                       //Text editor object has text atttribute which can read text
        textEditor.text = inputField.text;
        textEditor.SelectAll();
        textEditor.Copy();                                              
    }

    public void PasteFromClipboard()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.multiline = true;
        textEditor.Paste();
        inputField.text = textEditor.text;
    }

}
