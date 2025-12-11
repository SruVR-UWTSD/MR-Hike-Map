using UnityEngine;
using TMPro;
using System.Collections;

public class TitleSequenceManager : MonoBehaviour
{
    public RectTransform deeLogoRect;
    public CanvasGroup deeLogoCanvasGroup;

    public RectTransform appTitleRect;
    public CanvasGroup appTitleCanvasGroup;

    public CanvasGroup menuUICanvasGroup;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set initial alpha states
        
        deeLogoCanvasGroup.alpha = 0f;
        appTitleCanvasGroup.alpha = 0f;
        menuUICanvasGroup.alpha = 0f;

        StartCoroutine(RunIntro());
    }
    IEnumerator RunIntro()
    {
        // --- 1. Dee Presents ---
        yield return new WaitForSeconds(1f);
        yield return FadeCanvasGroup(deeLogoCanvasGroup, 1f, 1.2f);
        yield return new WaitForSeconds(1f);
        yield return FadeCanvasGroup(deeLogoCanvasGroup, 0f, 1.2f);
        yield return new WaitForSeconds(0.5f);

        // --- 2. App Title---
        yield return FadeCanvasGroup(appTitleCanvasGroup, 1f, 1.2f);
        yield return new WaitForSeconds(1f);
        yield return FadeCanvasGroup(appTitleCanvasGroup, 0f, 1.2f);
        yield return new WaitForSeconds(1f);

        // --- 3. Menu fade in ---
        yield return FadeCanvasGroup(menuUICanvasGroup, 1f, 2f);
    }

    // ====== HELPERS ======
    IEnumerator FadeCanvasGroup(CanvasGroup group, float targetAlpha, float duration)
    {
        float start = group.alpha;
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            group.alpha = Mathf.Lerp(start, targetAlpha, t / duration);
            yield return null;
        }

        group.alpha = targetAlpha;
    }
}
