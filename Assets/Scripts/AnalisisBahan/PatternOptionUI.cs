using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum GarmentModel
{
    Blouse,
    Dress,
    Rok
}

public class PatternOptionUI : MonoBehaviour
{
    [Header("Referensi UI")]
    public Button btnTambah;
    public Image thumbnail;
    public TMP_Text namaText;
    public TMP_Text jumlahText;

    [Header("Data Pola")]
    public string namaPola = "Badan depan";
    public Sprite polaSprite;
    public int jumlahPola = 1;

    [Tooltip("Lebar pola dalam cm")]
    public float lebarPolaCm = 40f;

    [Tooltip("Tinggi pola dalam cm")]
    public float tinggiPolaCm = 50f;

    public GarmentModel model = GarmentModel.Blouse;

    [Header("Manager")]
    public AnalisisBahanManager manager;

    private void OnEnable()
    {
        if (btnTambah != null)
        {
            btnTambah.onClick.RemoveListener(TambahPola);
            btnTambah.onClick.AddListener(TambahPola);
        }
    }

    private void OnDisable()
    {
        if (btnTambah != null)
            btnTambah.onClick.RemoveListener(TambahPola);
    }

    private void Start()
    {
        PerbaruiTampilan();
    }

    private void OnValidate()
    {
        PerbaruiTampilan();
    }

    private void PerbaruiTampilan()
    {
        if (namaText != null)
            namaText.text = namaPola;

        if (jumlahText != null)
            jumlahText.text = "X" + Mathf.Max(1, jumlahPola);

        if (thumbnail != null && polaSprite != null)
        {
            thumbnail.sprite = polaSprite;
            thumbnail.preserveAspect = true;
        }
    }

    private void TambahPola()
    {
        if (manager != null)
            manager.TambahPola(this);
        else
            Debug.LogWarning(
                "Manager belum dihubungkan pada kartu: " + namaPola);
    }
}