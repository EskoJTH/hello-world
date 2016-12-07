Työn tekijä Esko Hanell. esjutaha@student.jyu.fi
Ohjelma on kirjoitetty c# kielellä visual studiossa. Helpoin tapa kääntä se on varmaan avata se visualstudion 2015 versiossa ja kääntää debuggausta varten.

Pitäisi kai toimia linuxillakin mutta en oikeasti tiedä.
Viimeksi kun yritin kääntää Visualstuiota varten tehtyä c# koodia linuksilla ei se oikein halunnut olla yhteistyössä.

Ohjelma sisältää peliloopin joka pyörii rekursion päällä. Tämä kai ei ole mihin c# on suunniteltu, mutta en ainakaan ole vielä tömännyt ongelmiin. pelilooppi on todella hidas. Uusien kutsujen synty verrannainen kirjoitusnopeuteen. Käsiteltävä data ei ole mitään sääennuste luokkaa.

Ojeet kääntämiseen: Avaa sln tiedosto tietokoneella jossa on 2015 visual studio.

En ihan implementoinut kaikkea mitä suunnittelin, koska se ei ollut kurssin kannalta oleellista.
Ohje läpipelaukseeen:

go west
take polearm
go east
go east
go north
take scabbard
go west
take sword

;;go to the same room as creature

hit the creature with the polearm
hit the creature with the sword

;;win win its this easy



LocationNFA tiedostosta löytyy LocationNFA luokkam jossa luodaa Room olioista 3x3 gridin mallinen dfa jossa jokaisesta gridin tilasta on siirtymä toiseen tilaan ylös, alas, vasemmalle tai oikealle. jos yritetään siirtyä gridin reunan ulkopuolelle siirrytään takaisin samaan tilaan tai oikeastaan pysytään samassa tilassa. Toisaalta tämä ei ole kovakoodattuna gridissä vaan se käsitellään muussa logiikassa. jokainen huone gridissä voi sisältää yhden viidestä eri itemistä tai ei yhtään. Tämä ei riko dfa:ta vaan lisää vain jokaiseen huoneeseen viisi linkkiä toisiin 3x3 grideihin joissa itemit ovat eritavalla. Itemeiden määrää ei ole kovakoodattu Room olioon vaan se on aina viisi köytönnössä koska se on itemeiden määrä. 

Tiedosto CFL sisältää contekstittoman kieliopin (Olion nimi CFG kuten "context free grammar". Nimesin ensin vahingossa väärin enkä halua kokeilla mitä visual studio tykkää jos lähden muuttamaan tiedostonimiä.)


Kieliopin päätemerkit:
move = { "move", "go", "proceed", "walk", "run", "sprint" };
attack = { "cut", "hit", "thrust", "attack", "charge", "punch", "kick", "bite", "shoot" };
read = { "read" };
take = { "take", "get", "hold", "grab" };
items = { "sword", "scabbard", "polearm", "bow", "terahedron" };
directions = { "north", "east", "south", "west" };
look = { "see", "watch", "look", "inspect", "investigate", "read" };
room = { "around", "room", };
target = { "monster", "alien", "creature", "stone square", "hole" };
weapon = { "bow", "polearm", "spear", "sword", "fist", "foot", "head", "teeth", "jaws", "tetrahedron"  };
literature = { "book", "necronomicon" };
drop = { "drop", "put down", "empty hands", "free hands", "lay down", "leave", "discard" };

Kieliopin mielekkäät johdot

E -> read literature
E -> look L
E -> move directions
E -> take items
E -> attack T
E -> attack T

L -> directions
L -> items

T -> weapon target
T -> target weapon

Käsittely tapahtuu yleensä  LocationNFA:n puolella koska Yleensä tarvitaan tietoa ympäristöstä.

E -> read
E -> look
E -> move
E -> takep
E -> attack
E -> drop
E -> attack target
E -> attack weapon

Edellä mainituissa johdoissa järjestelmä kysyy käyttäjältä yksitellen puuttuvat päätemerkit jotta päästään seuraaviin johtoithin.
Jos järjestelmälle tässä annetaan mielettömiä merkkeje ei se palaa takaisin oletustilaan.

Ensimmäisen sanan syötteessä pitää aina sisältää ensimmäinen päätemerkki. muuten Syötteen käsittely hyväksyy kaikki merkkijonot jotka sisältävät jossakin kohtaa niiden tarvitsemat päätemerkit. Esimerkiksi johto: E -> attack "to the" target "by using the" weapon,  menee siis läpi samassa kuin: E -> attack target weapon.

vihollisen toiminta koostuu *kolmesta* eri tilasta. Ensimmäisessä tilassa vihollinen liikkuu satunnaisesti sokkelossa tietyllä kellotaajuudella. Jos vihollien saa havaitsee pelaajan lähellä se siirtyy uudella kelloajalla samaan ruutuun kuin pelaaja ja varoittaa tästä pelaajaa. Jos pelaaja ikinä on samassa ruudussa kuin alieni se paljastaa olemuksensa ja tappaa pelaajan jos tämä ei pysty reagoimaan oiken tietyn ajan sisällä. Tässä siis periaatteessa on dfa jossa on kolme tilaa. Niiden näkeminen koodista on tosin vaikeaa koska ajasstimet aiheuttavat että tapahtumat täytyy käsitellä epäsuuorasti ja koodi on sijoitettu moneen eri paikkaan. Myöskin osa tästä toiminnasta on että voidaan huomata kun pelaaja siirtyy vihollisen alueelle itse, joka täytyy käsitellä eri paikassa.
