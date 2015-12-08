/*

	C# TCP server

*/

#include <a_samp>

native callDotnetMethod(methodID, split[], {Float,_}:...);

forward onSocketReceiveData(remote_clientid, data[]); // called when a remote client sends data
forward onSocketRemoteConnect(remote_clientid); // called when a remote client connects to our socket server
forward onSocketRemoteDisconnect(remote_clientid); // called when a remote client disconnects from our socket server

enum c_sharp {
	createSocketServer,
	sendData
};

main()
{
    callDotnetMethod(createSocketServer, "ii", MAX_PLAYERS, 11000);
}

public onSocketRemoteConnect(remote_clientid) {
	printf( "onSocketRemoteConnect(%i)", remote_clientid );
	callDotnetMethod(sendData, "is", remote_clientid, "Hello! SA-MP Server. by Seregamil" );
	return true ;
}

public onSocketRemoteDisconnect(remote_clientid) {
    printf( "onSocketRemoteDisconnect(%i)", remote_clientid );
    callDotnetMethod(sendData, "is", remote_clientid, "Hello! SA-MP Se42322rver. by Seregamil" );
	return true ;
}

public onSocketReceiveData(remote_clientid, data[]) {
    printf( "onSocketReceiveData(%i, %s)", remote_clientid, data );
    callDotnetMethod(sendData, "is", remote_clientid, data );
	return true ;
}
