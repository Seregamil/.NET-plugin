/*

	.NET Plugin -> Regular expression's
	
	regex.Match( source[], pattern[] )
	regex.Replace( var[], sizeof var, ..., source[], pattern[], replacement[] );

*/
#include <a_samp>

native callDotnetMethod(methodName[], split[], {Float,_}:...);
native callDotnetMethodStr(methodName[], str[], len, split[], {Float,_}:...);

main(){

}

public OnGameModeInit() {
	printf("%d", callDotnetMethod("regex.Match", "ss", "Seregamil", "m" ));
	new original[] = "dotNOT regex test";
	new result[ 128 ] ;
	callDotnetMethodStr("regex.Replace", result, sizeof result, "sss", original, "N.T", "NET");
	printf("Original: %s | Result: %s", original, result);
	return true ;
}
