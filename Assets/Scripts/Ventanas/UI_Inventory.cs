using NaughtyAttributes;
using UnityEngine;

public class UI_Inventory : UI_Window
{
    [BoxGroup("Inventory")]
    [Header("Inventory Settings")]
    [SerializeField] private GameObject itemPrefap;
    [SerializeField] private GameObject content;

    [Button]
    private void SpamItem()
    {
        GameObject item = Instantiate(itemPrefap, content.transform);
    }
}
