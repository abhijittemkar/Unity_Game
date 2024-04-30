using UnityEngine;
using TMPro;

public class MonitorAndUpdateText : MonoBehaviour
{
    public TextMeshProUGUI sourceTextMeshPro; // Drag your source TextMeshPro GameObject here in the Unity Editor.
    public TextMeshProUGUI destinationTextMeshPro; // Drag your destination TextMeshPro GameObject here.

    private string previousTextValue;

    void Start()
    {
        // Check if both TextMeshPro components are assigned.
        if (sourceTextMeshPro != null && destinationTextMeshPro != null)
        {
            // Initialize the previous text value.
            previousTextValue = sourceTextMeshPro.text;
        }
        else
        {
            Debug.LogWarning("TextMeshPro components are not assigned!");
        }
    }

    void Update()
    {
        // Check if both TextMeshPro components are assigned.
        if (sourceTextMeshPro != null && destinationTextMeshPro != null)
        {
            // Check if the text value has changed.
            if (sourceTextMeshPro.text != previousTextValue)
            {
                // Update the destination TextMeshPro text with the source text value.
                destinationTextMeshPro.text = $"Final {sourceTextMeshPro.text}";

                // Update the previous text value.
                previousTextValue = sourceTextMeshPro.text;
            }
        }
    }
}
