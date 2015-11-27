#include "..\SDK\amx\amx.h"
#include "..\SDK\plugincommon.h"
#include <stdio.h> 
#include <iostream>
#include <string>

#import "C:\Users\Seregamil\Desktop\SHA512\c_sharp\bin\Debug\c_sharp.tlb" raw_interfaces_only
using namespace c_sharp;
using namespace std;

extern void *pAMXFunctions;

typedef void (*logprintf_t)(char* format, ...);
logprintf_t logprintf;

AMX *amxMachine;

#include "natives.h"
#include "c_sharp.h"

PLUGIN_EXPORT unsigned int PLUGIN_CALL Supports() 
{
    return SUPPORTS_VERSION | SUPPORTS_AMX_NATIVES;
}

PLUGIN_EXPORT bool PLUGIN_CALL Load(void **ppData) 
{
    pAMXFunctions = ppData[PLUGIN_DATA_AMX_EXPORTS];
	logprintf = (logprintf_t) ppData[PLUGIN_DATA_LOGPRINTF];

	if( CoInitialize(NULL) != S_OK ) {
		logprintf("\n\n\n\t\tInitialization error \"COM\" assembly");
	}
    return true;
}

PLUGIN_EXPORT void PLUGIN_CALL Unload()
{
	CoUninitialize();
    logprintf("DotNet plugin was unloaded");
}

PLUGIN_EXPORT int PLUGIN_CALL AmxLoad( AMX *amx ) 
{
	amxMachine = amx ;

	pluginPtr pICalc(__uuidof(pluginClass));
	pICalc->Initializate();

    return amx_Register(amx, PluginNatives, -1);
}


PLUGIN_EXPORT int PLUGIN_CALL AmxUnload( AMX *amx ) 
{
    return AMX_ERR_NONE;
}  

extern "C" __declspec(dllexport) void __stdcall logwrite( char message[] )
{
	logprintf(message);
}

/*
DUMP:
int index;
		int tempLen = length;

		while( --tempLen != -1 ) {
			string arg( strArray[tempLen] ) ; // save string
			char key = arg[0]; // get first char

			arg.erase(0, 1);
			printf("Callback %s; Arg: %s, key: %c\n", callback, arg.c_str(), key);
		}*/