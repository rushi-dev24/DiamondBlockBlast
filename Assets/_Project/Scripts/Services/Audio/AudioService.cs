using UnityEngine;

namespace BlockPuzzle.Services.Audio
{
    public sealed class AudioService : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (clip == null)
            {
                return;
            }

            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }

        public void StopMusic()
        {
            musicSource.Stop();
        }

        public void PlaySfx(AudioClip clip)
        {
            if (clip == null)
            {
                return;
            }

            sfxSource.PlayOneShot(clip);
        }

        public void SetMusicEnabled(bool enabled)
        {
            musicSource.mute = !enabled;
        }

        public void SetSfxEnabled(bool enabled)
        {
            sfxSource.mute = !enabled;
        }
    }
}