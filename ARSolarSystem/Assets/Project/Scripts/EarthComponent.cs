using UnityEngine;

public class EarthComponent : MonoBehaviour
{
    [SerializeField] GameObject moon = null;

    private void OnEnable()
    {
        if (moon)
            moon.SetActive(true);
    }

    private void OnDisable()
    {
        if (moon)
            moon.SetActive(false);
    }
}
