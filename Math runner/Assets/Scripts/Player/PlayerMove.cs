using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public float DistanceCovered => distanceCovered;

    public float initialMoveSpeed = 3f;
    public float leftRightSpeed = 4f;
    public float speedIncreaseRate = 0.1f;

    private float currentMoveSpeed;
    private float distanceCovered;

    private Vector2 touchStartPos;
    private const float minSwipeDistance = 50f;

    // Reference to the TextMeshPro UI element.
    public TextMeshProUGUI distanceText;

    void Start()
    {
        currentMoveSpeed = initialMoveSpeed;
        distanceCovered = 0f;

        // Check if a distanceText reference is provided.
        if (distanceText != null)
        {
            UpdateDistanceText();
        }
        else
        {
            Debug.LogWarning("DistanceText reference not set in the inspector.");
        }
    }

    void Update()
    {
        float adjustedMoveSpeed = initialMoveSpeed + speedIncreaseRate * Time.timeSinceLevelLoad;
        transform.Translate(Vector3.forward * Time.deltaTime * adjustedMoveSpeed, Space.World);

        // Calculate the distance covered.
        distanceCovered += Time.deltaTime * adjustedMoveSpeed;

        // Update the distance text.
        UpdateDistanceText();

        // Handle input for PC
        HandlePCInput();

        // Handle touch input for mobile
        HandleTouchInput();
    }

    void HandlePCInput()
    {
        // Handle left movement.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }

        // Handle right movement.
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    float swipeDistanceX = touch.position.x - touchStartPos.x;

                    // Check for a right swipe.
                    if (swipeDistanceX > minSwipeDistance)
                    {
                        MoveRight();
                    }
                    // Check for a left swipe.
                    else if (swipeDistanceX < -minSwipeDistance)
                    {
                        MoveLeft();
                    }
                    break;
            }
        }
    }

    void MoveLeft()
    {
        if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }
    }

    void MoveRight()
    {
        if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
        }
    }

    void UpdateDistanceText()
    {
        // Update the TextMeshPro UI element with the current distance covered.
        if (distanceText != null)
        {
            distanceText.text = $"Distance: {distanceCovered:F2} meters";
        }
    }
}
