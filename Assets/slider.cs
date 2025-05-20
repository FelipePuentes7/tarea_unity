using UnityEngine;
using UnityEngine.UI;

public class DamageOnCollision : MonoBehaviour
{
    public Slider healthSlider;  // El slider que representa la vida
    public float damageAmount = 10f;  // La cantidad de da�o por colisi�n

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisi�n detectada con: " + collision.gameObject.name);  // Muestra con qu� objeto se est� colisionando

        // Verificamos si el objeto que colisiona tiene el tag "Enemy"
        if (collision.gameObject.CompareTag("CARRO"))
        {
            Debug.Log("Colisi�n con enemigo detectada.");  // Verificaci�n de colisi�n con el enemigo

            // Verifica que el slider est� correctamente asignado
            if (healthSlider != null)
            {
                // Reducimos la vida en el slider
                healthSlider.value -= damageAmount;
                Debug.Log("Vida restante: " + healthSlider.value);  // Muestra la vida restante en el log

                // Si la vida llega a 0 o menos, podemos hacer algo (como destruir el objeto)
                if (healthSlider.value <= 0)
                {
                    Debug.Log("�El jugador ha sido derrotado!");
                    Destroy(gameObject);  // Puedes cambiar esto por otro comportamiento
                }
            }
            else
            {
                Debug.LogError("�El Slider de vida no est� asignado!");
            }
        }
    }
}