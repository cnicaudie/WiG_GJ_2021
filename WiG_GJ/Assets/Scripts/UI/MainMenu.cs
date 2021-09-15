using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_mainMenu;

    [SerializeField] private GameObject m_instructions;

    // =================================

    private void Start()
    {
        BackToMenu();
    }

    public void ShowInstructions()
    {
        m_mainMenu.SetActive(false);
        m_instructions.SetActive(true);
    }

    public void BackToMenu()
    {
        m_mainMenu.SetActive(true);
        m_instructions.SetActive(false);
    }
}
