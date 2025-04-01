using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] RawImage image = null;
    [SerializeField] TMP_Text text = null;
    [SerializeField] float delay = 5.0f;
    [SerializeField] bool isLoading = false;
    [SerializeField] float rotationAnimationSpeed = 1.0f;
    [SerializeField] float dotDelay = 0.5f;
    [SerializeField] int maxDots = 3;
    float currentDelay = 0.0f;
    int dots = 0;

    void Start()
    {
        StartLoading();
        Invoke(nameof(StopLoading), delay);
    }

    private void StartLoading()
    {
        currentDelay = 0.0f;
        dots = 0;
        UpdateText();
        isLoading = true;
    }

    private void StopLoading()
    {
        isLoading = false;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isLoading)
            return;
        float _deltatime = Time.deltaTime;
        currentDelay += _deltatime;
        if (currentDelay >= dotDelay)
        {
            dots++;
            currentDelay = 0.0f;
            if (dots > maxDots)
                dots = 0;
            UpdateText();
        }
        Vector3 _currentRotation = image.transform.rotation.eulerAngles;
        _currentRotation.y += rotationAnimationSpeed * _deltatime * 150.0f;
        image.transform.rotation = Quaternion.Euler(_currentRotation);
    }

    private void UpdateText()
    {
        string _text = "Loading";
        for (int _index = 0; _index < dots; _index++)
            _text += ".";
        text.text = _text;
    }
}
