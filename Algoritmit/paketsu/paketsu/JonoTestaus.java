/**
 * 
 */
package paketsu;

import paketsu.Jono;

/**
 * @author EskoHanell
 * @version 4.2.2016
 *
 */
public class JonoTestaus {

	/**
	 * aargs
	 * @param args ei oo...
	 */
	public static void main(String[] args) {
		
		Jono jono = new Jono(new int[] {3,2,10,5},20);
		
		System.out.println("-----STATISTICS-----");
		System.out.println("taulukon koko maksimissaan (annettu kutsussa) = " + jono.maxMitta());
		System.out.println("size == "+jono.size());
		System.out.println("front == "+jono.front());
		System.out.println("tyhjä == "+jono.isEmpty());
		System.out.println("---STATISTICS OUT---");
		System.out.println(jono.dequeue());
		jono.enque(9001);
		jono.enque(-700);
		jono.enque(42);
		System.out.println(jono.dequeue());
		System.out.println(jono.dequeue());
		System.out.println(jono.dequeue());
		System.out.println(jono.dequeue());
		System.out.println(jono.dequeue());
		System.out.println(jono.dequeue());
		System.out.println(jono.dequeue());
		System.out.println(jono.dequeue());
		System.out.println(jono.dequeue());
		System.out.println("-----STATISTICS-----");
		System.out.println("tyhjä == "+jono.isEmpty());
		System.out.println("front == "+jono.front());
		System.out.println("size == "+jono.size());
		System.out.println("--------END---------");
		

		
	}

}
