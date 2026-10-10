using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [Header("UI Soal")]
    public TMP_Text questionNumberText;
    public TMP_Text questionText;

    [Header("Pilihan Jawaban")]
    public Button answerA;
    public Button answerB;
    public Button answerC;
    public Button answerD;

    [Header("Text Pilihan Jawaban")]
    public TMP_Text answerAText;
    public TMP_Text answerBText;
    public TMP_Text answerCText;
    public TMP_Text answerDText;

    [Header("Tombol Selanjutnya")]
    public Button nextButton;

    [Header("Panel Hasil Quiz")]
    public GameObject resultPanel;
    public TMP_Text correctLabel;
    public TMP_Text scoreLabel;
    public Button homeButton;

    [Header("Pengaturan Quiz")]
    public int totalQuestions = 30;

    private List<QuizQuestion> questions;

    private int currentQuestionIndex = 0;
    private int score = 0;

    private bool answerSelected = false;
    private int selectedAnswer = -1;

    private void Start()
    {
        // Ambil semua soal
        questions = QuizData.GetQuestions();

        // Acak soal
        ShuffleQuestions();

        // Batasi jumlah soal
        if (questions.Count > totalQuestions)
        {
            questions = questions.GetRange(0, totalQuestions);
        }

        // Sembunyikan panel hasil
        resultPanel.SetActive(false);

        // Tampilkan soal pertama
        ShowQuestion();

        // Tombol selanjutnya
        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(NextQuestion);

        // Tombol Home
        homeButton.onClick.RemoveAllListeners();
        homeButton.onClick.AddListener(ReturnToHome);
    }

    private void ShuffleQuestions()
    {
        for (int i = questions.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            QuizQuestion temp = questions[i];
            questions[i] = questions[randomIndex];
            questions[randomIndex] = temp;
        }
    }

    private void ShowQuestion()
    {
        answerSelected = false;
        selectedAnswer = -1;

        if (currentQuestionIndex >= questions.Count)
        {
            return;
        }

        QuizQuestion currentQuestion = questions[currentQuestionIndex];

        // Nomor soal
        questionNumberText.text =
            "SOAL " + (currentQuestionIndex + 1) + " / " + questions.Count;

        // Pertanyaan
        questionText.text = currentQuestion.question;

        // Pilihan jawaban
        answerAText.text = "A. " + currentQuestion.optionA;
        answerBText.text = "B. " + currentQuestion.optionB;
        answerCText.text = "C. " + currentQuestion.optionC;
        answerDText.text = "D. " + currentQuestion.optionD;

        // Aktifkan tombol jawaban
        answerA.interactable = true;
        answerB.interactable = true;
        answerC.interactable = true;
        answerD.interactable = true;

        // Reset warna
        ResetAnswerButtonColors();

        // Tombol selanjutnya belum aktif
        nextButton.interactable = false;

        // Hubungkan tombol jawaban
        answerA.onClick.RemoveAllListeners();
        answerB.onClick.RemoveAllListeners();
        answerC.onClick.RemoveAllListeners();
        answerD.onClick.RemoveAllListeners();

        answerA.onClick.AddListener(() => SelectAnswer(0));
        answerB.onClick.AddListener(() => SelectAnswer(1));
        answerC.onClick.AddListener(() => SelectAnswer(2));
        answerD.onClick.AddListener(() => SelectAnswer(3));
    }

    public void SelectAnswer(int answerIndex)
    {
        if (answerSelected)
        {
            return;
        }

        answerSelected = true;
        selectedAnswer = answerIndex;

        QuizQuestion currentQuestion = questions[currentQuestionIndex];

        // Cek jawaban
        if (selectedAnswer == currentQuestion.correctAnswer)
        {
            score++;
        }

        // Tampilkan hasil jawaban
        ShowAnswerResult(currentQuestion.correctAnswer);

        // Aktifkan tombol selanjutnya
        nextButton.interactable = true;

        //// Nonaktifkan pilihan
        //answerA.interactable = false;
        //answerB.interactable = false;
        //answerC.interactable = false;
        //answerD.interactable = false;
    }

    private void ShowAnswerResult(int correctAnswer)
    {
        // Jawaban benar = hijau
        switch (correctAnswer)
        {
            case 0:
                SetButtonColor(answerA, Color.green);
                break;

            case 1:
                SetButtonColor(answerB, Color.green);
                break;

            case 2:
                SetButtonColor(answerC, Color.green);
                break;

            case 3:
                SetButtonColor(answerD, Color.green);
                break;
        }

        // Jawaban yang dipilih salah = merah
        if (selectedAnswer != correctAnswer)
        {
            switch (selectedAnswer)
            {
                case 0:
                    SetButtonColor(answerA, Color.red);
                    break;

                case 1:
                    SetButtonColor(answerB, Color.red);
                    break;

                case 2:
                    SetButtonColor(answerC, Color.red);
                    break;

                case 3:
                    SetButtonColor(answerD, Color.red);
                    break;
            }
        }
    }

    private void SetButtonColor(Button button, Color color)
    {
        ColorBlock colors = button.colors;

        colors.normalColor = color;
        colors.highlightedColor = color;
        colors.pressedColor = color;
        colors.selectedColor = color;
        colors.disabledColor = color;

        button.colors = colors;
    }

    private void ResetAnswerButtonColors()
    {
        ResetButtonColor(answerA);
        ResetButtonColor(answerB);
        ResetButtonColor(answerC);
        ResetButtonColor(answerD);
    }

    private void ResetButtonColor(Button button)
    {
        ColorBlock colors = button.colors;

        colors.normalColor = Color.white;
        colors.highlightedColor = Color.white;
        colors.pressedColor = Color.white;
        colors.selectedColor = Color.white;
        colors.disabledColor = Color.white;

        button.colors = colors;
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion();
        }
        else
        {
            FinishQuiz();
        }
    }

    private void FinishQuiz()
    {
        // Hitung nilai 0 - 100
        int finalScore = Mathf.RoundToInt(
            ((float)score / questions.Count) * 100f
        );

        Debug.Log("QUIZ SELESAI");
        Debug.Log("Jawaban benar: " + score + " / " + questions.Count);
        Debug.Log("Nilai: " + finalScore);

        // Tampilkan jumlah jawaban benar
        correctLabel.text =
            "Jawaban Benar: " + score + " / " + questions.Count;

        // Tampilkan nilai
        scoreLabel.text =
            "NILAI: " + finalScore;

        // Sembunyikan bagian quiz
        questionNumberText.transform.parent.gameObject.SetActive(false);

        // Tampilkan hasil
        resultPanel.SetActive(true);
    }

    private void ReturnToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public int GetScore()
    {
        return score;
    }

    public int GetFinalScore()
    {
        return Mathf.RoundToInt(
            ((float)score / questions.Count) * 100f
        );
    }

    public int GetTotalQuestions()
    {
        return questions.Count;
    }
}
