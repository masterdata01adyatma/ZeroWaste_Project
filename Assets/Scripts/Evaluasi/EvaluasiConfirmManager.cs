using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EvaluasiConfirmManager : MonoBehaviour
{
    [Header("Popup")]
    public GameObject evaluasiPopup;

    [Header("Tombol Main Menu")]
    public Button btnEvaluasi;

    [Header("Tombol Popup")]
    public Button btnYa;
    public Button btnTidak;

    private void Awake()
    {
        // Popup ditutup saat scene mulai
        if (evaluasiPopup != null)
            evaluasiPopup.SetActive(false);
    }

    private void Start()
    {
        // Tombol Evaluasi
        if (btnEvaluasi != null)
        {
            btnEvaluasi.onClick.RemoveAllListeners();
            btnEvaluasi.onClick.AddListener(BukaPopup);
        }

        // Tombol YA
        if (btnYa != null)
        {
            btnYa.onClick.RemoveAllListeners();
            btnYa.onClick.AddListener(MulaiEvaluasi);
        }

        // Tombol TIDAK
        if (btnTidak != null)
        {
            btnTidak.onClick.RemoveAllListeners();
            btnTidak.onClick.AddListener(TutupPopup);
        }
    }

    public void BukaPopup()
    {
        Debug.Log("Popup Evaluasi dibuka");

        if (evaluasiPopup != null)
            evaluasiPopup.SetActive(true);
    }

    public void TutupPopup()
    {
        Debug.Log("Tombol TIDAK diklik");

        if (evaluasiPopup != null)
            evaluasiPopup.SetActive(false);
    }

    public void MulaiEvaluasi()
    {
        Debug.Log("Tombol YA diklik - membuka Evaluasi");

        SceneManager.LoadScene("Evaluasi");
    }
}
