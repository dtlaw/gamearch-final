using UnityEngine;

[ RequireComponent( typeof( MeshFilter ), typeof( NaiveMesh ), typeof( CullingMesh ))]
public class MeshSwitcher : MonoBehaviour {

	// Private variables
	private MeshFilter _meshFilter;
	private NaiveMesh _naiveMesh;
	private CullingMesh _cullingMesh;


	// Messages
	private void Awake() {
		_meshFilter = GetComponent< MeshFilter >();
		_naiveMesh = GetComponent< NaiveMesh >();
		_cullingMesh = GetComponent< CullingMesh >();
	}
	
	private void Update() {
		if ( Input.GetKeyDown( "1" )) {
			_meshFilter.mesh = _naiveMesh.Generate();
		} else if ( Input.GetKeyDown( "2" )) {
			_meshFilter.mesh = _cullingMesh.Generate();
		} else if ( Input.GetKeyDown( "3" )) {

			// TODO: Greedy mesh
		}
	}
}
