using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;           // 대화 주체 이름 출력
    public TextMeshProUGUI dialogueContentText;       // 대화 내용 출력
    public GameObject dialoguePanel;       // 대화 UI 패널
    public DialogueData dialogueData;      // ScriptableObject 대화 데이터

    private int currentDialogueIndex = 0;  // 현재 대화 인덱스
    private bool isTyping = false;         // 글자 출력 중인지 여부
    private Coroutine typingCoroutine;     // 타이핑 코루틴

    void Start()
    {
        dialoguePanel.SetActive(false); // 초기에는 대화 패널 비활성화
    }

    //다이어로그 시작 이벤트
    public void StartDialogue()
    {
        currentDialogueIndex = 0;
        dialoguePanel.SetActive(true);
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        if (currentDialogueIndex >= dialogueData.dialogues.Count)
        {
            EndDialogue();
            return;
        }

        if (isTyping)
        {
            SkipTyping(); // 현재 타이핑 중인 대화를 스킵
        }
        else
        {
            var currentDialogue = dialogueData.dialogues[currentDialogueIndex];
            typingCoroutine = StartCoroutine(TypeDialogue(currentDialogue.speakerName, currentDialogue.content));
            currentDialogueIndex++;
        }
    }

    private IEnumerator TypeDialogue(string speakerName, string content)
    {
        isTyping = true;
        speakerNameText.text = speakerName;
        dialogueContentText.text = "";

        foreach (char letter in content)
        {
            dialogueContentText.text += letter;
            yield return new WaitForSeconds(0.05f); // 한 글자씩 출력 (속도 조절 가능)
        }

        isTyping = false;
    }

    private void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        var currentDialogue = dialogueData.dialogues[currentDialogueIndex - 1];
        dialogueContentText.text = currentDialogue.content;
        isTyping = false;
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        Debug.Log("Dialogue Ended");
    }

    void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextDialogue(); // 스페이스바로 대화 넘기기
        }
    }
}
