
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MateriDetailManager : MonoBehaviour
{
    [Header("UI Utama")]
    public Image imageCover;
    public TMP_Text titleMateri;

    [Header("Section Materi")]
    public SectionUI[] sections;

    [Header("Cover Materi Utama")]
    public Sprite coverTeori;
    public Sprite coverBlouse;
    public Sprite coverDress;
    public Sprite coverRok;

    [Header("Gambar Prinsip 5R")]
    public Sprite coverReduce;
    public Sprite coverReuse;
    public Sprite coverRecycle;
    public Sprite coverRecover;
    public Sprite coverRegenerate;

    private void Start()
    {
        int materiTerpilih = PlayerPrefs.GetInt("MateriTerpilih", 0);

        TampilkanMateri(materiTerpilih);
    }

    // Menyembunyikan semua section sebelum menampilkan materi.
    private void SembunyikanSemuaSection()
    {
        if (sections == null)
            return;

        foreach (SectionUI section in sections)
        {
            if (section != null && section.gameObject != null)
            {
                section.gameObject.SetActive(false);
            }
        }
    }

    // Memilih materi berdasarkan nilai PlayerPrefs.
    private void TampilkanMateri(int materi)
    {
        switch (materi)
        {
            case 0:
                TampilkanTeori();
                break;

            case 1:
                TampilkanBlouse();
                break;

            case 2:
                TampilkanDress();
                break;

            case 3:
                TampilkanRok();
                break;

            default:
                TampilkanTeori();
                break;
        }
    }

    // =====================================================
    // MATERI TEORI ZERO WASTE FASHION
    // =====================================================

    private void TampilkanTeori()
    {
        SembunyikanSemuaSection();

        UbahCover(coverTeori);
        titleMateri.text = "TEORI ZERO WASTE FASHION";

        AturSection(
            0,
            "Pengertian Zero Waste Fashion",
            "Zero Waste Fashion merupakan pendekatan dalam desain dan produksi busana yang bertujuan meminimalkan limbah tekstil sejak tahap pembuatan pola."
        );

        AturSection(
            1,
            "Konsep Zero Waste Fashion",
            "Konsep Zero Waste Fashion mempertimbangkan bentuk pola, ukuran kain, konstruksi, dan fungsi pakaian secara terpadu agar penggunaan material lebih efisien."
        );

        AturSection(
            2,
            "Prinsip 5R Zero Waste Fashion",
            "Prinsip 5R dalam Zero Waste Fashion terdiri dari Reduce, Reuse, Recycle, Recover, dan Regenerate untuk mendukung pengurangan limbah serta pemanfaatan sumber daya secara berkelanjutan."
        );

        AturSection(
            3,
            "Reduce",
            "Reduce merupakan upaya mengurangi penggunaan material dan menghasilkan limbah seminimal mungkin sejak tahap perancangan. Contohnya adalah menyusun pola pakaian secara efisien agar sisa kain berkurang."
        );

        AturSection(
            4,
            "Reuse",
            "Reuse merupakan upaya menggunakan kembali material atau produk agar tetap memiliki manfaat dan tidak langsung menjadi limbah. Contohnya adalah menggunakan kembali pakaian lama atau memanfaatkan kain bekas untuk produk lain."
        );

        AturSection(
            5,
            "Recycle",
            "Recycle merupakan proses mengolah kembali material atau limbah menjadi bahan atau produk yang dapat digunakan kembali. Contohnya adalah mengolah potongan kain menjadi serat tekstil atau bahan baru."
        );

        AturSection(
            6,
            "Recover",
            "Recover merupakan upaya mengambil kembali nilai atau manfaat dari material yang sudah tidak dapat digunakan dalam bentuk sebelumnya. Contohnya adalah memanfaatkan limbah tekstil untuk produk alternatif atau pemulihan energi melalui proses yang sesuai."
        );

        AturSection(
            7,
            "Regenerate",
            "Regenerate merupakan upaya mendukung pemulihan dan pembaruan sumber daya alam serta ekosistem. Dalam Zero Waste Fashion, penerapannya dapat berupa penggunaan bahan dari sumber yang dikelola secara regeneratif dan praktik produksi yang mendukung pemulihan lingkungan."
        );

        AturSection(
            8,
            "Kesimpulan",
            "Zero Waste Fashion merupakan pendekatan desain yang berupaya meminimalkan limbah tekstil melalui perencanaan pola dan penggunaan material secara efisien. Prinsip 5R membantu mengurangi limbah, menggunakan kembali material, mendaur ulang, memulihkan nilai sumber daya, dan mendukung regenerasi lingkungan."
        );

        PasangInteraksiGambar5R();
    }

    // =====================================================
    // INTERAKSI GAMBAR 5R
    // =====================================================

    private void PasangInteraksiGambar5R()
    {
        if (sections == null || sections.Length < 9)
        {
            Debug.LogWarning(
                "MateriDetailManager: Array Sections harus memiliki " +
                "minimal 9 elemen, dari indeks 0 sampai 8."
            );

            return;
        }

        // Indeks 3 = Reduce
        sections[3]?.SetOnClick(() =>
        {
            UbahGambar5R(coverReduce, "Reduce");
        });

        // Indeks 4 = Reuse
        sections[4]?.SetOnClick(() =>
        {
            UbahGambar5R(coverReuse, "Reuse");
        });

        // Indeks 5 = Recycle
        sections[5]?.SetOnClick(() =>
        {
            UbahGambar5R(coverRecycle, "Recycle");
        });

        // Indeks 6 = Recover
        sections[6]?.SetOnClick(() =>
        {
            UbahGambar5R(coverRecover, "Recover");
        });

        // Indeks 7 = Regenerate
        sections[7]?.SetOnClick(() =>
        {
            UbahGambar5R(coverRegenerate, "Regenerate");
        });
    }

    // Mengganti gambar di sebelah kiri sesuai materi yang diklik.
    private void UbahGambar5R(Sprite gambar, string namaMateri)
    {
        if (imageCover == null)
        {
            Debug.LogWarning(
                "Image Cover belum dihubungkan di Inspector."
            );

            return;
        }

        if (gambar == null)
        {
            Debug.LogWarning(
                "Gambar untuk materi " + namaMateri +
                " belum diisi di Inspector."
            );

            return;
        }

        imageCover.sprite = gambar;
        imageCover.preserveAspect = true;
    }

    // Mengatur gambar cover materi.
    private void UbahCover(Sprite gambar)
    {
        if (imageCover == null)
        {
            Debug.LogWarning(
                "Image Cover belum dihubungkan di Inspector."
            );

            return;
        }

        if (gambar != null)
        {
            imageCover.sprite = gambar;
            imageCover.preserveAspect = true;
        }
    }

    // =====================================================
    // MATERI BLOUSE
    // =====================================================

    private void TampilkanBlouse()
    {
        SembunyikanSemuaSection();

        UbahCover(coverBlouse);
        titleMateri.text = "BLOUSE ZERO WASTE";

        AturSection(
            0,
            "Pengertian Blouse Zero Waste",
            "Blouse Zero Waste merupakan penerapan konsep Zero Waste Fashion pada penyusunan pola blouse dengan mengoptimalkan penggunaan bidang kain."
        );

        AturSection(
            1,
            "Penyusunan Pola",
            "Pola blouse disusun dengan mempertimbangkan ukuran kain dan penempatan bagian pakaian agar penggunaan material dapat dimaksimalkan."
        );

        AturSection(
            2,
            "Bagian Pola Blouse",
            "Penyusunan pola memperhatikan bagian badan, garis leher, bagian bawah, serta komponen penyelesaian pakaian."
        );

        AturSection(
            3,
            "Proses Penyusunan",
            "Pada proses penyusunan, bagian pola disesuaikan dengan bidang kain sehingga ruang kosong dapat diminimalkan."
        );

        AturSection(
            4,
            "Finishing",
            "Tahap akhir meliputi penyelesaian bagian bawah dan komponen seperti waistband, elastis, atau tali sesuai rancangan blouse."
        );
    }

    // =====================================================
    // MATERI DRESS
    // =====================================================

    private void TampilkanDress()
    {
        SembunyikanSemuaSection();

        UbahCover(coverDress);
        titleMateri.text = "DRESS ZERO WASTE";

        AturSection(
            0,
            "Pengertian Dress Zero Waste",
            "Dress Zero Waste merupakan penerapan konsep Zero Waste Fashion pada penyusunan pola dress dengan memaksimalkan penggunaan bidang kain."
        );

        AturSection(
            1,
            "Penyusunan Pola",
            "Pola dress disusun berdasarkan ukuran dan bentuk kain sehingga penempatan pola dapat meminimalkan sisa material."
        );

        AturSection(
            2,
            "Bagian Pola Dress",
            "Penyusunan memperhatikan bagian badan, garis leher, bagian bawah, dan komponen lain sesuai rancangan dress."
        );

        AturSection(
            3,
            "Proses Penyusunan",
            "Setiap bagian pola ditempatkan secara terpadu pada bidang kain untuk mengoptimalkan pemanfaatan material."
        );

        AturSection(
            4,
            "Finishing",
            "Tahap akhir dilakukan dengan menyelesaikan bagian-bagian pakaian sesuai rancangan dress."
        );
    }

    // =====================================================
    // MATERI ROK
    // =====================================================

    private void TampilkanRok()
    {
        SembunyikanSemuaSection();

        UbahCover(coverRok);
        titleMateri.text = "ROK ZERO WASTE";

        AturSection(
            0,
            "Pengertian Rok Zero Waste",
            "Rok Zero Waste merupakan penerapan konsep Zero Waste Fashion pada penyusunan pola rok dengan mengoptimalkan penggunaan bidang kain."
        );

        AturSection(
            1,
            "Bagian Pola Rok",
            "Penyusunan pola rok terdiri dari beberapa bagian yang disesuaikan dengan rancangan dan kebutuhan pakaian."
        );

        AturSection(
            2,
            "Penyusunan Bagian Pola",
            "Bagian pola disusun dengan memperhatikan penggunaan bidang kain dan hubungan antarbagian pola."
        );

        AturSection(
            3,
            "Pencerminan Pola",
            "Beberapa bagian pola dapat menggunakan pencerminan untuk memperoleh pasangan bagian depan dan belakang sesuai rancangan."
        );

        AturSection(
            4,
            "Penyusunan Waistband",
            "Bagian waistband disusun sebagai komponen penyelesaian rok dan ditempatkan sesuai rancangan pakaian."
        );
    }

    // =====================================================
    // PENGATUR SECTION
    // =====================================================

    private void AturSection(
        int index,
        string header,
        string content)
    {
        if (sections == null ||
            index < 0 ||
            index >= sections.Length ||
            sections[index] == null)
        {
            return;
        }

        SectionUI section = sections[index];

        if (section.gameObject == null)
            return;

        section.gameObject.SetActive(true);
        section.SetData(header, content);
    }
}

// =========================================================
// KOMPONEN SECTION UI
// =========================================================

[System.Serializable]
public class SectionUI
{
    public GameObject gameObject;

    public TMP_Text headerText;
    public TMP_Text contentText;

    [Header("Tombol Dropdown")]
    public Button headerButton;

    private UnityAction clickAction;

    public void SetData(string header, string content)
    {
        if (headerText != null)
            headerText.text = header;

        if (contentText != null)
            contentText.text = content;
    }

    public void SetOnClick(UnityAction action)
    {
        if (headerButton == null)
        {
            Debug.LogWarning(
                "Header Button belum dihubungkan pada section: " +
                (gameObject != null
                    ? gameObject.name
                    : "Tidak diketahui")
            );

            return;
        }

        // Menghapus listener sebelumnya yang dibuat oleh script ini.
        if (clickAction != null)
        {
            headerButton.onClick.RemoveListener(clickAction);
        }

        clickAction = action;

        if (clickAction != null)
        {
            headerButton.onClick.AddListener(clickAction);
        }
    }
}
