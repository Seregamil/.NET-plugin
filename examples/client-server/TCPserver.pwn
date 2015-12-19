/*

	C# TCP server

*/

#include <a_samp>

native callDotnetMethod(methodName[], split[], {Float,_}:...);

forward onSocketReceiveData(remote_clientid, data[]); // called when a remote client sends data
forward onSocketRemoteConnect(remote_clientid); // called when a remote client connects to our socket server
forward onSocketRemoteDisconnect(remote_clientid); // called when a remote client disconnects from our socket server

main()
{
    callDotnetMethod("createSocketServer", "ii", MAX_PLAYERS, 11000);
}

public onSocketRemoteConnect(remote_clientid) {
	printf( "onSocketRemoteConnect(%i)", remote_clientid );
	callDotnetMethod(sendData, "is", remote_clientid, "Hello! SA-MP Server. by Seregamil" );
	return true ;
}

public onSocketRemoteDisconnect(remote_clientid) {
    printf( "onSocketRemoteDisconnect(%i)", remote_clientid );
	return true ;
}

public onSocketReceiveData(remote_clientid, data[]) {
    printf( "onSocketReceiveData(%i, %s)", remote_clientid, data );
	return true ;
}
