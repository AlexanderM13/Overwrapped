using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour {
    [SerializeField] private Slider musicVolumeSlider;
    private AudioSource backgroundMusic;

    private void Start() {
        backgroundMusic = GameObject.Find("Background Music").GetComponent<AudioSource>();

        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.1f);
        musicVolumeSlider.value = savedVolume;
        ApplyVolume(savedVolume);

        musicVolumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
    }

    public void OnVolumeChanged() {
        float volume = musicVolumeSlider.value;
        ApplyVolume(volume);

        // Save the volume to PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    private void ApplyVolume(float volume) {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = volume;
        }
    }
}


