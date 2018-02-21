#pragma once

#include <vector>
#include <string>
#include <sstream>
#include <iostream>

#include <GL/glew.h>

#include <SOIL.h>

#include <assimp/Importer.hpp>
#include <assimp/scene.h>
#include <assimp/postprocess.h>

#include "Shader.h"
#include "Mesh.h"

using namespace std;

GLint TextureFromFile(const char* path, string directory);
class Model
{
public:
	Model(GLchar* path);
	void Draw(Shader shader);
private:
	vector<Texture> textures_loaded;
	vector<Mesh> meshes;
	string directory;

	void loadModel(string path);
	void processNode(aiNode* node, const aiScene* scene);
	Mesh processMesh(aiMesh* mesh, const aiScene* scene);
	vector<Texture> loadMaterialTextures(aiMaterial* mat, aiTextureType type, string typeName);
};

