using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace EXO_CVR.Melon
{
    internal class Overrider : MelonMod
    {
        private static IEnumerable<BaseModule> MainModules = null;

        private static IEnumerable<BaseModule> MainModulesOnUpdate = null;

        internal static int FPS = 0;

        private float Offset = 0f;

        public override void OnApplicationStart()
        {
            var AllModules = Assembly.GetTypes().Where(o => o.IsSubclassOf(typeof(BaseModule))).OrderBy(o => (o.GetCustomAttributes(false).FirstOrDefault(q => q is LoadOrder) as LoadOrder)?.Priority).Select(a => (BaseModule)Activator.CreateInstance(a));

            var ModulesWithUpdate = AllModules.Where(o =>
                o.GetType().GetMethod("OnFixedUpdate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly) != null || o.GetType().GetMethod("OnUpdate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly) != null ||
                o.GetType().GetMethod("OnLateUpdate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly) != null ||
                o.GetType().GetMethod("OnSecondPassed", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly) != null).ToList(); // I hate reflection

            var ModulesWithoutUpdate = AllModules.Where(o => !ModulesWithUpdate.Contains(o)).ToList();

            MainModules = ModulesWithoutUpdate;
            MainModulesOnUpdate = ModulesWithUpdate;

            foreach (var module in MainModules)
            {
                module?.OnApplicationStart();
            }

        }

        public override void OnApplicationLateStart()
        {
            foreach (var module in MainModules)
                module?.OnApplicationLateStart();
        }

        public override void OnApplicationQuit()
        {
            foreach (var module in MainModules)
                module?.OnApplicationQuit();
        }

        public override void OnGUI()
        {
            foreach (var module in MainModules)
                module?.OnGUI();
        }               

        public override void OnFixedUpdate()
        {
            foreach (var module in MainModulesOnUpdate)
                module?.OnFixedUpdate();
        }

        public override void OnUpdate()
        {
            FPS = (int)(1f / Time.smoothDeltaTime);

            foreach (var module in MainModulesOnUpdate)
                module?.OnUpdate();

            if (Time.time > Offset)
            {
                Offset = Time.time + 1f;

                foreach (var module in MainModulesOnUpdate)
                    module?.OnSecondPassed();
            }
        }

        public override void OnLateUpdate()
        {
            foreach (var module in MainModulesOnUpdate)
                module?.OnLateUpdate();
        }


        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            foreach (var module in MainModules)
                module?.OnSceneWasInitialized(buildIndex, sceneName);
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            foreach (var module in MainModules)
                module?.OnSceneWasLoaded(buildIndex, sceneName);
        }

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            foreach (var module in MainModules)
                module?.OnSceneWasUnloaded(buildIndex, sceneName);
        }

        public override void OnPreferencesLoaded()
        {
            foreach (var module in MainModules)
                module?.OnPreferencesLoaded();
        }

        public override void OnPreferencesSaved()
        {
            foreach (var module in MainModules)
                module?.OnPreferencesSaved();
        }
    }
}
