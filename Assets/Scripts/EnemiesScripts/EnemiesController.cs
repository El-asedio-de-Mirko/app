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

    [Header("Level Complete Canvas")]
    [SerializeField] private GameObject finishCanvas;

    private float tiempoSiguienteEnemigo;
    private int totalSpawned;
    private int[] spawnCountPerPoint;
    private bool bossSpawned;
    private bool levelCompleted; 

    private void Start()
    {
        spawnCountPerPoint = new int[puntos.Length];
        if (finishCanvas != null)
            finishCanvas.SetActive(false);                 // 3) Asegúrate de empezar oculto
    }

    private void Update()
    {
        // 4) Spawnear enemigos regulares
        if (totalSpawned < maxEnemigosTotales)
        {
            tiempoSiguienteEnemigo += Time.deltaTime;
            if (tiempoSiguienteEnemigo >= tiempoEnemigos)
            {
                tiempoSiguienteEnemigo = 0f;
                CrearEnemigo();
            }
        }
        // 5) Spawnear boss cuando no queden enemigos y aún no se ha spawneado
        else if (!bossSpawned)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                SpawnearBoss();
                bossSpawned = true;
            }
        }
        // 6) Detectar muerte del boss (ya spawneado y ahora no hay más "Enemy")
        else if (bossSpawned && !levelCompleted)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                FinishLevel();
                levelCompleted = true;
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
        if (bossPrefab != null && bossPoint != null)
        {
            GameObject boss = Instantiate(bossPrefab, bossPoint.position, Quaternion.identity);
            boss.tag = "Enemy";  // Asegúrate que el prefab usa este tag
        }
        else
        {
            Debug.LogWarning("Boss prefab o bossPoint no asignado en el inspector.");
        }
    }

    private void FinishLevel()
    {
        if (finishCanvas != null)
            finishCanvas.SetActive(true);  // Mostrar canvas de nivel completado
        else
            Debug.LogWarning("FinishCanvas no asignado en el inspector.");
    }
}
