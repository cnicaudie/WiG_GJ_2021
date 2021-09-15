using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_gameOverMenuCanvas;
    [SerializeField] private GameObject m_gameWonMenuCanvas;

    [SerializeField] private GameObject m_protectiveLayersCanvas;
    [SerializeField] private GameObject m_bubbleCountCanvas;

    private ProtectiveLayers m_protectiveLayers;

    // =================================

    private void Start()
    {
        m_protectiveLayers = FindObjectOfType<ProtectiveLayers>();
        m_protectiveLayers.OnPlayerDeath += GameOver;
        m_protectiveLayers.OnPlayerWin += GameWon;

        InitUI();
    }

    private void InitUI()
    {
        SoundManager.PlayBackground("game");

        m_protectiveLayersCanvas.SetActive(true);
        m_bubbleCountCanvas.SetActive(true);

        m_gameOverMenuCanvas.SetActive(false);
        m_gameWonMenuCanvas.SetActive(false);
    }

    private void GameOver()
    {
        SoundManager.PlayBackground("menu");

        m_gameOverMenuCanvas.SetActive(true);

        m_protectiveLayersCanvas.SetActive(false);
        m_bubbleCountCanvas.SetActive(false);
    }

    private void GameWon()
    {
        m_gameWonMenuCanvas.SetActive(true);

        m_protectiveLayersCanvas.SetActive(false);
        m_bubbleCountCanvas.SetActive(false);
    }
}
