using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenOption : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _screenModeDropdown;
    [SerializeField] private TMP_Dropdown _resolutionDropdown;


    private int _MaxRefreshRate { get; set; }

    private readonly List<Resolution> resolutions = new();

    List<string> _screenModeOptions = new() {
            "Окно",
            "Полный экран"
        };

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        InitializeResolutions();
        InitializeScreenModes();
        LoadSavedOption();
        UpdateDropdownValues();
    }

    private void LoadSavedOption()
    {
        LoadScreenMode();
        LoadResolution();
    }

    private void LoadResolution()
    {
        string resolutionWidth = "resolutionWidth", resolutionHeight = "resolutionHeight";
        int width = PlayerPrefs.GetInt(resolutionWidth, resolutions[^1].width);
        int height = PlayerPrefs.GetInt(resolutionHeight, resolutions[^1].height);
        SetResolution(width, height);
    }

    private void SetResolution(int width, int height)
    {
        string resolutionWidth = "resolutionWidth", resolutionHeight = "resolutionHeight";
        Screen.SetResolution(width, height, Screen.fullScreenMode);
        PlayerPrefs.SetInt(resolutionWidth, width);
        PlayerPrefs.SetInt(resolutionHeight, height);
        PlayerPrefs.Save();
    }

    private void LoadScreenMode()
    {
        string screenMode = "screenMode";
        int screenModeInt = PlayerPrefs.GetInt(screenMode, (int) FullScreenMode.FullScreenWindow);
        _screenModeDropdown.value = screenModeInt;
        _screenModeDropdown.RefreshShownValue();

        if (screenModeInt == (int) FullScreenMode.FullScreenWindow)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        else
            Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    private void InitializeScreenModes()
    {
        _screenModeDropdown.ClearOptions();
        List<string> screenModeDropdownOptions = _screenModeOptions;
        _screenModeDropdown.AddOptions(screenModeDropdownOptions);
        _screenModeDropdown.RefreshShownValue();
    }

    private void InitializeResolutions()
    {
        var allResolutions = Screen.resolutions;
        _MaxRefreshRate = allResolutions[^1].refreshRate;
        var uniqueResolutions = new List<string>();

        foreach (var resolution in allResolutions)
        {
            if (resolution.refreshRate == _MaxRefreshRate)
            {
                uniqueResolutions.Add($"{resolution.width}x{resolution.height}");
                resolutions.Add(resolution);
            }
        }


        int currentIndex = GetResolutionIndex();

        _resolutionDropdown.ClearOptions();
        _resolutionDropdown.AddOptions(uniqueResolutions);
        _resolutionDropdown.value = currentIndex;
        _resolutionDropdown.RefreshShownValue();

        
    }

    private void UpdateDropdownValues()
    {
        _resolutionDropdown.value = GetResolutionIndex();
        _resolutionDropdown.RefreshShownValue();

        _screenModeDropdown.value = GetScreenModeIndex();
        _screenModeDropdown.RefreshShownValue();
    }

    private int GetResolutionIndex()
    {
        string resolutionWidth = "resolutionWidth", resolutionHeight = "resolutionHeight";
        int currentIndex = 0;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (resolutions[i].width == PlayerPrefs.GetInt(resolutionWidth) &&
                resolutions[i].height == PlayerPrefs.GetInt(resolutionHeight))
            {
                currentIndex = i;
                break;
            }
        }
        return currentIndex;
    }

    private int GetScreenModeIndex()
    {
        string screenMode = "screenMode";
        int screenModeInt = PlayerPrefs.GetInt(screenMode, (int)Screen.fullScreenMode);
        return screenModeInt;
    }






    public void OnResolutionOptionChanged()
    {
        Resolution resolution = resolutions[_resolutionDropdown.value];
        SetResolution(resolution.width, resolution.height);
    }

    public void OnScreenModeChanged()
    {
        string screenMode = "screenMode";
        PlayerPrefs.SetInt(screenMode, _screenModeDropdown.value);
        PlayerPrefs.Save();

        switch(_screenModeDropdown.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            default:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow; 
                break;

        }
    }
}
