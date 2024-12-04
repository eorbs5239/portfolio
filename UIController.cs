using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private TextMeshProUGUI textPlaytime;
    [SerializeField]
    private TextMeshProUGUI textMoveCount;
    [SerializeField]
    private Board board;
    [SerializeField]
    private GameObject canvaspuzzle;

    private PlayerMove playermove;
    

    private void Start()
    {
        // PlayerMove 및 ActionController 컴포넌트를 가져옵니다.
        playermove = GameObject.Find("Player").GetComponent<PlayerMove>();
        
    }

    void Update()
    {
        Offmovement();  // 매 프레임마다 Offmovement를 호출하여 상태를 관리
    }

    public void OnResultPanel()
    {
        resultPanel.SetActive(true);

        textPlaytime.text = $"PLAY TIME : {board.Playtime / 60:D2}:{board.Playtime % 60:D2}";
        textMoveCount.text = "MOVE COUNT : " + board.MoveCount;
    }

    public void OnClickQuit()
    {
        canvaspuzzle.SetActive(false);
    }

    public void Offmovement()
    {
        // canvaspuzzle UI가 활성화되었을 때 플레이어 및 액션 제어를 비활성화
        if (canvaspuzzle.activeSelf == true)
        {
            if (playermove != null) playermove.enabled = false;  // 플레이어 움직임 비활성화
            
        }
        else
        {
            if (playermove != null) playermove.enabled = true;  // 플레이어 움직임 활성화
            
        }
    }
}
