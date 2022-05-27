using UnityEngine;
using System.Collections;

public class CoroutineWithData
{
  private IEnumerator _target;
  public object result;
  public Coroutine Coroutine { get; private set; }

  public CoroutineWithData(MonoBehaviour owner_, IEnumerator target_)
  {
    _target = target_;
    Coroutine = owner_.StartCoroutine(Run());
  }

  private IEnumerator Run()
  {
    while (_target.MoveNext())
         {
      result = _target.Current;
      yield return result;
    }
  }
}