#include "..\SDK\amx\amx.h"
#include "..\SDK\plugincommon.h"

#include <iostream>
using namespace std;

#import "C:\Users\Seregamil\Desktop\SHA512\c_sharp\bin\Debug\c_sharp.tlb" raw_interfaces_only
using namespace c_sharp;

extern void *pAMXFunctions;

#include "fileFunctions.h"
#include "dirFunctions.h"

#include "natives.h"

PLUGIN_EXPORT unsigned int PLUGIN_CALL Supports() 
{
    return SUPPORTS_VERSION | SUPPORTS_AMX_NATIVES;
}

PLUGIN_EXPORT bool PLUGIN_CALL Load(void **ppData) 
{
    pAMXFunctions = ppData[PLUGIN_DATA_AMX_EXPORTS];

	if( CoInitialize(NULL) == S_OK ) {
		cout << "\n\ndotNet plugin was loaded. \nv0.1\n\tby Seregamil\n\n" << endl;
	} else {
		cout << "\n\n\n\t\tInitialization error \"COM\" assembly" << endl;
	}
    return true;
}

PLUGIN_EXPORT void PLUGIN_CALL Unload()
{
	CoUninitialize();
    cout << "DotNet plugin was unloaded" << endl;
}

PLUGIN_EXPORT int PLUGIN_CALL AmxLoad( AMX *amx ) 
{
    return amx_Register(amx, PluginNatives, -1);
}


PLUGIN_EXPORT int PLUGIN_CALL AmxUnload( AMX *amx ) 
{
    return AMX_ERR_NONE;
}  

