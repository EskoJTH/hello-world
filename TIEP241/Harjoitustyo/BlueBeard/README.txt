Ty�n tekij� Esko Hanell. esjutaha@student.jyu.fi
Ohjelma on kirjoitetty c# kielell� visual studiossa. Helpoin tapa k��nt� se on varmaan avata se visualstudion 2015 versiossa ja k��nt�� debuggausta varten.

Pit�isi kai toimia linuxillakin mutta en oikeasti tied�.
Viimeksi kun yritin k��nt�� Visualstuiota varten tehty� c# koodia linuksilla ei se oikein halunnut olla yhteisty�ss�.

Ohjelma sis�lt�� peliloopin joka py�rii rekursion p��ll�. T�m� kai ei ole mihin c# on suunniteltu, mutta en ainakaan ole viel� t�m�nnyt ongelmiin. pelilooppi on todella hidas. Uusien kutsujen synty verrannainen kirjoitusnopeuteen. K�sitelt�v� data ei ole mit��n s��ennuste luokkaa.

Ojeet k��nt�miseen: Avaa sln tiedosto tietokoneella jossa on 2015 visual studio.

En ihan implementoinut kaikkea mit� suunnittelin, koska se ei ollut kurssin kannalta oleellista.
Ohje l�pipelaukseeen:

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



LocationNFA tiedostosta l�ytyy LocationNFA luokkam jossa luodaa Room olioista 3x3 gridin mallinen dfa jossa jokaisesta gridin tilasta on siirtym� toiseen tilaan yl�s, alas, vasemmalle tai oikealle. jos yritet��n siirty� gridin reunan ulkopuolelle siirryt��n takaisin samaan tilaan tai oikeastaan pysyt��n samassa tilassa. Toisaalta t�m� ei ole kovakoodattuna gridiss� vaan se k�sitell��n muussa logiikassa. jokainen huone gridiss� voi sis�lt�� yhden viidest� eri itemist� tai ei yht��n. T�m� ei riko dfa:ta vaan lis�� vain jokaiseen huoneeseen viisi linkki� toisiin 3x3 grideihin joissa itemit ovat eritavalla. Itemeiden m��r�� ei ole kovakoodattu Room olioon vaan se on aina viisi k�yt�nn�ss� koska se on itemeiden m��r�. 

Tiedosto CFL sis�lt�� contekstittoman kieliopin (Olion nimi CFG kuten "context free grammar". Nimesin ensin vahingossa v��rin enk� halua kokeilla mit� visual studio tykk�� jos l�hden muuttamaan tiedostonimi�.)


Kieliopin p��temerkit:
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

Kieliopin mielekk��t johdot

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

K�sittely tapahtuu yleens�  LocationNFA:n puolella koska Yleens� tarvitaan tietoa ymp�rist�st�.

E -> read
E -> look
E -> move
E -> takep
E -> attack
E -> drop
E -> attack target
E -> attack weapon

Edell� mainituissa johdoissa j�rjestelm� kysyy k�ytt�j�lt� yksitellen puuttuvat p��temerkit jotta p��st��n seuraaviin johtoithin.
Jos j�rjestelm�lle t�ss� annetaan mielett�mi� merkkeje ei se palaa takaisin oletustilaan.

Ensimm�isen sanan sy�tteess� pit�� aina sis�lt�� ensimm�inen p��temerkki. muuten Sy�tteen k�sittely hyv�ksyy kaikki merkkijonot jotka sis�lt�v�t jossakin kohtaa niiden tarvitsemat p��temerkit. Esimerkiksi johto: E -> attack "to the" target "by using the" weapon,  menee siis l�pi samassa kuin: E -> attack target weapon.

vihollisen toiminta koostuu *kolmesta* eri tilasta. Ensimm�isess� tilassa vihollinen liikkuu satunnaisesti sokkelossa tietyll� kellotaajuudella. Jos vihollien saa havaitsee pelaajan l�hell� se siirtyy uudella kelloajalla samaan ruutuun kuin pelaaja ja varoittaa t�st� pelaajaa. Jos pelaaja ikin� on samassa ruudussa kuin alieni se paljastaa olemuksensa ja tappaa pelaajan jos t�m� ei pysty reagoimaan oiken tietyn ajan sis�ll�. T�ss� siis periaatteessa on dfa jossa on kolme tilaa. Niiden n�keminen koodista on tosin vaikeaa koska ajasstimet aiheuttavat ett� tapahtumat t�ytyy k�sitell� ep�suuorasti ja koodi on sijoitettu moneen eri paikkaan. My�skin osa t�st� toiminnasta on ett� voidaan huomata kun pelaaja siirtyy vihollisen alueelle itse, joka t�ytyy k�sitell� eri paikassa.
