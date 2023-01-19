using System;
using Something.Scripts.Something.Weapon.Base;
using UnityEngine;

public abstract class UnitBodyPresenter : MonoBehaviour
{
    public abstract Action<IAmmo, float> Visit { get; set; }

    protected abstract void SpawnShit(RaycastHit hit);
    public abstract void SpawnParticliesOnPoint(RaycastHit raycastHit);

}