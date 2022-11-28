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
            /*
            MakeCar(greenCar, 0, 0);
            MakeCar(redMotorcycle, 0, 0.5f);
            MakeCar(blueCar, 1, 0.25f);
            MakeCar(bigGreenCar, 1, 0.75f);
            //b
            MakeCar(brownMotorcycle, 2, 0);
            MakeCar(bigGreenCar, 2, 0.5f);
            MakeCar(greenCar, 3, 0.25f);
            MakeCar(whiteMotorcycle, 3, 0.75f);
            //e
            MakeCar(greenCar, 6, 0);
            MakeCar(purpleCar, 6, 0.3f);
            MakeCar(blueCar, 6, 0.6f);
            //f
            MakeCar(redCar, 7, 0);
            MakeCar(redMotorcycle, 7, 0.4f);
            MakeCar(yellowCar, 7, 0.8f);*/
        }

        void MakeCar(GameObject go, int num, float sP) {
            GameObject npc = Instantiate(go, spawnPos, Quaternion.identity);
            NPC pf = npc.GetComponent<NPC>();
            pf.pathCreator = paths[num];
            pf.startPoint = sP;
            pf.pathNum = num;
            npc.transform.SetParent(NPCParent);
            npcs[num].Add(pf);
        }
        public void Stop(int n) {
            foreach (NPC car in npcs[n]) {
                car.StopNPC();
            }
        }
        public void Move(int n) {
            foreach (NPC car in npcs[n]) {
                car.MoveNPC();
            }
        }
    }

}
