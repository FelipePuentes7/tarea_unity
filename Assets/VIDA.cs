using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public float vida = 100;
    public float tasaDeDisminucion = 1.0f; // Tasa de disminuci�n de vida por cada colisi�n
    public float danoFuego = 5.0f; // Da�o por segundo del fuego
    public string nombreCamaraInicio = "CameraInicio"; // Nombre de la c�mara del men� de inicio

    public Image VIDA3;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "VFX" || other.gameObject.name == "VFX(1)")
        {
            vida -= danoFuego * Time.deltaTime;
            vida = Mathf.Clamp(vida, 0, 100);
            VIDA3.fillAmount = vida / 100;

            if (vida <= 0)
            {
                // Cargar la escena del men� de inicio
                SceneManager.LoadScene(nombreCamaraInicio);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SlimePBR")
        {
            vida -= tasaDeDisminucion; // Reduce la vida
            vida = Mathf.Clamp(vida, 0, 100);
            VIDA3.fillAmount = vida / 100;


        }
    }
}