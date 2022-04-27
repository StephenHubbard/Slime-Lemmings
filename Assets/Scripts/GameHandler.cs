using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private int totalSlimesNeeded = 3;
    [SerializeField] private int currentSlimesSaved = 0;
    [SerializeField] private TMP_Text slimeAmountText;
    [SerializeField] private GameObject pauseUI;

    private void Start() {
        UpdateSlimeAmountText(currentSlimesSaved);
    }

    private void Update() {
        TogglePauseMenu();
    }

    private void TogglePauseMenu() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(pauseUI.activeInHierarchy) {
                pauseUI.SetActive(false);
                Time.timeScale = 1;
            } else if (!pauseUI.activeInHierarchy) {
                pauseUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void UpdateSlimeAmountText(int amount) {
        currentSlimesSaved += amount;
        slimeAmountText.text = currentSlimesSaved.ToString() + " / " + totalSlimesNeeded.ToString();
    }
}
