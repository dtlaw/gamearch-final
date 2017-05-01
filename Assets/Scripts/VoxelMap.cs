using UnityEngine;

public class VoxelMap : MonoBehaviour {

	// Public variables
	private int[, ,] _map = new int[, ,] {
		{{ 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }},
		{{ 1, 1, 1, 1, 0 }, { 1, 1, 1, 1, 0 }, { 1, 1, 1, 1, 0 }},
		{{ 1, 1, 1, 1, 1 }, { 0, 0, 1, 1, 1 }, { 0, 0, 1, 1, 1 }},
		{{ 1, 1, 1, 1, 0 }, { 1, 1, 1, 1, 0 }, { 1, 1, 1, 1, 0 }},
		{{ 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }}
	};
	public int[, ,] Map {
		get { return _map; }
	}
}
