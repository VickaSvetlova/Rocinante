using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    #region Propertes
    [Range(1, 100)]
    public float TrastStepEnginea;
    [Range(1, 100)]
    public float TrastShuntingEnginea;
    [Range(1, 10)]
    public float TimeCollDawnImpuls;
    #endregion

    #region field
    private Rigidbody _rig_body;
    [SerializeField]
    private Camera _camera;
    #endregion

    #region Metod
    private void Start()
    {
        _rig_body = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForvard(TrastStepEnginea);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveForvard(-TrastStepEnginea);
        }

        if (Input.GetKey(KeyCode.D))
        {
            RotationYaxis(-TrastShuntingEnginea);
        }
        if (Input.GetKey(KeyCode.A))
        {
            RotationYaxis(TrastShuntingEnginea);
        }
    }
    private void MoveForvard(float moveForvard)
    {
        _rig_body.AddRelativeForce(Vector3.forward * Time.deltaTime * moveForvard);
        Debug.Log(string.Format("boost: {0}", _rig_body.velocity.magnitude));
    }
    private void RotationYaxis(float rotationAxis)
    {
        _rig_body.AddRelativeTorque(Vector3.up * Time.deltaTime * rotationAxis);
        Debug.Log(string.Format("Torque: {0}", _rig_body.angularVelocity.y));
    }
    #endregion
}
