using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatisticsController : MonoBehaviour
{
    GameObject[] allJunctions;
    JunctionController[] allJunctionController;
    Dictionary<string, List<Pair>> directionStatistics;

    string[] directions = { "Left", "Right", "Up", "Down" };

    private static StatisticsController instance;
    public static StatisticsController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StatisticsController>();
                if (instance == null)
                {
                    GameObject element = new GameObject();
                    element.hideFlags = HideFlags.HideAndDontSave;
                    instance = element.AddComponent<StatisticsController>();
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("StatisticsController").Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        resetData();
    }
    public void collectData()
    {
        allJunctions = GameObject.FindGameObjectsWithTag("Junction");
        allJunctionController = new JunctionController[allJunctions.Length];

        for (int i = 0; i < allJunctions.Length; i++)
        {
            allJunctionController[i] = allJunctions[i].GetComponent<JunctionController>();
            List<string> junctionNames = allJunctionController[i].getNameList();
            List<float> junctionTimes = allJunctionController[i].getTimeList();

            float max = allJunctions[i].transform.GetComponentInChildren<BranchController>().max;
            float diff = allJunctionController[i].difference;

            string curDirection = junctionNames[0];

            for (int j = 1; j < junctionNames.Count; j++)
            {
                if (Math.Abs(junctionTimes[j] - max) < diff)
                {
                    continue;
                }
                string newDirection = junctionNames[j];
                List<Pair> curList = directionStatistics[curDirection];
                for (int k = 0; k < curList.Count; k++)
                {
                    if (curList[k].dir == newDirection)
                    {
                        curList[k].cnt[j - 1]++;
                    }
                }
            }
        }
    }
    public string formatData()
    {
        string formatted = string.Format("{0, 2}{1, -10}{2, -10}{3, -10}{4, -10}", " ", 
            directions[0].ToUpper(), directions[1].ToUpper(), 
            directions[2].ToUpper(), directions[3].ToUpper());
        formatted += "\n";
        string line = "";
        for (int i = 0; i < 44; i++)
        {
            line += "-";
        }

        string[,] rows = new string[9, 4];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                rows[i, j] = "";
            }
        }
        for (int c = 0; c < 4; c++)
        {
            string curDir = directions[c];
            List<Pair> curList = directionStatistics[curDir];
            int r = 0;
            for (int j = 0; j < curList.Count; j++)
            {
                Pair curPair = curList[j];
                for (int k = 0; k < curPair.cnt.Length; k++)
                {
                    if (k == 0)
                    {
                        rows[r++, c] += string.Format("{0, -5}{1, 3}{2, 2}",
                            curPair.dir, curPair.cnt[k], "");
                    }
                    else
                    {
                        rows[r++, c] += string.Format("{0, 8}{1, 2}", curPair.cnt[k], "");
                    }
                }
            }
        }
        for (int i = 0; i < rows.GetLength(0); i++)
        {
            if (i % 3 == 0)
            {
                formatted += line + "\n";
            }
            formatted += string.Format("{0, -3}", "|");
            for (int j = 0; j < rows.GetLength(1); j++)
            {
                formatted += rows[i, j].ToUpper();
            }
            formatted = formatted + "|";
            formatted += "\n";
        }
        formatted += line;

        return formatted;
    }
    public void resetData()
    {
        directionStatistics = new Dictionary<string, List<Pair>>();
        for (int i = 0; i < directions.Length; i++)
        {
            List<Pair> list = new List<Pair>();
            directionStatistics.Add(directions[i], list);
            for (int j = 0; j < directions.Length; j++)
            {
                if (i != j)
                {
                    int[] array = new int[directions.Length - 1];
                    directionStatistics[directions[i]].Add(new Pair(directions[j], array));
                }
            }
        }
    }
}
class Pair
{
    public string dir;
    public int[] cnt;
    public Pair(string newDir, int[] newCnt)
    {
        dir = newDir;
        cnt = newCnt;
    }
}