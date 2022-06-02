using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCameraControl : MonoBehaviour
{
    [SerializeField] private int[] minMax = {0,22};
    [SerializeField] private float scrollSpeed =200;
    private float scrollX;

    private Transform cameraPos;
    void Start()
    {
        cameraPos = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.mousePosition.x / Screen.width < 0.2f) {

            scrollX -= scrollSpeed* Time.deltaTime;

        }
        else if (Input.mousePosition.x / Screen.width > 0.8f)
        {

            scrollX += scrollSpeed * Time.deltaTime;

        }
        cameraPos.position = new Vector3 (Mathf.Clamp(scrollX, minMax[0], minMax[1]), 0 , -10);
    }
}
