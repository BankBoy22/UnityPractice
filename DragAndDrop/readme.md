# Unity DRAG & DROP UI
UI에서의 아이템 드래그 앤 드롭을 구현 방법 입니다.
## <Drag & Drop 구현을 위해 필요한 인터페이스>
Unity에서 마우스/터치를 이용해 오브젝트를 제어할 수 있도록 제공하는 IPointerHandler, IDragHandler, IDropHandler 인터페이스
#### UnityEngine.EventSystems 이름공간 선언 필요
### UI 오브젝트
#### GraphicRaycaster 컴포넌트 필요 (Canvas 오브젝트)
#### Imagem, TextMeshPro-Text와 같은 UI 컴포넌트 내부의 Raycast Target 변수 활성화
### 2D/3D 오브젝트
#### Colider2D/Colider 컴포넌트 필요
### IPointerHandler 인터페이스
#### 마우스 포인터가 특정 충돌 영역에 있는지, 클릭했는지 여부를 확일할 때 사용
|인터페이스|메소드|설명|
|---|:---|:---:|
|IPointerEnterHandler|void OnPointerEnter(PointerEventData)|마우스 포인터가 현재 오브젝트 영역 내부로 들어갈 때 1회 호출|
|IPointerExitHandler|void OnPointerDown(PointerEventData)|마우스 포인터가 현재 오브젝트 영역 빠져나갈 때 1회 호출|
|IPointerDownHandler|void OnPointerDown(PointerEventData)|현재 오브젝트 내부에서 클릭하는 순간 1회 호출|
|IPointerUPHandler|void OnPointerDown(PointerEventData)|현재 오브젝트 내부에서 클릭을 떼는 순간 1회 호출|
|IPointerClickHandler|void OnPointerClick(PointerEventData)|현재 오브젝트 내부에서 클릭했다 떼는 순간 1회 호출(다운&업 할 때 마우스가 해당 오브젝트 내부에 있어야 함|
### IDragHandler 인터페이스
#### 오브젝트를 드래그 할 때 사용
|인터페이스|메소드|설명|
|---|:---|:---:|
|IBeginDragHandler|void OnBeginDrag(PointerEventData)|현재 오브젝트를 드래그하기 시작할 때 1회 호출|
|IDragHandler|void OnDrag(PointerEventData)|현재 오브젝트를 드래그 중일 대 매 프레임 호출|
|IEndDragHandler|void OnPointerDown(PointerEventData)|현재 오브젝트의 드래그를 종료할 때 1회 호출|
|IDropHandler|void OnDrop(PointerEventData)|현재 오브젝트의 드래그를 종료할 때 1회 호출|
### IPointerHandler 인터페이스
#### 마우스 포인터가 특정 충돌 영역에 있는지, 클릭했는지 여부를 확일할 대 사용

