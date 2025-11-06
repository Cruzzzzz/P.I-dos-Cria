using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleBTN : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject selection;

    public void OnDeselect(BaseEventData eventData)
    {
        selection.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selection.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selection.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        selection.SetActive(true);
    }

    void Start()
    {
        selection = GetComponentInChildren<Animator>(true).gameObject;
        //btn.onClick.RemoveAllListeners();
    }
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {

    }
}