/**
 * 
 */
package paketsu;

import java.util.Arrays;

/**
 * @author EskoHanell
 * @version 4.2.2016
 *
 */
public class Jono {
private int maxPituus, ekanPaikka=0, vikanPaikka=0, pituus;
private int[] jono;

	/**
	 * konstruoi jono rakenne olion "queue" int tyyppisille alkioille.
	 * @param jono jono josta aloitetaan.
	 * @param tilaa kuinka monta alkiota jonoon mahtuu.
	 */
	public Jono(int[] jono, int tilaa) {
		this.maxPituus=tilaa;
		this.pituus=jono.length;
		this.jono=Arrays.copyOf(jono, tilaa);
		this.ekanPaikka=0;
		this.vikanPaikka=jono.length-1;
	}
	/**
	 * lis‰‰ jonon viimeiseksi luvun.
	 * @param jonottaa luku joka lis‰t‰‰n jonon viimeiseksi.
	 */
	public void enque(int jonottaa){
		if (pituus==maxPituus)stackOverflow();
		if (vikanPaikka+1 !=maxPituus) {
			vikanPaikka++; 
		} else vikanPaikka = jono[0];
		jono[vikanPaikka] = jonottaa;
		this.pituus++;

	}
	
	/**
	 * Huutaa tyhjyyteen. Ehk‰ se auttaa.
	 */
	private void stackOverflow() {
		System.out.println("Apuva! Apuva! Apuva! Nyt hajos meni rikki ja VUOTAA YLI!");
		
	}
	/**
	 * palauttaa jonossa seuaavana olevan ja poistaa sen.
	 * @return jonossa seuraavana olevan.
	 */
	public int dequeue(){
		int pois=ekanPaikka;
		if (pituus==0)stackOverflow();
		if (ekanPaikka+1 !=maxPituus) {
			ekanPaikka++; 
		} else ekanPaikka = jono[0];
		this.pituus--;
		return jono[pois];
	}
	
	/**
	 * palauttaa onko jono tyhj‰.
	 * @return onko tyhj‰.
	 */
	public boolean isEmpty(){
		if (pituus<=0)return true;
		return false;
	}
	
	/**
	 * palauttaa jonon t‰m‰nhetkisen pituuden. Ei koko pituutta.
	 * @return jonon pituus
	 */
	public int size(){
		return pituus;
	}
	
	/**
	 * palauttaa paikan miss‰ ensimm‰ien alkio asuu.
	 * @return ensimm‰isen alkion paikka
	 */
	public int front(){
		return ekanPaikka;
	}
	/**
	 * palauttaa kuinka monta lukua jonoon voi enint‰‰n mahtua
	 * @return jonon max pituus
	 */
	public int maxMitta(){
		return maxPituus;
	}
	
}
