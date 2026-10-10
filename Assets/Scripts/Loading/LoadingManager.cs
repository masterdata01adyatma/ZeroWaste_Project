using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    public Slider loadingBar;
    public TMP_Text percentText;

    [Header("Fade Settings")]
    public Image fadePanel;
    public float fadeDuration = 1.5f;

    public float loadingDuration = 7f;

    private float elapsedTime = 0f;
    private bool isLoadingFinished = false;

    void Start()
    {
        // Pastikan FadePanel awalnya transparan
        Color color = fadePanel.color;
        color.a = 0f;
        fadePanel.color = color;
    }

    void Update()
    {
        if (isLoadingFinished)
            return;

        elapsedTime += Time.deltaTime;

        float t = elapsedTime / loadingDuration;
        t = Mathf.Clamp01(t);

        float progress = Mathf.SmoothStep(0f, 1f, t);

        loadingBar.value = progress * 100f;
        percentText.text = Mathf.RoundToInt(progress * 100f) + "%";

        if (progress >= 1f)
        {
            isLoadingFinished = true;
            StartCoroutine(FadeAndLoadScene());
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        float elapsed = 0f;

        Color color = fadePanel.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            float alpha = Mathf.Clamp01(elapsed / fadeDuration);

            color.a = alpha;
            fadePanel.color = color;

            yield return null;
        }

        // Pastikan benar-benar hitam
        color.a = 1f;
        fadePanel.color = color;

        // Tunggu sebentar setelah layar benar-benar hitam
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene("MainMenu");
    }
}