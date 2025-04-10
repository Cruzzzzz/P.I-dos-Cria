using UnityEngine;

public class Creditos : MonoBehaviour
{
    public float speed = 20f;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }

    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, speed * Time.deltaTime);

    }
}