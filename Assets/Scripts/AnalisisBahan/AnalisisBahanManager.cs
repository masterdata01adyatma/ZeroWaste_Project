using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnalisisBahanManager : MonoBehaviour
{
    [Header("Area Kain")]
    public RectTransform fabricArea;
    public RectTransform patternContainer;
    public RectTransform cutLineContainer;

    [Header("Informasi Kain")]
    public TMP_Text panjangKainText;
    public TMP_Text lebarKainText;
    public TMP_Text sisaKainText;
    public TMP_Text efisiensiText;

    [Header("Ukuran Kain dalam cm")]
    public float panjangKain = 200f;
    public float lebarKain = 150f;

    [Header("Tombol Model")]
    public Button btnBlouse;
    public Button btnDress;
    public Button btnRok;

    [Header("Tombol Simulasi")]
    public Button btnPotong;
    public Button btnReset;

    [Header("Daftar Kartu Pola")]
    public PatternOptionUI[] patternOptions;

    [Header("Preview Hasil Pakaian")]
    public Image previewImage;
    public Sprite hasilBlouse;
    public Sprite hasilDress;
    public Sprite hasilRok;

    [Header("Garis Potong")]
    public CutPathController cutPathController;

    [Header("Animasi Garis Potong")]
    public Image cutLineImage;
    public float durasiPotong = 1.5f;
    public Color warnaGarisPotong = Color.red;
    public float ketebalanGaris = 4f;

    private readonly List<PatternDrag> polaTerpasang =
        new List<PatternDrag>();

    private readonly List<float> luasPolaTerpasang =
        new List<float>();

    private GarmentModel modelAktif = GarmentModel.Blouse;
    private bool sudahDipotong;
    private bool sedangMemotong;
    private Coroutine animasiPotong;
    private RectTransform cutLineRect;

    private float LuasKain
    {
        get { return panjangKain * lebarKain; }
    }

    private void Start()
    {
        if (btnPotong != null)
        {
            btnPotong.onClick.RemoveListener(Potong);
            btnPotong.onClick.AddListener(Potong);
        }

        if (btnReset != null)
        {
            btnReset.onClick.RemoveListener(ResetSimulasi);
            btnReset.onClick.AddListener(ResetSimulasi);
        }

        if (btnBlouse != null)
        {
            btnBlouse.onClick.RemoveListener(PilihBlouse);
            btnBlouse.onClick.AddListener(PilihBlouse);
        }

        if (btnDress != null)
        {
            btnDress.onClick.RemoveListener(PilihDress);
            btnDress.onClick.AddListener(PilihDress);
        }

        if (btnRok != null)
        {
            btnRok.onClick.RemoveListener(PilihRok);
            btnRok.onClick.AddListener(PilihRok);
        }

        if (cutPathController != null)
        {
            cutPathController.BuatGaris();
        }

        SiapkanGarisPotong();

        if (previewImage != null)
        {
            previewImage.preserveAspect = true;
            previewImage.enabled = false;
        }

        PilihModel(GarmentModel.Blouse);
        UpdateInfoAwal();
    }

    private void PilihBlouse()
    {
        PilihModel(GarmentModel.Blouse);
    }

    private void PilihDress()
    {
        PilihModel(GarmentModel.Dress);
    }

    private void PilihRok()
    {
        PilihModel(GarmentModel.Rok);
    }

    private void SiapkanGarisPotong()
    {
        if (cutLineImage == null && cutLineContainer != null)
        {
            GameObject obj = new GameObject(
                "AnimatedCutLine",
                typeof(RectTransform),
                typeof(CanvasRenderer),
                typeof(Image)
            );

            obj.transform.SetParent(cutLineContainer, false);
            cutLineImage = obj.GetComponent<Image>();
        }

        if (cutLineImage != null)
        {
            cutLineRect = cutLineImage.rectTransform;
            cutLineImage.color = warnaGarisPotong;
            cutLineImage.raycastTarget = false;
            cutLineImage.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning(
                "Cut Line Image belum diisi dan Cut Line Container belum tersedia."
            );
        }
    }

    public void TampilkanGarisPotong()
    {
        if (cutPathController != null)
        {
            cutPathController.BuatGaris();
        }
        else
        {
            Debug.LogError("Cut Path Controller belum dihubungkan!");
        }
    }

    public void PilihModel(GarmentModel model)
    {
        if (sedangMemotong)
            return;

        modelAktif = model;
        ResetSimulasi();

        if (patternOptions != null)
        {
            foreach (PatternOptionUI option in patternOptions)
            {
                if (option == null)
                    continue;

                option.manager = this;
                option.gameObject.SetActive(option.model == modelAktif);
            }
        }

        Debug.Log("Model aktif: " + modelAktif);
    }

    public void TambahPola(PatternOptionUI option)
    {
        if (option == null)
        {
            Debug.LogWarning("Kartu pola belum dihubungkan.");
            return;
        }

        if (option.polaSprite == null)
        {
            Debug.LogWarning(
                "Sprite pola belum diisi pada kartu: " + option.namaPola
            );
            return;
        }

        if (sudahDipotong || sedangMemotong)
            return;

        if (fabricArea == null || patternContainer == null)
        {
            Debug.LogError(
                "Fabric Area atau Pattern Container belum dihubungkan."
            );
            return;
        }

        int jumlahTerpasang = 0;

        foreach (PatternDrag item in polaTerpasang)
        {
            if (item == null)
                continue;

            PatternSource sumberPolaTerpasang =
                item.GetComponent<PatternSource>();

            if (sumberPolaTerpasang != null &&
                sumberPolaTerpasang.option == option)
            {
                jumlahTerpasang++;
            }
        }

        if (jumlahTerpasang >= option.jumlahPola)
        {
            Debug.Log("Jumlah pola sudah mencapai batas: " + option.namaPola);
            return;
        }

        if (panjangKain <= 0 || lebarKain <= 0)
        {
            Debug.LogError("Ukuran kain harus lebih besar dari nol.");
            return;
        }

        float scaleX = fabricArea.rect.width / panjangKain;
        float scaleY = fabricArea.rect.height / lebarKain;

        float width = Mathf.Min(
            option.lebarPolaCm * scaleX,
            fabricArea.rect.width
        );

        float height = Mathf.Min(
            option.tinggiPolaCm * scaleY,
            fabricArea.rect.height
        );

        GameObject obj = new GameObject(
            "Pola_" + option.namaPola,
            typeof(RectTransform),
            typeof(CanvasRenderer),
            typeof(Image)
        );

        obj.transform.SetParent(patternContainer, false);

        RectTransform rect = obj.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.localScale = Vector3.one;
        rect.sizeDelta = new Vector2(width, height);

        Image image = obj.GetComponent<Image>();
        image.sprite = option.polaSprite;
        image.preserveAspect = true;
        image.raycastTarget = true;

        // Tempatkan pola baru dengan sedikit jarak dari pola sebelumnya.
        int index = polaTerpasang.Count;
        float startX = -fabricArea.rect.width / 2f + width / 2f + 12f;
        float startY = fabricArea.rect.height / 2f - height / 2f - 12f;

        rect.anchoredPosition = new Vector2(
            Mathf.Clamp(
                startX + (index % 3) * 24f,
                -fabricArea.rect.width / 2f + width / 2f,
                fabricArea.rect.width / 2f - width / 2f
            ),
            Mathf.Clamp(
                startY - (index % 3) * 24f,
                -fabricArea.rect.height / 2f + height / 2f,
                fabricArea.rect.height / 2f - height / 2f
            )
        );

        PatternDrag drag = obj.AddComponent<PatternDrag>();
        PatternSource source = obj.AddComponent<PatternSource>();
        source.option = option;

        polaTerpasang.Add(drag);

        // Perkiraan luas pola menggunakan ukuran persegi panjang.
        float luasPola = option.lebarPolaCm * option.tinggiPolaCm;
        luasPolaTerpasang.Add(luasPola);

        UpdateInfoHasil();
        UpdateStatusTombol();

        Debug.Log("Pola ditambahkan: " + option.namaPola);
    }

    public void Potong()
    {
        if (sudahDipotong || sedangMemotong)
            return;

        if (polaTerpasang.Count == 0)
        {
            Debug.LogWarning("Tambahkan minimal satu pola sebelum memotong.");
            return;
        }

        if (fabricArea == null)
        {
            Debug.LogError("Fabric Area belum dihubungkan.");
            return;
        }

        animasiPotong = StartCoroutine(AnimasiPemotongan());
    }

    private IEnumerator AnimasiPemotongan()
    {
        sedangMemotong = true;
        UpdateStatusTombol();

        if (cutLineImage != null && cutLineRect != null)
        {
            cutLineImage.gameObject.SetActive(true);
            cutLineImage.color = warnaGarisPotong;
            cutLineImage.raycastTarget = false;

            cutLineRect.anchorMin = new Vector2(0.5f, 0.5f);
            cutLineRect.anchorMax = new Vector2(0.5f, 0.5f);
            cutLineRect.pivot = new Vector2(0.5f, 0.5f);
            cutLineRect.localScale = Vector3.one;

            cutLineRect.sizeDelta = new Vector2(
                ketebalanGaris,
                fabricArea.rect.height
            );

            float startX = -fabricArea.rect.width / 2f;
            float endX = fabricArea.rect.width / 2f;
            float elapsed = 0f;

            while (elapsed < durasiPotong)
            {
                elapsed += Time.deltaTime;

                float t = durasiPotong > 0f
                    ? Mathf.Clamp01(elapsed / durasiPotong)
                    : 1f;

                float x = Mathf.Lerp(startX, endX, t);
                cutLineRect.anchoredPosition = new Vector2(x, 0f);

                yield return null;
            }

            cutLineImage.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning(
                "Animasi garis potong tidak ditampilkan karena referensinya belum lengkap."
            );
        }

        foreach (PatternDrag pattern in polaTerpasang)
        {
            if (pattern != null)
                pattern.SetLocked(true);
        }

        TampilkanHasilPakaian();

        sudahDipotong = true;
        sedangMemotong = false;
        animasiPotong = null;

        UpdateInfoHasil();
        UpdateStatusTombol();

        Debug.Log("Simulasi pemotongan selesai.");
    }

    private void TampilkanHasilPakaian()
    {
        if (previewImage == null)
        {
            Debug.LogWarning("Preview Image belum dihubungkan di Inspector.");
            return;
        }

        Sprite hasil = null;

        switch (modelAktif)
        {
            case GarmentModel.Blouse:
                hasil = hasilBlouse;
                break;

            case GarmentModel.Dress:
                hasil = hasilDress;
                break;

            case GarmentModel.Rok:
                hasil = hasilRok;
                break;
        }

        if (hasil == null)
        {
            Debug.LogWarning(
                "Sprite hasil pakaian untuk " + modelAktif + " belum diisi."
            );
            return;
        }

        previewImage.sprite = hasil;
        previewImage.preserveAspect = true;
        previewImage.enabled = true;
    }

    public void ResetSimulasi()
    {
        if (animasiPotong != null)
        {
            StopCoroutine(animasiPotong);
            animasiPotong = null;
        }

        sedangMemotong = false;
        sudahDipotong = false;

        foreach (PatternDrag pattern in polaTerpasang)
        {
            if (pattern != null)
                Destroy(pattern.gameObject);
        }

        polaTerpasang.Clear();
        luasPolaTerpasang.Clear();

        if (cutLineImage != null)
            cutLineImage.gameObject.SetActive(false);

        if (previewImage != null)
        {
            previewImage.sprite = null;
            previewImage.enabled = false;
        }

        UpdateInfoAwal();
        UpdateStatusTombol();
    }

    private void UpdateInfoAwal()
    {
        if (panjangKainText != null)
        {
            panjangKainText.text =
                "Panjang Kain: " + panjangKain.ToString("0") + " cm";
        }

        if (lebarKainText != null)
        {
            lebarKainText.text =
                "Lebar Kain: " + lebarKain.ToString("0") + " cm";
        }

        if (sisaKainText != null)
            sisaKainText.text = "Sisa Kain: -";

        if (efisiensiText != null)
            efisiensiText.text = "Terpakai: -";

        UpdateStatusTombol();
    }

    private void UpdateInfoHasil()
    {
        float luasTerpakai = 0f;

        foreach (float area in luasPolaTerpasang)
            luasTerpakai += area;

        float luasKain = LuasKain;

        float persenTerpakai = luasKain > 0f
            ? luasTerpakai / luasKain * 100f
            : 0f;

        persenTerpakai = Mathf.Clamp(persenTerpakai, 0f, 100f);

        float luasSisa = Mathf.Max(0f, luasKain - luasTerpakai);
        float persenSisa = 100f - persenTerpakai;

        if (sisaKainText != null)
        {
            sisaKainText.text =
                "Sisa Kain: " + luasSisa.ToString("N0") +
                " cm² (" + persenSisa.ToString("0.0") + "%)";
        }

        if (efisiensiText != null)
        {
            efisiensiText.text =
                "Terpakai: " + persenTerpakai.ToString("0.0") + "%";
        }
    }

    private void UpdateStatusTombol()
    {
        if (btnPotong != null)
        {
            btnPotong.interactable =
                polaTerpasang.Count > 0 &&
                !sudahDipotong &&
                !sedangMemotong;
        }

        if (btnReset != null)
            btnReset.interactable = !sedangMemotong;
    }
}
public class PatternSource : MonoBehaviour
{
    public PatternOptionUI option;
}