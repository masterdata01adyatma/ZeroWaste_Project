using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(Image))]
public class PatternDrag : MonoBehaviour,

   IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private RectTransform parentRect;
    private Canvas canvas;
    private Image image;

    private bool locked;
    private Vector2 dragOffset;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRect = transform.parent as RectTransform;
        canvas = GetComponentInParent<Canvas>();
        image = GetComponent<Image>();

        if (image != null)
            image.raycastTarget = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (locked || parentRect == null || canvas == null)
            return;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint))
        {
            dragOffset = rectTransform.anchoredPosition - localPoint;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (locked || parentRect == null || canvas == null)
            return;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint))
        {
            rectTransform.anchoredPosition = localPoint + dragOffset;
            BatasiDalamKain();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!locked)
            BatasiDalamKain();
    }

    private void BatasiDalamKain()
    {
        if (parentRect == null)
            return;

        Vector2 parentSize = parentRect.rect.size;
        Vector2 itemSize = rectTransform.rect.size;

        float minX = -parentSize.x / 2f + itemSize.x / 2f;
        float maxX = parentSize.x / 2f - itemSize.x / 2f;
        float minY = -parentSize.y / 2f + itemSize.y / 2f;
        float maxY = parentSize.y / 2f - itemSize.y / 2f;

        Vector2 pos = rectTransform.anchoredPosition;

        pos.x = minX > maxX ? 0 : Mathf.Clamp(pos.x, minX, maxX);
        pos.y = minY > maxY ? 0 : Mathf.Clamp(pos.y, minY, maxY);

        rectTransform.anchoredPosition = pos;
    }

    public void SetLocked(bool value)
    {
        locked = value;

        if (image != null)
        {
            image.color = value
                ? new Color(0.8f, 0.8f, 0.8f, 1f)
                : Color.white;

            image.raycastTarget = !value;
        }
    }

    public void ResetPosition()
    {
        SetLocked(false);
    }
}