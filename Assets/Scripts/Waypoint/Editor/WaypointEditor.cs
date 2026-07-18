// UnityEditor.Editor를 상속하는 클래스(파일)는 반드시 "Editor" 폴더 아래에 존재해야 한다
using UnityEditor;
using UnityEngine;


// 컴포넌트(예: Waypoint) 전용 커스텀 에디터 설정 (필수)
// 전용 컴포넌트를 가진 오브젝트를 선택하는 순간, Unity가 자동으로 커스텀 에디터의 인스턴스를 생성하고 OnEnable 메소드를 호출한다
// CustomEditor 애트리뷰트로 전용 컴포넌트를 설정하지 않으면, 커스텀 에디터는 호출되지 않는다
[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    private Waypoint targetWaypoint;
    private GUIStyle style;

    // 전용 컴포넌트를 가진 오브젝트를 선택할 때 호출
    // 주로 초기화를 담당한다
    private void OnEnable()
    {
        // target 프로퍼티(전용 컴포넌트)가 에디터 클래스에 자동으로 주입된다
        // target 프로퍼티는 기본적으로 UnityEngine.Object 타입이기 때문에 형 변환이 필요하다
        targetWaypoint = target as Waypoint;

        // GUI 폰트 스타일 설정
        style = new GUIStyle();
        style.fontStyle = FontStyle.Bold;
        style.fontSize = 16;
        style.normal.textColor = Color.black;
    }

    // 인스펙터 창이 다시 그려질 때마다 반복 호출
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    // 씬 뷰에서 이벤트가 발생(씬 뷰가 다시 그려지거나 씬을 조작)할 때마다 반복 호출
    private void OnSceneGUI()
    {
        if (targetWaypoint.Points.Length == 0)
            return;

        Handles.color = Color.red;
        for (int i = 0; i < targetWaypoint.Points.Length; i++)
        {
            // 유저가 GUI 컨트롤(버튼, 핸들 등)을 조작해서 값이 바뀌는지 감지 시작  (※컨트롤이란 유저가 상호작용 가능한 요소를 의미한다)
            // 아래쪽에 있는 EndChangeCheck()와 한 쌍으로, "값이 바뀌었는지 여부"를 bool로 받기 위한 준비 단계
            EditorGUI.BeginChangeCheck();

            Vector3 currentPosition = targetWaypoint.Points[i] + targetWaypoint.EntityPosition;
            
            // 씬 뷰에 구(sphere) 모양의 드래그 가능한 핸들을 그린다
            // 유저가 핸들을 드래그하면 그 결과 좌표를 반환한다
            // 인자 순서: 현재위치, 핸들크기, snap간격, 핸들모양
            Vector3 newPosition = Handles.FreeMoveHandle(currentPosition, 0.5f, Vector3.one * 0.5f, Handles.SphereHandleCap);

            Vector3 textOffset = new Vector3(0.2f, -0.2f);
            Handles.Label(
                targetWaypoint.EntityPosition
                + targetWaypoint.Points[i]
                + textOffset,
                $"{i+1}",
                style
            ); // 핸들에 텍스트 라벨 출력

            // BeginChangeCheck() 이후 GUI 컨트롤이 유저의 조작으로 값이 실제로 바뀌었을 때만 true를 반환한다
            // 즉, 유저가 핸들을 드래그했을 때만 이 블록 실행
            if (EditorGUI.EndChangeCheck())
            {
                // 이 조작을 Undo 스택에 기록해서 "Ctrl+Z"로 되돌릴 수 있게 해줌
                // 반드시 "값을 바꾸기 직전"에 호출해야 함
                Undo.RecordObject(targetWaypoint, "Handle Move");

                targetWaypoint.Points[i] = newPosition - targetWaypoint.EntityPosition;
            }
        }
    }

    // 다른 오브젝트를 선택해서 에디터 클래스 인스턴스가 필요 없어질 때 호출
    private void OnDisable()
    {
        //
    }
}