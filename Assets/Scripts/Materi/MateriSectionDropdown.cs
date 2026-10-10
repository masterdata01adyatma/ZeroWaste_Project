using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MateriSectionDropdown : MonoBehaviour
{
    [Header("UI Section")]
    public Button btnHeader;
    public GameObject contentText;
    public RectTransform arrow;

    [Header("Pengaturan")]
    public bool openOnStart = false;

    [Header("Rotasi Arrow")]
    public float closedRotation = 180f;
    public float openRotation = 270f;

    private bool isOpen;

    private RectTransform sectionRect;
    private RectTransform contentRect;
    private RectTransform parentContent;

    private void Awake()
    {
        sectionRect = GetComponent<RectTransform>();

        if (contentText != null)
            contentRect = contentText.GetComponent<RectTransform>();

        // Content ScrollView
        if (sectionRect != null && sectionRect.parent != null)
            parentContent = sectionRect.parent.GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (btnHeader != null)
        {
            btnHeader.onClick.RemoveAllListeners();
            btnHeader.onClick.AddListener(ToggleSection);
        }

        isOpen = openOnStart;

        ApplySectionState();

        // Tunggu 1 frame agar Layout Group selesai menghitung ukuran
        Canvas.ForceUpdateCanvases();
        RebuildLayout();
    }

    public void ToggleSection()
    {
        isOpen = !isOpen;

        ApplySectionState();

        // Paksa Unity menghitung ulang layout
        Canvas.ForceUpdateCanvases();
        RebuildLayout();
    }

    private void ApplySectionState()
    {
        // Tampilkan / sembunyikan isi
        if (contentText != null)
        {
            contentText.SetActive(isOpen);
        }

        // Putar panah
        if (arrow != null)
        {
            float rotation = isOpen ? openRotation : closedRotation;

            arrow.localRotation = Quaternion.Euler(0f, 0f, rotation);
        }
    }

    private void RebuildLayout()
    {
        if (contentRect != null)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(contentRect);
        }

        if (sectionRect != null)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(sectionRect);
        }

        if (parentContent != null)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(parentContent);
        }

        Canvas.ForceUpdateCanvases();

        if (parentContent != null)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(parentContent);
        }
    }
}
