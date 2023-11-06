using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionSelector : MonoBehaviour
{
    [SerializeField] private Vector2[] resolutions;
    [SerializeField] private int[] fpsList;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown fpsDropdown;
    [SerializeField] private Toggle fullScreenTogle;
    [SerializeField] private Button applyButton;

    private void Awake()
    {
        applyButton.onClick.AddListener(ApplySettings);
    }

    private void ApplySettings()
    {
        Screen.SetResolution((int)resolutions[resolutionDropdown.value].x, (int)resolutions[resolutionDropdown.value].y,
           fullScreenTogle.isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed,
           fpsList[fpsDropdown.value]);
    }

    private void OnDestroy()
    {
        applyButton.onClick.RemoveListener(ApplySettings);
    }
}
