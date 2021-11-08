using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordHolder : MonoBehaviour
{
    public int normalRecord;
    public int infiniteRecord;
    private GameObject OtherGO;
    private void Awake()
    {
        OtherGO = GameObject.Find("RecordHolder");
        DontDestroyOnLoad(this.gameObject);
        if(OtherGO != this.gameObject && normalRecord == infiniteRecord)
        {
            Destroy(this.gameObject);
        }
    }
}
