using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectiveLayersCanvas : MonoBehaviour
{
    [SerializeField] Slider firstLayerSlider;
    [SerializeField] Slider secondLayerSlider;
    [SerializeField] Slider thirdLayerSlider;
    [SerializeField] Slider fourthLayerSlider;
    [SerializeField] Slider fifthLayerSlider;

    ProtectiveLayers protectiveLayers;
    void Start()
    {
        protectiveLayers = FindObjectOfType<ProtectiveLayers>();
    }
    void Update()
    {
        firstLayerSlider.value = protectiveLayers.firstLayer;
        secondLayerSlider.value = protectiveLayers.secondLayer;
        thirdLayerSlider.value = protectiveLayers.thirdLayer;
        fourthLayerSlider.value = protectiveLayers.fourthLayer;
        fifthLayerSlider.value = protectiveLayers.fifthLayer;
    }
}
