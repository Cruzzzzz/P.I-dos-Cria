using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleBTN : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject selection;
    private Button btn;
    private UnityAction action;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selection = GetComponentInChildren<Animator>(true).gameObject;
        btn = GetComponentInChildren<Button>();
        //btn.onClick.RemoveAllListeners();
        btn.onClick.RemoveListener(action);
        btn.onClick.AddListener(action);
    }
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}