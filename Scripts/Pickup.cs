using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum Types {Health, Ammo, Weapon};
    public Types type;
    public float amount;
}
