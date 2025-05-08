using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraculaBar : MonoBehaviour
{
    public Slider slider;
    public float maxLife;
  
    private void Awake()
    {
        maxLife = 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxLife;
        slider.value = maxLife;
    }

    public void DisminuirVida(float val)
    {
        slider.value -= val;
    }

}
