using System;
using System.Collections.Generic;
using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Architecture;
using UnityEngine;

namespace Something.Scripts.Architecture.Utilities
{
    public class PlayerProgress : IPlayerProgress
    {
        private List<ISaveable> _saveables;

        public PlayerProgress()
        {
            InventoryProgress = new InventoryProgress();
            HeathProgress = new Health(100);
            WorldProgress = new WorldDataProgress();
            _saveables = new List<ISaveable>();

            PlayerPosition = new Vector3(300, 132, 123);
        }

        public InventoryProgress InventoryProgress { get; private set; }
        public Health HeathProgress { get; private set; }
        public Vector3 PlayerPosition { get; private set; }
        public WorldDataProgress WorldProgress { get; private set; }

        public IReadOnlyList<ISaveable> GetSaveables()
        {
            var list = new List<ISaveable>();

            var eliminates = WorldProgress.EliminateProgress.GetAll();
            if (eliminates != null)
            {
                foreach (var saveable in eliminates)
                    list.Add(saveable);
            }

            var loots = WorldProgress.LootProgress.GetAll();
            if (loots != null)
            {
                foreach (var saveable in WorldProgress.LootProgress.GetAll())
                    list.Add(saveable);
            }

            return list;
        }


        // public void RegisterSaveable(params ISaveable[] saveables)
        // {
        //     if (saveables == null)
        //         return;
        //
        //     foreach (var saveable in saveables)
        //     {
        //         if (_saveables.Contains(saveable))
        //             throw new Exception("Saveable object already contains " + saveable);
        //
        //         _saveables.Add(saveable);
        //     }
        // }
    }
}