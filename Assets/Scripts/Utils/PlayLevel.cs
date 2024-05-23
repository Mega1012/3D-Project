using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayLevel : MonoBehaviour
{
    public TextMeshProUGUI uiTextName;

    private void Start()
    {
        SaveManager.instance.FileLoaded += OnLoad;
    }

    public void OnLoad(SaveSetup setup)
    {
        uiTextName.text = "Load Level " + (setup.lastLevel + 1);
    }

    private void OnDestroy()
    {
        SaveManager.instance.FileLoaded -= OnLoad;

    }
}