using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public bool walking = false;
    public Vector2 lastMovement = Vector2.zero;
    private const string 
        AXIS_H = "Horizontal", 
        AXIS_V = "Vertical", 
        WALKING = "Walking",
        LAST_HORIZONTAL = "LastHorizontal",
        LAST_VERTICAL="LastVertical";
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveCharacter();
    }

    void LateUpdate() {
        SetCharacterIsWalking(walking);
        SetAnimatorAxisValues();
        SetLastMovementAnimatorAxisValues(lastMovement);
    }

    void MoveCharacter()
    {
        if(Mathf.Abs(Input.GetAxisRaw(AXIS_H))>0.02f)
        {
            Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H)* speed * Time.deltaTime, 0,0);
            this.transform.Translate(translation);
            walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H),0);
        }

        if(Mathf.Abs(Input.GetAxisRaw(AXIS_V))>0.02f)
        {
            Vector3 translation = new Vector3(0, Input.GetAxisRaw(AXIS_V)* speed * Time.deltaTime, 0);
            this.transform.Translate(translation);
            walking = true;
            lastMovement = new Vector2(0,Input.GetAxisRaw(AXIS_V));
        }

        if((Mathf.Abs(Input.GetAxisRaw(AXIS_V))==0.0f) && (Mathf.Abs(Input.GetAxisRaw(AXIS_H))==0.0f))
        {
           walking = false;
        }
    }

    void SetAnimatorAxisValues()
    {
        _animator.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));
        _animator.SetFloat(AXIS_V, Input.GetAxisRaw(AXIS_V));
    }

    void SetLastMovementAnimatorAxisValues(Vector2 lastMovement){
        _animator.SetFloat(LAST_HORIZONTAL, lastMovement.x);
        _animator.SetFloat(LAST_VERTICAL, lastMovement.y);
    }

    void  SetCharacterIsWalking(bool newState)
    {
        _animator.SetBool(WALKING, newState);
    }
}
