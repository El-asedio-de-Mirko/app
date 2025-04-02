using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Slider slider;
    public float maxHealt;
    public CharacterScriptableObjects characterData;
    private void Awake()
    {
        maxHealt = characterData.Health;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxHealt;
        slider.value = maxHealt;
    }

    public void DisminuirVida(float val)
    {
        slider.value -= val;
    }

    public void AumentarVida(float val)
    {
        Debug.Log(slider.value);
        slider.value = val;
        Debug.Log(slider.value);
    }
}
