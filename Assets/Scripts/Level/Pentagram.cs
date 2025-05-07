using UnityEngine;
using UnityEngine.SceneManagement;



using UnityEngine;
using UnityEngine.SceneManagement;

public class Pentagram : MonoBehaviour
{
    private Animator animator;
    private bool bandera;

    [Header("Personalización visual")]
    public Renderer portalRenderer;
    public ParticleSystem portalParticles; 
    public Color colorActivado = new Color(0.3f, 1f, 1f);
    public Color colorInicial = new Color(1f, 0.4f, 0.4f, 0.8f);

    private void Start()
    {
        animator = GetComponent<Animator>();

        
        if (portalParticles != null)
        {
            var colorOverLifetime = portalParticles.colorOverLifetime;
            colorOverLifetime.enabled = true;

            Gradient grad = new Gradient();
            grad.SetKeys(
                new GradientColorKey[] {
                    new GradientColorKey(colorInicial, 0f),  
                    new GradientColorKey(colorInicial, 1f)   
                },
                new GradientAlphaKey[] {
                    new GradientAlphaKey(1f, 0f),
                    new GradientAlphaKey(0f, 1f)
                }
            );

            colorOverLifetime.color = grad;

            
            portalParticles.Clear();
            portalParticles.Play();
        }
    }

    public void ActivePentagram()
    {
        animator.SetTrigger("Activar");
        bandera = true;

        
        if (portalParticles != null)
        {
            var colorOverLifetime = portalParticles.colorOverLifetime;
            colorOverLifetime.enabled = true;

            Gradient grad = new Gradient();
            grad.SetKeys(
                new GradientColorKey[] {
                    new GradientColorKey(colorActivado, 0f),  
                    new GradientColorKey(colorActivado, 1f)   
                },
                new GradientAlphaKey[] {
                    new GradientAlphaKey(1f, 0f),
                    new GradientAlphaKey(0f, 1f)
                }
            );

            colorOverLifetime.color = grad;

           
            portalParticles.Clear();
            portalParticles.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && bandera)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Holis");
        }
    }
}


