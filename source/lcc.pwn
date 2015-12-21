/*
	.NET Plugin
		by Seregamil

	C# <- CLR/OLE -> pawn

	.NET
	        cpp.logwrite( test[] ) -- выводит текст в консоль
	        cpp.callRemoteCallback( callback[], params object[] args ) -- вызывает каллбэк на сервере с параметрами

	PAWN
	    	callDotnetMethod -- вызывает метод в плагине
	    	    Возвращаемые значения:
	    	        i - int32
	    	        b - boolean = int(0/1)
	    	        f - float
						Запись возвращаемых значений без типизации.
						    Пример:
						        new temp = call... -- return int
						        temp = call... -- return bool
								temp = call... -- return float

			callDotnetMethodStr -- так же вызывает метод в плагине.
			    Отличие от предыдущей функции - возвращает всегда единицу и записывает результат в отдельную переменную
			        Пример:
			            new string[ 128 ] ;
			            new call...( methodID, string, sizeof string, ...

						Текст будет записан в переменную string

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
