using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{

    [SerializeField] AudioSource _animationSoundPlayer;
    [SerializeField] GameObject _videoPanel;

    [SerializeField] private AudioClip[] _footstepRock;
    [SerializeField] private AudioClip[] _footstepSand;
    [SerializeField] private AudioClip[] _footstepMetal;
    [SerializeField] private AudioClip[] _footstepWood;

    [SerializeField] private AudioClip _landRock;
    [SerializeField] private AudioClip _landSand;
    [SerializeField] private AudioClip _landMetal;
    [SerializeField] private AudioClip _landWood;

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
        Debug.Log("pre hit raycast");

        if (Physics.Raycast(_player.transform.position, Vector3.down, out hit))
        {
            var floortag = hit.collider.gameObject.tag;
            Debug.Log("dentro if" + floortag);

            if (floortag == "Metal")
            {
                //play concrete sound code
                int n = Random.Range(1, _footstepMetal.Length);
                Debug.Log("metalFloor");
                _animationSoundPlayer.clip = _footstepMetal[n];
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
                _footstepMetal[n] = _footstepMetal[0];
                _footstepMetal[0] = _animationSoundPlayer.clip;
                // move picked sound to index 0 so it's not picked next time
            }
            else if (floortag == "RockFloor")
            {
                int n = Random.Range(1, _footstepRock.Length);
                _animationSoundPlayer.clip = _footstepRock[n];
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
                _footstepRock[n] = _footstepRock[0];
                _footstepRock[0] = _animationSoundPlayer.clip;
            }
            else if (floortag == "WoodFloor")
            {
                Debug.Log("LEGNOOOO");
                int n = Random.Range(1, _footstepWood.Length);
                _animationSoundPlayer.clip = _footstepWood[n];
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
                _footstepWood[n] = _footstepWood[0];
                _footstepWood[0] = _animationSoundPlayer.clip;
            }
            else if (floortag == "SandFloor")
            {
                int n = Random.Range(1, _footstepSand.Length);
                _animationSoundPlayer.clip = _footstepSand[n];
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
                _footstepSand[n] = _footstepSand[0];
                _footstepSand[0] = _animationSoundPlayer.clip;
            }
            else if (floortag == "GlassFloor")
            {
                int n = Random.Range(1, _footstepRock.Length);
                _animationSoundPlayer.clip = _footstepRock[n];
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
                _footstepRock[n] = _footstepRock[0];
                _footstepRock[0] = _animationSoundPlayer.clip;
            }
        }
    }

    private void PlayerLandSound()
    {
        RaycastHit hit;
        Debug.Log("pre hit raycast");

        if (Physics.Raycast(_player.transform.position, Vector3.down, out hit))
        {
            var floortag = hit.collider.gameObject.tag;
            Debug.Log("dentro if" + floortag);

            if (floortag == "Metal")
            {
                _animationSoundPlayer.clip = _landMetal;
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
            }
            else if (floortag == "RockFloor")
            {
                _animationSoundPlayer.clip = _landRock;
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
            }
            else if (floortag == "WoodFloor")
            {
                _animationSoundPlayer.clip = _landWood;
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
            }
            else if (floortag == "SandFloor")
            {
                _animationSoundPlayer.clip = _landSand;
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
            }
            else if (floortag == "GlassFloor")
            {
                _animationSoundPlayer.clip = _landRock;
                _animationSoundPlayer.PlayOneShot(_animationSoundPlayer.clip);
            }
        }
    }
}
