using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemiesController : MonoBehaviour
{
    [Header("Spawning Settings")]
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos = 2f;
    [SerializeField] private int maxEnemigosPorPunto = 5;
    [SerializeField] private int maxEnemigosTotales = 20;

    [Header("Boss Settings")]
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform bossPoint;

    private float tiempoSiguienteEnemigo;
    private int totalSpawned;
    private int[] spawnCountPerPoint;
    private bool bossSpawned;

    private void Start()
    {
        // Inicializar contador por punto
        spawnCountPerPoint = new int[puntos.Length];
    }

    private void Update()
    {
        // Si aún falta spawnear enemigos regulares
        if (totalSpawned < maxEnemigosTotales)
        {
            tiempoSiguienteEnemigo += Time.deltaTime;
            if (tiempoSiguienteEnemigo >= tiempoEnemigos)
            {
                tiempoSiguienteEnemigo = 0f;
                CrearEnemigo();
            }
        }
        else if (!bossSpawned)
        {
            // Cuando ya no quedan enemigos en escena, spawnear boss
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                SpawnearBoss();
                bossSpawned = true;
            }
        }
    }

    private void CrearEnemigo()
    {
        // Obtener índices de puntos disponibles
        List<int> disponibles = new List<int>();
        for (int i = 0; i < puntos.Length; i++)
        {
            if (spawnCountPerPoint[i] < maxEnemigosPorPunto)
                disponibles.Add(i);
        }

        // Si ningún punto tiene espacio libre, no spawnear más
        if (disponibles.Count == 0)
            return;

        // Elegir punto aleatorio entre los disponibles
        int idx = disponibles[Random.Range(0, disponibles.Count)];
        Transform punto = puntos[idx];

        // Elegir tipo de enemigo aleatorio
        int enf = Random.Range(0, enemigos.Length);
        GameObject nuevo = Instantiate(enemigos[enf], punto.position, Quaternion.identity);
        nuevo.tag = "Enemy"; // Asegúrate de usar este tag en tus prefabs

        spawnCountPerPoint[idx]++;
        totalSpawned++;
    }

    private void SpawnearBoss()
    {
        // Spawnear el boss en el punto designado
        if (bossPrefab != null && bossPoint != null)
        {
            Instantiate(bossPrefab, bossPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Boss prefab o bossPoint no asignado en el inspector.");
        }
    }
}
