using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossionItem : MonoBehaviour
{
  public int healtRestore;

  private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) 
        {
            PlayerStats player = col.GetComponent<PlayerStats>();
            
            if (player != null)
            {
                Debug.Log("El jugador ha recogido la poción. Restaurando " + healtRestore + " de vida.");
                player.health += healtRestore;


                if (player.health > player.characterData.Health)
                {
                    player.health = player.characterData.Health;
                }

                Destroy(gameObject);
            }
        }
    }
}
