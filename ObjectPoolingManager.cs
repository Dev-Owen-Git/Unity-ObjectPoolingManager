using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class PoolObjectData 
{
    public GameObject prefab;
    public int poolCount = 10;   

    [Header("해당 오브젝트 설명")]
    public string explan;
}

/// <summary> 오브젝트 풀링 매니저 </summary>
public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager instance;
    [ SerializeField ] private List<PoolObjectData> poolList = new List<PoolObjectData>();
    

    private Dictionary<string, Transform> poolParentDic = new Dictionary<string, Transform>();
    private Dictionary<string, PoolObjectData> instantiateObject = new Dictionary<string, PoolObjectData>();

    private void Awake() 
    {
        if ( instance == null )
        {
            instance = this;
        }

        MakeDir("Using");
        Pool( poolList );
    }

#region Instantiate
    public void Pool( List<PoolObjectData> _poolObjectList )
    {
        GameObject prefab;

        string prefabName;
        int count;

        foreach( PoolObjectData data in _poolObjectList )
        {
            if ( data.prefab == null ) 
            {
                Debug.LogWarning( "ObjectPooler Instantiate Error : GameObject Missing" );
                continue;
            }

            prefab = data.prefab;
            prefabName = prefab.name;
            count = data.poolCount;

            if ( poolParentDic.ContainsKey( prefabName ) == false )
            {
                MakeDir(prefabName);
                InstantiatePool( prefab, poolParentDic[prefabName] , count );

                instantiateObject[ prefabName ] = data;
            }
            else
            {
                continue;
            }
        }
    }

    void MakeDir( string _name )
    {
        GameObject newDir = new GameObject(_name);
        newDir.transform.SetParent( this.transform );
        poolParentDic[_name] = newDir.transform;
    }

    /// <summary> 오브젝트를 갯수 만큼 생성하고 마지막 생성된 오브젝트를 반환합니다 </summary>
    GameObject InstantiatePool( GameObject _prefab, Transform _parent, int _count )
    {
        GameObject inst = null;
        for ( int i = 0; i < _count; i++ )
        {
            inst = Instantiate( _prefab, Vector3.zero, Quaternion.identity, _parent );
            inst.name = _prefab.name;
            inst.SetActive( false );
        }
        return inst;
    }

#endregion

#region  Get
    public GameObject GetObject( string _id, Transform _parent = null, bool _enable = true )
    {
        if ( poolParentDic.ContainsKey( _id ) == false )
        {
            Debug.LogWarningFormat("ObjectPooler Get Error : Not Find {0} Object", _id );
            return null;
        }

        if ( poolParentDic[_id].childCount > 0 )
        {
            Transform pool = poolParentDic[_id].GetChild(0);
            if ( pool.gameObject.activeSelf == false )
            {
                if ( _parent == null )
                {
                    pool.SetParent( poolParentDic["Using"] );
                }
                else
                {
                    pool.SetParent( _parent );
                }

                pool.gameObject.SetActive( _enable );
                return pool.gameObject;
            }
        }
        
        // 부족한 경우 추가 생성 후 하나를 반환해 줍니다.
        return InstantiatePool( instantiateObject[ _id ].prefab, poolParentDic[ _id ],  instantiateObject[ _id ].poolCount );;
    }

    // Set Position, Rotation
    public GameObject GetObject( string _id, Vector3 _position, Quaternion _rotation, Transform _parent = null, bool _enable = true )
    {
        GameObject rtnObject  = GetObject( _id, _parent, false );
        rtnObject.transform.SetPositionAndRotation( _position, _rotation );
        rtnObject.gameObject.SetActive( _enable );
        return rtnObject;
    }

    // Set Position, Rotation And WaitReturn
    public GameObject GetObject( string _id, Vector3 _position, Quaternion _rotation, float _rtnTime, Transform _parent = null, bool _enable = true )
    {
        GameObject rtnObject = GetObject(_id, _position, _rotation, _parent, _enable );
        StartCoroutine(  WaitReturnObject( rtnObject, _rtnTime ));
        return rtnObject;
    }  

    // WaitReturn
    public GameObject GetObject( string _id, float _rtnTime, Transform _parent = null, bool _enable = true )
    {
        GameObject rtnObject  = GetObject( _id, _parent, _enable );
        StartCoroutine(  WaitReturnObject( rtnObject, _rtnTime ));
        return rtnObject;
    }

    // Auto Return And Set Position Rotation And Parent
    public GameObject GetObjectToAutoReturn( string _id, Vector3 _position, Quaternion _rotation, Transform _parent = null, bool _enable = true )
    {
        GameObject rtnObject  = GetObject( _id, _position, _rotation, _parent, _enable );
        StartCoroutine( AutoReturn( rtnObject ) );
        return rtnObject;
    }

    // Autu Return And Set Position Rotation
     public GameObject GetObjectToAutoReturn( string _id, Transform _parent = null, bool _enable = true )
    {
        GameObject rtnObject  = GetObject( _id, _parent, _enable );
        StartCoroutine(  AutoReturn( rtnObject ));
        return rtnObject;
    }  

#endregion

#region Return
    public void ReturnObject( GameObject _object )
    {
        if ( _object == null )
        {
            Debug.LogErrorFormat("ObjectPooler Return Error : Object Is Null" );
            return;
        }

        if ( poolParentDic.ContainsKey( _object.name ) == false )
        {
            Debug.LogWarningFormat("ObjectPooler Return Error : Not Find {0} Object", _object.name );
            return;
        }

        _object.transform.SetParent( poolParentDic[ _object.name ] );
        _object.SetActive( false );
    }

    private IEnumerator WaitReturnObject( GameObject _object ,float _waitTIme )
    {
        yield return new WaitForSeconds( _waitTIme );
        ReturnObject( _object );
    }

    private IEnumerator AutoReturn( GameObject _object )
    {
        while ( _object.activeSelf == true )
        {
            yield return null;
        }
        ReturnObject( _object );
    }
#endregion

}
