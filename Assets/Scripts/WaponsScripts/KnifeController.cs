using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KnifeController : WeaponsController
{
    public AudioClip throwSound;  // Sonido de lanzar el cuchillo
    public AudioSource audioSource;  // AudioSource para reproducir el sonido

    protected override void Attack()
    {
        base.Attack();

        // Instanciamos el prefab en tu posición
        GameObject spawnedKnife = Instantiate(weaponData.Prefab, transform.position, Quaternion.identity);

        // Reproducir el sonido de lanzamiento
        if (audioSource != null && throwSound != null)
        {
            audioSource.PlayOneShot(throwSound);
        }

        // Si no te mueves, usamos la última dirección
        Vector3 dir = pm.moveDirection;
        if (dir.sqrMagnitude < 0.01f)
            dir = pm.lastMoveDirection;

        spawnedKnife.GetComponent<KnifeBehavior>().DirectionChecker(dir);
    }
}
