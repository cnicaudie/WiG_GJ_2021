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
        List<int> notFilledLayerIndexes = m_protectiveLayers.GetNotFilledLayers();
        int tempIndex = Random.Range(0, notFilledLayerIndexes.Count);

        m_currentColorIndex = notFilledLayerIndexes[tempIndex];
        bubbleMeshRenderer.material.color = possibleColors[m_currentColorIndex];
    }
}
