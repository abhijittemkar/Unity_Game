using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SwitchHandler : MonoBehaviour
{
    private bool isSwitchOn = true;
    public GameObject switchBtn;

    private void Start()
    {
        // Initialize switch state based on the stored sound mute state
        isSwitchOn = !GameManager.Instance.IsSoundMuted;

        // Set the initial position of the switch button
        UpdateSwitchPosition();
    }

    public void OnSwitchButtonClicked()
    {
        // Toggle the switch state
        isSwitchOn = !isSwitchOn;

        // Move the switch button using DOTween
        UpdateSwitchPosition();

        // Update the GameManager's sound mute state based on the switch state
        GameManager.Instance.IsSoundMuted = !isSwitchOn;

        // Debug log to indicate the button that is toggled and its state
        Debug.Log($"Switch button toggled. IsSoundMuted: {GameManager.Instance.IsSoundMuted}");
    }

    private void UpdateSwitchPosition()
    {
        float targetPositionX = isSwitchOn ? switchBtn.GetComponent<RectTransform>().sizeDelta.x / 2 : -switchBtn.GetComponent<RectTransform>().sizeDelta.x / 2;
        switchBtn.transform.DOLocalMoveX(targetPositionX, 0.2f);
    }

}
