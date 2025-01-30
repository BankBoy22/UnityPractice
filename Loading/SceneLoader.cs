using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// 씬 이름을 열거형으로 저장
public enum ScemeNames { Intro = 0, Lobby}

namespace UnityNote
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; } //getter만 가능한 instance 변수

        [SerializeField]
        private GameObject loadingScreen;          // 로딩 화면
        [SerializeField]
        private Image loadingBackground;      // 로딩 화면의 배경
        [SerializeField]
        private Sprite[] loadingSprites;         // 배경 이미지 목록
        [SerializeField]
        private Slider loadingProgress;        // 로딩 진행도
        [SerializeField]
        private TextMeshProUGUI loadingText;            // 로딩 텍스트

        private WaitForSeconds waitChangeDelay;        // 씬 변경 지연 시간

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); // 이미 존재하는 인스턴스가 있으면 새로 생성된 인스턴스를 삭제
            }
            else
            {
                Instance = this; // instance 변수에 자신을 저장
                waitChangeDelay = new WaitForSeconds(0.5f); // 0.5초 지연
            }
        }

        public void LoadScene(string name)
        {
            int index = Random.Range(0, loadingSprites.Length); // 배경 이미지 목록 중 랜덤으로 선택
            loadingBackground.sprite = loadingSprites[index]; // 배경 이미지 설정
            loadingProgress.value = 0; // 로딩 진행도 초기화
            loadingScreen.SetActive(true); // 로딩 화면 활성화

            StartCoroutine(LoadSceneAsync(name)); // 비동기로 씬 로드
        }

        public void LoadScene(ScemeNames name)
        {
            LoadScene(name.ToString()); // LoadScene(string name) 호출
        }

        private IEnumerator LoadSceneAsync(string name)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name); // 비동기로 씬 로드

            // 비동기 작업(씬 불러오기)이 완료될 때까지 반복
            while (!asyncOperation.isDone)
            {
                // 로딩 진행도 갱신
                loadingProgress.value = asyncOperation.progress; // 로딩 진행도 갱신
                loadingText.text = $"{Mathf.RoundToInt(asyncOperation.progress * 100)}%"; // 로딩 텍스트 갱신
                yield return null; // 다음 프레임까지 대기
            }

            yield return waitChangeDelay; // 씬 변경 지연

            loadingScreen.SetActive(false); // 로딩 화면 비활성화
        }
    }
}
