using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{

    Character charecter;
    Vector3 location;

    void Awake()
    {
        if (FindObjectsOfType<sceneLoader>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void ChangeScene(string _sceneName)
    {
        if (!charecter)
        {
            charecter = Object.FindObjectOfType<Character>();
        }
        SceneManager.LoadScene(_sceneName);
    }
}
