using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;
using StarterAssets;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    
    [SerializeField] private Text messageText;
    [SerializeField] private GameObject canvas, uiCam, player, playerCam, conversationUI, startUI, conversationNxtBtn, conversationOkayBtn, envelope, thinkingEmoji, tuneEmoji, gameOver, timeUP,
    healthObj, timerObj, deadUI;

    [SerializeField] private Text gameOverTextField;
    [SerializeField] private Slider slider;
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
        healthObj.SetActive(true);
        timerObj.SetActive(true);
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
        GameManager.Instance.ShowEnvelopeModel();
        conversationUI.SetActive(false);
        canvas.SetActive(false);

    }

    public void ShowEnvelope(){
        envelope.SetActive(true);
    }

    public void ShowThinkingEmoji(){
        thinkingEmoji.SetActive(true);
    }

    public void OnClickEnvelopeBtn(){
        if(GameManager.Instance.GetChestState()){
            thinkingEmoji.SetActive(false);
            tuneEmoji.SetActive(true);
            Invoke("ShowGameOver",2f);
        }
    }

    public void ShowTimeUP(){
        timeUP.SetActive(true);
        HideHealthTimer();
    }

    public void ShowDeadUI(){
        deadUI.SetActive(true);
        HideHealthTimer();
    }

    public void ReloadGame(){
        SceneManager.LoadScene(0);
    }

    public void SetHealthSlider(float state){
        if(state < .7 && state > .4){
            ChangeFillColor(Color.yellow);
        }
        else if(state <= .4){
            ChangeFillColor(Color.red);
        }
        slider.value = state;

    }
    

    // Function to change the fill color
    private void ChangeFillColor(Color newColor)
    {
        // Access the Fill image component of the Slider
        Image fillImage = slider.fillRect.GetComponent<Image>();

        // Change the color of the Fill image
        fillImage.color = newColor;
    }

    private void ShowGameOver(){
        HideHealthTimer();
        gameOver.SetActive(true);
        envelope.SetActive(false);
        TextWriter.AddWriter_Static(gameOverTextField, "Game Over!", .1f, true, true, StopTalkingSound);
    }

    private void HideHealthTimer(){
        healthObj.SetActive(false);
        timerObj.SetActive(false);
    }

    private void StartTalkingSound() {
        //talkingAudioSource.Play();
    }

    private void StopTalkingSound() {
        //talkingAudioSource.Stop();
    }
}
