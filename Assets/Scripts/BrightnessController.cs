using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{

    public Slider slider;
    public Light sceneLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneLight.intensity = slider.value;
        Save();
    }

    private void Save()
    {
        throw new NotImplementedException();
    }
}
