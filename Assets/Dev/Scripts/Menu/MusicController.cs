using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Toggle musicToggle;
    private const string KEY = "Music";

    void Start()
    {
        bool on = PlayerPrefs.GetInt(KEY, 1) == 1;
        musicToggle.isOn = on;
        musicSource.mute = !on;
    }

    public void OnToggleChanged(bool isOn)
    {
        musicSource.mute = !isOn;
        PlayerPrefs.SetInt(KEY, isOn ? 1 : 0);
    }
}