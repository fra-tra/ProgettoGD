using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{

    [SerializeField] AudioSource _animationSoundPlayer;
    [SerializeField] GameObject _videoPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_videoPanel.activeSelf)
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
