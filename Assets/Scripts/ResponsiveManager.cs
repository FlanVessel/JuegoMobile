using System;
using Dino.UtilityTools.Singleton;
using UnityEngine;
using UnityEngine.Events;

public enum DeviceType
{
    Mobile,
    Tablet,
}

public class ResponsiveManager : Singleton<ResponsiveManager>
{
    private Vector2 _lastScreensize;

    public DeviceType CurrentDeviceType { get => GetDeviceTypeByResolution(Screen.width, Screen.height); }
    public bool IsPortrait() => Screen.width < Screen.height;

    public UnityEvent OnScreenSizeChanged { get; private set; } = new UnityEvent();

    private void Onable()
    {
        _lastScreensize = new Vector2(Screen.width, Screen.height);
        Application.onBeforeRender += CheckScreenSizeChange;
    }

    private void OnDisable()
    {
        Application.onBeforeRender -= CheckScreenSizeChange;
    }

    private void CheckScreenSizeChange()
    {
        Vector2 currentScreenSize = new Vector2(Screen.width, Screen.height);
        if (_lastScreensize != currentScreenSize)
        {
            _lastScreensize = currentScreenSize;
            OnScreenSizeChanged?.Invoke();
            Debug.Log($"Screen size changed: {currentScreenSize.x}x{currentScreenSize.y} Orientation: {(IsPortrait() ? "Portrait" : "Landscape")}");
        }
    }

    private DeviceType GetDeviceTypeByResolution(int width, int height)
    {
        float aspectRatio = (float)Math.Max(width, height) / Math.Min(width, height);
        int minDimension = Math.Min(width, height);

        // Example: Tablets usually have aspect ratios closer to 4:3 or 3:2
        if (minDimension >= 600 && aspectRatio < 2.0f)
            return DeviceType.Tablet;
        else
            return DeviceType.Mobile;
    }
}
