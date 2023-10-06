using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private GameObject envelopeModel;

    [SerializeField] private float maxHealth = 1; // The maximum health value
    [SerializeField] private float healthDecreaseInterval = 1f; // Time interval for health decrease
    private float currentHealth; // The current health value
    private float timer; // Timer for health decrease

    private bool isEnvelopeCatched;
    private bool isChestOpened;

    
    private bool isTimeUP;
    private bool isGameOver;
    private bool isWaterTouched;

    public static GameManager Instance;

    private void Awake() {
        if(Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
            return;
        CheckTimeUP();
        CheckAndDecreaseHealth();
    }

    private void Init(){
        UIController.Instance.ShowInitMessage();
        Cursor.visible = true;
        isEnvelopeCatched = false;
        isChestOpened = false;
        currentHealth = maxHealth;
        timer = healthDecreaseInterval;
        isTimeUP = false;
        isGameOver = false;
        isWaterTouched = false;
    }

    private void CheckTimeUP(){
        if(isTimeUP){
            isGameOver = true;
            UIController.Instance.ShowTimeUP();
            PausePlayerMovement();
            ShowCursor();
        }
    }

    private void CheckAndDecreaseHealth(){
        if(isWaterTouched && !isGameOver){
            // Update the timer
            timer -= Time.deltaTime;

            // Check if it's time to decrease health
            if (timer <= 0)
            {
                // Decrease health by a certain amount
                currentHealth -= .1f; // Adjust the amount as needed

                UIController.Instance.SetHealthSlider(currentHealth);

                // Reset the timer
                timer = healthDecreaseInterval;

                // Check if the player's health has reached zero or below
                if (currentHealth <= 0)
                {
                    // Player has lost all health, you can handle this here
                    // For example, trigger a game over or respawn the player
                    isGameOver = true;
                    Debug.Log("You died!");
                    PausePlayerMovement();
                    ShowCursor();
                    UIController.Instance.ShowDeadUI();
                }
            }
        }
    }

    public void StartGame(){
        HideCursor();
        TimerScript.Instance.TimerOn = true;
    }

    public void ShowCursor(){
        Cursor.visible = true;
    }

    public void HideCursor(){
        Cursor.visible = false;
    }

    public void PausePlayerMovement(){
        thirdPersonController.isMoving = false;
        starterAssetsInputs.cursorLocked = false;
        starterAssetsInputs.cursorInputForLook = false;
        ShowCursor();
    }

    public void ResumePlayerMovement(){
        thirdPersonController.isMoving = true;
        starterAssetsInputs.cursorLocked = true;
        starterAssetsInputs.cursorInputForLook = true;
        HideCursor();
    }

    public void CatchEnvelope(){
        isEnvelopeCatched = true;
        UIController.Instance.ShowEnvelope();
    }

    public void ChestOpened(){
        isChestOpened = true;
        PausePlayerMovement();
        UIController.Instance.ShowThinkingEmoji();
    }

    public void ShowEnvelopeModel(){
        envelopeModel.SetActive(true);
    }

    public bool GetEnvelopeState(){
        return isEnvelopeCatched;
    }

    public bool GetChestState(){
        return isChestOpened;
    }

    public void SetTimeUP(){
        isTimeUP = true;
    }

    public void SetWaterTouch(bool state){
        isWaterTouched = state;
        Debug.Log("water touch: " + state);
    }
}
