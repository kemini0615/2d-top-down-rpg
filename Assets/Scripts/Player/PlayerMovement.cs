using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;

    private Player player;

    private PlayerActions actions;
    private Rigidbody2D rb;

    private Vector2 moveDirection;
    private bool isMoving;

    private void Awake()
    {
        player = GetComponent<Player>();

        actions = new PlayerActions();
        rb = GetComponent<Rigidbody2D>(); // 현재 게임 오브젝트에서 컴포넌트를 찾아 반환
    }

    private void Update()
    {
        HandleMoveInput(); // 유저 이동 입력 처리
    }

    private void FixedUpdate()
    {
        Move(); // 이동
    }

    private void HandleMoveInput()
    {
        // 'Movement' 액션 맵의 'Move' 액션 값 읽기
        // 'Move' 액션의 Action Type은 Value, Control Type은 Vector2
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;

        // 유저 입력이 없을 때: 마지막으로 입력한 방향 유지
        if (moveDirection == Vector2.zero)
        {
            isMoving = false;
        }
        // 유저 입력이 있을 때
        else
        {
            isMoving = true;

            // 애니메이터 파라미터를 갱신하여 재생 애니메이션 변경
            player.animator.SetFloat("xInput", moveDirection.x);
            player.animator.SetFloat("yInput", moveDirection.y);
        }

        player.animator.SetBool("isMoving", isMoving);
    }

    private void Move()
    {
        // 플레이어가 죽었다면 움직이지 않음
        if (player.health.IsDead)
            return;

        // MovePostion은 물리 법칙(힘, 속도 등)을 무시하고, 해당 좌표로 순간 이동하는 메소드로, Kinematic Ridigbody에서 주로 사용된다
        // rb.MovePosition(transform.position + (new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.fixedDeltaTime)); // 비권장

        // linearVelocity 또는 AddForce는 물리 법칙에 의해 이동하는 메소드로, Dynamic Rigidbody에서 주로 사용된다
        rb.linearVelocity = moveDirection * speed * Time.fixedDeltaTime; // 이동 방향과 속력으로 이동 속도 설정
    }

    // Player가 활성화(Enable) 상태라면 유저 입력 처리
    private void OnEnable()
    {
        actions.Enable();
    }

    // Player가 비활성화(Disable) 상태라면 유저 입력 처리 안함
    private void OnDisable()
    {
        actions.Disable();
    }
}
