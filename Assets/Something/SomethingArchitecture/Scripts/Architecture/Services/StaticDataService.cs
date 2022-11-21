using System;
using System.Collections.Generic;
using System.Linq;
using Something.Scripts.Architecture.Data;
using Something.Scripts.Architecture.Services.ServiceLocator;
using Something.Scripts.Something;
using Something.SomethingArchitecture.Scripts.Architecture.Data;
using Something.SomethingArchitecture.Scripts.Architecture.Data.ID;
using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;
using SomethingArchitecture.Scripts.Dialoge;
using SomethingArchitecture.Scripts.Something.Weapon.Factory;
using UnityEngine;

namespace SomethingArchitecture.Scripts.Architecture.Services
{
    public class StaticDataService : IService
    {
        private Dictionary<EnemyCharacterID, EnemyCharacterData> _enemyStore;
        private Dictionary<DialogeCharacterId, DialogeWihCharacter> _dialogs;
        private Dictionary<WeaponTypeId, WeaponData> _weapons;
        private CharacterData _playerData;
        private CameraConfig _cameraConfig;
        private PlayerUIView _playerGUI;

        private const string WeaponsPath = "Weapons/Data";
        private const string DialogsPath = "Characters/Dailogs";
        private const string EnemiesPath = "Characters/Enemy";
        private const string PlayerPath = "Characters/Player/ch_playerCharacter";
        private const string MouseConfigPath = "Settings/CameraMouseConfig";
        private const string PlayerGUIPath = "Player/PlayerUI/PlayerInterface";

        public StaticDataService()
        {
            InitializeDialogsData();
            InitializePlayerData();
            InitializeWeaponData();
            InitializeEnemyData();
            InitializePlayerUI();
        }

        private void InitializeWeaponData()
        {
            _weapons = Resources.LoadAll<WeaponData>(WeaponsPath)
                .ToDictionary(id => id.WeaponID, weaponData => weaponData);
        }

        private void InitializeDialogsData()
        {
            _dialogs = Resources.LoadAll<DialogeWihCharacter>(DialogsPath)
                .ToDictionary(x => x.characterId, x => x);
        }

        private void InitializeEnemyData()
        {
            _enemyStore = Resources.LoadAll<EnemyCharacterData>(EnemiesPath)
                .ToDictionary(x => x.ID, x => x);
        }

        private void InitializePlayerUI()
        {
            _playerGUI = Resources.Load<PlayerUIView>(PlayerGUIPath);
        }

        private void InitializePlayerData()
        {
            var data = Resources.Load<CharacterData>(PlayerPath);
            var cameraConfig = Resources.Load<CameraConfig>(MouseConfigPath);

            if (data != null)
                _playerData = data;

            if (cameraConfig != null)
                _cameraConfig = cameraConfig;
        }

        public EnemyCharacterData GetEnemy(EnemyCharacterID enemyID)
        {
            if (_enemyStore.TryGetValue(enemyID, out EnemyCharacterData enemyData))
                return enemyData;

            throw new Exception("is " + enemyID + " not contains in data service or not founded");
        }

        public CharacterData GetPlayerData()
        {
            if (_playerData != null)
                return _playerData;

            throw new Exception("Player characterData not was find or null");
        }

        public CameraConfig GetCameraConfig()
        {
            if (_cameraConfig != null)
                return _cameraConfig;

            throw new Exception("CameraConfig not was find or null");
        }

        public Dictionary<DialogeCharacterId, DialogeWihCharacter> GetDialogsData()
        {
            if (_dialogs != null)
                return _dialogs;

            throw new Exception("DialogsData not was find or null");
        }

        public WeaponData GetWeaponData(WeaponTypeId weaponTypeId)
        {
            if (_weapons.TryGetValue(weaponTypeId, out WeaponData enemyData))
                return enemyData;

            throw new Exception("is " + weaponTypeId + " not contains in data service or not founded");
        }

        public PlayerUIView GetPlayerGUI()
        {
            if (_playerGUI != null)
                return _playerGUI;

            throw new Exception("PLayerGUI is null or not find");
        }
    }
}