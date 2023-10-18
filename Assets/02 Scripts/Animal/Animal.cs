using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour  // có thể kế thừa thêm IAnimalAction
{
    //class này sẽ thực hiện những chức năng cơ bản nhất của Animal  
    //ví dụ như Move, Eat, ... => Single responsibility principle
    //nếu có class con của Animal có thêm  chức năng đặc biệt
    //thì sẽ viết 1 interface riêng thực hiện chức năng đó và implement vào class con đó => Open/Close principle
    public float speed;
    protected Rigidbody2D Rigi { get; private set; }
    protected Camera MainCamera { get; private set; }
    protected virtual void Awake()
    {
        Rigi = this.GetComponent<Rigidbody2D>();
        MainCamera = Camera.main;
    }
    protected virtual void Update()
    {
        Move();
    }
    // Phương thức Move sử dụng abstract vì:
    // - Không có định nghĩa sẵn cho phương thức Move
    // - Các class con kế thừa Animal bắt buộc phải implement và override Move
    public abstract void Move(); 
    // Nếu chỉ để abstract thì sau này khi muốn gọi đến method này từ 1 class khác không phải là class con thì không thể gọi được
    // => Có thể viết phương thức Move vào 1 interface IAnimalAction (gồm các phương thức thực hiện chức năng cơ bản) 
    // => Các class khác không phải là class con thì vẫn có thê gọi đến được các method này thông qua IAnimalAction
    // => Dependency inversion principle
}
