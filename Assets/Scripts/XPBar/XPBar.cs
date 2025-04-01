using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 100;
        slider.value = 0;
    }

    public void AumentarXP(float val)
    {
        slider.value += val;

        if (slider.value == slider.maxValue)
        {
            GameObject.FindGameObjectWithTag("Pentagram").GetComponent<Pentagram>().ActivePentagram();
            
        }
    }

   

}
