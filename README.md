오브젝트 풀링 매니저 사용법 ( 2021-07-24 )
=======================

### 추가 방법 
```
ObjectPoolingManager.instance.Pool( _poolingObjectList );
```

### 오브젝트 가져오기 
```
ObjectPoolingManager.instance.GetObject( ... )
```

### 기능
```
부족한 경우 추가 생성
포지션 로테이션 스케일 설정가능
[ 기능 추가 21.07.07 ] 오브젝트 비활성화 시 사종 반환 기능
[ 기능 추가 21.07.07 ] 일정 시간 뒤 자동으로 반환되는 기능
[ 기능 추가 21.07.24 ] 특정 컨퍼넌트 반환 
```

### 오브젝트 반환하기 
```
 ObjectPoolingManager.instance.ReturnObject( _object );
 ```
