using System.Collections;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public bool OnCooldown;
    public float Cooldown;

    public abstract void TriggerEffect(Camera cam);

    internal IEnumerator HandleCoolDown()
    {
        OnCooldown = true;
        yield return new WaitForSecondsRealtime(Cooldown);
        OnCooldown = false;
    }
}