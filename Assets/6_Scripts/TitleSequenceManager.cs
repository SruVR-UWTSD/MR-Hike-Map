using UnityEngine;
using TMPro;
using System.Collections;

public class TitleSequenceManager : MonoBehaviour
{

    public RectTransform deeLogoRect;
    public CanvasGroup deeLogoCanvasGroup;

    public GameObject appTitle3D;    // changed to GameObject
    private Transform appTitleTransform;

    public CanvasGroup menuUICanvasGroup;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set initial states
        deeLogoRect.localScale = Vector3.zero;
        deeLogoCanvasGroup.alpha = 1f;

        appTitleTransform = appTitle3D.transform;
        appTitleTransform.localScale = Vector3.zero;

        menuUICanvasGroup.alpha = 0f;

        StartCoroutine(RunIntro());
    }
    IEnumerator RunIntro()
    {
        // --- 1. Dee Presents ---
        yield return ScaleOverTime(deeLogoRect, Vector3.one, 3f);
        yield return FadeCanvasGroup(deeLogoCanvasGroup, 0f, 1.2f);

        yield return new WaitForSeconds(1f);

        // --- 2. App Title 3D ---
        yield return ScaleOverTime(appTitleTransform, Vector3.one, 3f);

        yield return new WaitForSeconds(1f);

        // turn it off 
        appTitle3D.SetActive(false);

        yield return new WaitForSeconds(1f);

        // --- 3. Menu fade in ---
        yield return FadeCanvasGroup(menuUICanvasGroup, 1f, 2f);
    }

    // ====== HELPERS ======

    IEnumerator ScaleOverTime(Transform target, Vector3 endScale, float duration)
    {
        Vector3 startScale = target.localScale;
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            target.localScale = Vector3.Lerp(startScale, endScale, t / duration);
            yield return null;
        }

        target.localScale = endScale;
    }

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
