using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_IK : MonoBehaviour
{
    public Animator anim;
    public player_movement pm;
    public Player_inventory pivent;
    public Playerstatus ps;
    public Transform targetLook;



    public Transform rightHend;
    public Transform leftHend_target;
    public Transform leftHend;
    public Quaternion Left_hand_rot;

    public float rightHend_weight;

    public Transform shoulder;
    public Transform aimPivot;



    // Start is called before the first frame update
    void Start()
    {
        shoulder = anim.GetBoneTransform(HumanBodyBones.RightShoulder).transform;

        aimPivot = new GameObject().transform;
        aimPivot.name = "Aim_pivot";
        aimPivot.transform.parent = transform;




        rightHend = new GameObject().transform;
        rightHend.name = "Right_hand";
        rightHend.transform.parent = aimPivot;




        leftHend = new GameObject().transform;
        leftHend.name = "Left_hand";
        leftHend.transform.parent = aimPivot;


    }

    // Update is called once per frame
    void Update()
    {

        if (leftHend_target != null)
        {
            Left_hand_rot = leftHend_target.rotation;
            leftHend.position = leftHend_target.position;

        }



            if (ps.isAiming)
                rightHend_weight += Time.deltaTime * 2;
            else rightHend_weight -= Time.deltaTime * 2;
            rightHend_weight = Mathf.Clamp(rightHend_weight, 0, 1);
        
    }


    private void OnAnimatorIK(int layerIndex)
    {
        aimPivot.position = shoulder.position;

        if (ps.isAiming)
        {
            //это все для ровных рук

            aimPivot.LookAt(targetLook);

            anim.SetLookAtWeight(.2f, .8f, .2f);
            anim.SetLookAtPosition(targetLook.position);

            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHend.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, Left_hand_rot);


            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHend_weight);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHend_weight);
            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHend.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, rightHend.rotation);
        }
        else
        {
            anim.SetLookAtWeight(.3f, .3f, .3f);
            anim.SetLookAtPosition(targetLook.position);

            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHend.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, Left_hand_rot);


            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHend_weight);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHend_weight);
            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHend.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, rightHend.rotation);


        }
    }



}
