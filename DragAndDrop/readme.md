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
#### 마우스 포인터가 특정 충돌 영역에 있는지, 클릭했는지 여부를 확일할 대 사용

