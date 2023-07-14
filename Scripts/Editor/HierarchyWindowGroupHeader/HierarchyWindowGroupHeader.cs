using System;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class HierarchyWindowGroupHeader : UnityEditor.Editor
{
    // The string that will be used to identify the GameObjects that will have a custom rect
    private const string Marker = "---";
    // The color of the custom rect
    private static readonly Color RectColor = Color.gray;
    
    static HierarchyWindowGroupHeader()
    {
        // Register the delegate to be called for every GameObject in the Hierarchy window
        EditorApplication.hierarchyWindowItemOnGUI += DrawCustomHierarchyItem;
    }

    private static void DrawCustomHierarchyItem(int instanceId, Rect selectionRect)
    {
        // Verify if the instance id is a GameObject, otherwise abort
        if (EditorUtility.InstanceIDToObject(instanceId) is not GameObject item)
            return;
        
        // Verify if the GameObject name starts with the marker string, otherwise abort
        if (!item.name.StartsWith(Marker, StringComparison.Ordinal))
            return;
        
        // Draw a custom colored rect on the gameObject name
        EditorGUI.DrawRect(selectionRect, RectColor);
        
        // Configure the text to be drawn
        var text = item
            .name
            .Replace(Marker, string.Empty)
            .ToUpperInvariant();
        
        // Draw the text on the gameObject name
        EditorGUI.DropShadowLabel(selectionRect, text);
    }
}