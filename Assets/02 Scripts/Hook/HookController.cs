using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class HookController : MonoBehaviour
{
    [SerializeField] private HookAnimator hookAnimator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float offset;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector3 targetPosition;
    private Vector3 prevPosition;
    private Vector3 newPosition;
    private Camera mainCamera;
    private SoundManager soundManager;
    private GameManager gameManager;
    private UiManager uiManager;
    private float timer = 0.0f;
    private ItemPickUp hookedItem;
    private void Awake()
    {
        mainCamera = Camera.main;
        soundManager = SoundManager.Instant;
        gameManager = GameManager.Instant;
        uiManager = UiManager.Instant;
    }
    private void Update()
    {
        if (targetPosition == Vector3.zero)
            return;

        //newPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        //rigi.velocity = moveSpeed * Time.deltaTime * (newPosition - transform.position).normalized;
        //if (Vector3.Distance(transform.position, newPosition) < 0.1f)
        //{
        //    transform.position = newPosition;
        //    prevPosition = newPosition;
        //    StartCoroutine(PickUp());
        //}
    }
    private IEnumerator MoveSequence()
    {
        // Di chuyển đến vị trí A
        newPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        yield return MoveToPosition(newPosition);
        prevPosition = newPosition;

        // Di chuyển đến vị trí B
        yield return new WaitForSeconds(0.2f);
        newPosition = new Vector3(transform.position.x, targetPosition.y, transform.position.z);
        hookAnimator.SetState(HookAnimator.STATE.Open);
        soundManager.PlaySound((int)Constant.SOUND.Hook, 1f);
        while (timer < 1f)
        {
            yield return MoveToPosition(newPosition);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
        yield return new WaitForSeconds(0.25f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0f, layerMask);
        if (hit.collider != null)
        {
            hookedItem = hit.collider.gameObject.GetComponent<ItemPickUp>();
            hookedItem.transform.SetParent(transform);
            hookedItem.transform.localPosition = Vector3.zero;
        }
        hookAnimator.SetState(HookAnimator.STATE.Close);

        // Di chuyển đến vị trí giữa màn hình
        yield return new WaitForSeconds(0.25f);
        Vector3 centerScreenPoint = new Vector3(0.5f, 0.5f, 0);
        // Chuyển đổi tọa độ viewport thành tọa độ thế giới
        Vector3 centerWorldPoint = mainCamera.ViewportToWorldPoint(centerScreenPoint);
        newPosition = new Vector3(transform.position.x, centerWorldPoint.y, transform.position.z);
        Vector3 middlePosition = (newPosition + prevPosition) / 2;
        while(timer < 0.5f)
        {
            yield return MoveToPosition(middlePosition);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
        yield return new WaitForSeconds(0.25f);
        soundManager.PlayWord();
        uiManager.ShowWordText();
        bool isPlaying = true;
        while (isPlaying)
        {
            isPlaying = soundManager.IsWordPlaying();
            yield return null;
        }
        
        // Kéo vật phẩm ra khỏi màn hình
        yield return new WaitForSeconds(0.4f);
        // Lấy chiều cao và chiều rộng của camera trong không gian thế giới
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        // Tính giới hạn trên và giới hạn dưới của camera
        float cameraTop = transform.position.y + cameraHeight;
        float cameraBottom = transform.position.y - cameraHeight;
        newPosition = new Vector3(transform.position.x, cameraTop + offset, transform.position.z);
        soundManager.PlaySound((int)Constant.SOUND.Hook, 0.5f);
        while (timer < 0.5f)
        {
            yield return MoveToPosition(newPosition);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
        gameManager.AddToList(hookedItem);
        hookAnimator.SetState(HookAnimator.STATE.Waiting);

        if(gameManager.isGameWin)
        {
            this.gameObject.SetActive(false);
            gameManager.Victory();
            //gameManager.SetGameState(GameState.Victory);
            yield break;
        }

        // Quay về giữa màn hình
        yield return new WaitForSeconds(0.25f);
        while (timer < 0.5f)
        {
            yield return MoveToPosition(middlePosition);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
        yield return new WaitForSeconds(0.2f);
        gameManager.onTap = false; 
        // Kết thúc loạt hành động
        ResetTarget();
        soundManager.StartCountdown();
        Debug.Log("Hoàn thành!");
    }
    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
    public void SetTarget(Vector3 itemPosition)
    {
        targetPosition = itemPosition;
        StartCoroutine(MoveSequence());
    }
    public void ResetTarget()
    {
        targetPosition = Vector3.zero;
        gameManager.isHooking = false;
    }
}
