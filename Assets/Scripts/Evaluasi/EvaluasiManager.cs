using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EvaluasiManager : MonoBehaviour
{
    [Header("UI Soal")]
    public TMP_Text questionNumberText;
    public TMP_Text questionText;

    [Header("Pilihan Jawaban")]
    public Button answerA;
    public Button answerB;
    public Button answerC;
    public Button answerD;

    [Header("Text Jawaban")]
    public TMP_Text answerAText;
    public TMP_Text answerBText;
    public TMP_Text answerCText;
    public TMP_Text answerDText;

    [Header("Tombol")]
    public Button nextButton;

    [Header("Result Panel")]
    public GameObject resultPanel;

    public Image resultIcon;
    public Sprite correctIcon;
    public Sprite wrongIcon;

    public TMP_Text resultTitle;
    public TMP_Text correctLabel;
    public TMP_Text scoreLabel;
    public Button retryButton;
    public Button homeButton;

    [Header("Pengaturan")]
    public int totalQuestions = 5;

    private List<QuizQuestion> questions;

    private int currentQuestionIndex;
    private int score;

    private bool answerSelected;
    private int selectedAnswer = -1;

    private void Start()
    {
        PrepareQuestions();

        if (resultPanel != null)
            resultPanel.SetActive(false);

        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(NextQuestion);

        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(RestartEvaluation);

        homeButton.onClick.RemoveAllListeners();
        homeButton.onClick.AddListener(ReturnToHome);

        ShowQuestion();
    }

    private void PrepareQuestions()
    {
        List<QuizQuestion> allQuestions = QuizData.GetQuestions();

        Shuffle(allQuestions);

        questions = allQuestions.GetRange(
            0,
            Mathf.Min(totalQuestions, allQuestions.Count)
        );

        currentQuestionIndex = 0;
        score = 0;
    }

    private void Shuffle(List<QuizQuestion> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            QuizQuestion temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private void ShowQuestion()
    {
        answerSelected = false;
        selectedAnswer = -1;

        QuizQuestion question = questions[currentQuestionIndex];

        questionNumberText.text =
            "SOAL " +
            (currentQuestionIndex + 1) +
            " / " +
            questions.Count;

        questionText.text = question.question;

        answerAText.text = "A. " + question.optionA;
        answerBText.text = "B. " + question.optionB;
        answerCText.text = "C. " + question.optionC;
        answerDText.text = "D. " + question.optionD;

        ResetButtonColors();

        answerA.interactable = true;
        answerB.interactable = true;
        answerC.interactable = true;
        answerD.interactable = true;

        nextButton.interactable = false;

        answerA.onClick.RemoveAllListeners();
        answerB.onClick.RemoveAllListeners();
        answerC.onClick.RemoveAllListeners();
        answerD.onClick.RemoveAllListeners();

        answerA.onClick.AddListener(() => SelectAnswer(0));
        answerB.onClick.AddListener(() => SelectAnswer(1));
        answerC.onClick.AddListener(() => SelectAnswer(2));
        answerD.onClick.AddListener(() => SelectAnswer(3));
    }

    private void SelectAnswer(int answerIndex)
    {
        if (answerSelected)
            return;

        answerSelected = true;
        selectedAnswer = answerIndex;

        QuizQuestion question = questions[currentQuestionIndex];

        if (selectedAnswer == question.correctAnswer)
        {
            score++;
        }

        ShowAnswerResult(question.correctAnswer);

        answerA.interactable = false;
        answerB.interactable = false;
        answerC.interactable = false;
        answerD.interactable = false;

        nextButton.interactable = true;
    }

    private void ShowAnswerResult(int correctAnswer)
    {
        // Reset semua tombol terlebih dahulu
        ResetButtonColors();

        // Jawaban yang benar = hijau
        SetButtonColor(GetButton(correctAnswer), Color.green);

        // Jika jawaban yang dipilih salah = merah
        if (selectedAnswer != correctAnswer)
        {
            SetButtonColor(GetButton(selectedAnswer), Color.red);
        }
    }

    private Button GetButton(int index)
    {
        switch (index)
        {
            case 0: return answerA;
            case 1: return answerB;
            case 2: return answerC;
            case 3: return answerD;
        }

        return null;
    }

    private void SetButtonColor(Button button, Color color)
    {
        if (button == null)
            return;

        Image image = button.GetComponent<Image>();

        if (image != null)
        {
            image.color = color;
        }
    }

    private void ResetButtonColors()
    {
        ResetButtonColor(answerA);
        ResetButtonColor(answerB);
        ResetButtonColor(answerC);
        ResetButtonColor(answerD);
    }

    private void ResetButtonColor(Button button)
    {
        if (button == null)
            return;

        Image image = button.GetComponent<Image>();

        if (image != null)
        {
            image.color = Color.white;
        }
    }

    private void NextQuestion()
    {
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion();
        }
        else
        {
            FinishEvaluation();
        }
    }

    private void FinishEvaluation()
    {
        int finalScore = Mathf.RoundToInt(
            ((float)score / questions.Count) * 100f
        );

        questionNumberText.gameObject.SetActive(false);
        questionText.gameObject.SetActive(false);

        answerA.gameObject.SetActive(false);
        answerB.gameObject.SetActive(false);
        answerC.gameObject.SetActive(false);
        answerD.gameObject.SetActive(false);

        nextButton.gameObject.SetActive(false);

        resultPanel.SetActive(true);

        correctLabel.text =
            "Jawaban Benar: " +
            score +
            " / " +
            questions.Count;

        scoreLabel.text =
            "NILAI: " +
            finalScore;

        if (score == questions.Count)
        {
            resultTitle.text = "EVALUASI BERHASIL";

            if (resultIcon != null)
                resultIcon.sprite = correctIcon;

            retryButton.gameObject.SetActive(false);
        }
        else
        {
            resultTitle.text = "BELUM LULUS";

            if (resultIcon != null)
                resultIcon.sprite = wrongIcon;

            retryButton.gameObject.SetActive(true);
        }
    }

    private void RestartEvaluation()
    {
        questionNumberText.gameObject.SetActive(true);
        questionText.gameObject.SetActive(true);

        answerA.gameObject.SetActive(true);
        answerB.gameObject.SetActive(true);
        answerC.gameObject.SetActive(true);
        answerD.gameObject.SetActive(true);

        nextButton.gameObject.SetActive(true);

        resultPanel.SetActive(false);

        PrepareQuestions();
        ShowQuestion();
    }

    private void ReturnToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
