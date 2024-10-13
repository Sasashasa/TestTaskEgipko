using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    
    [SerializeField] private AudioClipRefsSO _audioClipRefsSO;
    [SerializeField] private float _volume = 0.3f;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayFootstepsSound(Vector3 position, float volume)
    {
        PlaySound(_audioClipRefsSO.Footstep, position, volume);
    }
    
    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * _volume);
    }
}