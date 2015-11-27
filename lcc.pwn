#include <a_samp>
#include jit

main(){

}

forward onDotnetLoaded( val1, val2, Float: val3, bool: val4, Float: val5, val6[] );
public onDotnetLoaded( val1, val2, Float: val3, bool: val4, Float: val5, val6[] ) {
	printf("onDotnetLoaded( %i, %i, %f, %b, %f, %s )", val1, val2, val3, val4, val5, val6 );
}

forward dotnet_test( val, var, var1 );
public dotnet_test( val, var, var1) {
	printf("dotnet_test(%i, %i, %i)",val, var, var1);
}

forward pabota(str[]);
public pabota(str[])
	printf("pabota: %s", str);

public OnPlayerConnect( playerid ){
	printf("OnPlayerCOnnectCalled; %i", playerid);
	return true;
}
