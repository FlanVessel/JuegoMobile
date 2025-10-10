using System.Collections.Generic;
using Dino.UtilityTools.Singleton;
using NaughtyAttributes;
using UnityEngine;

public class UI_Manager : Singleton<UI_Manager>
{
    [SerializeField] private List<UI_Window> uiWindows = new List<UI_Window>();

    public void ShowUI(string windowUI)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowID == windowUI)
            {
                window.Show();
                return;
            }
        }
        Debug.LogWarning($"UI Window with name {windowUI} not found.");
    }

    public void HideUI(string windowUI)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowID == windowUI)
            {
                window.Hide();
                return;
            }
        }
        Debug.LogWarning($"UI Window with name {windowUI} not found.");
    }

    public void HideAllUI()
    {
        foreach (var window in uiWindows)
        {
            window.Hide();
        }
    }

    public UI_Window GetUIWindow(string windowUI)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowID == windowUI)
            {
                return window;
            }
        }
        Debug.LogWarning($"UI Window with name {windowUI} not found.");
        return null;
    }

    #region Editor
    [Button]
    private void GetAllUIWindows()
    {
        uiWindows.Clear();
        UI_Window[] windows = FindObjectsByType<UI_Window>(FindObjectsSortMode.InstanceID);
        uiWindows.AddRange(windows);
    }

    #endregion

}

public static class WindowsIDs
{
    public static string Popup = "PopupUI";
    public static string UI_Inventory = "InventoryUI";
    public static string UI_Principal = "PrincipalMenu";
    public static string UI_Settings = "Settings";
    public static string UI_Profile = "Profile";
    public static string UI_Notes = "Notes";
    public static string UI_Granjas = "Granjas";
    public static string UI_Tienda = "Tienda";
    public static string UI_ElegirGranja = "ElegirGranja";
    public static string UI_ElegirTienda = "ElegirTienda";


}
