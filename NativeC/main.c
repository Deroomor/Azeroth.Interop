#include<stdio.h>

typedef int (Function)(int v1,int v2);

int Add(int v1,int v2)
{
	return (v1+v2)*100;
}

__declspec(dllexport) int Handler(int v1,int v2,Function* callback)
{
	return callback(v1,v2);
}