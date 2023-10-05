/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Assistant : MonoBehaviour {

    public Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    public GameObject canvas, uiCam, player, playerCam;
    //private AudioSource talkingAudioSource;


    private void StartTalkingSound() {
        //talkingAudioSource.Play();
    }

    private void StopTalkingSound() {
        //talkingAudioSource.Stop();
    }

    private void Start() {
        string _message = "Welcome to 'Whispers of the Shore,' an atmospheric exploration game that beckons you to step into a world of haunting beauty and mystery. As you venture forth, you'll find yourself on a tranquil yet abandoned beach, its sands kissed by the gentle caress of soft waves. Bathed in the warm embrace of the sun's golden glow, the scenery before you exudes an aura of serene tranquility, inviting you to embark on a journey of discovery.";
        TextWriter.AddWriter_Static(messageText, _message, .1f, true, true, StopTalkingSound);
    }

    public void StartGame(){
        canvas.SetActive(false);
        uiCam.SetActive(false);
        playerCam.SetActive(true);
        player.SetActive(true);
    }

}
