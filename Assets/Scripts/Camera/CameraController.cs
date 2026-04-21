using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [Header("References")]
    public PlayerInput playerInput;
    public CinemachineCamera cineCam;

    private CinemachinePositionComposer composer;

    [Header("Look Ahead")]
    public float lookAheadDistance = 2f;
    public float lookAheadSpeed = 6f;

    private float currentLookAhead;

    [Header("Damping")]
    public float normalDamping = 0.8f;
    public float fallDamping = 0.25f;

    private Rigidbody2D playerRb;

    void Start()
    {
        composer = cineCam.GetComponent<CinemachinePositionComposer>();
        playerRb = playerInput.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleLookAhead();
        HandleFallDamping();
    }

    void HandleLookAhead()
    {
        float dir = playerInput.LookingRight ? 1f : -1f;
        float target = dir * lookAheadDistance;

        currentLookAhead = Mathf.Lerp(
            currentLookAhead,
            target,
            Time.deltaTime * lookAheadSpeed
        );

        composer.TargetOffset =
            new Vector3(currentLookAhead, composer.TargetOffset.y, 0f);
    }

    void HandleFallDamping()
    {
        if (playerRb.linearVelocity.y < -0.1f)
        {
            composer.Damping =
                new Vector3(composer.Damping.x, fallDamping, composer.Damping.z);
        }
        else
        {
            composer.Damping =
                new Vector3(composer.Damping.x, normalDamping, composer.Damping.z);
        }
    }
}