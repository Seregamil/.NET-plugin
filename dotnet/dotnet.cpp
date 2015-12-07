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

PLUGIN_EXPORT unsigned int PLUGIN_CALL Supports() 
{
	return SUPPORTS_VERSION | SUPPORTS_AMX_NATIVES | SUPPORTS_PROCESS_TICK;
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

extern "C" __declspec(dllexport) void __stdcall __callRemoteCallback(const char* callback, const char** strArray, int length) {
	int index;
	if (!amx_FindPublic(amxMachine, callback, &index)) {	        
		
		int tempLen = length;
		cell addr;

		while( --tempLen != -1 ) {
			string arg( strArray[tempLen] ) ; // save string
			char key = arg[0]; // get first char

			arg.erase(0, 1); // delete first char
			switch (key) {
				case 'i': amx_Push(amxMachine, atoi(arg.c_str())); break;// push int32
				case 's': amx_PushString(amxMachine, &addr, NULL, arg.c_str(), NULL, NULL); break; // push string
				case 'b': amx_Push(amxMachine, arg.compare("false") ? 0 : 1); break; // push boolean
				case 'c': amx_Push(amxMachine, key); break; // push
				case 'f': {
					float f = std::stof(arg.c_str());
					amx_Push(amxMachine, amx_ftoc(f)); // push float*
					break;
				}
			}
		}
		amx_Exec(amxMachine, NULL, index); 
	}
}

cell* get_amxaddr(AMX *amx,cell amx_addr)
{
	return (cell *)(amx->base + (int)(((AMX_HEADER *)amx->base)->dat + amx_addr));
}

cell AMX_NATIVE_CALL __callDotnetMethod(AMX* amx, cell* params){
	long methodID = params[ 1 ] ;
	
	char* format;
	amx_StrParam(amx, params[ 2 ], format);

	int length = strlen(format);

	string data;

	for( int j = 0 ; j != length ; j ++ ) {
		char key = format[ j ] ;
		switch(key){
				case 'i': { 
							int i = *get_amxaddr(amx, params[j + 3]);
							data = data + "i" + to_string(i);
							break;
						  }
				case 's': {
							char* s ;
							amx_StrParam(amx, params[j + 3], s);
							data = data + "s" + s;
							break;
						  }
				case 'c': {
							char* c = new char[ 1 ] ;
							cell *addr	= NULL;

							amx_GetAddr(amx, params[j + 3], &addr); 
							amx_GetString(c, addr, 0, 2);

							data = data + "c" + c;
							break;
						  }
				case 'f': { 
							float f = amx_ctof(*get_amxaddr(amx, params[j + 3]));
							data = data + "f" + to_string(f);
							break;
						  }	
		}

		if( j != length - 1 )
			data = data + "\n" ;
	}

	VARIANT_BOOL lResult ;
	
	pluginPtr pICalc(__uuidof(pluginClass));
	pICalc->callDotnetMethod(methodID, bstr_t(data.c_str()), &lResult);
	
	return 1;
}

AMX_NATIVE_INFO PluginNatives[] =
{
	{"callDotnetMethod", __callDotnetMethod},
	//{"HelloWorld", HelloWorld},
    {0, 0}
};

PLUGIN_EXPORT int PLUGIN_CALL AmxLoad( AMX *amx ) 
{
	amxMachine = amx ;

	int reg = amx_Register(amx, PluginNatives, -1);

	pluginPtr pICalc(__uuidof(pluginClass));
	VARIANT_BOOL result = false;
	pICalc->Initializate(&result);

	if( !result ){
		logprintf("dotnet: error with initializating library");
	} else {
		logprintf("dotnet: library was loaded.");
	}

    return reg;
}


PLUGIN_EXPORT int PLUGIN_CALL AmxUnload( AMX *amx ) 
{
    return AMX_ERR_NONE;
}  

extern "C" __declspec(dllexport) void __stdcall logwrite( char message[] )
{
	logprintf(message);
}

PLUGIN_EXPORT void PLUGIN_CALL ProcessTick()
{

}