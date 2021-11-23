using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class health : MonoBehaviour
{
    public int healthMax;
    public int healthTotal;
    public abstract void takeDamage(int amount);
    public abstract void addHealth(int amount);
}
