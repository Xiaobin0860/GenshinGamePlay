﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaoTie
{
    public class InputManager : IManager, IUpdateManager
    {
        private const int KeyDown = 1;
        private const int KeyUp = 2;
        private const int Key = 4;
        public static KeyCode[] Default = new KeyCode[(int) GameKeyCode.Max]
        {
            KeyCode.W,
            KeyCode.S,
            KeyCode.A,
            KeyCode.D,
            KeyCode.Alpha1,
        };
        
        public static InputManager Instance { get; private set; }
        public bool IsPause;

        /// <summary>
        /// 按键绑定
        /// </summary>
        private readonly KeyCode[] keySetMap = new KeyCode[(int)GameKeyCode.Max];

        /// <summary>
        /// 按键状态
        /// </summary>
        private readonly int[] keyStatus = new int[(int)GameKeyCode.Max];

        #region IManager

        public void Init()
        {
            Instance = this;
            //todo:
            for (int i = 0; i < (int)GameKeyCode.Max; i++)
            {
                keySetMap[i] = Default[i];
            }
        }

        public void Destroy()
        {
            Instance = null;
            Array.Clear(keySetMap,0,(int)GameKeyCode.Max);
            Array.Clear(keyStatus,0,(int)GameKeyCode.Max);
        }

        #endregion

        public void Update()
        {
            if (IsPause) return;
            Array.Clear(keyStatus,0,(int)GameKeyCode.Max);
            for (int i= 0; i< (int)GameKeyCode.Max; ++i)
            {
                KeyCode key = keySetMap[i];
                int val = 0;
                if (key >= 0)
                {
                    if (Input.GetKeyDown(key))
                        val += KeyDown;
                    if (Input.GetKeyUp(key))
                        val += KeyUp;
                    if (Input.GetKey(key))
                        val += Key;
                }
                keyStatus[i] = val;
            }
        }

        /// <summary>
        ///  获取按键
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public bool GetKey(GameKeyCode keyCode)
        {
            return (keyStatus[(int)keyCode]& Key) != 0;
        }

        /// <summary>
        ///  获取按键是否按下
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public bool GetKeyDown(GameKeyCode keyCode)
        {
            return (keyStatus[(int)keyCode]& KeyDown) != 0;
        }
        
        /// <summary>
        ///  获取按键是否抬起
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public bool GetKeyUp(GameKeyCode keyCode)
        {
            return (keyStatus[(int)keyCode]& KeyUp) != 0;
        }
        
        public void SetInputKeyMap(GameKeyCode key, KeyCode keyCode)
        {
            keySetMap[(int) key] = keyCode;
        }
    }
}