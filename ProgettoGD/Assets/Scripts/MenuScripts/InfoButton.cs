using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoButton : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] public GameObject _selectedButtonMainMenu;

    public void GoBack()
    {
        _mainMenu.SetActive(true);
        gameObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_selectedButtonMainMenu);
    }
}
