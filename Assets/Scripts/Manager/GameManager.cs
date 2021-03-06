using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownShooter
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Texture2D cursorTexture = null;

        private void Awake()
        {
            Application.targetFrameRate = -1;
        }

        private void Start()
        {
            SetCursorIcon();
        }

        private void SetCursorIcon()
        {
            Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2f, cursorTexture.height / 2f), CursorMode.Auto);
        }
        
        public void RestartLevel()
        {
            DOTween.KillAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

