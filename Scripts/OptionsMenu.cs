/** The options menu script allows for functionality of the options menu buttons and sliders
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Debug.Log(isFullScreen);
        Screen.fullScreen = isFullScreen;

    }
}
