using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class FindEnemyDemo : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("查找血量最低的敌人"))
        {
            //1.通过标签获取敌人
            //GameObject[] allEnemyGO = GameObject.FindGameObjectsWithTag("Enemy");
            //Enemy[] allEnemy = new Enemy[allEnemyGO.Length];
            //for (int i = 0; i < allEnemyGO.Length; i++)
            //{
            //    allEnemy[i] = allEnemyGO[i].GetComponent<Enemy>();
            //}

            //2.通过类型获取敌人
            Enemy[] allEnemy = FindObjectsOfType<Enemy>();

            Enemy min = FindEnemyByMinHP(allEnemy);
            min.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (GUILayout.Button("查找距离最近的敌人"))
        {
            Enemy[] allEnemy = FindObjectsOfType<Enemy>();
            Enemy minDistance = FindeEnemyByMinDistance(allEnemy,transform);
            minDistance.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public Enemy FindEnemyByMinHP(Enemy[] enemys)
    {
        Enemy min = enemys[0];
        for (int i = 1; i < enemys.Length; i++)
        {
            if (min.HP > enemys[i].HP)
                min = enemys[i];
        }
        return min;
    } 

    //练习2：获取最近的敌人
    //float distance = Vector3.Distance(物体1.位置,物体2.位置);
    public Enemy FindeEnemyByMinDistance(Enemy[] enemys,Transform targetTF)
    {
        Enemy min = enemys[0];
        float minDistance =  Vector3.Distance(min.transform.position,targetTF.position  );
         
        for (int i = 1; i < enemys.Length; i++)
        {
            float distance = Vector3.Distance( enemys[i].transform.position,targetTF.position);
            if (minDistance > distance)
            {
                min = enemys[i];
                minDistance = distance;
            }
        }

        return min;
    }

}
