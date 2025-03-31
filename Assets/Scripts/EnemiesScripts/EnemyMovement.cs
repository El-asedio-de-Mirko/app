using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;

    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.Speed * Time.deltaTime);
    }
}
