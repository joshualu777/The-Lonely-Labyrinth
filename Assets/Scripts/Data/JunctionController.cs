using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunctionController : MonoBehaviour
{
    public float difference = 0.01f;

    List<float> branchesTime = new List<float>();
    List<string> branchesName = new List<string>();

    void Update()
    {
        foreach (Transform child in transform)
        {
            GameObject current = child.gameObject;
            BranchController branchController = current.GetComponent<BranchController>();
            float curTime = branchController.getTimeVisited();
            string curName = current.name;

            for (int i = 0; i < branchesTime.Count; i++)
            {
                if (curTime - branchesTime[i] < difference)
                {
                    if (branchesName.Contains(curName))
                    {
                        int index = branchesName.IndexOf(curName);
                        branchesTime.RemoveAt(index);
                        branchesName.RemoveAt(index);
                    }
                    branchesTime.Insert(i, curTime);
                    branchesName.Insert(i, curName);
                    break;
                }
            }
            if (!branchesName.Contains(curName))
            {
                branchesTime.Add(curTime);
                branchesName.Add(curName);
            }
        }
        string toPrint = "";
        for (int i = 0; i < 4; i++)
        {
            toPrint += branchesName[i] + ": " + branchesTime[i] + ", ";
        }
    }
    public List<float> getTimeList()
    {
        return branchesTime;
    }
    public List<string> getNameList()
    {
        return branchesName;
    }
}