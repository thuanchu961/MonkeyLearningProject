using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManager : MonoBehaviour
{
    private ISetHookState hookAnimator;
    private IMovable hookController;
    private SoundManager soundManager;
    private GameManager gameManager;
    private UiManager uiManager;
    private void Awake()
    {
        hookAnimator = GetComponent<ISetHookState>();
        hookController = GetComponent<IMovable>();
        soundManager = SoundManager.Instant;
        gameManager = GameManager.Instant;
        uiManager = UiManager.Instant;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTarget(Vector3 targetPosition)
    {
        hookController.Move(targetPosition);
    }
}
