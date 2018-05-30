#include<stdio.h>

typedef int (Function)(int v1,int v2);

int Add(int v1,int v2)
{
	return (v1+v2)*100;
}

__declspec(dllexport) int Handler(char* str,Function* callback)
{
	printf("%s \r\n",str);
	return callback(12,22);
}