using System;

[Serializable]
public class Transition
{
    public Decision decision;   // Decision의 반환값에 따라 어떤 상태로 트랜지션할지 결정된다
    public string trueStateId;    // Decision이 참인 경우
    public string falseStateId;   // Decision이 거짓인 경우
}
