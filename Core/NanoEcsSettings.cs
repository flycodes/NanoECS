﻿#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Directives
{
    public const string Debug = "NANOECS_DEBUG";
    public const string Reactivity = "NANOECS_REACTIVE";
}

public static class UnityMenuStructure
{
    public const string RootFolder = "NanoECS/";
    public const string SettingsItem = RootFolder + "Settings";
}

[CreateAssetMenu]
public class NanoEcsSettings : ScriptableObject
{
    public bool VisualDebugEnabled
    {
        get
        {
            return visualDebugEnabled;
        }
        set
        {
            visualDebugEnabled = value;

            if (visualDebugEnabled)
            {
                DefineTool.AddDefine(Directives.Debug);
            }
            else
            {
                DefineTool.RemoveDefine(Directives.Debug);
            }
        }
    }

    public bool ReactivityEnabled
    {
        get
        {
            return reactivityEnabled;
        }

        set
        {
            reactivityEnabled = value;

            if (reactivityEnabled)
            {
                DefineTool.AddDefine(Directives.Reactivity);
            }
            else
            {
                DefineTool.RemoveDefine(Directives.Reactivity);
            }
        }
    }

    public bool reactivityEnabled;
    public bool visualDebugEnabled;

    public List<ContextSettings> Contexts;
}

[System.Serializable]
public class ContextSettings
{
    public string Name;
    public int MinEntitiesPoolSize;
}

#endif