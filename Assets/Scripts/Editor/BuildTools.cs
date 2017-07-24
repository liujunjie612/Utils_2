using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildTools : MonoBehaviour {

    public static BuildTarget TargetPlatform = BuildTarget.StandaloneWindows;

    /// <summary>
    /// Build with "Development" flag, so that we can see the console if something 
    /// goes wrong
    /// </summary>
    public static BuildOptions BuildOptions = BuildOptions.Development;

    #region Editor Menu

    [MenuItem("Tools/Build EXE/ Build All", false,0)]
    public static void BuildAll()
    {
        var path = GetPath();
        if (string.IsNullOrEmpty(path))
            return;

        BuildJoystick(path);
        BuildAutoBuildEXE(path);
    }

    [MenuItem("Tools/Build EXE/Build Joystick", false, 11)]
    public static void BuildJoystickMenu()
    {
        var path = GetPath();
        if (!string.IsNullOrEmpty(path))
        {
            BuildJoystick(path);
        }
    }

    [MenuItem("Tools/Build EXE/Build AutoBuildEXE", false, 11)]
    public static void BuildAutoBuildEXEMenu()
    {
        var path = GetPath();
        if (!string.IsNullOrEmpty(path))
        {
            BuildAutoBuildEXE(path);
        }
    }

    #endregion

    /// <summary>
    /// Creates a build for MasterServer
    /// </summary>
    /// <param name="path"></param>
    private static void BuildJoystick(string path)
    {
        var gameServerScenes = new[]
        {
            "Assets/Scenes/Joystick.unity",
        };
        BuildPipeline.BuildPlayer(gameServerScenes, path + "Joystick.exe", TargetPlatform, BuildOptions);
    }

    /// <summary>
    /// Creates a build for DBServer
    /// </summary>
    /// <param name="path"></param>
    private static void BuildAutoBuildEXE(string path)
    {
        var gameServerScenes = new[]
        {
            "Assets/Scenes/AutoBuildEXE.unity",
        };
        BuildPipeline.BuildPlayer(gameServerScenes, path + "AutoBuildEXE.exe", TargetPlatform, BuildOptions);
    }

    public static string GetPath()
    {
        return Application.dataPath + @"../../Bin/";
    }
}
