using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Sons",menuName = "ScriptableObject/Sons")]
public class ScriptableSons : ScriptableObject
{
    public List<AudioClip> audios;
}
