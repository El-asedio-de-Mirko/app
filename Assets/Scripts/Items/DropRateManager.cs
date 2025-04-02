using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateDropManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate; // Probabilidad de que caiga este objeto
    }

    public List<Drops> drops;

    void OnDestroy()
    {
        float randomNumber = UnityEngine.Random.Range(0f, 100f);
        float cumulativeProbability = 0f;

        foreach (Drops drop in drops)
        {
            cumulativeProbability += drop.dropRate;

            if (randomNumber <= cumulativeProbability) // Se selecciona el primer drop que cumpla la condición
            {
                Instantiate(drop.itemPrefab, transform.position, Quaternion.identity);
                return; // Salimos después de hacer un drop
            }
        }
    }
}
