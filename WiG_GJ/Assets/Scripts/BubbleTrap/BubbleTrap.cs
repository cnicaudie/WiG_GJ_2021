using System.Collections.Generic;
using UnityEngine;

public class BubbleTrap : MonoBehaviour
{
    private int m_currentColorIndex;
    public int CurrentColorIndex
    {
        get { return m_currentColorIndex; }
    }

    // =================================

    public void DefineRandomColor()
    {
        ProtectiveLayers protectiveLayers = FindObjectOfType<ProtectiveLayers>();

        List<Color> possibleColors = protectiveLayers.GetProtectiveLayersColors();

        m_currentColorIndex = protectiveLayers.GetRandomLayerIndex(false);

        MeshRenderer bubbleMeshRenderer = gameObject.GetComponent<MeshRenderer>();

        bubbleMeshRenderer.material.color = possibleColors[m_currentColorIndex];
    }
}
