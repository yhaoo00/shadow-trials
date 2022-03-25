using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FieldOfView fieldOfView;

    public static PlayerMovement Instance;
    public Player.PlayMode playMode;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator anim;
    public float viewDistance;

    Vector3 movement;

    private void Start()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        playMode = Player.Instance.GetPlayMode();
        
        switch (playMode)
        {
            default:
            case Player.PlayMode.Hider:
                viewDistance = 5f;
                //fieldOfView.SetViewDistance(viewDistance);
                moveSpeed = 5f;
                //Debug.Log("Move speed in movement: " + moveSpeed);
                break;

            case Player.PlayMode.Seeker:
                viewDistance = 7f;
                //fieldOfView.SetViewDistance(viewDistance);
                moveSpeed = 5f;
                break;
        }

        Debug.Log(playMode);
    }

    private void FixedUpdate()
    {
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetViewDistance(viewDistance);

        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector3.zero)
        {
            MoveCharacter();
            anim.SetFloat("moveX", movement.x);
            anim.SetFloat("moveY", movement.y);
            anim.SetBool("isMoving", true);
        }
        else
            anim.SetBool("isMoving", false);
    }

    private void MoveCharacter()
    {
        rb.MovePosition(transform.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
