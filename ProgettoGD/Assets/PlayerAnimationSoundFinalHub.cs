using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSoundFinalHub : MonoBehaviour
{

    [SerializeField] AudioSource _animationSoundPlayer;
    [SerializeField] GameObject _videoPanel;
    [SerializeField] GameObject _videoPanel2;
    [SerializeField] GameObject _videoPanel3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_videoPanel.activeSelf || _videoPanel2.activeSelf || _videoPanel3.activeSelf)
        {
            _animationSoundPlayer.mute = true;
        }
        else
        {
            _animationSoundPlayer.mute = false;
        }
    }

    private void PlayerFootstepSound()
    {
        _animationSoundPlayer.Play();
    }
}

