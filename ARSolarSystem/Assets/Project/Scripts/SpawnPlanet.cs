using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnPlanet : MonoBehaviour
{
    [SerializeField] ARTrackedImageManager manager;
    [SerializeField] List<GameObject> planets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        manager.trackedImagesChanged -= DetectPlanetToSpawn;
    }

    void Init()
    {
        //manager = GetComponent<ARTrackedImageManager>();
        if (!manager) return;
        manager.trackedImagesChanged += DetectPlanetToSpawn;
    }

    void DetectPlanetToSpawn(ARTrackedImagesChangedEventArgs _image)
    {
        foreach (ARTrackedImage _trackedImage in _image.added)
        {
            SpawnPlanetWithName(_trackedImage.referenceImage.name);
        }
    }

    void SpawnPlanetWithName(string _name)
    {
        foreach (GameObject planet in planets)
        {
            if(planet.name == _name)
            {
                planet.SetActive(true);
            }
        }
    }
}
