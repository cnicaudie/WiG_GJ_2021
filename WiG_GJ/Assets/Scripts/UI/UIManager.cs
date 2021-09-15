using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_gameOverMenuCanvas;

    [SerializeField] private GameObject m_protectiveLayersCanvas;

    private ProtectiveLayers m_protectiveLayers;

    // =================================

    private void Start()
    {
        m_protectiveLayers = FindObjectOfType<ProtectiveLayers>();
        m_protectiveLayers.OnPlayerDeath += GameOver;

        InitUI();
    }

    private void InitUI()
    {
        SoundManager.PlayBackground("game");

        m_protectiveLayersCanvas.SetActive(true);
        m_gameOverMenuCanvas.SetActive(false);
    }

    private void GameOver()
    {
        SoundManager.PlayBackground("menu");

        m_gameOverMenuCanvas.SetActive(true);
        m_protectiveLayersCanvas.SetActive(false);
    }
}
