using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private GameObject slimeExplosionFX;

    private GameHandler gameHandler;

    private void Awake() {
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<SlimeMovement>()) {
            InstantiateSlimeExplosionFX(other.gameObject.transform);
            gameHandler.UpdateSlimeAmountText(1);
            Destroy(other.gameObject);
        }
    }

    private void InstantiateSlimeExplosionFX(Transform slime) {
        Instantiate(slimeExplosionFX, gameObject.transform.position, Quaternion.identity);
    }
}
