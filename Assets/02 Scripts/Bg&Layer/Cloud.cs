using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour, IScrollingLayer
{
    [SerializeField] private bool goToRight;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private Vector3 offset;

    public void Scroll()
    {
        transform.position += new Vector3((goToRight ? -1 : 1) * scrollSpeed * Time.fixedDeltaTime, 0, 0);
        if (transform.position.x <= offset.x * (goToRight ? -1 : 1))
        {
            transform.position = new Vector3(offset.x * (goToRight ? 1 : -1), transform.position.y, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        Scroll();
    }

}
