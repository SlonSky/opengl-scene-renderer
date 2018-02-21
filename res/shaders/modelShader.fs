#version 330 core

in vec3 Normal;
in vec2 TexCoords;
in vec3 FragPos;

out vec4 color;

struct DirLight {
	vec3 direction;

	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};

uniform DirLight light;
uniform vec3 viewPos;

uniform sampler2D texture_diffuse1;
uniform sampler2D texture_diffuse2;
uniform sampler2D texture_diffuse3;

uniform sampler2D texture_specular1;
uniform sampler2D texture_specular2;
uniform sampler2D texture_specular3;

void main()
{    

	vec3 lightDir = normalize(-light.direction);
	vec3 viewDir = normalize(viewPos - FragPos);

	float diff = max(dot(Normal, lightDir), 0.0);

	vec3 reflectDir = reflect(-lightDir, Normal);
	float spec = pow(max(dot(viewDir, reflectDir), 0.0), 64);

	vec3 resDiffTexture = (vec3(texture(texture_diffuse1, TexCoords)) + vec3(texture(texture_diffuse2, TexCoords)) + vec3(texture(texture_diffuse3, TexCoords)));
	vec3 resSpecTexture = (vec3(texture(texture_diffuse1, TexCoords)) + vec3(texture(texture_specular2, TexCoords)) + vec3(texture(texture_specular3, TexCoords)));
	
	vec3 ambient = light.ambient * resDiffTexture;
	vec3 diffuse = light.diffuse * diff * resDiffTexture;
	vec3 specular = light.specular * spec * resSpecTexture;

    color = vec4((ambient + diffuse ), 1.0);
}