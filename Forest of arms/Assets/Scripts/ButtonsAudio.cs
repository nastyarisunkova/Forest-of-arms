using UnityEngine;

public class ButtonsAudio : MonoBehaviour
{
    public void AudioClick(AudioClip click)
    {
        GetComponent<AudioSource>().PlayOneShot(click);
    }
}
