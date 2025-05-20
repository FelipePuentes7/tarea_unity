using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Asegurate de que el nombre aquí coincida exactamente con la escena en Build Settings
        SceneManager.LoadScene("SimpleNaturePack_Demo");  // Cambia "juego" por el nombre exacto de tu escena
    }
}
