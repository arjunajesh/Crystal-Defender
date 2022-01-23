using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{
    private AudioSource audioScr;
    private float gameVolume = 1f;

     void Start()
    {
        audioScr = GetComponent<AudioSource>();

    }

    void Update()
    {
        audioScr.volume = gameVolume;    
    }

    public void SetVolume(float vol) {
        gameVolume = vol;

    }

}
