using UnityEngine;
using System.Collections.Generic;

[ RequireComponent( typeof( VoxelMap ), typeof( MeshFilter ))]
public class CullingMesh : MonoBehaviour {

	// Private variables
	private List< Vector3 > _verts;
	private List< Vector2 > _uv;
	private List< int > _tris;


	// Public interface
	public Mesh Generate() {
		int[, ,] map = GetComponent< VoxelMap >().Map;

		// Generate mesh, skipping any obstructed faces
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
						if ( z > 0 && map[ x, y, z - 1 ] == 0 || z == 0 ) {
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

							i += 4;
						}

						// Top
						if ( y < map.GetLength( 1 ) - 1 && map[ x, y + 1, z ] == 0 || y == map.GetLength( 1 ) - 1 ) {
							_verts.Add( new Vector3( x, y + 1, z ));
							_verts.Add( new Vector3( x + 1, y + 1, z ));
							_verts.Add( new Vector3( x + 1, y + 1, z + 1 ));
							_verts.Add( new Vector3( x, y + 1, z + 1 ));
							_uv.Add( new Vector2( 0, 1 ));
							_uv.Add( new Vector2( 1, 1 ));
							_uv.Add( new Vector2( 1, 0 ));
							_uv.Add( new Vector2( 0, 0 ));
							_tris.Add( 0 + i ); _tris.Add( 2 + i ); _tris.Add( 1 + i );
							_tris.Add( 0 + i ); _tris.Add( 3 + i ); _tris.Add( 2 + i );

							i += 4;
						}

						// Back
						if ( z < map.GetLength( 2 ) - 1 && map[ x, y, z + 1 ] == 0 || z == map.GetLength( 2 ) - 1 ) {
							_verts.Add( new Vector3( x + 1, y, z + 1 ));
							_verts.Add( new Vector3( x, y, z + 1 ));
							_verts.Add( new Vector3( x, y + 1, z + 1 ));
							_verts.Add( new Vector3( x + 1, y + 1, z + 1 ));
							_uv.Add( new Vector2( 0, 1 ));
							_uv.Add( new Vector2( 1, 1 ));
							_uv.Add( new Vector2( 1, 0 ));
							_uv.Add( new Vector2( 0, 0 ));
							_tris.Add( 0 + i ); _tris.Add( 2 + i ); _tris.Add( 1 + i );
							_tris.Add( 0 + i ); _tris.Add( 3 + i ); _tris.Add( 2 + i );

							i += 4;
						}

						// Bottom
						if ( y > 0 && map[ x, y - 1, z ] == 0 || y == 0 ) {
							_verts.Add( new Vector3( x, y, z + 1 ));
							_verts.Add( new Vector3( x + 1, y, z + 1 ));
							_verts.Add( new Vector3( x + 1, y, z ));
							_verts.Add( new Vector3( x, y, z ));
							_uv.Add( new Vector2( 0, 1 ));
							_uv.Add( new Vector2( 1, 1 ));
							_uv.Add( new Vector2( 1, 0 ));
							_uv.Add( new Vector2( 0, 0 ));
							_tris.Add( 0 + i ); _tris.Add( 2 + i ); _tris.Add( 1 + i );
							_tris.Add( 0 + i ); _tris.Add( 3 + i ); _tris.Add( 2 + i );

							i += 4;
						}

						// Left
						if ( x > 0 && map[ x - 1, y, z ] == 0 || x == 0 ) {
							_verts.Add( new Vector3( x, y, z + 1 ));
							_verts.Add( new Vector3( x, y, z ));
							_verts.Add( new Vector3( x, y + 1, z ));
							_verts.Add( new Vector3( x, y + 1, z + 1 ));
							_uv.Add( new Vector2( 0, 1 ));
							_uv.Add( new Vector2( 1, 1 ));
							_uv.Add( new Vector2( 1, 0 ));
							_uv.Add( new Vector2( 0, 0 ));
							_tris.Add( 0 + i ); _tris.Add( 2 + i ); _tris.Add( 1 + i );
							_tris.Add( 0 + i ); _tris.Add( 3 + i ); _tris.Add( 2 + i );

							i += 4;
						}

						// Right
						if ( x < map.GetLength( 0 ) - 1 && map[ x + 1, y, z ] == 0 || x == map.GetLength( 0 ) - 1 ) {
							_verts.Add( new Vector3( x + 1, y, z ));
							_verts.Add( new Vector3( x + 1, y, z + 1 ));
							_verts.Add( new Vector3( x + 1, y + 1, z + 1 ));
							_verts.Add( new Vector3( x + 1, y + 1, z ));
							_uv.Add( new Vector2( 0, 1 ));
							_uv.Add( new Vector2( 1, 1 ));
							_uv.Add( new Vector2( 1, 0 ));
							_uv.Add( new Vector2( 0, 0 ));
							_tris.Add( 0 + i ); _tris.Add( 2 + i ); _tris.Add( 1 + i );
							_tris.Add( 0 + i ); _tris.Add( 3 + i ); _tris.Add( 2 + i );

							i += 4;
						}
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
