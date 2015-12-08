/*
	C# API
	
	C# plugin functions:
	
	    server.callRemoteCallback("callback name", object[] args) --> call callback on a server
	    server.logwrite(text[]) == !printf!
	    server.loadConfiguration(server.cfg) =)

	Samp server functions:
	    callDotnetMethod( methodID, format, params... )
	    
*/
#include <a_samp>

native callDotnetMethod(methodID, split[], {Float,_}:...);

enum c_sharp {
	onDotnetLoaded,
	onPlayerConnect,
	onPlayerDisconnect
};

main(){

}

public OnGameModeInit() {
    callDotnetMethod( onDotnetLoaded, "s", "hi");
	return true ;
}

public OnPlayerConnect( playerid ) {
    callDotnetMethod( onPlayerConnect, "i", playerid );
	return true ;
}

public OnPlayerDisconnect( playerid, reason ) {
    callDotnetMethod( onPlayerDisconnect, "ii", playerid, reason );
	return true ;
}
