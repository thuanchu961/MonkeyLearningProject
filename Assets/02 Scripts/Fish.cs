using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private bool isRight; 
    [SerializeField] private float speed;
    [SerializeField] private float limitX;
    private Rigidbody2D rigi;
    private void Awake()
    {
        rigi = this.gameObject.GetComponent<Rigidbody2D>();
        if (transform.position.x >= 0)
        {
            isRight = true;
        }
    }
    private void Update()
    {
        if(isRight ? (transform.position.x <= -limitX) : (transform.position.x >= limitX))
        {
            isRight = !isRight;
            transform.localScale = new Vector2(transform.localScale.x * (-1), transform.localScale.y);
        }

        rigi.velocity = (isRight ? 1 : -1) * speed * Time.deltaTime * Vector2.left;
    }
}
