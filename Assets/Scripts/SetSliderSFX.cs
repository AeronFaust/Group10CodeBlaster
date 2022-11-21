using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSliderSFX : MonoBehaviour
{
    public Slider sliderObj;
    // Start is called before the first frame update
    void Start()
    {
        sliderObj.value = PersistentData.Instance.GetSFX();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
