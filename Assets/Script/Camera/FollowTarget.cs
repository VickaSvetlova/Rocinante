using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    #region Deligates
    #endregion

    #region Propertes
    private Vector3 _distanceForTarget;
    private Quaternion origRotation;
    private float vertical;
    private float horizontal;
    private bool Hit;
    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    [Range(1, 10)]
    [SerializeField]
    private float mouseSens;
    #endregion

    #region Fields
    [SerializeField]
    private GameObject target;
    public GameObject _rotationSpot;
    private GameObject _aimPosition;
    int layerMask = 1 + 2 + 4 + 8 + 16 + 32 + 64 + 128;
    //   layerMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI");
    #endregion

    #region Events
    #endregion

    #region Metods
    private void Start()
    {
        _distanceForTarget = transform.position - target.transform.position;
        origRotation = target.transform.rotation;
        _aimPosition = GameObject.FindGameObjectWithTag("Aim");
    }
    private void Update()
    {
        //transform.position = target.transform.position + _distanceForTarget;
        rayCaster();
    }
    private void FixedUpdate()
    {
        CameraMove();
        RotationAroundTarget();
    }
    private void rayCaster()
    {
        RaycastHit hit;
        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward) * 1000;
        Debug.DrawRay(Camera.main.transform.position, forward, Color.green);
        Hit = Physics.Raycast(Camera.main.transform.position, (forward), out hit, LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI"));
        if (Hit)
        {
            if (hit.collider.gameObject.name != "Rocinante")
            {
                _aimPosition.transform.position = hit.collider.gameObject.transform.position;
                Debug.Log(string.Format("Target: {0}", hit.collider.gameObject.name));
            }
        }
    }
    private void RotationAroundTarget()
    {
        //input mouse Axis
        horizontal += Input.GetAxis("Mouse X") * mouseSens;
        vertical += Input.GetAxis("Mouse Y") * mouseSens;

        Quaternion rotationY = Quaternion.AngleAxis(horizontal, Vector3.up);
        Quaternion rotationX = Quaternion.AngleAxis(-vertical, Vector3.right);
        _rotationSpot.transform.rotation = origRotation * rotationY * rotationX;
        transform.LookAt(target.transform.position);
    }
    private void CameraMove()
    {
        transform.position = target.transform.position - (_rotationSpot.transform.rotation * _distanceForTarget);
    }
    #endregion
}


