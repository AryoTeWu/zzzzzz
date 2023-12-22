using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speedMove = 5f;
    public float gravity = -9.81f;

    public AudioClip walkSoundClip; 
    public AudioSource walkAudioSource;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        walkAudioSource.clip = walkSoundClip; 
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(move * speedMove * Time.deltaTime);
        ApplyGravity();

        if (move.magnitude > 0 && !walkAudioSource.isPlaying)
        {
            walkAudioSource.Play();
        }
        else if (move.magnitude == 0)
        {
            walkAudioSource.Stop(); 
        }
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
