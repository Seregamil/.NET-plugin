#include "..\SDK\amx\amx.h"
#include "..\SDK\plugincommon.h"

//#include <iostream>
//using namespace std;

#import "C:\Users\Seregamil\Desktop\SHA512\c_sharp\bin\Debug\c_sharp.tlb" raw_interfaces_only
using namespace c_sharp;

extern void *pAMXFunctions;

typedef void (*logprintf_t)(char* format, ...);
logprintf_t logprintf;


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
	logprintf = (logprintf_t) ppData[PLUGIN_DATA_LOGPRINTF];

	if( CoInitialize(NULL) == S_OK ) {
		pluginPtr pICalc(__uuidof(pluginClass));
		pICalc->Initializate();
	} else {
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
    return amx_Register(amx, PluginNatives, -1);
}


PLUGIN_EXPORT int PLUGIN_CALL AmxUnload( AMX *amx ) 
{
    return AMX_ERR_NONE;
}  

#define DllExport   __declspec( dllexport )

extern "C" __declspec(dllexport) void __stdcall logwrite( char message[] )
{
	logprintf(message);
}
/*
extern "C" __declspec(dllexport) void __stdcall callCallback( char callback[], ... )
{
	logprintf(message);
}
*/

/*
char *cbuf;
int i=10;
BSTR wBuf;
_itoa(i,cbuf,10);
wBuf=bstr_t(cbuf);

			char* text = new char[ len ];
			VARIANT_BOOL lResult = false;
			pICalc->fileCreate(bstr_t(text), &lResult);
			logprintf("result: %s", lResult ? "true" : "false");


			case 0: {
			int len = 0, ret = 0;
				cell *addr	= 0;
			amx_GetAddr(amx, params[2], &addr); 
			amx_StrLen(addr, &len);

			if(!len)
				return 1;

			len++;
			char* text = new char[ len ];
			amx_GetString(text, addr, 0, len);

			VARIANT_BOOL lResult = false;

			pICalc->fileCreate(bstr_t(text), &lResult);

			int idx;
			if( lResult ) {				
				if(!amx_FindPublic(amx, "OnFileCreated", &idx))
				{
					cell
						ret, 
						addr;

					amx_PushString(amx, &addr, NULL, text, NULL, NULL);

					amx_Exec(amx, &ret, idx);
					amx_Release(amx, addr);
				}
			} else {
				if(!amx_FindPublic(amx, "OnFileFailCreation", &idx)) {
					cell
						ret, 
						addr;

					amx_PushString(amx, &addr, NULL, text, NULL, NULL);

					amx_Exec(amx, &ret, idx);
					amx_Release(amx, addr);
				}
			}
			delete[] text;
		}
*/