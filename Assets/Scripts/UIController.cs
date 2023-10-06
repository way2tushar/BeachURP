using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;
using StarterAssets;

public class UIController : MonoBehaviour
{
    
    [SerializeField] private Text messageText;
    [SerializeField] private GameObject canvas, uiCam, player, playerCam, conversationUI, startUI, conversationNxtBtn, conversationOkayBtn;

    [SerializeField] private Text[] chatTextField;
    [SerializeField] private string[] chatList;

    private TextWriter.TextWriterSingle textWriterSingle;
    private string startMessage = "Welcome to 'Whispers of the Shore,' an atmospheric exploration game that beckons you to step into a world of haunting beauty and mystery. As you venture forth, you'll find yourself on a tranquil yet abandoned beach, its sands kissed by the gentle caress of soft waves. Bathed in the warm embrace of the sun's golden glow, the scenery before you exudes an aura of serene tranquility, inviting you to embark on a journey of discovery.";

    private int currentChatPosition;

    public static UIController Instance;

    private void Awake() {
        if(Instance == null)
            Instance = this;
    }


    public void ShowInitMessage(){
        TextWriter.AddWriter_Static(messageText, startMessage, .1f, true, true, StopTalkingSound);
    }

    public void OnClickStartBtn(){
        canvas.SetActive(false);
        uiCam.SetActive(false);
        playerCam.SetActive(true);
        player.SetActive(true);
        GameManager.Instance.StartGame();
    }

    public void ShowConversation(){
        GameManager.Instance.PausePlayerMovement();
        startUI.SetActive(false);
        canvas.SetActive(true);
        conversationUI.SetActive(true);
        currentChatPosition = 0;
        TextWriter.AddWriter_Static(chatTextField[currentChatPosition], chatList[currentChatPosition], .1f, true, true, StopTalkingSound);
        currentChatPosition++;
    }

    public void ShowNextChat(){
        TextWriter.AddWriter_Static(chatTextField[currentChatPosition], chatList[currentChatPosition], .1f, true, true, StopTalkingSound);
        currentChatPosition++;
        if(currentChatPosition == chatTextField.Length){
            conversationNxtBtn.SetActive(false);
            conversationOkayBtn.SetActive(true);
        }
    }

    public void OnClickOkayBtn(){
        GameManager.Instance.ResumePlayerMovement();
        conversationUI.SetActive(false);
        canvas.SetActive(false);
    }

    private void StartTalkingSound() {
        //talkingAudioSource.Play();
    }

    private void StopTalkingSound() {
        //talkingAudioSource.Stop();
    }
}
