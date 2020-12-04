using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static bool playerCreated;

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
    private Rigidbody2D _rigidbody;
    public string nextUuid;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if(!PlayerController.playerCreated)
        {
            DontDestroyOnLoad(this.transform.gameObject);
            playerCreated  = true;
        }else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        MoveCharacter();
    }

    void LateUpdate() {
        SetCharacterIsWalking(walking);
        SetAnimatorAxisValues();
        SetLastMovementAnimatorAxisValues(lastMovement);
        StopPlayerMovement();

    }

    void MoveCharacter()
    {
        if(Mathf.Abs(Input.GetAxisRaw(AXIS_H))>0.02f)
        {
            //Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H)* speed * Time.deltaTime, 0,0);
            //this.transform.Translate(translation);
            _rigidbody.velocity = new Vector2(Input.GetAxisRaw(AXIS_H)* speed, _rigidbody.velocity.y);
            walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H),0);
        }

        if(Mathf.Abs(Input.GetAxisRaw(AXIS_V))>0.02f)
        {
            //Vector3 translation = new Vector3(0, Input.GetAxisRaw(AXIS_V)* speed * Time.deltaTime, 0);
            //this.transform.Translate(translation);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Input.GetAxisRaw(AXIS_V)*speed);
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

    void StopPlayerMovement()
    {
        if(!walking)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
