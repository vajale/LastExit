using System;
using UnityEngine;

namespace Something.Scripts.Architecture.Utilities
{
    public static class SceneReferenceFinderExtensions
    {
        public static bool FindByTag(string tag, out GameObject reference)
        {
            var findObject = GameObject.FindWithTag(tag);

            if (findObject == null)
            {
                reference = null;
                return false;
            }

            reference = findObject;
            return true;
        }

        public static GameObject[] FindByTags(string tag)
        {
            var findObject = GameObject.FindGameObjectsWithTag(tag);

            if (findObject == null)
                throw new Exception("GameObject with tag - " + tag + " not cantains on scene");
            
            return findObject;
        }

        public static GameObject FindByTag(string tag)
        {
            var findObject = GameObject.FindWithTag(tag);

            if (findObject == null)
                throw new Exception("GameObject with tag - " + tag + " not cantains on scene");

            return findObject;
        }
    }
}