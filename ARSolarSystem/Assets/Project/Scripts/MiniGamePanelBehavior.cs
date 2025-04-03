using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class MiniGamePanelBehavior : MonoBehaviour
{
    [SerializeField] MiniGameSave save = null;
    [SerializeField] Button playButton = null;
    [SerializeField] Button resetButton = null;
    [SerializeField] RotationUIBehavior miniGame = null;
    [SerializeField] TMP_Text lastScoreText = null;
    [SerializeField] TMP_Text bestScoreText = null;
    [SerializeField] AudioResource buttonPressSound = null;
    [SerializeField] GameObject settingsPanel = null;

    [SerializeField] GameObject particles = null;
    [SerializeField] GameObject solarSystem = null;
    [SerializeField] GameObject skybox = null;
    [SerializeField] GameObject darkIrlBackground = null;
    [SerializeField] GameObject tutorialMenu = null;

    bool skyboxActive = false;
    bool darkIrlBackgroundActive = false;

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
        PrepareGame();
        miniGame.gameObject.SetActive(true);
        settingsPanel.SetActive(false);
    }

    private void ResetScore()
    {
        SoundManager.Instance.PlaySound(buttonPressSound);
        if (!save)
            return;
        save.SetNewScore(0);
        UpdateTexts();
    }

    private void PrepareGame()
    {
        skyboxActive = skybox.activeInHierarchy;
        darkIrlBackgroundActive = darkIrlBackground.activeInHierarchy;
        particles.SetActive(false);
        solarSystem.SetActive(false);
        skybox.SetActive(false);
        darkIrlBackground.SetActive(false);
        tutorialMenu.SetActive(false);
    }

    public void ResetGame()
    {
        particles.SetActive(true);
        solarSystem.SetActive(true);
        tutorialMenu.SetActive(true);
        skybox.SetActive(skyboxActive);
        darkIrlBackground.SetActive(darkIrlBackgroundActive);
    }
}
