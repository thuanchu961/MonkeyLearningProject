using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public enum GameState
{
    Intro,
    GamePlay,
    Victory
}
public class GameManager : Singleton<GameManager>
{
    public static event Action OnGameStateChanged;
    public static UnityEvent OnGameWin;
    [Header("References")]
    [SerializeField] private HookManager hookController;
    [SerializeField] private BackgroundController bgController;
    [SerializeField] private CameraController camController;
    [SerializeField] private BoatManager boatController;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private UiManager uiManager;
    [SerializeField] private int maxItems;
    private List<ItemPickUp> lists = new();
    public bool isGameWin, isHooking, onTap;
    
    public GameState currentState = GameState.Intro;

    private void Awake()
    {
        soundManager = SoundManager.Instant;
        uiManager = UiManager.Instant;
        bgController.ChangeBackground(isGameWin);
        //OnGameWin.AddListener(Victory);
    }
    private void Start()
    {
        SetGameState(currentState);     
    }
    public void SetGameState(GameState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case GameState.Intro:
                OnGameStateChanged?.Invoke();
                break;
            case GameState.GamePlay:
                break;
            case GameState.Victory:
                //OnGameWin.Invoke();
                break;
        }
    }
    public void SendPositionToHook(Vector3 pos)
    {
        hookController.SetTarget(pos);
    }
    public void SendAudioClip(AudioClip clip)
    {
        soundManager.ReceiveAudioClip(clip);
    }
    public void SendWord(string word)
    {
        uiManager.ReceiveWord(word);
    }
    public void AddToList(ItemPickUp item)
    {
        lists.Add(item);
        item.gameObject.SetActive(false);
        if(lists.Count == maxItems)
        {
            //currentState = GameState.Victory;
            isGameWin = true;
        }
    }
    public void Victory()
    {
        bgController.ChangeBackground(isGameWin);

        IMoveCamera cam = new CameraController();
        cam.MoveCamera(new Vector3(0,10,0));

        boatController.BoatEnding();
        uiManager.ShowPopupVictory();
    }
}
