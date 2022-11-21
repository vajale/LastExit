using System;
using Something.Scripts.Something.Weapon.Base;
using UnityEngine;


public class UnitBodyPresenter : MonoBehaviour
{
    public Action<IAmmo, float> Visit { get; set; }

    private void SpawnShit(RaycastHit hit)
    {
    }

    public void SpawnParticliesOnPoint(RaycastHit raycastHit)
    {
        
    }
}