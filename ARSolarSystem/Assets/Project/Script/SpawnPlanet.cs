using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnPlanet : MonoBehaviour
{
    [SerializeField] ARTrackedImageManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.trackedImagesChanged += SpawnPlanetWithImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        manager.trackedImagesChanged -= SpawnPlanetWithImage;
    }

    void SpawnPlanetWithImage(ARTrackedImagesChangedEventArgs _image)
    {
        foreach (ARTrackedImage _trackedImage in _image.added)
        {
            Debug.Log(_trackedImage.referenceImage.name);
        }
    }
}
