using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MiniGamePanelBehavior : MonoBehaviour
{
    [SerializeField] MiniGameSave save = null;
    [SerializeField] Button playButton = null;
    [SerializeField] Button resetButton = null;
    [SerializeField] MiniGame miniGame = null;
    [SerializeField] Text lastScoreText = null;
    [SerializeField] Text bestScoreText = null;
    [SerializeField] AudioResource buttonPressSound = null;

    private void Start()
    {
        if (playButton)
            playButton.onClick.AddListener(Play);
        if (resetButton)
            resetButton.onClick.AddListener(ResetScore);
    }

    private void OnEnable()
    {
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        if (!save)
            return;
        lastScoreText.text = "Last score: " + save.GetLastScore();
        bestScoreText.text = "Best score: " + save.GetBestScore();
    }

    private void Play()
    {
        SoundManager.Instance.PlaySound(buttonPressSound);
        miniGame.gameObject.SetActive(true);
        miniGame.StartGame();
    }

    private void ResetScore()
    {
        SoundManager.Instance.PlaySound(buttonPressSound);
        if (!save)
            return;
        save.SetNewScore(0);
        UpdateTexts();
    }
}
