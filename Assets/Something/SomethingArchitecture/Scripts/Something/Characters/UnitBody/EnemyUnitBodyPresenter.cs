using System;
using Something.Scripts.Something.Weapon.Base;
using Something.SomethingArchitecture.Scripts.Something.Characters.Enemy;
using UnityEngine;


public class EnemyUnitBodyPresenter : UnitBodyPresenter
{
    private EnemyCharacter _enemyCharacter;
    public override Action<IAmmo, float> Visit { get; set; }

    protected override void SpawnShit(RaycastHit hit)
    {
        
    }

    public override void SpawnParticliesOnPoint(RaycastHit raycastHit)
    {
        
    }
}