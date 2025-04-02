using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GemItem : MonoBehaviour
{
    public int xpValue = 5;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            XPBar xpBar = FindObjectOfType<XPBar>();
            
            if (xpBar != null)
            {
              Debug.Log("El jugador ha recogido la gema de " + xpValue + " xp");
                xpBar.AumentarXP(xpValue);
                Destroy(gameObject);
            }
        }
    }
}
