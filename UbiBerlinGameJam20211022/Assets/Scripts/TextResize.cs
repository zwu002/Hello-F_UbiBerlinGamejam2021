using UnityEngine;
using TMPro;

public class TextResize : MonoBehaviour
{
    public TMP_Text textComponent;
    public RectTransform rectTransform;
    private void Awake()
    {
        textComponent.autoSizeTextContainer = true;

        // Get the size of the text for the given string.
        Vector2 textSize = textComponent.GetPreferredValues();

        // Adjust the button size / scale.
        rectTransform.sizeDelta = textSize;
    }
}
