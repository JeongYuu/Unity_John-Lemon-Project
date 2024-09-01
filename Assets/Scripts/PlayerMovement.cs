using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigidbody;

    private Vector3 movement;

    public float moveSpeed = 5f;

    private Quaternion rotation;

    public float turnSpeed = 20f;

    public Animator playerAnimator;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //Ű���尪 �Է�
        float moveVertical = Input.GetAxis("Vertical");

        //Debug.Log($"moveHorizontal : moveVertical = {moveHorizontal} : {moveVertical}");

        movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement.Normalize(); //����ȭ 1�� ����� ����

        Vector3 desiredForward = Vector3.RotateTowards(this.transform.forward, movement, Time.fixedDeltaTime*turnSpeed, 0f);
        rotation = Quaternion.LookRotation(desiredForward);

        playerRigidbody.MovePosition(playerRigidbody.position + movement * Time.fixedDeltaTime * moveSpeed);

        playerRigidbody.MoveRotation(rotation);

        if(moveHorizontal != 0 || moveVertical != 0) //Ű���带 ������
        {
            playerAnimator.SetBool("IsWalking", true);
        }
        else //������ ������
        {
            playerAnimator.SetBool("IsWalking", false);
        }
    }
}
