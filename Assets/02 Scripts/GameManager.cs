using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("References")]
    [SerializeField] private HookController hookController;
    [SerializeField] private BackgroundController bgController;
    [SerializeField] private CameraController camController;
    [SerializeField] private BoatController boatController;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private int maxItems;
    private List<ItemPickUp> lists = new List<ItemPickUp>();

    public bool isGameWin, isHooking, onTap;
    public enum GameState
    {
        Intro,
        GamePlay,
        Victory
    }
    public GameState currentState = GameState.Intro;
    private void Awake()
    {
        soundManager = SoundManager.Instant;
        bgController.ChangeBackground(isGameWin);
    }
    private void Start()
    {
        
    }
    public void SetState()
    {
        switch (currentState)
        {
            case GameState.Intro:
                break;
            case GameState.GamePlay:
                break;
            case GameState.Victory:
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
        camController.MoveCamera(false);
        boatController.Ending();
    }
}
