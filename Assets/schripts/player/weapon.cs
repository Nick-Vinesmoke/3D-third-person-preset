using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    public Weapon_properties wp;
    public Transform shootPoint;
    public Transform targetLook;


    public GameObject mainCamera;
    public GameObject hole;
    public GameObject bullet;
    public Transform l_hand_target;



    public ParticleSystem MuzleFlash;
    AudioSource ax;
    public AudioClip shootClip;


    public GameObject shell;
    public Transform shellPisition;


    private void Start()
    {
        ax = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        //делает стрельбу ровной(
        shootPoint.LookAt(targetLook);
        //)
        Vector3 origin = shootPoint.position;
        Vector3 dir = targetLook.position;



        RaycastHit hit;

        //hole.SetActive(false);

       // Debug.DrawLine(origin, dir, Color.black);
       // Debug.DrawLine(mainCamera.transform.position, dir, Color.black);



        if(Physics.Linecast(origin, dir, out hit))
        {
            //hole.SetActive(true);
            //hole.transform.position = hit.point + hit.normal * 0.01f;
            //hole.transform.rotation = Quaternion.LookRotation(-hit.normal);
        }
    }



    public void Shoot()
    {
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);

        ax.PlayOneShot(shootClip);

        MuzleFlash.Play();
        AddShell();
    }


    public void AddShell()
    {
        GameObject newShell = Instantiate(shell);
        newShell.transform.position = shellPisition.position;

        Quaternion rot = shellPisition.rotation;
        newShell.transform.rotation = rot;


        newShell.transform.parent = null;
        newShell.GetComponent<Rigidbody>().AddForce(-newShell.transform.forward * Random.Range(80, 120));
        Destroy(newShell, 20);

    }


    


}
