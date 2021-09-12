using System.Collections.Generic;
using UnityEngine;

public class ProtectiveLayers : MonoBehaviour
{
    public const float layerMaxValue = 100f;

    public const int numberOfLayers = 5;

    [SerializeField] private List<float> m_protectiveLayers;

    [SerializeField] private List<Color> m_protectiveLayersColors;

    private bool m_isAlive = true;
    public bool IsAlive
    {
        get { return m_isAlive; }
    }

    private float m_hitCooldown = 2f;
    private float m_lastHitTime = 0f;

    public delegate void UpdateLayerValue(int layerIndex);
    public event UpdateLayerValue OnLayerValueChange;

    // =================================

    private void Awake()
    {
        InitLayers();
        InitColors();
    }

    private void Update()
    {
        m_lastHitTime += Time.deltaTime;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        float effectValue = 5f;

        if (m_lastHitTime > m_hitCooldown)
        {
            if (hit.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Player bumped into obstacle !");

                int randomLayerIndex = Random.Range(0, numberOfLayers);

                ReduceLayers(effectValue, randomLayerIndex);

                m_lastHitTime = 0f;
            }
            else if (hit.gameObject.CompareTag("Enemy"))
            {
                GameObject enemyGameObject = hit.transform.root.gameObject;
                Enemy enemy = enemyGameObject.GetComponent<Enemy>();
                int currentColorIndex = enemy.GetCurrentColorIndex();

                if (enemy.IsTrappedInBubble)
                {
                    Debug.Log("Player popped the bubble trap !");

                    Destroy(enemyGameObject);

                    AddToLayers(effectValue, currentColorIndex);
                }
                else
                {
                    Debug.Log("Player bumped into an enemy !");

                    ReduceLayers(effectValue, currentColorIndex);
                }

                m_lastHitTime = 0f;
            }
        }

    }

    private void InitLayers()
    {
        for (int i = 0; i < numberOfLayers; i++)
        {
            m_protectiveLayers.Add(0f);
        }
    }

    private void InitColors()
    {
        Color red = new Color(1f, 0f, 0f, 0.5f);
        Color yellow = new Color(1f, 0.92f, 0.016f, 0.5f);
        Color cyan = new Color(0f, 1f, 1f, 0.5f);
        Color magenta = new Color(1f, 0f, 1f, 0.5f);
        Color green = new Color(0f, 1f, 0f, 0.5f);

        m_protectiveLayersColors = new List<Color>(numberOfLayers);
        m_protectiveLayersColors.Add(red);
        m_protectiveLayersColors.Add(yellow);
        m_protectiveLayersColors.Add(cyan);
        m_protectiveLayersColors.Add(magenta);
        m_protectiveLayersColors.Add(green);
    }

    public void AddToLayers(float amount, int layerIndex)
    {
        m_protectiveLayers[layerIndex] += amount;
        CheckIfLayersAllFilled();

        if (OnLayerValueChange != null)
        {
            OnLayerValueChange(layerIndex);
        }
    }

    public void ReduceLayers(float amount, int layerIndex)
    {
        m_protectiveLayers[layerIndex] -= amount;
        CheckIfLayersAllEmpty();

        if (OnLayerValueChange != null)
        {
            OnLayerValueChange(layerIndex);
        }
    }

    public List<Color> GetProtectiveLayersColors()
    {
        return m_protectiveLayersColors;
    }

    public float GetLayerValue(int layerIndex)
    {
        return m_protectiveLayers[layerIndex];
    }

    public List<int> GetNotFilledLayers()
    {
        List<int> notFilledLayerIndexes = new List<int>();

        for (int i = 0; i < m_protectiveLayers.Count; i++)
        {
            if (m_protectiveLayers[i] < layerMaxValue)
            {
                notFilledLayerIndexes.Add(i);
            }
        }

        return notFilledLayerIndexes;
    }

    private void CheckIfLayersAllFilled()
    {
        bool hasFilledAllLayers = true;
        
        foreach (float layer in m_protectiveLayers)
        {
            if (layer < layerMaxValue)
            {
                hasFilledAllLayers = false;
            }
        }

        if (hasFilledAllLayers)
        {
            Debug.Log("Player won !");

            // TODO : End menu ?
        }
    }

    private void CheckIfLayersAllEmpty()
    {
        bool allLayersEmpty = true;

        foreach (float layer in m_protectiveLayers)
        {
            if (layer > 0f)
            {
                allLayersEmpty = false;
            }
        }

        if (allLayersEmpty)
        {
            Debug.Log("Player lost !");

            // TODO : Restart menu (or automatic restart ?)
            m_isAlive = false;
        }
    }
}
