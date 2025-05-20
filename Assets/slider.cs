using UnityEngine;
using UnityEngine.UI;

public class DamageOnCollision : MonoBehaviour
{
    public Slider healthSlider;  // El slider que representa la vida
    public float damageAmount = 10f;  // La cantidad de daño por colisión

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);  // Muestra con qué objeto se está colisionando

        // Verificamos si el objeto que colisiona tiene el tag "Enemy"
        if (collision.gameObject.CompareTag("CARRO"))
        {
            Debug.Log("Colisión con enemigo detectada.");  // Verificación de colisión con el enemigo

            // Verifica que el slider está correctamente asignado
            if (healthSlider != null)
            {
                // Reducimos la vida en el slider
                healthSlider.value -= damageAmount;
                Debug.Log("Vida restante: " + healthSlider.value);  // Muestra la vida restante en el log

                // Si la vida llega a 0 o menos, podemos hacer algo (como destruir el objeto)
                if (healthSlider.value <= 0)
                {
                    Debug.Log("¡El jugador ha sido derrotado!");
                    Destroy(gameObject);  // Puedes cambiar esto por otro comportamiento
                }
            }
            else
            {
                Debug.LogError("¡El Slider de vida no está asignado!");
            }
        }
    }
}