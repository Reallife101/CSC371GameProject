using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextHolder : MonoBehaviour
{
    [SerializeField] string text = "";
    [SerializeField] string cost = "Costs 1 Upgrade Point.";

    public string GetText() { return text + "\n" + cost; }

    public void ChangeCost(int newCost)
    {
        cost = "Costs " + newCost + " Upgrade ";
        if (newCost == 1)
        {
            cost += "Point.";
        } else
        {
            cost += "Points.";
        }
    }
}
