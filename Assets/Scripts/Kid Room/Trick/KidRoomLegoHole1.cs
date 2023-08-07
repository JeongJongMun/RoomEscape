using UnityEngine;

public class KidRoomLegoHole1 : Trick
{
    [Header("���� 1")]
    public GameObject lego1;
    [Header("�θ� ���� ����")]
    public GameObject legoHole;
    public override void TrySolve(GameObject obj)
    {
        if (obj.name == name)
        {
            if (Inventory.Instance.IsClicked("Lego1"))
            {
                Debug.LogFormat("{0} is Solved", name);
                Inventory.Instance.RemoveItem("Lego1");
                SetIsSolved(true);
                SolvedAction();
            }
            else
            {
                Debug.LogFormat("{0} is Not Solved", name);
            }
        }
    }
    public override void SolvedAction()
    {
        if (!DatabaseManager.Instance.IsTrickSolved(roomName, "LegoHole"))
        {
            legoHole.GetComponent<KidRoomLegoHole>().legoCount++;
            legoHole.GetComponent<KidRoomLegoHole>().TrySolve(legoHole);
            lego1.SetActive(true);
        }
    }
}