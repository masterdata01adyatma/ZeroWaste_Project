using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScissorCutAnimation : MonoBehaviour
{
    [Header("Referensi")]
    public CutPathController cutPathController;
    public RectTransform scissorImage;
    public Button btnPotong;

    [Header("Pengaturan Animasi")]
    [Min(0.1f)]
    public float durasiPotong = 2f;

    private bool sedangMemotong;
    private Coroutine animasiAktif;

    private void Awake()
    {
        if (btnPotong != null)
        {
            btnPotong.onClick.RemoveListener(MulaiPotong);
            btnPotong.onClick.AddListener(MulaiPotong);
        }
    }

    private void Start()
    {
        if (scissorImage != null)
            scissorImage.gameObject.SetActive(false);

        Debug.Log("ScissorCutAnimation siap.");
    }

    public void MulaiPotong()
    {
        Debug.Log("Tombol POTONG diklik.");

        if (sedangMemotong)
        {
            Debug.LogWarning("Animasi potong masih berjalan.");
            return;
        }

        if (cutPathController == null)
        {
            Debug.LogError("CutPathController belum dihubungkan!", this);
            return;
        }

        if (scissorImage == null)
        {
            Debug.LogError("ScissorImage belum dihubungkan!", this);
            return;
        }

        if (cutPathController.cutLineContainer == null)
        {
            Debug.LogError("CutLineContainer belum dihubungkan!", this);
            return;
        }

        List<Vector2> titik = cutPathController.titikPotong;

        if (titik == null || titik.Count < 2)
        {
            Debug.LogWarning("Jalur potong membutuhkan minimal dua titik.");
            return;
        }

        if (animasiAktif != null)
            StopCoroutine(animasiAktif);

        animasiAktif = StartCoroutine(AnimasiPotong());
    }

    private IEnumerator AnimasiPotong()
    {
        sedangMemotong = true;

        RectTransform areaGaris =
            cutPathController.cutLineContainer;

        RectTransform areaGunting =
            scissorImage.parent as RectTransform;

        if (areaGunting == null)
        {
            Debug.LogError(
                "ScissorImage harus memiliki parent bertipe RectTransform.",
                this
            );

            sedangMemotong = false;
            animasiAktif = null;
            yield break;
        }

        List<Vector2> titik = cutPathController.titikPotong;

        // Pastikan posisi awal dan tujuan memakai koordinat layar
        // yang sama, lalu konversi ke area parent gunting.
        List<Vector2> titikLokal = new List<Vector2>();

        Camera kamera = null;
        Canvas canvas = areaGaris.GetComponentInParent<Canvas>();

        if (canvas != null &&
            canvas.renderMode != RenderMode.ScreenSpaceOverlay)
        {
            kamera = canvas.worldCamera;
        }

        foreach (Vector2 titikArea in titik)
        {
            Vector3 posisiDunia =
                areaGaris.TransformPoint(titikArea);

            Vector2 posisiLayar =
                RectTransformUtility.WorldToScreenPoint(
                    kamera, posisiDunia
                );

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                areaGunting,
                posisiLayar,
                kamera,
                out Vector2 posisiLokal
            );

            titikLokal.Add(posisiLokal);
        }

        float totalPanjang = 0f;

        for (int i = 0; i < titikLokal.Count - 1; i++)
        {
            totalPanjang += Vector2.Distance(
                titikLokal[i], titikLokal[i + 1]
            );
        }

        if (totalPanjang <= 0f)
        {
            Debug.LogWarning("Panjang jalur potong adalah nol.");
            scissorImage.gameObject.SetActive(false);
            sedangMemotong = false;
            animasiAktif = null;
            yield break;
        }

        scissorImage.gameObject.SetActive(true);
        scissorImage.SetAsLastSibling();

        for (int i = 0; i < titikLokal.Count - 1; i++)
        {
            Vector2 awal = titikLokal[i];
            Vector2 akhir = titikLokal[i + 1];

            float panjangSegmen = Vector2.Distance(awal, akhir);
            float durasiSegmen =
                durasiPotong * panjangSegmen / totalPanjang;

            float waktu = 0f;
            Vector2 arah = akhir - awal;

            while (waktu < durasiSegmen)
            {
                waktu += Time.deltaTime;

                float t = Mathf.Clamp01(waktu / durasiSegmen);

                scissorImage.anchoredPosition =
                    Vector2.Lerp(awal, akhir, t);

                scissorImage.localRotation =
                    Quaternion.Euler(
                        0f, 0f,
                        Mathf.Atan2(arah.y, arah.x) * Mathf.Rad2Deg
                    );

                yield return null;
            }

            scissorImage.anchoredPosition = akhir;
        }

        scissorImage.gameObject.SetActive(false);
        sedangMemotong = false;
        animasiAktif = null;

        Debug.Log("Animasi gunting selesai.");
    }

    private void OnDestroy()
    {
        if (btnPotong != null)
            btnPotong.onClick.RemoveListener(MulaiPotong);
    }
}
