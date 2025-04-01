using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    
    public static T Instance => instance;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        if(!instance)
        {
            instance = this as T;
            DontDestroyOnLoad(instance);
        }

    }
}
