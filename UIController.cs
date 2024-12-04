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
        // PlayerMove �� ActionController ������Ʈ�� �����ɴϴ�.
        playermove = GameObject.Find("Player").GetComponent<PlayerMove>();
        
    }

    void Update()
    {
        Offmovement();  // �� �����Ӹ��� Offmovement�� ȣ���Ͽ� ���¸� ����
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
        // canvaspuzzle UI�� Ȱ��ȭ�Ǿ��� �� �÷��̾� �� �׼� ��� ��Ȱ��ȭ
        if (canvaspuzzle.activeSelf == true)
        {
            if (playermove != null) playermove.enabled = false;  // �÷��̾� ������ ��Ȱ��ȭ
            
        }
        else
        {
            if (playermove != null) playermove.enabled = true;  // �÷��̾� ������ Ȱ��ȭ
            
        }
    }
}
