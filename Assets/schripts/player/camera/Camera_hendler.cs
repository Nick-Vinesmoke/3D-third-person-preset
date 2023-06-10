using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_hendler : MonoBehaviour
{

    public Transform camTrans;
    public Transform Pivot;
    public Transform Player;
    public Transform mTransform;


    public Playerstatus playerstatus;
    public camera_config camera_Config;

    public bool leftPivot;
    public float delta;


    public Transform targetLook;



    public float mouseX;
    public float mouseY;
    public float smoothX;
    public float smoothY;

    public float smoothXVelosity;
    public float smoothYVelosity;
    public float lookAngle;
    public float titlAngle;

    private void Update()
    {
        Tick();
    }


    public void Tick()
    {
        delta = Time.deltaTime;
        HandlePosition();
        HandleRotation();

        Vector3 targetPosition = Vector3.Lerp(mTransform.position, Player.position, 1);
        mTransform.position = targetPosition;
        TargetLook();

    }


    void TargetLook()
    {

        //нужно для стрельбы деает траекторию
        Ray ray = new Ray(camTrans.position, camTrans.forward * 2000);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            targetLook.position = Vector3.Lerp(targetLook.position, hit.point, Time.deltaTime * 40);
        }
        else
        {
            targetLook.position = Vector3.Lerp(targetLook.position, targetLook.transform.forward * 200, Time.deltaTime * 5);
        }

    }


    public void HandlePosition()
    {
        float targetX = camera_Config.normalX;
        float targetY = camera_Config.normalY;
        float targetZ = camera_Config.normalZ;

        if (playerstatus.isAiming)
        {
            targetX = camera_Config.aimX;
            targetZ = camera_Config.aimZ;
        }

        if (leftPivot)
        {
            targetX = -targetX;
        }


        Vector3 newPivotPosition = Pivot.localPosition;
        newPivotPosition.x = targetX;
        newPivotPosition.y = targetY;


        Vector3 newCameraPosition = camTrans.localPosition;
        newCameraPosition.z = targetZ;

        float t = delta * camera_Config.pivotSpeed;
        Pivot.localPosition = Vector3.Lerp(Pivot.localPosition, newPivotPosition, t);
        camTrans.localPosition = Vector3.Lerp(camTrans.localPosition, newCameraPosition, t);

    }


    public void HandleRotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (camera_Config.turnSmooth > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXVelosity, camera_Config.turnSmooth);
            smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothXVelosity, camera_Config.turnSmooth);
        }
        else
        {
            smoothX = mouseX;
            smoothY = mouseY;
        }


        lookAngle += smoothX * camera_Config.Y_rot_speed;
        Quaternion targetRot = Quaternion.Euler(0, lookAngle, 0);
        mTransform.rotation = targetRot;

        titlAngle -= smoothY * camera_Config.X_rot_speed;
        titlAngle = Mathf.Clamp(titlAngle, camera_Config.minAndgle, camera_Config.maxAndgle);
        Pivot.localRotation = Quaternion.Euler(titlAngle, 0, 0);
    }




}
