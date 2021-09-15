using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUtils : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        SoundManager.PlayBackground("game");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowRules()
    {
        // TODO
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
