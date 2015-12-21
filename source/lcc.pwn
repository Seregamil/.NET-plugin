/*
	.NET Plugin
		by Seregamil

	C# <- CLR/OLE -> pawn

	.NET
	        cpp.logwrite( test[] ) -- ������� ����� � �������
	        cpp.callRemoteCallback( callback[], params object[] args ) -- �������� ������� �� ������� � �����������

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

main(){

}

public OnGameModeInit() {
    callDotnetMethod("onDotnetLoaded", "cf", 'v', 1.0);

    new temp_int = callDotnetMethod("kernel.testINT", "ii", 10, 24);
    printf("testINT returned: %i", temp_int);

    new temp_bool = callDotnetMethod("kernel.testBOOL", "isi", 1, "boolean=)", 0);
    printf("testBOOL returned: %i", temp_bool);

    new temp_float = callDotnetMethod("kernel.testFLOAT", "ifcf", 10, 1.432, 'c', 242);
    printf("testFLOAT returned: %f", temp_float);

    new temp_str[ 16 ] ;
	callDotnetMethodStr("kernel.testSTRING", temp_str, sizeof temp_str, "sss", "by", "Seregamil", "dotNET v1.0");
    printf("testSTRING returned: %s", temp_str);
	return true ;
}

forward onDotnetWasLoaded(str[]);
public onDotnetWasLoaded(str[]){
	print(str);
}
