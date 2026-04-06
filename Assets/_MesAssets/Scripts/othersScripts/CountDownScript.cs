using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CountDownScript : MonoBehaviour
{

    [SerializeField]
    private int startCountDown = 60;
    [SerializeField]
    TextMeshProUGUI txtCountDown;
    void Start()
    {
        txtCountDown.text = "TimeLeft : " + startCountDown;
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        while (startCountDown>0)
        { 
            yield return new WaitForSeconds(1f);
            startCountDown--;
            txtCountDown.text = "TimeLeft : " + startCountDown;
        }
        Debug.Log("You are dead");
            
    }
}
