using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MateriDetailManager : MonoBehaviour
{
    [Header("UI Utama")]
    public Image imageCover;
    public TMP_Text titleMateri;

    [Header("Section")]
    public SectionUI[] sections;

    [Header("Cover Materi")]
    public Sprite coverTeori;
    public Sprite coverBlouse;
    public Sprite coverDress;
    public Sprite coverRok;

    private void Start()
    {
        int materiTerpilih = PlayerPrefs.GetInt("MateriTerpilih", 0);

        TampilkanMateri(materiTerpilih);
    }

    private void SembunyikanSemuaSection()
    {
        for (int i = 0; i < sections.Length; i++)
        {
            sections[i].gameObject.SetActive(false);
        }
    }

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

    private void TampilkanTeori()
    {
        SembunyikanSemuaSection();


        imageCover.sprite = coverTeori;
        titleMateri.text = "TEORI ZERO WASTE FASHION";

        AturSection(
            0,
            "Pengertian Zero Waste Fashion",
            "Zero Waste Fashion merupakan pendekatan dalam desain dan produksi busana yang bertujuan untuk meminimalkan limbah tekstil sejak tahap pembuatan pola."
        );

        AturSection(
            1,
            "Konsep Zero Waste Fashion",
            "Konsep Zero Waste Fashion mempertimbangkan bentuk pola, ukuran kain, konstruksi, dan fungsi pakaian secara terpadu agar penggunaan material lebih efisien."
        );

        AturSection(
            2,
            "Prinsip 4R Zero Waste Fashion",
            "Prinsip 4R dalam Zero Waste Fashion terdiri dari Reduce, Reuse, Recycle, dan Recover."
        );

        AturSection(
            3,
            "Reduce",
            "Reduce merupakan upaya mengurangi penggunaan material dan menghasilkan limbah seminimal mungkin sejak tahap perancangan."
        );

        AturSection(
            4,
            "Reuse",
            "Reuse merupakan upaya menggunakan kembali material atau produk agar tetap memiliki manfaat dan tidak langsung menjadi limbah."
        );

        AturSection(
            5,
            "Recycle",
            "Recycle merupakan proses mengolah kembali material atau limbah menjadi bahan atau produk yang dapat digunakan kembali."
        );

        AturSection(
            6,
            "Recover",
            "Recover merupakan upaya memulihkan atau memanfaatkan kembali nilai dari material yang sudah tidak dapat digunakan dalam bentuk sebelumnya."
        );

        AturSection(
            7,
            "Kesimpulan",
            "Zero Waste Fashion merupakan pendekatan desain yang berupaya meminimalkan limbah tekstil melalui perencanaan pola dan penggunaan material secara lebih efisien."
        );
    }

    private void TampilkanBlouse()
    {
        SembunyikanSemuaSection();


        imageCover.sprite = coverBlouse;
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

    private void TampilkanDress()
    {
        SembunyikanSemuaSection();


        imageCover.sprite = coverDress;
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

    private void TampilkanRok()
    {
        SembunyikanSemuaSection();


        imageCover.sprite = coverRok;
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

    private void AturSection(int index, string header, string content)
    {
        if (index >= sections.Length)
            return;

        sections[index].gameObject.SetActive(true);

        sections[index].SetData(header, content);
    }
}

[System.Serializable]
public class SectionUI
{
    public GameObject gameObject;
    public TMP_Text headerText;
    public TMP_Text contentText;

    public void SetData(string header, string content)
    {
        headerText.text = header;
        contentText.text = content;
    }
}
