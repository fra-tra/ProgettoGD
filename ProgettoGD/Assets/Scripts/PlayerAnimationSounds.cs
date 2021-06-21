using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{

    [SerializeField] AudioSource _animationSoundPlayer;
    [SerializeField] GameObject _videoPanel;

    [SerializeField] AudioClip _footstepRock;
    [SerializeField] AudioClip _footstepSand;
    [SerializeField] AudioClip _footstepMetal;
    [SerializeField] AudioClip _footstepWood;

    [SerializeField] Rigidbody _player;



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
        RaycastHit hit;

        if (Physics.Raycast(_player.transform.position, Vector3.down, out hit))
        {
            var floortag = hit.collider.gameObject.tag;

            if (floortag == "Metal")
            {
                //play concrete sound code
                _animationSoundPlayer.clip = _footstepMetal;
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
                // move picked sound to index 0 so it's not picked next time
            }
            else if (floortag == "RockFloor")
            {
                _animationSoundPlayer.clip = _footstepRock;
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
            }
            else if (floortag == "WoodFloor")
            {
                Debug.Log("LEGNOOOO");
                _animationSoundPlayer.clip = _footstepWood;
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
            }
            else if (floortag == "SandFloor")
            {
                _animationSoundPlayer.clip = _footstepSand;
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
            }
        }
    }
}
