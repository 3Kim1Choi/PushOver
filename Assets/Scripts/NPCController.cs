using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation {
    public class NPCController : MonoBehaviour {
        public Transform NPCParent;
        public GameObject NPCPrefab;
        public PathCreator[] paths;
        public float npcSpeed;
        Vector3 spawnPos = new Vector3 (-1000, -1000, 0);
        List<NPC>[] npcs = new List<NPC>[8];
        void Start() {
            for (int i = 0; i < 8; i++) {
                npcs[i] = new List<NPC>();
            }
            MakeNPCGroupe(15, 0);
            MakeNPCGroupe(15, 1);
            MakeNPCGroupe(15, 2);
        }

        void MakeNPCGroupe(int cnt, int line) {
            for (int i = 0; i < cnt; i++) {
                MakeNPC(NPCPrefab, line, (float)i / cnt, Random.Range(0,8));
            }
        }

        void MakeNPC(GameObject go, int num, float sP, int character) {
            GameObject npc = Instantiate(go, spawnPos, Quaternion.identity);
            NPC pf = npc.GetComponent<NPC>();
            pf.pathCreator = paths[num];
            if (pf.pathCreator == null) {
                Destroy(npc);
                return;
            }
            pf.startPoint = sP;
            npc.GetComponent<CharacterAnimation>().characterNum = character + 3;
            npc.transform.SetParent(NPCParent);
            npcs[num].Add(pf);
        }
        public void Stop(int n) {
            foreach (NPC npc in npcs[n]) {
                npc.StopNPC();
            }
        }
        public void Move(int n) {
            foreach (NPC npc in npcs[n]) {
                npc.MoveNPC();
            }
        }
    }

}
