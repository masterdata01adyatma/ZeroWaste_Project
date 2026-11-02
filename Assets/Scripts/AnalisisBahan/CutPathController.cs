using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutPathController : MonoBehaviour
{
    [Header("Area Garis Potong")]
    public RectTransform cutLineContainer;

    [Header("Pengaturan Garis")]
    [Min(1)]
    public float ketebalanGaris = 4f;
    public Color warnaGaris = Color.red;

    [Header("Titik Jalur Potong")]
    public List<Vector2> titikPotong = new List<Vector2>();

    private readonly List<GameObject> garisAktif =
        new List<GameObject>();

    public bool GarisSudahDibuat =>
        garisAktif.Count > 0;

    public void BuatGaris()
    {
        HapusGaris();

        if (cutLineContainer == null)
        {
            Debug.LogError(
                "CutLineContainer belum dihubungkan!", this);
            return;
        }

        if (titikPotong == null || titikPotong.Count < 2)
        {
            Debug.LogWarning(
                "Minimal diperlukan dua titik.", this);
            return;
        }

        for (int i = 0; i < titikPotong.Count - 1; i++)
        {
            BuatSegmen(
                titikPotong[i],
                titikPotong[i + 1],
                i
            );
        }
    }

    private void BuatSegmen(
        Vector2 awal, Vector2 akhir, int nomor)
    {
        GameObject objek = new GameObject(
            "GarisPotong_" + nomor,
            typeof(RectTransform),
            typeof(Image)
        );

        objek.transform.SetParent(cutLineContainer, false);

        RectTransform rt =
            objek.GetComponent<RectTransform>();

        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);

        Vector2 arah = akhir - awal;

        rt.anchoredPosition = (awal + akhir) / 2f;
        rt.sizeDelta = new Vector2(
            arah.magnitude, ketebalanGaris);

        rt.localRotation = Quaternion.Euler(
            0f, 0f,
            Mathf.Atan2(arah.y, arah.x) * Mathf.Rad2Deg
        );

        Image gambar = objek.GetComponent<Image>();
        gambar.color = warnaGaris;
        gambar.raycastTarget = false;

        garisAktif.Add(objek);
    }

    public void HapusGaris()
    {
        foreach (GameObject objek in garisAktif)
        {
            if (objek != null)
                Destroy(objek);
        }

        garisAktif.Clear();
    }

    public Vector2 AmbilTitik(int indeks)
    {
        if (titikPotong == null ||
            indeks < 0 ||
            indeks >= titikPotong.Count)
        {
            return Vector2.zero;
        }

        return titikPotong[indeks];
    }
}
