using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{


    public Transform cameraTrans;

    public Playerstatus playerstatus;

    public Animator anim;

    public float speed;

    public float vertical;
    public float horizontal;
    public float moveAmount;
    public float rotationSpeed;

    public Vector3 rotationDirection;

    public Vector3 moveDirection;

    // обычная ходьба

    public void MoveUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));






        Vector3 moveDir = cameraTrans.forward * vertical;
        moveDir += cameraTrans.right * horizontal;
        moveDir.Normalize();
        moveDirection = moveDir;
        rotationDirection = cameraTrans.forward;

        NormalRotation();
        playerstatus.isGround = Ground();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("run", true);
            playerstatus.isAiming = false;
            playerstatus.Isruning = true;
        }
        else
        {
            anim.SetBool("run", false);
            playerstatus.Isruning = false;
        }

        
        
    }



    public void NormalRotation()
    {
        if (!playerstatus.isAiming)
        {
            rotationDirection = moveDirection;
        }

        Vector3 targetDir = rotationDirection;
        targetDir.y = 0;



        if (targetDir == Vector3.zero)
            targetDir = transform.forward;


        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation, lookDir, rotationSpeed);
        transform.rotation = targetRot;
    }


    public bool Ground()
    {
        Vector3 origin = transform.position;
        origin.y += 0.01f;
        Vector3 dir = Vector3.up;
        float dis = 0.7f;
        RaycastHit hit;
        if(Physics.Raycast(origin, dir, out hit, dis))
        {
            Vector3 tp = hit.point;
            transform.position = tp;
            return true;
        }

        return false;
    }



}
