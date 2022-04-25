using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudMovement : MonoBehaviour
{
    [SerializeField] private Sprite[] cloudSprites;

    private float speed;

    void Start()
    {
        speed = Random.Range(0.1f, .4f);

        ChangeSprite();
        // ChangeSize();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void ChangeSprite() {
        int randomNum = Random.Range(0, cloudSprites.Length);

        GetComponent<Image>().sprite = cloudSprites[randomNum];
    }

    private void ChangeSize() {
        transform.localScale = new Vector3(Random.Range(.9f, 1.1f), Random.Range(.9f, 1.1f), 0);
    }
}