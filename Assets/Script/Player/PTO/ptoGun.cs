using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ptoGun : MonoBehaviour
{

    #region Deligates
    #endregion

    #region Propertes
    #endregion

    #region Fields
    public GameObject target;
    private bool Hit;
    #endregion

    #region Events
    #endregion

    #region Metods
    private void Update()
    {
        rayCaster();
        Aim(target);
    }
    private void rayCaster()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.red);
        Hit = Physics.Raycast(transform.position, (forward), out hit);
        if (Hit)
        {
            //Debug.Log(string.Format("Target: {0}", hit.collider.gameObject.name));
        }
    }
    private void Aim(GameObject targ)
    {
        if (targ != null)
        {
            transform.LookAt(targ.transform.position);
        }
    }
    #endregion
}


