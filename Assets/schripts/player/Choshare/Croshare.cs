using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Croshare : MonoBehaviour
{


    public float curentSpread;
    public float speedSpread;


    public Parts[] parts;
    public player_movement pm;
    public Playerstatus ps;


    float t;

    float curSpread;


    void Update()
    {
        CroshareUpdate();
        if (pm.moveAmount > 0)
        {
            if (!ps.isAiming)
            {

                curentSpread = 20 * (5 + pm.moveAmount);

                if (ps.Isruning)
                {
                    curentSpread = 20 * (8 + pm.moveAmount);
                }

                if (ps.IsCouching)
                {
                    curentSpread = 20 * (2 + pm.moveAmount);
                }

            }
            else
            {
                curentSpread = 20 * (2 + pm.moveAmount);


                if (ps.IsCouching)
                {
                    curentSpread = 10 * (1 + pm.moveAmount);
                }
            }

        }
        else
        {
            curentSpread = 20;
        }
    }

    public void CroshareUpdate()
    {
        t = 0.005f * speedSpread;
        curSpread = Mathf.Lerp(curSpread, curentSpread, t);


        for(int i = 0; i < parts.Length; i++)
        {
            Parts p = parts[i];
            p.trans.anchoredPosition = p.pos * curSpread;
        }
    }

    [System.Serializable]
    public class Parts
    {
        public RectTransform trans;
        public Vector2 pos;
    }
}
