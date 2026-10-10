using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Exit Popup")]
    public GameObject exitPopup;

    [Header("Popup Animation")]
    public float animationDuration = 0.25f;
    public float startScale = 0.8f;

    private CanvasGroup canvasGroup;
    private RectTransform popupTransform;
    private bool isAnimating = false;

    void Start()
    {
        if (exitPopup == null)
        {
            Debug.LogError("Exit Popup belum dihubungkan!");
            return;
        }

        popupTransform = exitPopup.GetComponent<RectTransform>();
        canvasGroup = exitPopup.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = exitPopup.AddComponent<CanvasGroup>();
        }

        // Popup disembunyikan saat awal
        exitPopup.SetActive(false);
    }

    // ==============================
    // TAMPILKAN POPUP
    // ==============================
    public void ShowExitPopup()
    {
        if (isAnimating)
            return;

        StopAllCoroutines();
        StartCoroutine(ShowPopupAnimation());
    }

    IEnumerator ShowPopupAnimation()
    {
        isAnimating = true;

        exitPopup.SetActive(true);

        // Posisi awal animasi
        popupTransform.localScale = Vector3.one * startScale;
        canvasGroup.alpha = 0f;

        float elapsed = 0f;

        while (elapsed < animationDuration)
        {
            elapsed += Time.unscaledDeltaTime;

            float t = Mathf.Clamp01(elapsed / animationDuration);

            // Smooth animation
            float smoothT = Mathf.SmoothStep(0f, 1f, t);

            // Scale
            popupTransform.localScale = Vector3.Lerp(
                Vector3.one * startScale,
                Vector3.one,
                smoothT
            );

            // Fade
            canvasGroup.alpha = smoothT;

            yield return null;
        }

        // Pastikan posisi akhir
        popupTransform.localScale = Vector3.one;
        canvasGroup.alpha = 1f;

        isAnimating = false;
    }

    // ==============================
    // TUTUP POPUP
    // ==============================
    public void CloseExitPopup()
    {
        if (isAnimating)
            return;

        StopAllCoroutines();
        StartCoroutine(ClosePopupAnimation());
    }

    IEnumerator ClosePopupAnimation()
    {
        isAnimating = true;

        Vector3 startScaleVector = popupTransform.localScale;

        float elapsed = 0f;

        while (elapsed < animationDuration)
        {
            elapsed += Time.unscaledDeltaTime;

            float t = Mathf.Clamp01(elapsed / animationDuration);

            float smoothT = Mathf.SmoothStep(0f, 1f, t);

            // Mengecil
            popupTransform.localScale = Vector3.Lerp(
                startScaleVector,
                Vector3.one * startScale,
                smoothT
            );

            // Fade out
            canvasGroup.alpha = Mathf.Lerp(
                1f,
                0f,
                smoothT
            );

            yield return null;
        }

        popupTransform.localScale = Vector3.one * startScale;
        canvasGroup.alpha = 0f;

        exitPopup.SetActive(false);

        isAnimating = false;
    }

    // ==============================
    // KELUAR APLIKASI
    // ==============================
    public void ExitApplication()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
