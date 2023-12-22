using UnityEngine;

public class JumpscareController : MonoBehaviour
{
    public GameObject jumpscareImage; // Jumpscare image GameObject
    public GameObject hideGameObject; // 3D GameObject to hide after jumpscare
    public AudioClip jumpscareAudioClip; // Jumpscare audio clip
    public float jumpscareDuration = 2f; // Adjust the time as needed
    private float timer;
    private bool isJumpscareActive;
    private AudioSource audioSource; // AudioSource component for playing audio

    void Start()
    {
        // Initialize variables
        timer = 0f;
        isJumpscareActive = false;

        // Add an AudioSource component to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // Set the audio clip for the AudioSource
        if (jumpscareAudioClip != null)
        {
            audioSource.clip = jumpscareAudioClip;
        }
    }

    void Update()
    {
        // Check if the jumpscare is active
        if (isJumpscareActive)
        {
            // Update the timer
            timer += Time.deltaTime;

            // Check if the timer exceeds the jumpscare duration
            if (timer >= jumpscareDuration)
            {
                // Call a method to hide the jumpscare image and the specified 3D GameObject
                HideJumpscare();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the jumpscare image and play the audio when the player enters the collider
            ShowJumpscare();
            PlayJumpscareAudio();
            Debug.Log("Player entered the collider");
        }
    }

    private void ShowJumpscare()
    {
        if (jumpscareImage != null)
        {
            jumpscareImage.SetActive(true);
            isJumpscareActive = true;
        }
    }

    private void HideJumpscare()
    {
        // Hide the jumpscare image
        if (jumpscareImage != null)
        {
            jumpscareImage.SetActive(false);
        }

        // Hide the specified 3D GameObject
        if (hideGameObject != null)
        {
            hideGameObject.SetActive(false);
        }

        // Reset variables for the next activation
        isJumpscareActive = false;
        timer = 0f;
    }

    private void PlayJumpscareAudio()
    {
        // Play the jumpscare audio
        if (audioSource != null && jumpscareAudioClip != null)
        {
            audioSource.Play();
        }
    }
}
