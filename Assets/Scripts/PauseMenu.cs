using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject miniMap;

    private bool isPaused = false;

    void Start()
    {
        // Si las referencias no fueron asignadas manualmente, buscarlas por nombre
        if (pauseMenuCanvas == null)
            pauseMenuCanvas = GameObject.Find("PauseMenuCanvas");

        if (miniMap == null)
            miniMap = GameObject.Find("MiniMap");

        // Asegurarse de que el menú esté oculto al inicio
        if (pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        if (pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(false);

        if (miniMap != null)
            miniMap.SetActive(true); // Mostrar el minimapa nuevamente

        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        if (pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(true);

        if (miniMap != null)
            miniMap.SetActive(false); // Ocultar el minimapa

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
