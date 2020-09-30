using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextLocalizerUI : MonoBehaviour
{
    Text textField;

    public LocalisedString localizedString;

    void Start()
    {
        textField = GetComponent<Text>();
        SetTextField(localizedString.value);
    }

    public void SetTextField(string value)
    {
        string valueLocal = value;
        valueLocal = valueLocal.TrimStart(' ', '"');
        valueLocal = valueLocal.Replace("\"", "");
        textField.text = valueLocal;
    }
}
