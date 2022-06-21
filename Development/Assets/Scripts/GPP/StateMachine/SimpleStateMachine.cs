using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
  public Node Next;
  public Node Last;
  public GameObject obj; // This objs contain their own logic
}

public class SimpleStateMachine : MonoBehaviour
{
  [SerializeField]
  public List<Node> root = new List<Node>();

  public void NewNode(GameObject obj, Node last)
  {
    Node tmpNode = new Node();
    tmpNode.obj = obj;
    tmpNode.Next = null;
    tmpNode.Last = last;

    root.Add(tmpNode);

    Debug.Log("New Node Created");
  }

  public void Update()
  {
    if (Input.GetKey(KeyCode.N))
    {
      NewNode(new GameObject(), null);
    }
  }
}
