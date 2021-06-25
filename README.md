# Unity-ObjectPoolingManager
ObjectPoolingManager

Function  

// Add 
ObjectPoolingManager.instance.Pool( _poolingObjectList );

// Get
ObjectPoolingManager.instance.GetObject( _id );
ObjectPoolingManager.instance.GetObject( _id, _position, _rotation );

ObjectPoolingManager.instance.GetObject( _id, _rtnTime );
ObjectPoolingManager.instance.GetObject( _id, _position, _rotation, _rtnTime );

ObjectPoolingManager.instance.GetObjectToAutoReturn( _id );
ObjectPoolingManager.instance.GetObjectToAutoReturn( _id, _position, _rotation );

// Return
ObjectPoolingManager.instance.ReturnObject( _object );
