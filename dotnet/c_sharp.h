extern "C" __declspec(dllexport) void __stdcall callPublic(const char* callback, const char** strArray, int length) {
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