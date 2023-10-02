using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Rigidbody2D Rigi { get; private set; }
    protected Camera mainCamera { get; private set; }
    protected virtual void Awake()
    {
        Rigi = this.GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }
    protected virtual void Start()
    {
        
    }
    protected virtual void Update()
    {
        Moving();
    }
    protected virtual void Moving()
    {

    }
}
