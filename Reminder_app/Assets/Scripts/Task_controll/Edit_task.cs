using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Edit_task : MonoBehaviour, IPointerClickHandler
{
    [Header("Menu")]
    [SerializeField] private GameObject _main_menu;
    [SerializeField] private GameObject _edit_menu;
    
    [Space] [Header("Edit_task_menu")]
    [SerializeField] private TMP_InputField _task_title;
    [SerializeField] private TMP_InputField _task_text;

    [Space] [Header("Task_place")]
    [SerializeField] private TMP_Text _title_txt;
    [SerializeField] private TMP_Text _text_txt;

    [Space] [Header("Btn_save")]
    [SerializeField] private Button _button_save;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        if (eventData.clickCount == 2)
        {
            Debug.Log("Open edit");
            _main_menu.SetActive(false);
            _edit_menu.SetActive(true);
            _task_title.text = _title_txt.text;
            _task_text.text = _text_txt.text;
        }
    }

    private void btn_click_edit()
    {
        _title_txt.text = _task_title.text;
        _text_txt.text = _task_text.text;
        _main_menu.SetActive(true);
        _edit_menu.SetActive(false);
    }

    private void Update()
    {
        _button_save.onClick.AddListener(delegate { btn_click_edit(); });
    }
}
