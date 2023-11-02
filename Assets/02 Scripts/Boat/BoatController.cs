using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour, IMovable
{
    [SerializeField] private float moveSpeed = 10;
    public BoatController() { }
    public void Move(Vector3 targetPosition)
    {
        StartCoroutine(MoveToPosition(targetPosition));
    }
    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
