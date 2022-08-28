using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Control : MonoBehaviour
{
    public TMP_Text Result;
    public GameObject Message;
    private int temperature;

    Calculate Count;

    public void Start()
    {
        Count = GetComponent<Calculate>();

        Message.SetActive(false);
        temperature = Random.Range(15, 23);
        Result = GetComponent<TMP_Text>();
        Result.text = "������ ���� �µ�: " + temperature.ToString() + "��C";
    }

    public void ClickUp()
    {
        temperature += 1;
        Result.text = "������ ���� �µ�: " + temperature.ToString() + "��C";
    }

    public void ClickDown()
    {
        temperature -= 1;
        Result.text = "������ ���� �µ�: " + temperature.ToString() + "��C";
    }

    public void Ok()
    {
        Message.SetActive(true);

        if (temperature == 26){
        Count.AddScore(20);
        }
        
    }

    // ������ �µ� 26�� ���� �� ���� �߰�!!!!
}
