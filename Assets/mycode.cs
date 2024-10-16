using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mycode : MonoBehaviour
{
    public GameObject rotation_00;
    public GameObject rotation_01;
    public GameObject rotation_02;
    public double ArmScale = 2;

    public GameObject target;


    public double calcule2(double x, double y,bool type)
    {
        double res;
        if (type)
        {
            res = (Math.Asin(x / y) * 180 / Math.PI);
        }
        else
        {
            res = (Math.Acos(x / y) * 180 / Math.PI);
        }
        
        return res;
    }
    public double calcule(double x , double y)
    {
        double res,h;
        h = Math.Sqrt((Math.Pow(x, 2) + Math.Pow(y, 2)));
        res = (Math.Asin( y / h) * 180 / Math.PI);
        if (x<0)
        {
            res = res * -1 + 180;
        }
        return res;
    }
    public void follow(GameObject _target)
    {
        double x, y ,z ,h1,h2,deg0,deg1,deg2;
        y = _target.transform.localPosition.x - rotation_01.transform.localPosition.x;
        x = _target.transform.localPosition.z - rotation_01.transform.localPosition.x;
        z = _target.transform.localPosition.y - rotation_01.transform.localPosition.y ;
        h1 = Math.Sqrt((Math.Pow(x,2) + Math.Pow(y, 2)));
        deg0 = calcule(x, y);
        h2 = Math.Sqrt((Math.Pow(z, 2) + Math.Pow(h1, 2)));
        deg1 = calcule2(h2 / 2, ArmScale,true) + calcule(z, h1) - 90;
        deg2 = 2*calcule2(h2 / 2, ArmScale,false);


        Debug.Log("valeur X : " + x + " || Y = " + y + " || Z = " + z);
        Debug.Log("valeur H : " + h1 + " || H2 = " + h2);
        Debug.Log("valeur deg0 : " + deg0 + " || deg1 = " + deg1 + " || deg2 = " + deg2);


        rotation_00.gameObject.transform.localEulerAngles = new Vector3(0, (float)deg0, 0);
        rotation_01.gameObject.transform.localEulerAngles = new Vector3((float)deg1, 0, 0);
        rotation_02.gameObject.transform.localEulerAngles = new Vector3((float)deg2, 0, 0);

    }
    // Start is called before the first frame update
    void Start()
    {

        rotation_00.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        rotation_01.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        rotation_02.gameObject.transform.localEulerAngles = new Vector3(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        follow(target);
    }
}
