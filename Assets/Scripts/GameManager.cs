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

    private bool isEnvelopeCatched;
    private bool isChestOpened;

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
        
    }

    private void Init(){
        UIController.Instance.ShowInitMessage();
        Cursor.visible = true;
        isEnvelopeCatched = false;
        isChestOpened = false;
    }

    public void StartGame(){
        HideCursor();
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
}
