오브젝트 풀링 매니저 사용법 ( 2021-06-26 )
------------

추가 방법 
<br>ObjectPoolingManager.instance.Pool( _poolingObjectList );</br>

------------
오브젝트 가져오기 
<br>ObjectPoolingManager.instance.GetObject( _id );
<br>ObjectPoolingManager.instance.GetObject( _id, _position, _rotation );
<br>ObjectPoolingManager.instance.GetObject( _id, _position, _rotation, _parent );
<br>ObjectPoolingManager.instance.GetObject( _id, _position, _rotation, _parent, _enable );

<br>ObjectPoolingManager.instance.GetObject( _id, _rtnTime );
<br>ObjectPoolingManager.instance.GetObject( _id, _rtnTime, _parent );
<br>ObjectPoolingManager.instance.GetObject( _id, _rtnTime, _parent, _enable );

<br>ObjectPoolingManager.instance.GetObject( _id, _position, _rotation, _rtnTime );
<br>ObjectPoolingManager.instance.GetObject( _id, _position, _rotation, _rtnTime, _parent );
<br>ObjectPoolingManager.instance.GetObject( _id, _position, _rotation, _rtnTime, _parent, _enable );

<br>ObjectPoolingManager.instance.GetObjectToAutoReturn( _id );
<br>ObjectPoolingManager.instance.GetObjectToAutoReturn( _id, _enable );

<br>ObjectPoolingManager.instance.GetObjectToAutoReturn( _id, _position, _rotation );
<br>ObjectPoolingManager.instance.GetObjectToAutoReturn( _id, _position, _rotation, _parent );
<br>ObjectPoolingManager.instance.GetObjectToAutoReturn( _id, _position, _rotation, _parent, _enable );


------------
오브젝트 반환하기 
<br> ObjectPoolingManager.instance.ReturnObject( _object ); </br>
