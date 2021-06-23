using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudioSources : MonoBehaviour
{

    [SerializeField] GameObject _videoPanel;
    [SerializeField] AudioSource _ricordo;
    [SerializeField] AudioSource _musica;
    [SerializeField] AudioSource _ambientale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_videoPanel.activeSelf)
        {
            _ricordo.mute = true;
            _musica.mute = true;
            _ambientale.mute = true;

        }
    }
}
