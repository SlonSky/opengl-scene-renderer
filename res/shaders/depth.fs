#version 330 core
in vec2 TexCoords;

out vec4 color;

uniform sampler2D texture1;

float near = 1.0;
float far = 100.0;

float linearizeDepth(float depth)
{
	float z = depth * 2.0 - 1.0;
	return (2.0 * near * far) / (far + near - z * (far - near));
}

void main()
{             
    color = texture(texture1, TexCoords);
//   float depth = linearizeDepth(gl_FragCoord.z) / far;
  // color = vec4(vec3(depth), 1.0);
}