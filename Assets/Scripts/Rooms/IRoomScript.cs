using UnityEngine;
using System.Collections;
/**
 * Interfaz para todos los scripts de habitaciones en el que se basara el cambio de tiempo
 * 
 * */
public interface IRoomScript {

	void changeTime(int time);

	void toPast();
	
	void toPresent();
	
	void toFuture();

	int getCurrentTime();
}
