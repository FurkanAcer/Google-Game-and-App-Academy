using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using System.Runtime.InteropServices;
using MusicFilesNS;

public class PowerUpCollection : MonoBehaviour
{
    private GameObject _music;
    private MusicFiles _musicFiles;
    private FirstPersonController _firstPersonController;
    private void Start()
    {
        _music = GameObject.Find("AudioManager");
         _musicFiles = _music.GetComponent(typeof(MusicFiles)) as MusicFiles;
        _firstPersonController = GetComponent<FirstPersonController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(_musicFiles.music[0], gameObject.transform.position);
            _firstPersonController.SprintSpeed = 10f;
            Invoke("BackToNormalSpeed", 3f);
            
        }
    }


    private void BackToNormalSpeed()
    {
        _firstPersonController.SprintSpeed = 5f;
    }
}
