using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System;

public class SpawnBulbs : MonoBehaviour
{
    public GameObject Parent;

    private void Start()
    {
        var json = Resources.Load("SampleJSON");
        ImportData data = JsonConvert.DeserializeObject<ImportData>(json.ToString());
        for (int i = 0; i < data.timecontent.Length; i++)
        {
            for (int j = 0; j < data.timecontent[i].subtimecontent.Length; j++)
            {
                for (int k = 0; k < data.timecontent[i].subtimecontent[j].value2.Length; k++)
                {
                    GameObject instance = Instantiate(Resources.Load("Bulb", typeof(GameObject)), transform.position + Vector3.forward * GameManager.instance.spawnDistanceToParent, Quaternion.identity) as GameObject;

                    instance.GetComponent<BulbData>().Time = data.time;
                    instance.GetComponent<BulbData>().Subtime = new Tuple<int,int>(data.timecontent[0].subtime, data.timecontent[1].subtime);
                    instance.GetComponent<BulbData>().Value1 = data.timecontent[i].subtimecontent[j].value1;
                    instance.GetComponent<BulbData>().Value2 = data.timecontent[i].subtimecontent[j].value2[k].contentvalue1;
                    instance.GetComponent<BulbData>().Contentvalue3 = new Tuple<float,float> (data.timecontent[0].subtimecontent[j].value2[k].contentvalue2, data.timecontent[1].subtimecontent[j].value2[k].contentvalue2);
                    instance.GetComponent<BulbData>().Contentvalue2 = new Tuple<float, float>(data.timecontent[0].subtimecontent[j].value2[k].contentvalue3, data.timecontent[1].subtimecontent[j].value2[k].contentvalue3);

                    instance.GetComponent<BulbPhysics>().magnetStrength = UnityEngine.Random.Range(GameManager.instance.magnetStrengthRange[0], GameManager.instance.magnetStrengthRange[1]);
                    instance.transform.parent = Parent.transform;
                    Parent.transform.rotation = Quaternion.Euler(0, Parent.transform.rotation.eulerAngles.y, Parent.transform.rotation.eulerAngles.z);
                    Parent.transform.rotation *= Quaternion.Euler(UnityEngine.Random.Range(5, 80), 360 / 100, 0);

                }
            }
        }
    }
}