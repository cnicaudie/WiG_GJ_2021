using System.Collections.Generic;
using UnityEngine;

public class BubbleTrap : MonoBehaviour
{
    [SerializeField] private ProtectiveLayers m_protectiveLayers;

    private int m_currentColorIndex;
    public int CurrentColorIndex
    {
        get { return m_currentColorIndex; }
    }

    // =================================

    public void DefineRandomColor()
    {
        MeshRenderer bubbleMeshRenderer = gameObject.GetComponent<MeshRenderer>();

        List<Color> possibleColors = m_protectiveLayers.GetProtectiveLayersColors();

        m_currentColorIndex = m_protectiveLayers.GetRandomLayerIndex(false);

        bubbleMeshRenderer.material.color = possibleColors[m_currentColorIndex];
    }
}
