using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioNivel : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject.FindGameObjectWithTag("Pentagram").GetComponent<Pentagram>().EnemigoEliminado();
            
        }

    }
}