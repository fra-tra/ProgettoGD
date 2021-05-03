using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] LevelLoader _levelLoader;

    public void EndGameClick()
    {
        _levelLoader.ToMenu();
    }
}
