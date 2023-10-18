using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : Animal, IJellyFishSkill
{
    [SerializeField] private bool isUp; // = true đi lên; = false đi xuống
    private float topLimit, bottomLimit;
    protected override void Awake()
    {
        base.Awake();
        
        float cameraHeight = 2.0f * MainCamera.orthographicSize; // Chiều cao của camera
        float cameraWidth = cameraHeight * MainCamera.aspect; // Chiều rộng của camera
        float cameraPosY = 0f; // MainCamera.transform.position.y

        // Giới hạn trên (biên trên) của camera
        topLimit = cameraPosY + cameraHeight / 2.0f;

        // Giới hạn dưới (biên dưới) của camera
        bottomLimit = cameraPosY - cameraHeight / 2.0f;

        if (transform.position.y >= 0)
        {
            isUp = true;
        }
    }
    public override void Move()
    {
        if (isUp ? (transform.position.y <= bottomLimit - 1) : (transform.position.y >= topLimit + 1))
        {
            isUp = !isUp;
            transform.localScale = new Vector2(transform.localScale.x , transform.localScale.y * (-1));
        }

        Rigi.velocity = (isUp ? 1 : -1) * speed * Time.deltaTime * Vector2.down;
    }

    public void SpecialSkill()
    {
        Debug.Log("Jelly fish is using special skill");
    }
}
