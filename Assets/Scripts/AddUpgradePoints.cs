using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddUpgradePoints : MonoBehaviour
{
    [SerializeField] int amountToAdd;
    [SerializeField] CharacterStats stats;
    [SerializeField] bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered & other.tag.Equals("Player"))
        {
            stats.AvailableUpgradePoints += amountToAdd;
            triggered = true;
        }
    }
}
