using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_input : MonoBehaviour
{
    public Playerstatus playerstatus;
    public weapon wp;
    public Transform TargetLook;
    public Animator anim;
    public Player_inventory pinv;

    public bool debugAiming;
    public bool isAiming;
    public float Startreloadtime;
    public float Reloadtime;

    public float PistolStartreloadtime;
    public float PistolReloadtime;


    public bool AportunityToAim;
    public float distance;

    public int SelectedWeapon;

    private void Start()
    {

        SelectedWeapon = 1;


    }




    public void InputUpdate()
    {






        //Отвечает за вызов прицеливания по кнопке и стрельбы
        RaycastAiming();


        AimingInput();


        ChangeWeapon();


    }



    public void AimingInput()
    {
        if (Input.GetMouseButton(1) && AportunityToAim)
        {
            if (!playerstatus.Isruning)
            {
                playerstatus.isAiming = true;
                playerstatus.isAimingMove = true;
            }
            else
            {
                playerstatus.isAiming = isAiming;
            }

        }
        if (Input.GetMouseButton(1) && !AportunityToAim)
        {
            if (!playerstatus.Isruning)
            {
                playerstatus.isAiming = false;
                playerstatus.isAimingMove = true;
            }
            else
            {
                playerstatus.isAiming = isAiming;
            }
        }
        if (!Input.GetMouseButton(1))
        {
            playerstatus.isAiming = false;
            playerstatus.isAimingMove = false;
        }

        //if (!debugAiming)
        //{
        // if (!playerstatus.Isruning)
        //{
        // playerstatus.isAiming = Input.GetMouseButton(1);
        //}
        // else
        // {
        //playerstatus.isAiming = isAiming;
        // }

        // }

        //else
        //{
        //playerstatus.isAiming = isAiming;
        //}

        if (playerstatus.isAiming)
        {
            if (Input.GetMouseButton(0) && AportunityToAim)
            {


                if(SelectedWeapon == 2)
                {
                    if (Reloadtime <= 0)
                    {
                        wp.Shoot();
                        Reloadtime = Startreloadtime;
                    }
                    else
                    {
                        Reloadtime -= Time.deltaTime;
                    }
                }

                if (SelectedWeapon == 3)
                {
                    if (PistolReloadtime <= 0)
                    {
                        wp.Shoot();
                        PistolReloadtime = PistolStartreloadtime;
                    }
                    else
                    {
                        PistolReloadtime -= Time.deltaTime;
                    }
                }






            }
        }



        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("couch", true);
            playerstatus.IsCouching = true;
        }
        else
        {
            anim.SetBool("couch", false);
            playerstatus.IsCouching = false;
        }





    }


    public void ChangeWeapon()
    {
        if (!anim.GetBool("aiming"))
        {
            if(Input.GetKeyDown(KeyCode.Alpha1) && SelectedWeapon != 1)
            {
                SelectedWeapon = 1;
                anim.SetTrigger("Select");
                AportunityToAim = false;

            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && SelectedWeapon != 2)
            {
                SelectedWeapon = 2;
                anim.SetTrigger("Select");

            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && SelectedWeapon != 3)
            {
                SelectedWeapon = 3;
                anim.SetTrigger("Select");

            }
        }
    }


    public void SelectWeapon()
    {
        if (SelectedWeapon != 1)
        {
            pinv.DestroyWeapon();
        }
        pinv.SelectWeapon(SelectedWeapon);
    }

    // Проверяет не столкнулись ли мы со стеной
    public void RaycastAiming()
    {

        
        


            Debug.DrawLine(transform.position + transform.up * 1.4f, TargetLook.position, Color.green);


            distance = Vector3.Distance(transform.position + transform.up * 1.4f, TargetLook.position);
            if (distance > 1.5f)
                AportunityToAim = true;
            else AportunityToAim = false;
        
    }









}
