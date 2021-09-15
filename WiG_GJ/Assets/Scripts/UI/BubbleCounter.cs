using UnityEngine;
using UnityEngine.UI;

public class BubbleCounter : MonoBehaviour
{
    [SerializeField] private Gun m_gun;

    [SerializeField] private Text m_bubbleCount;

    // =================================

    private void Start()
    {
        UpdateBubbleCount();

        m_gun.OnBulletNumberChange += UpdateBubbleCount;
    }

    private void UpdateBubbleCount()
    {
        m_bubbleCount.text = m_gun.GetAmmunitionCount().ToString();
    }
}
