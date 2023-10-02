using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Animal
{
    [SerializeField] private bool isRight; 
    [SerializeField] private float limitX;
    private float edgeRightX, edgeLeftX;
    protected override void Awake()
    {
        base.Awake();
        float cameraWidth = mainCamera.orthographicSize * 2 * mainCamera.aspect;
        edgeLeftX = mainCamera.transform.position.x - cameraWidth / 2f;
        edgeRightX = mainCamera.transform.position.x + cameraWidth / 2f;
        if (transform.position.x >= 0)
        {
            isRight = true;
        }
    }
    protected override void Moving()
    {
        if (isRight ? (transform.position.x <= edgeLeftX - 1) : (transform.position.x >= edgeRightX + 1))
        {
            isRight = !isRight;
            transform.localScale = new Vector2(transform.localScale.x * (-1), transform.localScale.y);
        }

        Rigi.velocity = (isRight ? 1 : -1) * speed * Time.deltaTime * Vector2.left;
    }

}
