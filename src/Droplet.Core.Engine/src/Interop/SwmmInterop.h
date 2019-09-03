// SwmmInterop.h
// By: Adam Renaud
// Created: 2019-08-10

#ifndef SWMMINTEROP_H
#define SWMMINTEROP_H
#include "../Swmm5Src/swmm5.h"

typedef struct
{
	int		FlowUnits;
} TSwmmInstance;

TSwmmInstance DLLEXPORT swmm_export_test(char* filename);

#endif // !SWMMINTEROP_H
