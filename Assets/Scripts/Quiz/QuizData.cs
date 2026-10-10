using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizData : MonoBehaviour
{
    public static List<QuizQuestion> GetQuestions()
    {
        return new List<QuizQuestion>
        {
            new QuizQuestion
            {
                question = "Apa pengertian utama dari Zero Waste Fashion menurut materi teks tersebut?",
                optionA = "Pendekatan pengelolaan limbah tekstil setelah produk pakaian selesai diproduksi.",
                optionB = "Pendekatan desain dan produksi busana yang bertujuan meminimalkan limbah sejak tahap perancangan pola (pattern making).",
                optionC = "Teknik mendaur ulang pakaian bekas menjadi pakaian baru siap pakai.",
                optionD = "Strategi pemasaran untuk menjual pakaian ramah lingkungan dengan harga ekonomis.",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Menurut Gwilt (2020), zero waste fashion merupakan salah satu bentuk implementasi dari...",
                optionA = "Fast fashion",
                optionB = "Traditional fashion",
                optionC = "Sustainable fashion",
                optionD = "Mass production",
                correctAnswer = 2
            },

            new QuizQuestion
            {
                question = "Pendekatan sustainable fashion mempertimbangkan keseimbangan di antara aspek-aspek berikut sepanjang siklus hidup produk, KECUALI...",
                optionA = "Ekonomi",
                optionB = "Sosial",
                optionC = "Lingkungan",
                optionD = "Politik",
                correctAnswer = 3
            },

            new QuizQuestion
            {
                question = "Istilah analisis yang digunakan untuk menilai siklus hidup produk secara menyeluruh dalam sustainable fashion adalah...",
                optionA = "Product Lifecycle Analysis",
                optionB = "Lifecycle Assessment",
                optionC = "Sustainable Evaluation",
                optionD = "Eco-Efficiency Assessment",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Teori dasar yang menjadi landasan berkembangnya konsep zero waste fashion adalah...",
                optionA = "Linear Economy",
                optionB = "Circular Economy",
                optionC = "Market Economy",
                optionD = "Command Economy",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Lembaga yang mengemukakan teori ekonomi sirkular pada tahun 2017 terkait perkembangan konsep ini adalah...",
                optionA = "United Nations Environment Programme (UNEP)",
                optionB = "Ellen MacArthur Foundation",
                optionC = "World Trade Organization (WTO)",
                optionD = "Fashion Revolution Organization",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Di bawah ini yang merupakan 4 prinsip utama dalam konsep zero waste fashion berdasarkan teks adalah...",
                optionA = "Reduce, Reuse, Recycle, Replace",
                optionB = "Reduce, Reuse, Re-adjust, Recover",
                optionC = "Reduce, Reuse, Recycle, Recover",
                optionD = "Reduce, Remake, Recycle, Repair",
                correctAnswer = 2
            },

            new QuizQuestion
            {
                question = "Menurut Rissanen dan McQuillan (2016), fokus utama dari pendekatan zero waste fashion dalam pembuatan pola adalah...",
                optionA = "Memanfaatkan seluruh bidang kain agar sisa potongan kain dapat diminimalkan.",
                optionB = "Menggunakan kain sintetis yang mudah terurai oleh alam.",
                optionC = "Mengurangi jumlah jahitan pada pakaian agar proses produksi lebih cepat.",
                optionD = "Membuat pola baju berukuran besar (oversized) agar pas untuk semua orang.",
                correctAnswer = 0
            },

            new QuizQuestion
            {
                question = "Upaya pencegahan limbah (waste prevention) sebelum limbah itu terbentuk merupakan perwujudan dari prinsip...",
                optionA = "Recover",
                optionB = "Recycle",
                optionC = "Reuse",
                optionD = "Reduce",
                correctAnswer = 3
            },

            new QuizQuestion
            {
                question = "Berdasarkan data UNEP (2020), apa tujuan utama dilakukannya prinsip Reuse dalam industri tekstil?",
                optionA = "Membakar sisa kain menjadi energi panas.",
                optionB = "Mengubah struktur serat kain secara kimiawi.",
                optionC = "Mengurangi konsumsi sumber daya baru dan menekan jumlah limbah yang dibuang.",
                optionD = "Menghasilkan kain jenis nonwoven dari serat sintetis.",
                correctAnswer = 2
            },

            new QuizQuestion
            {
                question = "Manakah di antara aktivitas berikut yang merupakan contoh nyata dari prinsip Reuse?",
                optionA = "Membakar limbah tekstil sebagai bahan bakar alternatif.",
                optionB = "Memanfaatkan sisa potongan kain sebagai bahan latihan praktik atau membuat aksesori.",
                optionC = "Mengolah limbah kain secara kimiawi menjadi serat tekstil baru.",
                optionD = "Membuat benang baru dari kain katun bekas yang dipintal ulang.",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Mengolah material tekstil bekas menjadi bahan baku atau produk baru yang masih memiliki nilai guna adalah definisi dari prinsip...",
                optionA = "Reduce",
                optionB = "Reuse",
                optionC = "Recycle",
                optionD = "Recover",
                correctAnswer = 2
            },

            new QuizQuestion
            {
                question = "Menurut Ellen MacArthur Foundation (2017), strategi daur ulang (recycle) sangat penting untuk...",
                optionA = "Memastikan material tetap berada di dalam siklus ekonomi.",
                optionB = "Menghilangkan ketergantungan desainer pada mesin jahit otomatis.",
                optionC = "Mengurangi biaya upah pekerja jahit.",
                optionD = "Mempercepat distribusi produk ke tangan konsumen.",
                correctAnswer = 0
            },

            new QuizQuestion
            {
                question = "Manakah di bawah ini yang merupakan produk hasil dari proses Recycle atau upcycling tekstil?",
                optionA = "Sisa kain yang langsung dibuang ke tempat pembuangan akhir.",
                optionB = "Kain nonwoven yang dihasilkan dari pengolahan limbah tekstil.",
                optionC = "Pola baju yang digambar pada kertas karton tebal.",
                optionD = "Kain utuh yang baru saja dibeli dari pabrik tekstil.",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Proses memperoleh kembali nilai atau manfaat dari material yang sudah tidak dapat lagi digunakan kembali (reuse) maupun didaur ulang (recycle) disebut...",
                optionA = "Reduction",
                optionB = "Recovery",
                optionC = "Remaking",
                optionD = "Refusing",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Menurut UNEP (2020), pemulihan energi (recover) dari limbah tekstil sebaiknya dilakukan pada tahap kapan?",
                optionA = "Sebelum proses mendesain pola baju dimulai.",
                optionB = "Bersamaan dengan proses memotong bahan utama.",
                optionC = "Setelah upaya reduce, reuse, dan recycle telah dilakukan.",
                optionD = "Menjadi pilihan pertama dan utama sebelum strategi lainnya.",
                correctAnswer = 2
            },

            new QuizQuestion
            {
                question = "Apa salah satu contoh tindakan penerapan prinsip Recover dalam industri fesyen?",
                optionA = "Memperbaiki pakaian yang rusak agar bisa dipakai kembali.",
                optionB = "Menggunakan kembali potongan kain perca untuk membuat boneka.",
                optionC = "Pemanfaatan limbah tekstil yang tidak bisa diolah lagi sebagai bahan bakar alternatif.",
                optionD = "Mendesain pola pakaian berbentuk geometris kotak-kotak tanpa sisa kain.",
                correctAnswer = 2
            },

            new QuizQuestion
            {
                question = "Mengapa dalam hubungan 4R, pendekatan zero waste fashion lebih menekankan Reduce sebagai strategi utamanya?",
                optionA = "Karena biaya penerapan prinsip Reduce adalah yang paling mahal.",
                optionB = "Karena tujuan utamanya mencegah terbentuknya limbah sejak tahap desain dan pembuatan pola.",
                optionC = "Karena prinsip Reduce tidak membutuhkan kreativitas dalam merancang baju.",
                optionD = "Karena Reduce berfokus pada daur ulang pakaian jadi setelah dipakai konsumen.",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Pada langkah awal animasi pola Blouse Zero Waste, bagian pola manakah yang digeser ke atas terpisah dari bahan?",
                optionA = "Ban bawah",
                optionB = "Kerung leher",
                optionC = "Lengan baju",
                optionD = "Saku depan",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Apa yang terjadi ketika panjang kain pada pola Blouse Zero Waste dibentangkan tanpa lipatan?",
                optionA = "Panjang kain menjadi setengahnya dan bagian tengah menyusut.",
                optionB = "Kain terputus menjadi dua bagian yang sama besar secara horizontal.",
                optionC = "Panjang menjadi 2x lipat dan terlihat bagian tengah berlubang akibat pergeseran kerung leher.",
                optionD = "Kain secara otomatis membentuk lipatan rimpel di bagian dada.",
                correctAnswer = 2
            },

            new QuizQuestion
            {
                question = "Berapa kali lipat panjang kain yang terlihat saat dibentangkan tanpa lipatan pada proses pembuatan Blouse maupun Dress Zero Waste?",
                optionA = "1,5 kali",
                optionB = "2 kali",
                optionC = "3 kali",
                optionD = "4 kali",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Setelah kain dikembalikan ke bentuk semula tanpa dibuka lipatannya pada pola Blouse, langkah penjahitan berikutnya dilakukan pada bagian...",
                optionA = "Sisi kanan dan kiri kain",
                optionB = "Bagian tengah yang berlubang saja",
                optionC = "Sepanjang garis kerung lengan saja",
                optionD = "Hanya pada bagian ban bawah kain",
                correctAnswer = 0
            },

            new QuizQuestion
            {
                question = "Pada tahap finishing pembuatan Blouse Zero Waste, bagian ban dapat diberi kelengkapan berupa...",
                optionA = "Kancing hias besi atau resleting jepang",
                optionB = "Kerah rebah atau aplikasi bordir langsung",
                optionC = "Elastik atau dijadikan ban yang bisa diikat",
                optionD = "Tali kur rajut atau kawat penyangga",
                correctAnswer = 2
            },

            new QuizQuestion
            {
                question = "Perbedaan mendasar pada langkah awal antara pembuatan pola Blouse Zero Waste dan Dress Zero Waste dalam teks tersebut adalah...",
                optionA = "Pada Dress, tidak ada langkah pemotongan dan pergeseran ban bawah di awal animasi.",
                optionB = "Pada Blouse, tidak ada langkah pergeseran kerung leher ke arah atas.",
                optionC = "Pola Dress tidak perlu dibentangkan menjadi 2x panjang semula.",
                optionD = "Pola Blouse membutuhkan waktu penjahitan sisi yang lebih lama daripada Dress.",
                correctAnswer = 0
            },

            new QuizQuestion
            {
                question = "Pada animasi pola Rok Zero Waste, bagian nomor (1) yang digeser ke arah kiri terpisah dari bahan utama adalah...",
                optionA = "Bagian Tengah Muka (TM)",
                optionB = "Bagian Tengah Belakang (TB)",
                optionC = "Ban pinggang",
                optionD = "Saku rok",
                correctAnswer = 2
            },

            new QuizQuestion
            {
                question = "Bagian pola Rok Zero Waste nomor (3) yang digeser ke arah kanan terpisah dari bahan utama disebut dengan istilah...",
                optionA = "Sisi Rok",
                optionB = "Tengah Muka (TM)",
                optionC = "Kupnat Rok",
                optionD = "Kelim Bawah",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Ketika bagian TM (3) pada pola Rok Zero Waste dibuka lipatannya, efek visual yang muncul menyerupai...",
                optionA = "Gradasi warna kain",
                optionB = "Potongan serong (bias cut)",
                optionC = "Bayangan cermin (mirror image)",
                optionD = "Kerutan elastis",
                correctAnswer = 2
            },

            new QuizQuestion
            {
                question = "Setelah lipatan bagian TM (3) dibuka, potongan tersebut akan menjadi bagian rok untuk posisi...",
                optionA = "Rok bagian muka (depan)",
                optionB = "Rok bagian belakang kanan",
                optionC = "Rok bagian belakang kiri",
                optionD = "Ban pinggang rok lengkap",
                correctAnswer = 0
            },

            new QuizQuestion
            {
                question = "Bagian nomor (2) pada pola Rok Zero Waste dimodifikasi menyerupai bayangan cermin namun terpisah menjadi bagian kiri dan kanan untuk digunakan sebagai...",
                optionA = "Pola potongan rok bagian muka",
                optionB = "Pola potongan rok bagian belakang",
                optionC = "Kantong sembunyi pada sisi rok",
                optionD = "Lapisan dalam (furing) rok",
                correctAnswer = 1
            },

            new QuizQuestion
            {
                question = "Bagaimana urutan penumpukan visual animasi akhir untuk produk Rok Zero Waste berdasarkan teks?",
                optionA = "Bagian muka di bawah, ditumpuk ban pinggang, lalu ditumpuk bagian belakang.",
                optionB = "Bagian belakang (kanan & kiri) diatur berurutan, ditumpuk gambar bagian muka (TM) sehingga bagian belakang tak terlihat, lalu ban pinggang dipasang di atas rok bagian muka.",
                optionC = "Ban pinggang dipasang paling bawah, ditumpuk bagian belakang, baru ditutup bagian muka.",
                optionD = "Semua bagian diletakkan sejajar berdampingan tanpa ada bagian yang saling menumpuk.",
                correctAnswer = 1
            }
        };
    }
}
