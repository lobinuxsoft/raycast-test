using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveController : MonoBehaviour
{
    [SerializeField] float speedMovement = 10, jumpSpeed = 8;
    CharacterController characterController = default;

    Transform camT;

    Vector3 lookDir = Vector3.zero;

    // Start is called before the first frame update
    void Awake()
    {
        TryGetComponent<CharacterController>(out characterController);
        camT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = camT.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = camT.right;
        right.y = 0;
        right.Normalize();

        Vector3 jumpVelocity = Input.GetButtonDown("Jump") ? jumpSpeed * Vector3.up : Vector3.zero;

        Vector3 moveDir = (Input.GetAxis("Vertical") * forward + Input.GetAxis("Horizontal") * right);

        if (moveDir.magnitude > 0) lookDir = moveDir;

        characterController.SimpleMove((speedMovement * moveDir) + jumpVelocity + Physics.gravity);

        characterController.transform.rotation = Quaternion.Lerp(characterController.transform.rotation, Quaternion.LookRotation(lookDir), Time.deltaTime);
    }
}
