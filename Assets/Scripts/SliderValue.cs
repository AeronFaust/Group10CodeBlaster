using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue: MonoBehaviour {
  Text sliderValue;
  void Start() 
  {
    sliderValue = GetComponent < Text > ();
  }

  public void textUpdate(float value) 
  {
    sliderValue.text = value.ToString("0.00");
  }
}