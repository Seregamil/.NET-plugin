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

//static dotnetMethod[] METHOD_ID = {
//	onPlayerConnect, // 0
//	onPlayerDisconnect // 1 etc
//};

#define onPlayerConnect 0
#define onPlayerDisconnect 1

native callDotnetMethod(methodID, split[], {Float,_}:...);
