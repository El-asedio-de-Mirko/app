using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PossionItem : MonoBehaviour
{
  public int healtRestore;

    private LifeBar lifeBar;

    private void Start()
    {
        lifeBar = FindAnyObjectByType<LifeBar>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) 
        {
            PlayerStats player = col.GetComponent<PlayerStats>();
            
            if (player != null)
            {
                Debug.Log("El jugador ha recogido la poción. Restaurando " + healtRestore + " de vida.");
                player.health += healtRestore;
                lifeBar.AumentarVida(player.health);


                if (player.health > player.characterData.Health)
                {
                    player.health = player.characterData.Health;
                }

                Destroy(gameObject);
            }
        }
    }
}
