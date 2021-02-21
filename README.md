# miniAvtosoleTadej

KRATEK OPIS APLIKACIJE:
Aplikacija je namenjena avtosolam in njenim uporabnikom. Uporabnik se lahko registrira in ureja svoje podatke. Avtosola se lahko registrira ali prijavi, nato pa vidi vse svoje instruktorje in izpite, ki jih imajo na voljo. Te lahko ureja ali pa dodaja po želji. Prav tako lahko tudi spreminja svoje podatke.

STREŽNIŠKI PODPROGRAMI:

Trigerji:
CREATE TRIGGER arhiviraj
    AFTER INSERT
    ON public.izpiti
    FOR EACH ROW
    EXECUTE PROCEDURE public.arhiviraj();
  
CREATE TRIGGER stetje_izpitov
    AFTER INSERT OR DELETE OR UPDATE 
    ON public.izpiti
    FOR EACH ROW
    EXECUTE PROCEDURE public.stetjeizpitov();

CREATE TRIGGER stetje_uporabnikov
    AFTER INSERT OR DELETE OR UPDATE 
    ON public.uporabniki
    FOR EACH ROW
    EXECUTE PROCEDURE public.stetjeuporabnikov();
    
  OSTALO:
  CREATE OR REPLACE FUNCTION public.izbrisiuporabnika(
	iduporabnika integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
BEGIN
DELETE FROM uporabniki WHERE id=idUporabnika;
RETURN 'USPESNO';
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.izbrisiizbit(
	idizpita integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
BEGIN
DELETE FROM izpiti WHERE id = idIzpita;
RETURN 'USPESNO';
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.izbrisiinstruktor(
	idinstruktorja integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
BEGIN
DELETE FROM instruktorji WHERE id = idInstruktorja;
RETURN 'USPESNO';
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.izbrisiavtosolo(
	idavtosole integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
BEGIN
DELETE FROM instruktorji WHERE avtosola_id = idAvtosole;
DELETE FROM izpiti WHERE avtosola_id = idAvtosole;
DELETE FROM avtosole WHERE id = idAvtosole;
RETURN 'USPESNO';
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.prijavauporabnika(
	emailu character varying,
	passu character varying)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
idu INT;
BEGIN
IF ((SELECT email FROM uporabniki WHERE email=emailU)=emailU) THEN
	SELECT INTO idu id FROM uporabniki WHERE email=emailU;
ELSE
	RETURN 'NEUSPESNO';
END IF;
IF((SELECT pass FROM uporabniki WHERE id=idu)=passU) THEN
	RETURN 'USPESNO';
ELSE
	RETURN 'NEUSPESNO';
END IF;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.prijavaavtosole(
	emaila character varying)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
BEGIN
IF ((SELECT email FROM avtosole WHERE email=emaila)=emailA) THEN
	RETURN 'USPESNO';
ELSE
	RETURN 'NEUSPESNO';
END IF;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.registracijaavtosole(
	imea character varying,
	emaila character varying,
	telefona character varying,
	kida integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
BEGIN
IF ((SELECT email FROM avtosole WHERE email=emaila)=emailA) THEN
	RETURN 'NEUSPESNO';
ELSE
	INSERT INTO avtosole (ime,email,telefon, kraj_id) VALUES (imeA, emailA, telefonA, kidA);
	RETURN 'USPESNO';
END IF;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.registracijauporabnika(
	emailu character varying,
	passu character varying,
	naslovu character varying,
	starostu integer,
	telefonu character varying,
	idku integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
BEGIN
IF ((SELECT email FROM uporabniki WHERE email=emailU)=emailU) THEN
	RETURN 'NEUSPESNO';
ELSE
	INSERT INTO uporabniki (email,pass,starost,naslov,telefon, kraj_id) VALUES (emailU, passU, starostU, naslovU, telefonU, idKU);
	RETURN 'USPESNO';
END IF;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.urediinstruktorja(
	idi integer,
	imei character varying,
	priimeki character varying,
	emaili character varying,
	telefoni character varying,
	kraj_idi integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
test INT;
BEGIN
UPDATE instruktorji
SET
ime=imeI,
priimek=priimekI,
email=emailI,
telefon=telefonI,
kraj_id=kraj_idI
WHERE id=idI;
IF ((SELECT ime FROM instruktorji WHERE id=idI)=imeI)THEN
	IF ((SELECT priimek FROM instruktorji WHERE id=idI)=priimekI)THEN
		IF ((SELECT email FROM instruktorji WHERE id=idI)=emailI)THEN
			IF ((SELECT telefon FROM instruktorji WHERE id=idI)=telefonI)THEN
				IF ((SELECT kraj_id FROM instruktorji WHERE id=idI)=kraj_idI)THEN
					test :=1;
				END IF;			
			END IF;
		END IF;
	END IF;
END IF;
IF(test = 1) THEN
RETURN 'USPESNO';
ELSE
RETURN 'NEUSPESNO';
END IF;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.urediavtosolo(
	ida integer,
	emaila character varying,
	imea character varying,
	telefona character varying,
	krajida integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
BEGIN
UPDATE avtosole
SET ime = imeA,
email = emailA,
telefon = telefonA,
kraj_id = krajidA
WHERE id = idA;
if ((SELECT ime from avtosole WHERE ime = imeA) = imeA ) THEN
RETURN 'USPESNO';
ELSE
RETURN 'NEUSPESNO';
END IF;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.uporabnikpodatki(
	emailu character varying)
    RETURNS TABLE(idu integer, emailup character varying, passu character varying, starostu integer, naslovu character varying, telefonu character varying, id_ku integer) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
DECLARE
BEGIN
RETURN QUERY SELECT id, email, pass, starost, naslov, telefon, kraj_id  FROM Uporabniki WHERE email=emailU;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.urediuporabnika(
	idu integer,
	emailu character varying,
	passu character varying,
	naslovu character varying,
	starostu integer,
	telefonu character varying,
	idku integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
BEGIN
UPDATE uporabniki
SET email = emailU,
pass = passU,
starost = starostU,
naslov = naslovU,
telefon = telefonU,
kraj_id = idkU
WHERE id = idU;
RETURN 'USPESNO';
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.urediizpit(
	idi integer,
	tipi character varying,
	starostmini integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
BEGIN
UPDATE izpiti
SET
tip = tipi,
starost_min = starostmini
WHERE id = idi;
if ((SELECT tip FROM izpiti WHERE id=idi) = tipi ) THEN
RETURN 'USPESNO';
END IF;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.vsikrajiizpis(
	)
    RETURNS TABLE(id_k integer, ime_k character varying, posta_k character varying) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN
   RETURN QUERY SELECT id, ime, posta FROM kraji ORDER BY ime;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.vseavtosoleizpitiizpis(
	ida integer)
    RETURNS TABLE(idi integer, tipi character varying, minstari integer, avtosolaidi integer) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
DECLARE
BEGIN
RETURN QUERY SELECT id, tip, starost_min, avtosola_id  FROM izpiti WHERE avtosola_id=ida;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.dodajdvetabeli(
	emaila character varying,
	imea character varying,
	krajida integer,
	telefona character varying,
	tipi character varying,
	minstarosti integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
idAvtosole int;
BEGIN
INSERT INTO avtosole(ime,email,telefon,kraj_id) VALUES (imeA,emailA,telefonA,krajIdA);
IF((SELECT email FROM avtosole WHERE email=emailA)=emailA) THEN
	SELECT INTO idAvtosole id FROM avtosole WHERE email = emailA;
	INSERT INTO izpiti (tip, starost_min, avtosola_id) VALUES (tipI, minStarostI, idAvtosole);
END IF;
IF ((SELECT tip FROM izpiti WHERE avtosola_id = idAvtosole AND tip=tipI)=tipI) THEN
	RETURN 'USPESNO';
ELSE
	RETURN 'NEUSPESNO';
END IF;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.dodajinstruktorja(
	idavtosole integer,
	imei character varying,
	priimeki character varying,
	emaili character varying,
	telefoni character varying,
	kraj_id integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
test int;
BEGIN
IF ((SELECT ime FROM instruktorji WHERE ime=imei)=imei) THEN
	IF ((SELECT priimek FROM instruktorji WHERE priimek=priimeki)=priimeki) THEN
	test := 1;
	END IF;
END IF;
IF(test = 1) THEN
RETURN 'NEUSPESNO';
ELSE
INSERT INTO instruktorji (ime,priimek,email,telefon, kraj_id, avtosola_id)
VALUES (imei,priimeki,emaili,telefoni,kraj_id,idavtosole);
RETURN 'USPESNO';
END IF;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.dodajizpit(
	idai integer,
	tipi character varying,
	starostmini integer)
    RETURNS character varying
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
DECLARE
test int;
BEGIN
IF ((SELECT tip FROM izpiti WHERE tip=tipi AND avtosola_id=idai)=tipi) THEN
	IF ((SELECT starost_min FROM izpiti WHERE starost_min=starostmini AND avtosola_id=idai)=starostmini)THEN
	test := 1;
	END IF;
END IF;
IF(test = 1) THEN 
	RETURN 'NEUSPESNO';
ELSE
	INSERT INTO izpiti (tip,starost_min,avtosola_id) VALUES (tipi,starostmini,idai);
	RETURN'USPESNO';
END IF;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.instruktorjipodatkiid(
	idavtosole integer)
    RETURNS TABLE(idin integer, imein character varying, priimekin character varying, emailin character varying, telefonin character varying, krajidin integer, avtosolaidin integer) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
DECLARE
BEGIN
RETURN QUERY SELECT id, ime, priimek, email, telefon, kraj_id, avtosola_id  FROM instruktorji WHERE avtosola_id=idAvtosole;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.avtosolapodatkiid(
	idavtosole integer)
    RETURNS TABLE(ida integer, imea character varying, emailav character varying, telefona character varying, krajida integer) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
DECLARE
BEGIN
RETURN QUERY SELECT id, ime, email, telefon, kraj_id  FROM avtosole WHERE id=idAvtosole;
END;
$BODY$;

CREATE OR REPLACE FUNCTION public.avtosolapodatki(
	emaila character varying)
    RETURNS TABLE(ida integer, imea character varying, emailav character varying, telefona character varying, krajida integer) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
DECLARE
BEGIN
RETURN QUERY SELECT id, ime, email, telefon, kraj_id  FROM avtosole WHERE email=emailA;
END;
$BODY$;
