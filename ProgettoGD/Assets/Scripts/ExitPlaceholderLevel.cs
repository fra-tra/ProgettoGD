using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPlaceholderLevel : MonoBehaviour
{
    [SerializeField] public LevelLoader _levelLoader;
    private bool _pressed = false;

    void Update()
    {
        if (Input.GetButton("SpecialObject") && !_pressed)
        {
            Debug.Log("Loading...");
            _pressed = true;
            _levelLoader.LoadNextLevel();
        }
    }
}
