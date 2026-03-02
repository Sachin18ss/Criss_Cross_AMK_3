using UnityEngine;
using UnityEngine.UI;

public class SFXController : MonoBehaviour
{
    public static bool Enabled = true;
    private const string KEY = "SFX";
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioClip _placeSfxClip;
    [SerializeField] private Toggle sfxToggle;

    void Start()
    {
        Enabled = PlayerPrefs.GetInt(KEY, 1) == 1;
        sfxToggle.isOn = Enabled;
    }

    public void OnToggleChanged(bool isOn)
    {
        Enabled = isOn;
        PlayerPrefs.SetInt(KEY, isOn ? 1 : 0);
    }

    public void PlayPlaceSFX()
    {
        if (Enabled)
            _sfxSource.PlayOneShot(_placeSfxClip);
    }
}