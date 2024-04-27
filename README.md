Vizsgafeladat

Első lépésként létre kell hozni a fájlban található adatok (egy sor egy dolgozathoz tartozik) tárolására egy alkalmas osztályt Dolgozat néven, melyben tároljuk a nevet, valamint a dolgozat feladataira kapott pontszámokat egy listában. Készítsen egy konstruktort, mely paraméterként a dolgozatot író diák nevét, valamint egy listát kap paraméterként, melyben az egyes feladatokra kapott pontok találhatók, majd a kapott adatokat felhasználva beállítja minden egyes objektum tulajdonságait.
Készítse el továbbá a következő metódusokat:
•	FeladatokSzama(): a metódus az adott dolgozatban található feladatok számát adja vissza
•	OsszPontszam(): a metódus egész számmal tér vissza, mely megadja az adott dolgozatban elért pontszámot.
•	Ertekel(maxPontszam) a metódus paraméterként megkapja a dolgozatban elérhető maximális pontszámot, majd visszatér a szerzett érdemjeggyel. Az érdemjegy meghatározása a következő:
    maxPontszám 100%
        •	0-40% elégséges(2)
        •	41%-55% közepes(3)
        •	56%-70% közepes(3)
        •	71%-85% jó(4)
        •	86%-100% jeles(5)
•	Eredmeny(maxPontszam): a metódus megkapja a dolgozatban elérhető maximális pontszámot, majd visszatér a „Név: Elért pontszám – értékelés” mintájú szöveggel:

•	ToString(): visszatér a dolgozatot író nevével, valamint az összpontszámmal! (felülírás)

Minden tantárgyhoz (Matematika, Történelem, Irodalom) készítsen külön osztályt, melyek a Dolgozat osztály leszármazottjai. A matematika dolgozat esetében 45, a történelem dolgozatnál 30, míg az irodalomnál 40 pont volt a maximálisan elérhető pontszám. 

•	Matematika dolgozatok: van egy temakor szöveges osztályváltozója, amit a konstruktora állít be, természetesen a szülő osztályváltozóit is beállítja. A matematika dolgozatok eredményeinek meghatározásánál a témakört is hozzáfűzi az Eredmeny metódus (felülírás).

•	A történelem dolgozatok esetében háromfokozatú (Nem felelt meg, megfelelt, kiválóan megfelelt) az értékelés:
o	nem felelt meg: elégtelen vagy elégséges
o	megfelelt: közepes, jó
o	kiválóan megfelelt: jeles
Az értékelést az Eredmenyek() metódus végzi.(felülírás)

•	Az irodalom dolgozatok esetében az Eredmeny hasonlóan működik, mint a matematika dolgozatoknál, csak itt a csoportot fűzzük hozzá az eredményekhez.
Feladatok:
Minden egyes feladat eredményét, ha arról tájékoztatni kell a felhasználót, a konzolra kell kiíratni, a feladat sorszámával együtt, úgy ahogyan az a mintában látható.

1. Feladat.
Hozzon létre egy dolgozatok tárolására alkalmas listát a Main metódust tartalmazó osztályban, mely az osztály bármely metódusából elérhető.

2. Feladat 
Készítsen egy Beolvas() metódust, mely beolvassa a fájlból az adatokat, a különböző tantárgyakhoz tartozó dolgozatokat azoknak megfelelő módon példányosítja, majd hozzáadja a listához.

3. Feladat
Írassa ki a kijelzőre a fájlban tárolt matematika dolgozatok számát.
 
4. Feladat
Kérjen be a felhasználótól egy nevet (vezetéknév keresztnév). Amennyiben a megadott nevű tanuló írt történelem dolgozatot, írassa ki az elért eredményt, különben írja ki a konzolra, hogy „X Y nevű tanuló nem írt dolgozatot történelemből!”!
 
 
5. Feladat 
Kérjen be a felhasználótól egy feladat sorszámot. Amennyiben van megadott sorszámú feladat az irodalom dolgozatban, írja ki a kijelzőre a feladatra kapott átlagos pontszámot, különben írja ki a konzolra, hogy "Sajnos ilyen sorszámú feladat nem létezik!"!
 
 
6. Feladat
Írjon ki egy menüt a konzolra, mely menüben az egyes tantárgyak szerepelnek. A felhasználó választása alapján listázza ki az összes adott tantárgyhoz tartozó dolgozat eredményét. Hibás választás esetén írja ki, hogy "Sajnos ilyen opció nincs"!