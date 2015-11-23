#include <a_samp>
#include jit

native fileCreate( path[] ) ;
native existFile( path[] ) ;
native removeFile( path[] );
native renameFile( old_path[], new_path[] );

native directoryCreate( path[] );
native existDirectory( path[] );
native removeDirectory( path[] );
native renameDirectory( old_path[], new_path[] );

main()
{
    //InitializateNET("dotnet.Net.dll");
    //CallMethod(createFile, "file.ini");
	if(!existDirectory("scriptfiles/dotnet/")) {
	    directoryCreate("scriptfiles/dotnet/");
	}
	new temp = fileCreate( "scriptfiles/dotnet/test.file" );
	printf("%s", (temp ? ("true") : ("false"))); // if file exist returl false
}
