using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float CrashInvokeDelay = 1f;
    [SerializeField] ParticleSystem deadEffect;
    [SerializeField] AudioClip crashSFX;
    

    void OnTriggerEnter2D(Collider2D other) { 

        if(other.tag == "Ground" && FindObjectOfType<PlayerController>().canMove){
            deadEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene",CrashInvokeDelay);
            FindObjectOfType<PlayerController>().DisableControls();
        }

    }
    void ReloadScene(){
        SceneManager.LoadScene(0);
    }

}
