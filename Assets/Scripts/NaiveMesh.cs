using UnityEngine;
using System.Collections.Generic;

[ RequireComponent( typeof( VoxelMap ), typeof( MeshFilter ))]
public class NaiveMesh : MonoBehaviour {

	// Private variables
	private List< Vector3 > _verts;
	private List< Vector2 > _uv;
	private List< int > _tris;


	// Messages
	public Mesh Generate() {
		int[, ,] map = GetComponent< VoxelMap >().Map;

		// Generate mesh
		Mesh mesh = new Mesh();
		_verts = new List< Vector3 >();
		_uv = new List< Vector2 >();
		_tris = new List< int >();

		int i = 0;
		for ( int x = 0; x < map.GetLength( 0 ); ++x ) {
			for ( int y = 0; y < map.GetLength( 1 ); ++y ) {
				for ( int z = 0; z < map.GetLength( 2 ); ++z ) {
					if ( map[ x, y, z ] == 1 ) {

						// Front
						_verts.Add( new Vector3( x, y, z ));
						_verts.Add( new Vector3( x + 1, y, z ));
						_verts.Add( new Vector3( x + 1, y + 1, z ));
						_verts.Add( new Vector3( x, y + 1, z ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 0 + i ); _tris.Add( 2 + i ); _tris.Add( 1 + i );
						_tris.Add( 0 + i ); _tris.Add( 3 + i ); _tris.Add( 2 + i );

						// Top
						_verts.Add( new Vector3( x, y + 1, z ));
						_verts.Add( new Vector3( x + 1, y + 1, z ));
						_verts.Add( new Vector3( x + 1, y + 1, z + 1 ));
						_verts.Add( new Vector3( x, y + 1, z + 1 ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 4 + i ); _tris.Add( 6 + i ); _tris.Add( 5 + i );
						_tris.Add( 4 + i ); _tris.Add( 7 + i ); _tris.Add( 6 + i );

						// Back
						_verts.Add( new Vector3( x + 1, y, z + 1 ));
						_verts.Add( new Vector3( x, y, z + 1 ));
						_verts.Add( new Vector3( x, y + 1, z + 1 ));
						_verts.Add( new Vector3( x + 1, y + 1, z + 1 ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 8 + i ); _tris.Add( 10 + i ); _tris.Add( 9 + i );
						_tris.Add( 8 + i ); _tris.Add( 11 + i ); _tris.Add( 10 + i );

						// Bottom
						_verts.Add( new Vector3( x, y, z + 1 ));
						_verts.Add( new Vector3( x + 1, y, z + 1 ));
						_verts.Add( new Vector3( x + 1, y, z ));
						_verts.Add( new Vector3( x, y, z ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 12 + i ); _tris.Add( 14 + i ); _tris.Add( 13 + i );
						_tris.Add( 12 + i ); _tris.Add( 15 + i ); _tris.Add( 14 + i );

						// Left
						_verts.Add( new Vector3( x, y, z + 1 ));
						_verts.Add( new Vector3( x, y, z ));
						_verts.Add( new Vector3( x, y + 1, z ));
						_verts.Add( new Vector3( x, y + 1, z + 1 ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 16 + i ); _tris.Add( 18 + i ); _tris.Add( 17 + i );
						_tris.Add( 16 + i ); _tris.Add( 19 + i ); _tris.Add( 18 + i );

						// Right
						_verts.Add( new Vector3( x + 1, y, z ));
						_verts.Add( new Vector3( x + 1, y, z + 1 ));
						_verts.Add( new Vector3( x + 1, y + 1, z + 1 ));
						_verts.Add( new Vector3( x + 1, y + 1, z ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 20 + i ); _tris.Add( 22 + i ); _tris.Add( 21 + i );
						_tris.Add( 20 + i ); _tris.Add( 23 + i ); _tris.Add( 22 + i );

						i += 24;
					}
				}
			}
		}

		mesh.vertices = _verts.ToArray();
		mesh.uv = _uv.ToArray();
		mesh.triangles = _tris.ToArray();

		return mesh;
	}
}
