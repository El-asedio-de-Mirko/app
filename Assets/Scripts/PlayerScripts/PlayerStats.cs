using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Characters/Character")]
public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObjects characterData;

    //Player Stats
    public float health;
    public float recovery;
    public float might;

  void Awake()
  {
    // Initialize player stats from character data
    health = characterData.Health;
    recovery = characterData.Recovery;
    might = characterData.Might;
  }

  public void TakeDamage(float damage)
  {
    health -= damage;
    if (health <= 0)
    {
      KillPlayer();
    }
  }

  public void KillPlayer()
  {
    Debug.Log("Player is dead!");
  }

  public void RestoreHealth(float amount)
  {
    if (health < characterData.Health)
    {
      health += amount;
      if (health > characterData.Health)
      {
        health = characterData.Health;
      }
    }
  }
}

