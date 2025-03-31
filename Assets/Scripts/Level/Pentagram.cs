using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pentagram : MonoBehaviour
{
    private int cantidadEnemigos;
    private int enemigosEliminados;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cantidadEnemigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemigosEliminados = 0;
        Debug.Log(cantidadEnemigos);
        Debug.Log(enemigosEliminados);
        

    }

    private void ActivePentagram()
    {
        animator.SetTrigger("Activar");
    }

    public void EnemigoEliminado()
    {
        enemigosEliminados += 1;
        Debug.Log(enemigosEliminados);
        if(enemigosEliminados == cantidadEnemigos)
        {
            ActivePentagram();
           
        }
    }



    //En la parte del codigo en donde se elimine el enemigo pon lo siguiente
    // GameObject.FindGameObjectWithTag("Pentagram").GetComponent<Pentagram>().EnemigoEliminado();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && enemigosEliminados == cantidadEnemigos)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Holis");
        }
    }
}
