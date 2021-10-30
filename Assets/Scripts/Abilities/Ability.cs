using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public bool OnCooldown;
    public float Cooldown;

    // Used to trigger effects, all Abilities will use this
    public abstract void TriggerEffect(Camera cam);

    // Used to handle cooldowns, Abilities must set the cooldown in thier awake function
    internal IEnumerator HandleCoolDown()
    {
        OnCooldown = true;
        yield return new WaitForSecondsRealtime(Cooldown);
        OnCooldown = false;
    }
}