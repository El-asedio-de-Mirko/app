using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CambioNivel : MonoBehaviour
{
    // Start is called before the first frame update


    private XPBar xpBar;

    private void Start()
    {
        xpBar = FindAnyObjectByType<XPBar>();
    }
    private void Update()
    {

    }
}