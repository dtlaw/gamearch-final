using UnityEngine;
using System.Collections.Generic;

public class GreedyMesh : MonoBehaviour {

	// Private variables
	private List< Vector3 > _verts;
	private List< Vector2 > _uv;
	private List< int > _tris;


	// Public interface
	public Mesh Generate() {

		// XXX: Clone the map because this method modifies it
		int[, ,] map = ( int[, ,] )GetComponent< VoxelMap >().Map.Clone();

		// Generate mesh by creading quads for each 2D slice
		Mesh mesh = new Mesh();
		_verts = new List< Vector3 >();
		_uv = new List< Vector2 >();
		_tris = new List< int >();

		int id = 0;
		for ( int z = 0; z < map.GetLength( 2 ); ++z ) {
			for ( int y = 0; y < map.GetLength( 1 ); ++y ) {
				for ( int x = 0; x < map.GetLength( 0 ); ++x ) {
					if ( map[ x, y, z ] == 1 ) {

						// Find as wide a quad as possible
						int width1 = 0;
						int height1 = map.GetLength( 1 ) - y;
						for ( int i = x; i < map.GetLength( 0 ); ++i ) {
							if ( map[ i, y, z ] == 1 ) {
								for ( int j = y; j < height1 + y; ++j ) {
									if ( map[ i, j, z ] != 1 ) {
										height1 = j - y;
										break;
									}
								}
								++width1;
							} else {
								break;
							}
						}

						// Find as tall a quad as possible
						// XXX: Finds basically the same thing?
						int height2 = 0;
						int width2 = map.GetLength( 0 ) - x;
						for ( int i = y; i < map.GetLength( 1 ); ++i ) {
							if ( map[ x, i, z ] == 1 ) {
								for ( int j = x; j < width2 + x; ++j ) {
									if ( map[ j, i, z ] != 1 ) {
										width2 = j - x;
										break;
									}
								}
								++height2;
							} else {
								break;
							}
						}

						// Compare the two quads
						int width = 0;
						int height = 0;
						if ( CompareQuads( width1, height1, width2, height2 )) {
							width = width1;
							height = height1;
						} else {
							width = width2;
							height = height2;
						}

						// Create the new quad
						// Front
						_verts.Add( new Vector3( x, y, z ));
						_verts.Add( new Vector3( x + width, y, z ));
						_verts.Add( new Vector3( x + width, y + height, z ));
						_verts.Add( new Vector3( x, y + height, z ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 0 + id ); _tris.Add( 2 + id ); _tris.Add( 1 + id );
						_tris.Add( 0 + id ); _tris.Add( 3 + id ); _tris.Add( 2 + id );

						// Top
						_verts.Add( new Vector3( x, y + height, z ));
						_verts.Add( new Vector3( x + width, y + height, z ));
						_verts.Add( new Vector3( x + width, y + height, z + 1 ));
						_verts.Add( new Vector3( x, y + height, z + 1 ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 4 + id ); _tris.Add( 6 + id ); _tris.Add( 5 + id );
						_tris.Add( 4 + id ); _tris.Add( 7 + id ); _tris.Add( 6 + id );

						// Back
						_verts.Add( new Vector3( x + width, y, z + 1 ));
						_verts.Add( new Vector3( x, y, z + 1 ));
						_verts.Add( new Vector3( x, y + height, z + 1 ));
						_verts.Add( new Vector3( x + width, y + height, z + 1 ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 8 + id ); _tris.Add( 10 + id ); _tris.Add( 9 + id );
						_tris.Add( 8 + id ); _tris.Add( 11 + id ); _tris.Add( 10 + id );

						// Bottom
						_verts.Add( new Vector3( x, y, z + 1 ));
						_verts.Add( new Vector3( x + width, y, z + 1 ));
						_verts.Add( new Vector3( x + width, y, z ));
						_verts.Add( new Vector3( x, y, z ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 12 + id ); _tris.Add( 14 + id ); _tris.Add( 13 + id );
						_tris.Add( 12 + id ); _tris.Add( 15 + id ); _tris.Add( 14 + id );

						// Left
						_verts.Add( new Vector3( x, y, z + 1 ));
						_verts.Add( new Vector3( x, y, z ));
						_verts.Add( new Vector3( x, y + height, z ));
						_verts.Add( new Vector3( x, y + height, z + 1 ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 16 + id ); _tris.Add( 18 + id ); _tris.Add( 17 + id );
						_tris.Add( 16 + id ); _tris.Add( 19 + id ); _tris.Add( 18 + id );

						// Right
						_verts.Add( new Vector3( x + width, y, z ));
						_verts.Add( new Vector3( x + width, y, z + 1 ));
						_verts.Add( new Vector3( x + width, y + height, z + 1 ));
						_verts.Add( new Vector3( x + width, y + height, z ));
						_uv.Add( new Vector2( 0, 1 ));
						_uv.Add( new Vector2( 1, 1 ));
						_uv.Add( new Vector2( 1, 0 ));
						_uv.Add( new Vector2( 0, 0 ));
						_tris.Add( 20 + id ); _tris.Add( 22 + id ); _tris.Add( 21 + id );
						_tris.Add( 20 + id ); _tris.Add( 23 + id ); _tris.Add( 22 + id );

						id += 24;

						// Flag the voxels of the new quad as used
						for ( int i = x; i < width + x; ++i ) {
							for ( int j = y; j < height + y; ++j ) {
								map[ i, j, z ] = -1;
							}
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


	// Private interface

	// Returns true if quad1 is first in the lexical order
	private bool CompareQuads( int width1, int height1, int width2, int height2 ) {
		if ( width1 != width2 ) {
			return width1 > width2;
		} else {
			return height1 >= height2;
		}
	}
}
