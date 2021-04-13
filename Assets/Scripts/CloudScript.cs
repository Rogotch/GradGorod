using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class CloudScript : MonoBehaviour, ISpawn
{
    // Скрипт движения облаков, завязан на 

    private float _speed, _endPosX;
    private bool _leftToRight;

    private float YOffsetRange = 0;

    private bool FixedScale = false;

    private float ScaleRange = 0f;

    private bool FixedSpeed = false;
    [Range(0.6f, 2f)]
    private float BaseSpeed = 1f;

    private bool LeftToRight = true;

    private float endPosX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartFloating(bool FixedSpeed, float BaseSpeed, float endPosX, float YOffsetRange, bool FixedScale, float ScaleRange, bool LeftToRight)
    {
        this.FixedSpeed = FixedSpeed;
        this.BaseSpeed = BaseSpeed;
        this.endPosX = endPosX;
        this.YOffsetRange = YOffsetRange;
        this.FixedScale = FixedScale;
        this.ScaleRange = ScaleRange;
        this.LeftToRight = LeftToRight;

        //Определение, какое указано рандомное смещение по оси y
        if (YOffsetRange != 0 && YOffsetRange * -1 > YOffsetRange)
            YOffsetRange *= -1;

        float speed;
        if (FixedSpeed)
            speed = BaseSpeed;
        else
            speed = UnityEngine.Random.Range(BaseSpeed - 0.5f, BaseSpeed + 0.5f);

        float yOffset = UnityEngine.Random.Range(YOffsetRange * -1, YOffsetRange);

        float scale;
        if (FixedScale)
            scale = ScaleRange;
        else
            scale = UnityEngine.Random.Range(1f - ScaleRange, 1f + ScaleRange);

        _leftToRight = LeftToRight;
        if (!LeftToRight)
            _speed = -1 * speed;
        else
            _speed = speed;
        GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        GetComponent<Transform>().localScale = new Vector2(scale, scale);
        _endPosX = endPosX;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * _speed));

        if (transform.position.x > _endPosX && _leftToRight || transform.position.x < _endPosX && !_leftToRight)
        {
            GetComponent<Transform>().position = transform.parent.position;
            transform.parent.GetComponent<ISpawn>().ReloadParams(gameObject);
        }

        //Destroy(gameObject);
    }

    public void ReloadParams(GameObject _object = null)
    {
        StartFloating(FixedSpeed, BaseSpeed, endPosX, YOffsetRange, FixedScale, ScaleRange, LeftToRight);
    }

}
