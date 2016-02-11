#include <a_samp>

// (c) Fro1sha: http://forum.sa-mp.com/showthread.php?t=247893

#define regex_match(%0,%1) callDotnetMethod("regex.Match", "ss", %0, %1)
#define regex_is_match(%0,%1) callDotnetMethod("regex.IsMatch", "ss", %0, %1)
#define regex_replace(%0,%1,%2) callDotnetMethodStr("regex.Replace", %0, sizeof(%0), "sss", %0, %1, %2)

#define REGULAR_IP_ADDRESS "(([2]([0-4][0-9]|[5][0-5])|[0-1]?[0-9]?[0-9])[.]){3}(([2]([0-4][0-9]|[5][0-5])|[0-1]?[0-9]?[0-9]))"

//

native callDotnetMethod(methodName[], split[], {Float,_}:...);
native callDotnetMethodStr(methodName[], str[], len, split[], {Float,_}:...);

main(){
	print( "\nUsing Regular expressions!\n" );
    new str[ 123 ];
    format( str,sizeof str, "localhost: 127.0.0.1 (c) lol: 192.168.1.2" );
    printf( "Original line: %s", str );

    new regex_match_exist = regex_is_match( str, REGULAR_IP_ADDRESS );
    if(regex_match_exist) {
		new regex_index = regex_match( str, REGULAR_IP_ADDRESS );
		printf( "Index: %i", regex_index );
        regex_replace( str, "***.***.***.***", REGULAR_IP_ADDRESS );
		printf( "Result: %s", str );
    } else {
        print("Match not found");
    }
}



