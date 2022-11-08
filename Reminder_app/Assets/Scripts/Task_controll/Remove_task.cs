using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Remove_task : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Menu")]
    [SerializeField] private GameObject main_menu;
    [SerializeField] private GameObject remove_menu;

    [Space] [Header("Button")]
    [SerializeField] private Button _button;
    
    private void destroy_task()
    {
        Destroy(gameObject);
        main_menu.SetActive(true);
        remove_menu.SetActive(false);
    }

    private void Update()
    {
        _button.onClick.AddListener(delegate { destroy_task(); });
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(Task_btn_Press());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
    }

    private IEnumerator Task_btn_Press()
    {
        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime;
            yield return null;
        }
        open_remove();
    }
    
    private void open_remove()
    {
        Debug.Log("Open");
        main_menu.SetActive(false);
        remove_menu.SetActive(true);
    }
}
