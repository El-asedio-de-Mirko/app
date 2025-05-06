using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Characters/Character")]
public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObjects characterData;

    private LifeBar lifeBar;
    [SerializeField] private GameOverMenu gameOverMenu;

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

    private void Start()
    {
        lifeBar = FindAnyObjectByType<LifeBar>();
     
    }

    public void TakeDamage(float damage)
  {
    health -= damage;
    lifeBar.DisminuirVida(damage);
    if (health <= 0)
    {
      KillPlayer();
    }
  }

  public void KillPlayer()
  {
    Debug.Log("Player is dead!");
    gameOverMenu.GameOver();

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

