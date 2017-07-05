using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class WindowRemoveBorder : MonoBehaviour {

    public Rect screenPosition;

    [DllImport("user32.dll")]
    static extern IntPtr SetWindowLong(IntPtr hwnd, int _nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    static extern bool SetWindowPos(IntPtr hWnd, int hWndInserAfter, int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    [DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
    public static extern IntPtr GetSystemMetrics(int nIndex);

    const int SM_CXSCREEN = 0x00000000;
    const int SM_CYSCREEN = 0x00000001;  

    const uint SWP_SHOWWINDOW = 0x0040;
    const int GWL_STYLE = -16;
    const int WS_BORDER = 1;
    const int WS_POPUP = 0x800000;

    void Start()
    {
        //当前屏幕分辨率  
        int resWidth = (int)GetSystemMetrics(SM_CXSCREEN);  
        int resHeight = (int)GetSystemMetrics(SM_CYSCREEN);

        //窗体的宽高
        screenPosition.width = Screen.width;
        screenPosition.height = Screen.height;

        //设置窗体的位置
        screenPosition.x = resWidth / 2 - screenPosition.width / 2;
        screenPosition.y = resHeight / 2 - screenPosition.height / 2;

        //将网上的WS_BORDER替换成WS_POPUP
        SetWindowLong(GetForegroundWindow(), GWL_STYLE, WS_POPUP);

        bool result = SetWindowPos(GetForegroundWindow(), 0, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, SWP_SHOWWINDOW);
    }
}
