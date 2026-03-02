using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    private const string KEY = "Music";

    void Start()
    {
        bool on = PlayerPrefs.GetInt(KEY, 1) == 1;
        GetComponent<Toggle>().isOn = on;
        musicSource.mute = !on;
    }

    public void OnToggleChanged(bool isOn)
    {
        musicSource.mute = !isOn;
        PlayerPrefs.SetInt(KEY, isOn ? 1 : 0);
    }
}