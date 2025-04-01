using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilWeapon : MonoBehaviour
{
  public WeaponScriptableObject weaponData;
    protected Vector3 direction;
    public float destroyAfterSeconds;

    //Current stats
    protected float Damage;
    protected float Speed;
    protected float CooldownDuration;
    protected int Pierce;

    void Awake()
    {
        Damage = weaponData.Damage;
        Speed = weaponData.Speed;
        CooldownDuration = weaponData.CooldownDuration;
        Pierce = weaponData.Pierce;
    }
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(1, 1, angle - 90);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy")){
          EnemyStats enemy = col.GetComponent<EnemyStats>();
          enemy.TakeDamage(Damage);
          ReducePierce();
        }
    }

    void ReducePierce(){
        Pierce--;
        if (Pierce <= 0){
            Destroy(gameObject);
        }
    }
}