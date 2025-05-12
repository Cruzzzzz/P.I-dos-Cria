using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]private GameObject Text_Notice;
    [SerializeField] public string Scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(Text_Notice, 8f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           SceneManager.LoadScene(Scene);
            print("aqui");
        }
    }

}
