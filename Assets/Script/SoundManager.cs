using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private readonly Queue<AudioSource> _audioSourcePool = new();

    public void PlayFx(AudioClip audioClip, bool isLoop)
    {
        StartCoroutine(UpdatePlayFxCoroutine(audioClip, isLoop));
    }

    private IEnumerator UpdatePlayFxCoroutine(AudioClip audioClip, bool isLoop)
    {
        var audioSource = InstantiateAudioSource();
        
        // 사운드 재생
        audioSource.clip = audioClip;
        audioSource.loop = isLoop;
        audioSource.Play();
        
        // 사운드 길이만큼 대기
        yield return new WaitForSeconds(audioSource.clip.length);
        
        _audioSourcePool.Enqueue(audioSource);
        audioSource.enabled = false;
    }
    
    private AudioSource InstantiateAudioSource()
    {
        AudioSource audioSource;
        if (_audioSourcePool.Count > 0)
        {
            audioSource = _audioSourcePool.Dequeue();
            audioSource.enabled = true;
        }
        else
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        return audioSource;
    }
}