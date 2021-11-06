using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public bool OnCooldown;
    public float Cooldown;

    // Used to trigger effects, all Abilities will use this
    public abstract void TriggerEffect(Camera cam, GameObject player);

    // Used to handle cooldowns, Abilities must set the cooldown in thier awake function
    internal IEnumerator HandleCoolDown()
    {
        OnCooldown = true;
        yield return new WaitForSecondsRealtime(Cooldown);
        OnCooldown = false;
    }

    // For Abilities that need to check range
    internal bool InRange(Vector3 a, Vector3 b, float range)
    {
        float distance;
        distance = Vector3.Distance(new Vector3(a.x, 0f, a.z),
                                    new Vector3(b.x, 0f, b.z));
        return distance <= range;
    }
}