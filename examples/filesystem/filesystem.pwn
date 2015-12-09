#include <a_samp>

native callDotnetMethod(methodID, split[], {Float,_}:...);

enum c_sharp {
	createFile,
	deleteFile,
	renameFile,
	existFile,
	
	createDir,
	deleteDir,
	renameDir,
	existDir
};

main(){
	if(!callDotnetMethod(existFile, "s", "scriptfiles/c_sharp.ini")) {
	    callDotnetMethod(createFile, "s", "scriptfiles/c_sharp.ini");
	} else {
	    callDotnetMethod(renameFile, "ss", "scriptfiles/c_sharp.ini", "scriptfiles/c_sharp.dump.ini") ;
	    if( !callDotnetMethod(existDir, "s", "scriptfiles/c_sharp/") ) {
            callDotnetMethod(createDir, "s", "scriptfiles/c_sharp/") ;
	    }
	}
}
