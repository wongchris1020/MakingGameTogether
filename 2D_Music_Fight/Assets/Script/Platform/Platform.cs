using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum PlatformType { Moving, Rotating, Disappearing, JumpPad, GravityManipulator }
    public PlatformType type;
    private void Start()
    {
        foreach (Platform platform in GameObject.FindObjectsOfType<Platform>())
        {
            switch (platform.type)
            {
                case PlatformType.Moving:
                    platform.gameObject.AddComponent<MovingPlatform>();
                    break;
                case PlatformType.Rotating:
                    platform.gameObject.AddComponent<RotatingPlatform>();
                    break;
                case PlatformType.Disappearing:
                    platform.gameObject.AddComponent<DisappearingPlatform>();
                    break;
                case PlatformType.JumpPad:
                    platform.gameObject.AddComponent<JumpPad>();
                    break;
                case PlatformType.GravityManipulator:
                    platform.gameObject.AddComponent<GravityManipulator>();
                    break;
            }
        }
    }
}
