using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class TimerScore : MonoBehaviour
{
    [SerializeField] private Canvas[] colors; //0 is R, 1 is G, 2 is B, 3 is Y
    [SerializeField] private GameObject[] screens; //0 is Main, 1 is Wait, 2 is NOW, 3 is Early, 4 is Done
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private bool greenReady = false;
    [SerializeField] private InputManager inputMan;

    private float timer = 0f;
    private float randSec = 0f;

    public void StartTimer()
    {
        greenReady = false;
        randSec = 0f;
        timer = 0f;
        randSec = Random.Range(4f, 6f);
        StartCoroutine(TimerStart());
    }

    public void StopTimer()
    {
        if (greenReady)
        {
            greenReady = false;
            foreach (var c in colors)
                c.gameObject.SetActive(false);
            foreach (var t in screens)
                t.gameObject.SetActive(false);
            inputMan.gameObject.SetActive(false);

            colors[2].gameObject.SetActive(true);
            screens[4].gameObject.SetActive(true);

            return;
        }
        else
        {
            StopAllCoroutines();
            foreach (var c in colors)
                c.gameObject.SetActive(false);
            foreach (var t in screens)
                t.gameObject.SetActive(false);
            inputMan.gameObject.SetActive(false);

            colors[3].gameObject.SetActive(true);
            screens[3].gameObject.SetActive(true);
            return;
        }
    }

    private void Update()
    {
        if (greenReady)
        {
            timer += (int) (1000 *Time.deltaTime);
            finalScore.text = $"Good job!\nYour time was {timer} ms";
        }
    }

    private IEnumerator TimerStart()
    {
        foreach (var c in colors)
            c.gameObject.SetActive(false);
        foreach (var t in screens)
            t.gameObject.SetActive(false);
        inputMan.gameObject.SetActive(true);

        colors[0].gameObject.SetActive(true);
        screens[1].gameObject.SetActive(true);

        yield return new WaitForSeconds(randSec);

        foreach (var c in colors)
            c.gameObject.SetActive(false);
        foreach (var t in screens)
            t.gameObject.SetActive(false);
        greenReady = true;
        colors[1].gameObject.SetActive(true);
        screens[2].gameObject.SetActive(true);

    }
}
