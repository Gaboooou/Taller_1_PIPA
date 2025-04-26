using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource controlSonido;

    public AudioClip sonidoCaminar;
    [SerializeField] private AudioClip[] sound;

    
    private void Awake()
    {
        controlSonido = GetComponent<AudioSource>();
    }

    public void PlaySound(int sonido,float volumen){

        controlSonido.PlayOneShot(sound[sonido],volumen);
    }

    public void PlaySoundLargo(){
        controlSonido.clip = sonidoCaminar;
        controlSonido.Play();
    } 

    public void StopSound(){

        controlSonido.Stop();
    }


}
