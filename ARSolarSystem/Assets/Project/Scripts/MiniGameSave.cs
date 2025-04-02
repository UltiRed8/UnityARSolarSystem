using UnityEngine;

public class MiniGameSave : MonoBehaviour
{
    [SerializeField] int lastScore = 0;
    [SerializeField] int bestScore = 0;

    public void SetNewScore(int _score)
    {
        lastScore = _score;
    }

    public void SetBestScore(int _score)
    {
        if (bestScore < _score)
            bestScore = _score;
    }

    public int GetLastScore()
    {
        return lastScore;
    }

    public int GetBestScore()
    {
        return bestScore;
    }
}
