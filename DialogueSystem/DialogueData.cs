using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/DialogueData", order = 1)]
public class DialogueData : ScriptableObject
{
    [System.Serializable]
    public class Dialogue
    {
        public string speakerName;        // 대화 주체 이름
        [TextArea(3, 10)]
        public string content;           // 대화 내용
    }

    public List<Dialogue> dialogues;     // 대화 리스트
}
