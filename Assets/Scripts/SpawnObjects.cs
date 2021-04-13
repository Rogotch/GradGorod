using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

//Скрипт, спавнящий объекты из массива с периодичностью
public class SpawnObjects : MonoBehaviour, ISpawn
{
    public bool EndlessGenerate = false;
    [SerializeField]
    private GameObject[] Objects;

    [SerializeField]
    private float spawnInterval;

    [SerializeField]
    private GameObject EndPoint;

    private Vector3 startPos;

    public float YOffsetRange = 0;

    public bool FixedScale = false;
    [Range(0f, 1f)]
    public float ScaleRange = 0f;

    public bool FixedSpeed = false;

    [Range(0.6f, 2f)]
    public float BaseSpeed = 1f;

    public bool LeftToRight = true;

    public int PrewarmObj = 12;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Prewarm();
        //Рассмотреть возможность использовать корутины, они быстрее
        if (EndlessGenerate)
            Invoke("AttemptSpawn", spawnInterval);

    }

    void ObjSpawn(Vector3 startPos)
    {
        int randomIndex = UnityEngine.Random.Range(0, Objects.Length);
        GameObject _object = Instantiate(Objects[randomIndex]);
        _object.transform.SetParent(transform);
        _object.transform.position = startPos;

        _object.GetComponent<CloudScript>().StartFloating(FixedSpeed, BaseSpeed, EndPoint.transform.position.x, YOffsetRange, FixedScale, ScaleRange, LeftToRight);
        
    }

    void AttemptSpawn()
    {
        ObjSpawn(startPos);
 
        Invoke("AttemptSpawn", spawnInterval);
    }

    /// <summary>
    /// Предварительная генерация объектов при запуске в кол-ве, равном PrewarmObj
    /// </summary>
    void Prewarm()
    {
        float firstPos, secondPos;
        if (startPos.x > EndPoint.transform.position.x)
        {
            firstPos = startPos.x;
            secondPos = EndPoint.transform.position.x;
        }
        else
        {
            firstPos = EndPoint.transform.position.x;
            secondPos = startPos.x;
        }
            for (int i = 0; i < PrewarmObj; i++)
            {
                Vector3 SpawnPos = new Vector3(UnityEngine.Random.Range(firstPos, secondPos), startPos.y, startPos.z);
                ObjSpawn(SpawnPos);
            }
    }

    public void ReloadParams(GameObject _object)
    {
        foreach (var spawnScript in _object.GetComponents<ISpawn>())
        {
            spawnScript.ReloadParams();
        }
        
    }
}
