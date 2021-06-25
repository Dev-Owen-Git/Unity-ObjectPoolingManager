# Unity-ObjectPoolingManager
ObjectPoolingManager

Function  

<br> Add </br>
ObjectPoolingManager.instance.Pool( _poolingObjectList );

<br> Get </br>
ObjectPoolingManager.instance.GetObject( _id );
ObjectPoolingManager.instance.GetObject( _id, _position, _rotation );

ObjectPoolingManager.instance.GetObject( _id, _rtnTime );
ObjectPoolingManager.instance.GetObject( _id, _position, _rotation, _rtnTime );

ObjectPoolingManager.instance.GetObjectToAutoReturn( _id );
ObjectPoolingManager.instance.GetObjectToAutoReturn( _id, _position, _rotation );

<br> Return </br>
ObjectPoolingManager.instance.ReturnObject( _object );
