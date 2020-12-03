using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical";

    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        if(Mathf.Abs(Input.GetAxisRaw(AXIS_H))>0.2f)
        {
            Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H)* speed * Time.deltaTime, 0,0);
            this.transform.Translate(translation);
        }

        if(Mathf.Abs(Input.GetAxisRaw(AXIS_V))>0.2f)
        {
            Vector3 translation = new Vector3(0, Input.GetAxisRaw(AXIS_V)* speed * Time.deltaTime, 0);
            this.transform.Translate(translation);
        }
    }
}
