/*
	.NET Plugin
		by Seregamil
		
	C# <- CLR/OLE -> pawn
	    
	.NET
	        cpp.logwrite( test[] ) -- ������� ����� � �������
	        cpp.callRemoveCallback( callback[], params object[] args ) -- �������� ������� �� ������� � �����������
	        
	PAWN
	    	callDotnetMethod -- �������� ����� � �������
	    	    ������������ ��������:
	    	        i - int32
	    	        b - boolean = int(0/1)
	    	        f - float
						������ ������������ �������� ��� ���������.
						    ������:
						        new temp = call... -- return int
						        temp = call... -- return bool
								temp = call... -- return float

			callDotnetMethodStr -- ��� �� �������� ����� � �������.
			    ������� �� ���������� ������� - ���������� ������ ������� � ���������� ��������� � ��������� ����������
			        ������:
			            new string[ 128 ] ;
			            new call...( methodID, string, sizeof string, ...

						����� ����� ������� � ���������� string
						
*/
#include <a_samp>

native callDotnetMethod(methodName[], split[], {Float,_}:...);
native callDotnetMethodStr(methodName[], str[], len, split[], {Float,_}:...);

/*enum c_sharp {
	onDotnetLoaded,
	testINT,
	testBOOL,
	testSTRING,
	testFLOAT
};*/

main(){

}

public OnGameModeInit() {
    callDotnetMethod("onDotnetLoaded", "cf", 'v', 1.0);

    new temp_int = callDotnetMethod("testINT", "ii", 10, 24);
    printf("testINT returned: %i", temp_int);
    
    new temp_bool = callDotnetMethod("testBOOL", "isi", 1, "boolean=)", 0);
    printf("testBOOL returned: %i", temp_bool);
    
    new temp_float = callDotnetMethod("testFLOAT", "ifcf", 10, 1.432, 'c', 242);
    printf("testFLOAT returned: %f", temp_float);
    
    new temp_str[ 16 ] ;
	callDotnetMethodStr("testSTRING", temp_str, sizeof temp_str, "sss", "by", "Seregamil", "dotNET v1.0");
    printf("testSTRING returned: %s", temp_str);
	return true ;
}

forward onDotnetWasLoaded(str[]);
public onDotnetWasLoaded(str[]){
	print(str);
}
