using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectiveLayersCanvas : MonoBehaviour
{
    [SerializeField] private ProtectiveLayers m_protectiveLayers;

    [SerializeField] private List<Slider> m_layersSliders;

    // =================================

    private void Start()
    {
        // Event subscription
        m_protectiveLayers.OnLayerValueChange += UpdateSliderProgress;

        InitSliders();
    }

    private void InitSliders()
    {
        List<Color> possibleColors = m_protectiveLayers.GetProtectiveLayersColors();

        for (int i = 0; i < possibleColors.Count; i++)
        {
            Slider slider = m_layersSliders[i];

            Image fillImage = slider.GetComponentsInChildren<Image>()[1];
            fillImage.color = possibleColors[i];

            slider.maxValue = ProtectiveLayers.layerMaxValue;
            slider.value = m_protectiveLayers.GetLayerValue(i);
        }
    }

    public void UpdateSliderProgress(int layerIndex)
    {
        m_layersSliders[layerIndex].value = m_protectiveLayers.GetLayerValue(layerIndex);
    }
}
