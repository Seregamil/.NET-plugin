
#include "header.h"

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