using UnityEngine;

[CreateAssetMenu]
public class AudioClipRefsSO : ScriptableObject
{
    public AudioClip[] Footstep => _footstep;
    
    [SerializeField] private AudioClip[] _footstep;
}