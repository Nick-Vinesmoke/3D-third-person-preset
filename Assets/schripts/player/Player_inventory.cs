using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_inventory : MonoBehaviour
{
    public Weapon_properties firstw;
    public Weapon_properties secondw;

    public Animator anim;

    public Transform targetlook;

    public GameObject Mcamera;
    public Transform R_hand;



    public Player_IK p_ik;
    public Player_input pi;

    public GameObject objWeapon;
    weapon activeWeapon;


    public void SelectWeapon(int SelectedWeapon)
    {
        if(SelectedWeapon == 1)
        {
            DestroyWeapon();
        }
        if (SelectedWeapon == 2)
        {
            objWeapon = Instantiate(firstw.weaponPref);
            activeWeapon = objWeapon.GetComponent<weapon>();
            objWeapon.transform.parent = R_hand;
            objWeapon.transform.localPosition = firstw.Weapon_pos;
            objWeapon.transform.localRotation = Quaternion.Euler(firstw.Wapon_rot);
            p_ik.rightHend.localPosition = firstw.rHandPos;
            Quaternion rotRight = Quaternion.Euler(firstw.rHandRot.x, firstw.rHandRot.y, firstw.rHandRot.z);
            p_ik.rightHend.localRotation = rotRight;




            activeWeapon.targetLook = targetlook;
            activeWeapon.mainCamera = Mcamera;
            pi.wp = activeWeapon;
            p_ik.leftHend_target = activeWeapon.l_hand_target;
            anim.SetBool("Weapon", true);
            
        }
        if (SelectedWeapon == 3)
        {
            objWeapon = Instantiate(secondw.weaponPref);
            activeWeapon = objWeapon.GetComponent<weapon>();
            objWeapon.transform.parent = R_hand;
            objWeapon.transform.localPosition = secondw.Weapon_pos;
            objWeapon.transform.localRotation = Quaternion.Euler(secondw.Wapon_rot);
            p_ik.rightHend.localPosition = secondw.rHandPos;
            Quaternion rotRight = Quaternion.Euler(secondw.rHandRot.x, secondw.rHandRot.y, secondw.rHandRot.z);
            p_ik.rightHend.localRotation = rotRight;




            activeWeapon.targetLook = targetlook;
            activeWeapon.mainCamera = Mcamera;
            pi.wp = activeWeapon;
            p_ik.leftHend_target = activeWeapon.l_hand_target;
            anim.SetBool("Weapon", true);
        }

    }


    public void DestroyWeapon()
    {
        p_ik.leftHend_target = null;
        pi.wp = null;
        Destroy(objWeapon);
        objWeapon = null;
        anim.SetBool("Weapon", false);
        
    }







}
