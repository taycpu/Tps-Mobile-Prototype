namespace IdleMovement
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
#if UNITY_EDITOR
    using UnityEditor;
#endif
    using UnityEngine;
    using UnityEngine.AI;

    public class MovementController : MonoBehaviour
    {
        public MovementType movement;

        public  void Initialize()
        {
            movement.Initialize();
        }

        public void StopMovement()
        {
            movement.Stop();
        }

        public void ContinueMovement()
        {
            movement.Continue();
        }
    }


#if UNITY_EDITOR

    [CustomEditor(typeof(MovementController))]
    public class MovementControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();


            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Freeroam Movement"))
            {
                var go = target as MovementController;

                if (go.gameObject.GetComponent<MovementType>() != null)
                {
                    DestroyImmediate(go.gameObject.GetComponent<MovementType>());
                }

                go.movement = go.gameObject.AddComponent<FreeroamMovement>();
            }

            if (GUILayout.Button("Navmesh Movement"))
            {
                var go = target as MovementController;

                if (go.gameObject.GetComponent<MovementType>() != null)
                {
                    DestroyImmediate(go.gameObject.GetComponent<MovementType>());
                }

                go.movement = go.gameObject.AddComponent<NavmeshMovement>();
            }

            GUILayout.EndHorizontal();
        }
    }
#endif
}