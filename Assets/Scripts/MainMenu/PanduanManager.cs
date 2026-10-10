using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanduanManager : MonoBehaviour
{
    [Header("Popup")]
    public GameObject panduanPopup;
    public TMP_Text titlePopup;
    public TMP_Text descriptionPopup;
    public Button btnTutup;

    [Header("Tombol Panduan")]
    public Button btnSmartPattern;
    public Button btnAnalisisBahan;
    public Button btnQuiz;
    public Button btnEvaluasi;
    public Button btnVideo;
    public Button btnNavigasi;

    private void Start()
    {
        // Popup awalnya disembunyikan
        panduanPopup.SetActive(false);

        // Tombol panduan
        btnSmartPattern.onClick.AddListener(() =>
            ShowPanduan(
                "SMART PATTERN",
                "Menu Smart Pattern digunakan untuk mempelajari konsep Zero Waste Fashion, pola blouse, dress, dan rok Zero Waste."
            )
        );

        btnAnalisisBahan.onClick.AddListener(() =>
            ShowPanduan(
                "ANALISIS BAHAN",
                "Menu Analisis Bahan digunakan untuk mempelajari dan melakukan analisis bahan dalam proses Zero Waste Fashion."
            )
        );

        btnQuiz.onClick.AddListener(() =>
            ShowPanduan(
                "QUIZ",
                "Menu Quiz digunakan untuk menguji pemahaman pengguna mengenai materi Zero Waste Fashion melalui soal pilihan ganda."
            )
        );

        btnEvaluasi.onClick.AddListener(() =>
            ShowPanduan(
                "EVALUASI",
                "Menu Evaluasi digunakan untuk mengukur pemahaman pengguna setelah mempelajari materi Zero Waste Fashion."
            )
        );

        btnVideo.onClick.AddListener(() =>
            ShowPanduan(
                "VIDEO PENGGUNAAN",
                "Menu Video Penggunaan berisi video panduan mengenai cara menggunakan aplikasi Zero Waste Fashion."
            )
        );

        btnNavigasi.onClick.AddListener(() =>
            ShowPanduan(
                "NAVIGASI",
                "Gunakan tombol navigasi untuk berpindah antar menu dan kembali ke halaman sebelumnya atau halaman utama."
            )
        );

        // Tombol tutup
        btnTutup.onClick.AddListener(ClosePanduan);
    }

    private void ShowPanduan(string title, string description)
    {
        titlePopup.text = title;
        descriptionPopup.text = description;

        panduanPopup.SetActive(true);
    }

    private void ClosePanduan()
    {
        panduanPopup.SetActive(false);
    }
}
