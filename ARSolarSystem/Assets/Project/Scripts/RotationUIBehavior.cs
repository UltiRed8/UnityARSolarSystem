using UnityEngine;

public class RotationUIBehavior : MonoBehaviour
{
    [SerializeField] MiniGame miniGame = null;

    private void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            miniGame.gameObject.SetActive(true);
            miniGame.StartGame();
            gameObject.SetActive(false);
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
