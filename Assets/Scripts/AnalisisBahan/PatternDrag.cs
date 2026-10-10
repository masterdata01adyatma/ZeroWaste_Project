using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PatternDrag : MonoBehaviour,
    
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    [Header("Area Kain")]
    public RectTransform panelKain;

    private RectTransform patternRect;
    private Canvas canvas;

    private Vector2 startPosition;

    private void Awake()
    {
        patternRect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        startPosition = patternRect.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Menyimpan posisi sebelum mulai digeser
        startPosition = patternRect.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (panelKain == null || canvas == null)
            return;

        // Pergerakan mouse/touch dikonversi sesuai skala Canvas
        Vector2 delta = eventData.delta / canvas.scaleFactor;

        Vector2 newPosition =
            patternRect.anchoredPosition + delta;

        // Batasi agar pola tetap berada di dalam PanelKain
        newPosition = ClampToPanel(newPosition);

        patternRect.anchoredPosition = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Posisi terakhir tetap dipertahankan
    }

    private Vector2 ClampToPanel(Vector2 position)
    {
        float panelHalfWidth = panelKain.rect.width / 2f;
        float panelHalfHeight = panelKain.rect.height / 2f;

        float patternHalfWidth = patternRect.rect.width / 2f;
        float patternHalfHeight = patternRect.rect.height / 2f;

        float minX =
            -panelHalfWidth + patternHalfWidth;

        float maxX =
            panelHalfWidth - patternHalfWidth;

        float minY =
            -panelHalfHeight + patternHalfHeight;

        float maxY =
            panelHalfHeight - patternHalfHeight;

        position.x = Mathf.Clamp(
            position.x,
            minX,
            maxX
        );

        position.y = Mathf.Clamp(
            position.y,
            minY,
            maxY
        );

        return position;
    }

    public void ResetPosition()
    {
        patternRect.anchoredPosition = startPosition;
    }
}