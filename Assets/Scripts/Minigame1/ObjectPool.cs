using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo
{
    public GameObject prefab;
    public int count;
    public Transform objParent;
}
public class ObjectPool : MonoBehaviour
{
    [SerializeField] ObjectInfo[] objectInfo = null;
    public static ObjectPool instance;
    public Queue<GameObject> gearQueue = new Queue<GameObject>();
    
    private void Start() {
        instance = this;
        gearQueue= InsertQueue(objectInfo[0]);
    }
    
    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo) {
        Queue<GameObject> t_Queue = new Queue<GameObject>();
        for (int i = 0; i < p_objectInfo.count; i++) {
            GameObject t_clone = Instantiate(p_objectInfo.prefab, transform.position, Quaternion.identity);
            t_clone.SetActive(false);
            if (p_objectInfo.objParent != null)
                t_clone.transform.SetParent(p_objectInfo.objParent);
            else
                t_clone.transform.SetParent(this.transform);
            t_Queue.Enqueue(t_clone);
        }
        return t_Queue;
    }
}
