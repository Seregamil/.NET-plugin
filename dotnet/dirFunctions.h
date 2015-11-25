
/*cell AMX_NATIVE_CALL __directory_create(AMX* amx, cell* params){
	fileManagerPtr pICalc(__uuidof(ManagedClass));
	
	int len = 0;
	cell *addr	= 0;
	VARIANT_BOOL lResult = false;

	amx_GetAddr(amx, params[1], &addr); 
	amx_StrLen(addr, &len);

	char* text = new char[ ++len ];
	amx_GetString(text, addr, 0, len);

	pICalc->directoryCreate(bstr_t(text), &lResult);
	return lResult;
}
cell AMX_NATIVE_CALL __directory_exist(AMX* amx, cell* params){
	fileManagerPtr pICalc(__uuidof(ManagedClass));
	int len = 0;
	cell *addr	= 0;
	VARIANT_BOOL lResult = false;

	amx_GetAddr(amx, params[1], &addr); 
	amx_StrLen(addr, &len);

	char* text = new char[ ++len ];
	amx_GetString(text, addr, 0, len);

	pICalc->directoryCreate(bstr_t(text), &lResult);
	return lResult;
}
cell AMX_NATIVE_CALL __directory_remove(AMX* amx, cell* params){
	fileManagerPtr pICalc(__uuidof(ManagedClass));
	int len = 0;
	cell *addr	= 0;
	VARIANT_BOOL lResult = false;

	amx_GetAddr(amx, params[1], &addr); 
	amx_StrLen(addr, &len);

	char* text = new char[ ++len ];
	amx_GetString(text, addr, 0, len);

	pICalc->removeDirectory(bstr_t(text), &lResult);
	return lResult;
}
cell AMX_NATIVE_CALL __directory_rename(AMX* amx, cell* params){
	fileManagerPtr pICalc(__uuidof(ManagedClass));
	int len = 0;
	cell *addr	= 0;
	VARIANT_BOOL lResult = false;

	amx_GetAddr(amx, params[1], &addr); 
	amx_StrLen(addr, &len);

	char* text = new char[ ++len ];
	amx_GetString(text, addr, 0, len);

	amx_GetAddr(amx, params[2], &addr); 
	amx_StrLen(addr, &len);

	char* text1 = new char[ ++len ];
	amx_GetString(text1, addr, 0, len);

	pICalc->renameDirectory( bstr_t(text), bstr_t(text1), &lResult );
	return lResult;
}*/