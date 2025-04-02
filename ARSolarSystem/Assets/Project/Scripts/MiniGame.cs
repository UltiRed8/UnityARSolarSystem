using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    [SerializeField] int delay = 30;
    [SerializeField] MiniGameSave save = null;
    [SerializeField] TMP_Text timeText = null;
    [SerializeField] TMP_Text scoreText = null;
    [SerializeField] RawImage questionImage = null;
    [SerializeField] RawImage answerImage = null;
    [SerializeField] List<Texture> questionsImages = null;
    [SerializeField] List<Texture> answersImages = null;
    [SerializeField] float delayBetweenQuestions = 0.5f;
    int currentQuestionIndex = 0;
    int currentDelay = 30;
    int currentScore = 0;

    public void StartGame()
    {
        currentScore = 0;
        currentDelay = delay;
        InvokeRepeating(nameof(UpdateTime), 1.0f, 1.0f);
        SelectRandomQuestion();
    }

    private void UpdateTime()
    {
        currentDelay--;
        timeText.text = "Time: " + currentDelay;
        if (delay <= 0)
            EndGame();
    }

    private void SelectRandomQuestion()
    {
        currentQuestionIndex = Random.Range(0, questionsImages.Count - 1);
        questionImage.texture = questionsImages[currentQuestionIndex];
        answerImage.texture = null;
    }

    private void EndGame()
    {
        CancelInvoke(nameof(UpdateTime));
        SaveScore();
        gameObject.SetActive(false);
    }

    private void CheckAnswer()
    {
        // check if answer texture index is the same as the question
        Success();
        Failed();
    }

    private void Success()
    {
        currentScore += 3;
        NextQuestion();
    }

    private void Failed()
    {
        currentScore -= 1;
        NextQuestion();
    }

    private void NextQuestion()
    {
        UpdateScoreText();
        Invoke(nameof(SelectRandomQuestion), delayBetweenQuestions);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentDelay;
    }

    private void SaveScore()
    {
        if (!save)
            return;
        save.SetNewScore(currentScore);
        save.SetBestScore(currentScore);
    }
}
