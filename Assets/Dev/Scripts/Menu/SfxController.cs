using UnityEngine;
using UnityEngine.UI;

public class SFXController : MonoBehaviour
{
    public static bool Enabled = true;
    private const string KEY = "SFX";

    void Start()
    {
        Enabled = PlayerPrefs.GetInt(KEY, 1) == 1;
        GetComponent<Toggle>().isOn = Enabled;
    }

    public void OnToggleChanged(bool isOn)
    {
        Enabled = isOn;
        PlayerPrefs.SetInt(KEY, isOn ? 1 : 0);
    }
}