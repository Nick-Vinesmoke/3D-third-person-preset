using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animation : MonoBehaviour
{
    public Animator anim;
    public player_movement pm;
    public Playerstatus ps;


    // отвечает за ходьбу в прицеле

    public void AnimUpdate()
    {

        anim.SetBool("sprint", ps.isSprinting);
        anim.SetBool("aiming", ps.isAiming);


        if (!ps.isAiming)
            NormalAnim();
        else
            AimAnim();


    }


    void NormalAnim()
    {
        anim.SetFloat("vertical", pm.moveAmount, 0.15f, Time.deltaTime);
    }


    void AimAnim()
    {
        float v = pm.vertical;
        float h = pm.horizontal;
        anim.SetFloat("vertical", v, 0.15f, Time.deltaTime);
        anim.SetFloat("horizontal", h, 0.15f, Time.deltaTime);
        
    }
}
