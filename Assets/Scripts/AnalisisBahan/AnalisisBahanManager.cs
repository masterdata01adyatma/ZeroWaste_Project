using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnalisisBahanManager : MonoBehaviour
{
    [Header("Pattern")]
    public PatternDrag patternDrag;
    public GameObject patternImage;

    [Header("Tombol")]
    public Button btnPotong;
    public Button btnReset;

    [Header("Informasi Kain")]
    public TMP_Text panjangKainText;
    public TMP_Text lebarKainText;
    public TMP_Text sisaKainText;
    public TMP_Text efisiensiText;

    [Header("Pengaturan Simulasi")]
    public float panjangKain = 200f;
    public float lebarKain = 150f;

    // Perkiraan penggunaan kain blouse
    public float penggunaanBlouse = 160f;

    private bool sudahDipotong = false;

    private void Start()
    {
        btnPotong.onClick.RemoveAllListeners();
        btnPotong.onClick.AddListener(Potong);

        btnReset.onClick.RemoveAllListeners();
        btnReset.onClick.AddListener(ResetSimulasi);

        UpdateInfoAwal();
    }

    private void UpdateInfoAwal()
    {
        if (panjangKainText != null)
            panjangKainText.text = "Panjang Kain : " + panjangKain + " cm";

        if (lebarKainText != null)
            lebarKainText.text = "Lebar Kain : " + lebarKain + " cm";

        if (sisaKainText != null)
            sisaKainText.text = "Sisa Kain : -";

        if (efisiensiText != null)
            efisiensiText.text = "Efisiensi : -";

        sudahDipotong = false;

        if (btnPotong != null)
            btnPotong.interactable = true;
    }

    public void Potong()
    {
        if (sudahDipotong)
            return;

        sudahDipotong = true;

        // Kunci pola setelah dipotong
        if (patternDrag != null)
        {
            patternDrag.enabled = false;
        }

        // Simulasi penggunaan kain
        float sisaKain = panjangKain - penggunaanBlouse;

        if (sisaKain < 0)
            sisaKain = 0;

        // Efisiensi berdasarkan panjang kain
        float efisiensi =
            (penggunaanBlouse / panjangKain) * 100f;

        if (efisiensi > 100f)
            efisiensi = 100f;

        // Tampilkan hasil
        if (sisaKainText != null)
        {
            sisaKainText.text =
                "Sisa Kain : " +
                sisaKain.ToString("0") +
                " cm";
        }

        if (efisiensiText != null)
        {
            efisiensiText.text =
                "Efisiensi : " +
                efisiensi.ToString("0") +
                "%";
        }

        // Tombol potong tidak dapat ditekan lagi
        if (btnPotong != null)
            btnPotong.interactable = false;
    }

    public void ResetSimulasi()
    {
        sudahDipotong = false;

        // Aktifkan kembali drag
        if (patternDrag != null)
        {
            patternDrag.enabled = true;
        }

        // Reset posisi pola
        if (patternDrag != null)
        {
            patternDrag.ResetPosition();
        }

        UpdateInfoAwal();
    }
}
