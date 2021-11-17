using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneSingleton<T> : MonoBehaviour where T : SceneSingleton<T>
{
    private static T _Instance = null;

    protected SceneSingleton() { }

    public static T Instance
    {
        get
        {
            if (!_Instance)
            {
                _Instance = FindObjectOfType<T>();

                if (!_Instance)
                    Debug.LogError($"Não foi possivel carregar o singleton {nameof(T)}.");

                //if (!_Instance)
                //    _Instance = new GameObject(typeof(T).Name).AddComponent<T>();

                //DontDestroyOnLoad(_Instance.gameObject); //isso é só pra objetos que vão ser inicializador apenas uma vez
            }
            return _Instance;
        }
    }

}

