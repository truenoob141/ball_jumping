using Project.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Project
{
    [RequireComponent(typeof(Camera))]
    public class CameraControl : MonoBehaviour
    {
        private const float REF_ASPECT = 16f / 9f;

        private Camera cam;
        private float initialSize;
        private Vector2Int lastRes;

        private void Awake()
        {
            this.cam = GetComponent<Camera>();
            this.initialSize = this.cam.orthographicSize;
        }

        private void LateUpdate()
        {
            if (lastRes.x == Screen.width && lastRes.y == Screen.height)
                return;

            float size = this.initialSize * (REF_ASPECT / cam.aspect);
            Debug.Log($"Change camera size from {cam.orthographicSize} to {size}");
            cam.orthographicSize = size;

            lastRes = new Vector2Int(Screen.width, Screen.height);
        }
    }
}
