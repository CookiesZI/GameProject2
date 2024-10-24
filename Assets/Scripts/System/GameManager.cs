using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Damage Text Settings")]
    public Canvas damageTextCanvas;
    public float textFontSize = 20;
    public TMP_FontAsset textFont;
    public Camera referenceCamera;

    IEnumerator GenerateFloatingTextCoroutine(string text, Transform target, float duration = 1f, float speed = 50f)
    {
        // Start generating the floating text.
        GameObject textObj = new GameObject("Damage Floating Text");

        RectTransform rect = textObj.AddComponent<RectTransform>();
        TextMeshProUGUI
     tmPro = textObj.AddComponent<TextMeshProUGUI>();

        tmPro.text = text;
        tmPro.horizontalAlignment = HorizontalAlignmentOptions.Center;
        tmPro.verticalAlignment = VerticalAlignmentOptions.Middle;
        tmPro.fontSize = textFontSize;

        if (textFont) tmPro.font = textFont;

        rect.position = referenceCamera.WorldToScreenPoint(target.position);


        // Makes sure this is destroyed after the duration finishes.
        Destroy(textObj, duration);

        // Parent the generated text object to the canvas.
        textObj.transform.SetParent(instance.damageTextCanvas.transform);

        // Pan the text upwards and fade it away over time.
        WaitForEndOfFrame w = new WaitForEndOfFrame();

        float
     t = 0;
        float yOffset = 0;

        while (t < duration)

        {
            yield return w;

            t += Time.deltaTime;

            // Fade the text to the right alpha value.
            tmPro.color = new Color(tmPro.color.r, tmPro.color.g, tmPro.color.b, 1 - t / duration);

            // Pan the text upwards.
            yOffset += speed * Time.deltaTime;

            rect.position = referenceCamera.WorldToScreenPoint(target.position + new Vector3(0, yOffset));
        }
    }

        public static void GenerateFloatingText(string text, Transform target, float duration = 1f, float speed = 1f)
    {
        // If the canvas is not set, end the function so we don't
        // generate any floating text.
        if (!instance.damageTextCanvas) return;

        // Find a relevant camera that we can use to convert the world
        // position to a screen position.
        if (!instance.referenceCamera) instance.referenceCamera = Camera.main;

        instance.StartCoroutine(instance.GenerateFloatingTextCoroutine(text, target, duration,speed));
    }
}
