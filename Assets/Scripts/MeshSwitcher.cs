using UnityEngine;
using UnityEngine.UI;

[ RequireComponent( typeof( MeshFilter ), typeof( NaiveMesh ), typeof( CullingMesh ))]
[ RequireComponent( typeof( GreedyMesh ))]
public class MeshSwitcher : MonoBehaviour {

	// Exposed variables
	[ SerializeField ]
	private Text _triDisplay;
	[ SerializeField ]
	private Text _vertDisplay;


	// Private variables
	private MeshFilter _meshFilter;
	private NaiveMesh _naiveMesh;
	private CullingMesh _cullingMesh;
	private GreedyMesh _greedyMesh;


	// Messages
	private void Awake() {
		_meshFilter = GetComponent< MeshFilter >();
		_naiveMesh = GetComponent< NaiveMesh >();
		_cullingMesh = GetComponent< CullingMesh >();
		_greedyMesh = GetComponent< GreedyMesh >();
	}
	
	private void Update() {
		if ( Input.GetKeyDown( "1" )) {
			_meshFilter.mesh = _naiveMesh.Generate();
			_triDisplay.text = "Tris: " + _meshFilter.mesh.triangles.Length;
			_vertDisplay.text = "Verts: " + _meshFilter.mesh.vertices.Length;
		} else if ( Input.GetKeyDown( "2" )) {
			_meshFilter.mesh = _cullingMesh.Generate();
		} else if ( Input.GetKeyDown( "3" )) {
			_meshFilter.mesh = _greedyMesh.Generate();
		}

		_triDisplay.text = "Tris: " + _meshFilter.mesh.triangles.Length;
		_vertDisplay.text = "Verts: " + _meshFilter.mesh.vertices.Length;
	}
}
