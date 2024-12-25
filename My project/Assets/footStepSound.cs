using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstepSource; // مصدر الصوت
    public AudioClip[] footstepClips; // مجموعة من أصوات الخطوات
    public float stepInterval = 0.5f; // الفاصل الزمني بين الخطوات
    private float stepTimer = 0f; // عداد زمني للخطوات
    private CharacterController characterController;

    void Start()
    {
        if (footstepSource == null)
        {
            footstepSource = GetComponent<AudioSource>();
        }

        characterController = GetComponent<CharacterController>();

        if (footstepSource == null)
        {
            Debug.LogError("AudioSource is not assigned or missing on this GameObject!");
        }

        if (characterController == null)
        {
            Debug.LogError("CharacterController is not attached to this GameObject!");
        }
    }

    void Update()
    {
        // التحقق من ضغط مفتاح W أو العصا الافتراضية
        bool isMovingForward = Input.GetKey(KeyCode.W) || Input.GetAxisRaw("Vertical") > 0.1f;

        if (characterController != null && isMovingForward && characterController.velocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            int index = Random.Range(0, footstepClips.Length);
            footstepSource.clip = footstepClips[index];
            footstepSource.Play();

            Debug.Log("Playing footstep sound: " + footstepClips[index].name);
        }
        else
        {
            Debug.LogWarning("No footstep clips assigned!");
        }
    }
}
