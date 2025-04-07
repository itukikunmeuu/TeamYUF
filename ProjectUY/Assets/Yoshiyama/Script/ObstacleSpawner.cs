using UnityEngine;
using UnityEngine.UI; // UI Text を使う場合

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;  // 障害物のプレハブ
    [SerializeField] GameObject midPrefab;      // midプレハブ
    [SerializeField] int numberOfObstacles = 10; // 増やす障害物数
    [SerializeField] float spacingZ = 15f;      // 奥行き間隔
    [SerializeField] float spacingX = 1.5f;     // 横の間隔（狭くする）

    private void Start()
    {
        // midプレハブを0の位置に配置
        CreateMidObstacle(Vector3.zero);

        for (int i = 0; i < 10; i++)
        {
            float zPos = i * spacingZ;

            // 左右に2つの障害物を配置
            int leftValue = Random.Range(-10, 11);  // 左側のランダム値
            int rightValue = Random.Range(-10, 11); // 右側のランダム値

            // 左右の障害物を生成
            CreateObstacle(new Vector3(-2.0f, 0.5f, zPos), leftValue);  // 左側
            CreateObstacle(new Vector3(2.0f, 0.5f, zPos), rightValue); // 右側
        }
    }

    void CreateObstacle(Vector3 position, int value)
    {
        // プレハブを生成
        GameObject obj = Instantiate(obstaclePrefab, position, Quaternion.identity);

        // プレハブ内のTextコンポーネントを取得
        Text obstacleText = obj.GetComponentInChildren<Text>();

        // プレハブ内のRendererコンポーネント（例えばPlane）を取得
        Renderer objRenderer = obj.GetComponent<Renderer>();

        if (obstacleText != null)
        {
            obstacleText.text = value.ToString(); // プレハブ内のTextにランダム値を設定
            obstacleText.alignment = TextAnchor.MiddleCenter; // 中央揃え
        }
    }

    void CreateMidObstacle(Vector3 position)
    {
        // midプレハブを生成（位置は0,0,0）
        Instantiate(midPrefab, position, Quaternion.identity);
    }
}