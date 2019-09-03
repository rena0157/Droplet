// SwmmInterop.c
// By: Adam Renaud
// Created: 2019-08-10

#include "../Swmm5Src/headers.h"
#include "../Swmm5Src/swmm5.h"
#include "SwmmInterop.h"
#include <stdlib.h>

TSwmmInstance DLLEXPORT swmm_export_test(char* filename)
{
	swmm_open(filename, "nothing.rpt", "nothing.dat");
	TSwmmInstance i;
	i.FlowUnits = CFS;
	swmm_close();
	return i;
}
