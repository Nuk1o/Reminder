using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Add_task : MonoBehaviour
{
    [Header("Main_menu")]
    [SerializeField] private GameObject Place;
    [SerializeField] private GameObject Task;

    [Space] [Header("Add_task_menu")]
    [SerializeField] private TMP_InputField _task_title;
    [SerializeField] private TMP_InputField _task_text;

    [Space] [Header("Canvas")]
    [SerializeField] private GameObject _main_menu;
    [SerializeField] private GameObject _add_menu;

    public void save_tasks()
    {
        try
        {
            if (_task_title.text.Length > 3 && _task_text.text.Length > 3)
            {
                set_active_menu();
                string text_title = _task_title.text;
                string text_task = _task_text.text;

                GameObject _new_task = Instantiate(Task, Task.transform.position, quaternion.identity,Place.transform);
                TMP_Text [] _text_arr = _new_task.GetComponentsInChildren<TMP_Text>();
                TMP_Text _title = _text_arr[0];
                TMP_Text _text = _text_arr[1];
                _title.text = text_title;
                _text.text = text_task;
                _new_task.SetActive(true);
                
                _main_menu.SetActive(true);
                _add_menu.SetActive(false);
            }
            else
            {
                Debug.Log("Ошибка");
            }
        }
        catch (Exception e)
        {
            Debug.Log("Ошибка");
            Debug.Log(e);
        }
    }

    private void set_active_menu()
    {
        if (_main_menu.activeSelf == false || _add_menu.activeSelf == false)
        {
            _main_menu.SetActive(true);
            _add_menu.SetActive(true);
        }
    }
}
