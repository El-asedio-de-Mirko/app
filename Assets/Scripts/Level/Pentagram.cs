using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pentagram : MonoBehaviour
{
    
    private Animator animator;
    private bool bandera;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivePentagram()
    {
        animator.SetTrigger("Activar");
        bandera = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && bandera)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Holis");
        }
    }
}
