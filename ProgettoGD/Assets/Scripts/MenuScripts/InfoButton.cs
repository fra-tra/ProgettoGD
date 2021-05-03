using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;

    public void GoBack()
    {
        _mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
