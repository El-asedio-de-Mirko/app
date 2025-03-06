using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilWeapon : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir.normalized; // Normalizamos para evitar problemas con diferentes velocidades

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calcula el ángulo correcto
        transform.rotation = Quaternion.Euler(1, 1, angle - 90); // Aplica la rotación
    }
}
