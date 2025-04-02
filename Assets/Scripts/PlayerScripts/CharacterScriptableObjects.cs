using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Characters/Character")]
public class CharacterScriptableObjects : ScriptableObject
{

  [SerializeField]
  GameObject startingWeapon;
  public GameObject StartingWeapon { get => startingWeapon; set => startingWeapon = value; }

  [SerializeField]
  float health;
  public float Health { get => health; set => health = value; }

  [SerializeField]
  float recovery;
  public float Recovery { get => recovery; set => recovery = value; }

  [SerializeField]
  float speed;
  public float Speed { get => speed; set => speed = value; }

  [SerializeField]
  float might;
  public float Might { get => might; set => might = value; }

  [SerializeField]
  float projectilSpeed;
  public float ProjectilSpeed { get => projectilSpeed; set => projectilSpeed = value; }
}
