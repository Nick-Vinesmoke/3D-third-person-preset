using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;

    Vector3 LastPos;

    public GameObject hole;
    public GameObject wood;
    public GameObject stone;
    public GameObject metal;
    public GameObject sand;
    public GameObject[] meatHitEfx;



    // Start is called before the first frame update
    void Start()
    {
        LastPos = transform.position;
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //перемещает пулю
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // проверяет столкновения
        RaycastHit hit;
        Debug.DrawLine(LastPos, transform.position);
        if(Physics.Linecast(LastPos, transform.position, out hit))
        {

            if (hit.collider.sharedMaterial != null)
            {

                string materialName = hit.collider.sharedMaterial.name;
                switch (materialName)
                {
                    case "Metal":
                        SpawnHole(hit, metal);
                        break;
                    case "Sand":
                        SpawnHole(hit, sand);
                        break;
                    case "Stone":
                        SpawnHole(hit, stone);
                        break;
                    case "Wood":
                        SpawnHole(hit, wood);
                        break;
                    case "Meat":
                        SpawnHole(hit, meatHitEfx[Random.Range(0, meatHitEfx.Length)]);
                        break;
                }
            }
            else
            {
                SpawnHole(hit, stone);
            }

            Destroy(gameObject);
        }
        LastPos = transform.position;



        void SpawnHole(RaycastHit hitt, GameObject pefab)
        {
            GameObject spawnHole = GameObject.Instantiate(pefab, hit.point, Quaternion.LookRotation(hit.normal));
            spawnHole.transform.SetParent(hit.collider.transform);
            Destroy(spawnHole.gameObject, 10);
        }
    }
}
