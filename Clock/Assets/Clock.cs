using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

    public GameObject clockSec;
    public GameObject clockSec2;
    public GameObject zeroPos;
    public GameObject zeroPos2;
    private string _sec;
    public float time;
    public int cur_time;
    public int cur_time2;

    [Range(0, 1000)]
    public float speed;

    private bool move = false;

	// Use this for initialization
	void Start () {
        _sec = "0";
        time = 0;

        StartCoroutine(ClockWerk());
        StartCoroutine(ClockWerk2());
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        cur_time = (int) time;

        cur_time = (int) time % 10;
        cur_time2 = (int) time % 100 - cur_time;
        
	}

    IEnumerator ClockWerk()
    {
        while (true)
        {
            switch (cur_time)
            {
                case 0:
                    clockSec.transform.position = zeroPos.transform.position;
                    break;
                default:
                    var moving = new Vector2(clockSec.transform.position.x - 16, clockSec.transform.position.y);
                    var cur_move = clockSec.transform.position;
                    //clockSec.transform.position = Vector2.Lerp(cur_move, moving, Time.deltaTime * speed);
                    clockSec.transform.Translate(new Vector2(-16, 0));
                    break;
            }

            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator ClockWerk2()
    {
        while (true)
        {
            switch (cur_time2)
            {
                case 0:
                    clockSec2.transform.position = zeroPos2.transform.position;
                    break;
                default:
                    var moving = new Vector2(clockSec2.transform.position.x - 16, clockSec2.transform.position.y);
                    var cur_move = clockSec2.transform.position;
                    clockSec2.transform.position = Vector2.Lerp(cur_move, moving, Time.deltaTime * speed);
                    break;
            }

            yield return new WaitForSeconds(10);
        }
    }
}
