using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

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
    [SerializeField] AudioResource successSound = null;
    [SerializeField] AudioResource failedSound = null;
    [SerializeField] ARSession session = null;

    //Detection
    [SerializeField] ARTrackedImageManager manager;

    Dictionary<string, bool> imageVisibility = new Dictionary<string, bool>();

    bool isGameRunning = false;
    bool hasAnswered = false;
    int currentQuestionIndex = 0;
    int currentDelay = 30;
    int currentScore = 0;

    public void StartGame()
    {
        if (manager)
            manager.trackedImagesChanged += CheckAnswer;
        currentScore = 0;
        isGameRunning = true;
        hasAnswered = false;
        UpdateScoreText();
        UpdateTimeText();
        currentDelay = delay;
        InvokeRepeating(nameof(UpdateTime), 1.0f, 1.0f);
        SelectRandomQuestion();
    }

    private void UpdateTime()
    {
        currentDelay--;
        UpdateTimeText();
        if (currentDelay <= 0)
            EndGame();
    }

    private void UpdateTimeText()
    {
        timeText.text = "Time: " + currentDelay;
    }

    private void SelectRandomQuestion()
    {
        currentQuestionIndex = Random.Range(0, questionsImages.Count - 1);
        questionImage.texture = questionsImages[currentQuestionIndex];
        answerImage.texture = null;
        hasAnswered = false;
        Debug.Log("DEBUG GAME ===> NEXT QUESTION = " + questionsImages[currentQuestionIndex].name);
    }

    private void EndGame()
    {
        CancelInvoke(nameof(UpdateTime));
        SaveScore();
        if (manager)
            manager.trackedImagesChanged -= CheckAnswer;
        isGameRunning = false;
        gameObject.SetActive(false);
    }

    private void CheckAnswer(ARTrackedImagesChangedEventArgs _image)
    {
        foreach (ARTrackedImage _trackedImage in _image.added)
        {
            imageVisibility[_trackedImage.referenceImage.name] = true;
        }
        foreach (ARTrackedImage _trackedImage in _image.updated)
        {
            imageVisibility[_trackedImage.referenceImage.name] = _trackedImage.trackingState == TrackingState.Tracking;
        }
        foreach (ARTrackedImage _trackedImage in _image.removed)
        {
            imageVisibility[_trackedImage.referenceImage.name] = false;
        }
    }

    private void Update()
    {
        if (!isGameRunning || hasAnswered)
            return;

        foreach (KeyValuePair<string, bool> _pair in imageVisibility)
        {
            if (_pair.Value)
            {
                if (int.TryParse(_pair.Key, out int _indexAnswer))
                {
                    answerImage.texture = answersImages[_indexAnswer];
                    Debug.Log("DEBUG GAME ===> " + answersImages[_indexAnswer].name);
                    if (_indexAnswer == currentQuestionIndex) Success();
                    else Failed();
                    Invoke(nameof(ResetSession), 0.0f);
                    imageVisibility[_pair.Key] = false;
                }
            }
        }
    }

    private void ResetSession()
    {
        session.Reset();
    }

    private void Success()
    {
        if (hasAnswered)
            return;
        hasAnswered = true;
        SoundManager.Instance.PlaySound(successSound);
        currentScore += 3;
        NextQuestion();
        Debug.Log("DEBUG GAME ===> SUCCESS");
    }

    private void Failed()
    {
        if (hasAnswered)
            return;
        hasAnswered = true;
        SoundManager.Instance.PlaySound(failedSound);
        currentScore -= 1;
        NextQuestion();
        Debug.Log("DEBUG GAME ===> FAILED");
    }

    private void NextQuestion()
    {
        UpdateScoreText();
        Invoke(nameof(SelectRandomQuestion), delayBetweenQuestions);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore;
    }

    private void SaveScore()
    {
        if (!save)
            return;
        save.SetNewScore(currentScore);
        save.SetBestScore(currentScore);
    }
}
