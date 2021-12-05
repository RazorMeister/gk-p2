//Includes for IntelliSense 
#define _SIZE_T_DEFINED
#ifndef __CUDACC__
#define __CUDACC__
#endif
#ifndef __cplusplus
#define __cplusplus
#endif

#include <cuda.h>
#include <stdio.h>
#include <device_launch_parameters.h>
#include <texture_fetch_functions.h>
#include "float.h"
#include <builtin_types.h>
#include <vector_functions.h>


extern "C" {
	__device__
    inline float getDotProduct(float3 a, float3 b)
	{
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}
	
	__device__ 
	float3 getNormalizedVec(const float3 v)
	{
		float invLen = 1.0f / sqrtf(getDotProduct(v, v));
		return make_float3(v.x * invLen, v.y * invLen, v.z * invLen);
	}

	__device__
	float3 operator*(const float3 &a, const float &b) {
		return make_float3(a.x * b, a.y * b, a.z * b);
	}
	
	__device__
	float3 operator-(const float3 &a, const float3 &b) {
		return make_float3(a.x-b.x, a.y-b.y, a.z-b.y);
	}

	
	struct Test {
		float X;
		float Y;
		float Z;
	};
	
	struct PointStruct {
		float X;
		float Y;
		float Z;
	};
	
	struct ColorStruct {
		int R;
		int G;
		int B;
	};
	
	struct PixelStruct {
		ColorStruct color;
		float Z;
		PointStruct point;
	};

	__device__
	int rgbToInt(int r, int g, int b) {
		return 0x00000000 | r << 16 | g << 8 | b | 255 << 24;
	}

	// Device code
	__global__ void VecAdd(
		struct PixelStruct* pixels,
		
		struct ColorStruct lightColor, 
		struct PointStruct lightV, 
		
		float kD,
		float kS,
		int m,
		
		int n, 
		int *result
	) {
		int index = blockDim.x * blockIdx.x + threadIdx.x;
	
		if (index >= n) return;
	
		int y = index / 500;
		int x = index - y * 500;
		
		struct PixelStruct pix = pixels[index];
	
		if (pix.Z == 0) {
			result[index] = rgbToInt(127, 127, 255);
			return;
		}
	
		float3 L = getNormalizedVec(make_float3(lightV.X - (float)x, lightV.Y - (float)y, lightV.Z - pix.Z));
		float3 N = getNormalizedVec(make_float3(pix.point.X, pix.point.Y, pix.point.Z));

		float nCosL = getDotProduct(N, L);
		float3 R = getNormalizedVec(N * (2.0f * nCosL) - L);
		float vCosR = R.z;
		
		float first = kD * max(.0f, nCosL);
		float second = kS * pow(vCosR, (float)m);
		
		int r, g, b;
		
		// Red
		float iLiOR = ((float)lightColor.R / 255.0f) * (float)pix.color.R;
		int colorR = (int)(first * iLiOR + second * iLiOR);
		r = max(0, min(255, colorR));
		
		// Green
		float iLiOG = ((float)lightColor.G / 255.0f) * (float)pix.color.G;
		int colorG = (int)(first * iLiOG + second * iLiOG);
		g = max(0, min(255, colorG));
		
		// Blue
		float iLiOB = ((float)lightColor.B / 255.0f) * (float)pix.color.B;
		int colorB = (int)(first * iLiOB + second * iLiOB);
		b = max(0, min(255, colorB));
		
		result[index] = rgbToInt(r, g, b);
	}
	
}

int main() { 
	return 0; 
}