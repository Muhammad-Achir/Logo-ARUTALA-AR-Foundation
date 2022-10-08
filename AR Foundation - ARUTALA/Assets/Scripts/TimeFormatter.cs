using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFormatter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string time = FormatTime("07:05:45PM");
        Debug.Log(time);
    }

    string FormatTime(string s)
    {
        bool isPm = false;
        string result = "";
        string[] timeList = s.Split(':');

        char[] characters = timeList[2].ToCharArray();
        if (characters[2] == 'P')
        {
            isPm = true;
        }
        timeList[2] = "" + characters[0] + characters[1];

        for (int i = 0; i < timeList.Length; i -= -1)
        {
            if (i == 0)
            {
                if (isPm)
                {
                    int time = int.Parse(timeList[i]);
                    time += 12;
                    result += time;
                }
                else
                {
                    result += timeList[i];
                }
            }
            else
            {
                result += timeList[i];
            }
            if (i + 1 >= timeList.Length)
            {
                break;
            }
            result += ":";
        }
        return result;
    }
}
