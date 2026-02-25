using System.Collections.Generic;
using UnityEngine;

namespace Pattern_Examples.State
{
    public class MyAgent_StateController : MonoBehaviour
    {
        // Support a list of agents so we can change many at once from the inspector.
        // Keep the single-agent field for backward compatibility (old scenes).
        public List<MyAgent> agents = new List<MyAgent>();
        public Transform moveTarget;

        private void Update(){

            if (agents == null || agents.Count == 0) return;

            if (Input.GetKeyDown(KeyCode.Alpha1)){
                foreach (var a in agents){
                    if (a == null) continue;
                    a.ChangeState(new State_Idle(a));
                }

                Debug.Log($"[Controller] Changed {agents.Count} agent(s) → Idle");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)){
                foreach (var a in agents){
                    if (a == null) continue;
                    a.ChangeState(new State_MoveToTarget(a, moveTarget));
                }

                Debug.Log($"[Controller] Changed {agents.Count} agent(s) → MoveToTarget");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)){
                foreach (var a in agents){
                    if (a == null) continue;
                    a.ChangeState(new State_Patrol(a));
                }

                Debug.Log($"[Controller] Changed {agents.Count} agent(s) → Patrol");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4)){
                foreach (var a in agents){
                    if (a == null) continue;
                    a.ChangeState(new State_Seek(a, moveTarget));
                }

                Debug.Log($"[Controller] Changed {agents.Count} agent(s) → Seek");
            }
        }
    }
}