

"FICHA EVENTO por evento"

- el club organizador
- los participantes compradores con el club representan
- los objetos a subastar especificando el orden, el precio base en las dos monedas, el dueño del objeto y la duracion total para las pujas
- En la subasta de **caridad** tambien va la informacion de las organizaciones que recibiran el dinero resultante de las ventas logradas y el % que le corresponde recibir a cada una


-- Datos de la subasta y duracion de las pujas (SubastaByID)
select
	s.id,
	s.tipo,
	to_char(s.fecha, 'DD-MM-YYYY') AS fecha,
	to_char(COALESCE(sum(l.duracion_min),0),'99999') || ' min' as duracion_pujas,
	CASE
		WHEN s.caridad
		THEN 'Benefica'
		ELSE 'No Benefica'
	END AS caridad
from
    jagsubasta s

left join jaglistado l on l.subasta_id = s.id

where
    s.id = 9

group by
    s.id


-- Organizadores (OrganizadoresBySubasta)
select
	cl.id,
	cl.nombre
from
    jagorg_inv o,
    jagclub cl
where
    o.subasta_id = 9 and
    o.club_id_org = cl.id


-- Partipantes (ParticipantesBySubasta)
select
	c.documento_identidad,
	c.primer_nombre,
	c.primer_apellido,
	cl.nombre
from
	jagparticipante p,
	jagcoleccionista c,
	jagclub cl

where
	p.subasta_id = 9 and
	p.membresia_coleccionista_documento_identidad = c.documento_identidad and
	p.membresia_club_id = cl.id

order by
	cl.id


-- Objetos a subasta (ObjetosBySubasta)
SELECT
	l.orden,

    concat(co.titulo,cl.nombre) as objeto,

	to_char(l.precio_base_dolar,'999990.0 $') as precio_base_dolar,
	to_char(l.precio_base_dolar * 0.84,'999990.0 €') as precio_base_euro,

	c.documento_identidad,
	concat(c.primer_nombre,' ',c.primer_apellido) as dueno

FROM jaglistado l

JOIN jagdueno_historico dh ON dh.id = l.dueno_historico_id
JOIN jagcoleccionista c ON c.documento_identidad = dh.coleccionista_documento_identidad
left join jagcomic co on co.id = dh.comic_id
LEFT JOIN jagcoleccionable cl ON cl.id = dh.coleccionable_id

where l.subasta_id = 9
order by l.orden;

-- Organizaciones caridad (OrgCaridadBySubasta)
SELECT
    oc.nombre,
    oc.mision,
    to_char(os.porcentaje,'999%') as porcentaje

FROM
    JAGORGANIZACION_CARIDAD oc,
    JAGORG_SUB os

WHERE
    os.subasta_id = 8 and
    os.organizacion_caridad_id = oc.id







"Resultados Evento por evento"

- Objetos vendidos: precio alcanzado, nuevo dueño (con su club)
- Objetos no vendidos
- En las subastas de caridad, el total otorgado a cada organizacion.



"Resumen de Participacion por coleccionista y rango fecha"

- . para un periodo de tiempo, mostrar la lista de eventos en los que ha participado especificando el rol que desempeñe en cada uno (vendedor o comprador) y cual club representaba. El resumen debe estar organizado por rol - primero como vendedor, segundo como comprador y en cada caso se debe presentar la informacion cronologicamente.


-- Datos coleccionista (ColeccionistaByIDSimp)
SELECT
    documento_identidad,
    primer_nombre || ' ' || segundo_nombre as nombres,
    primer_apellido || ' ' || segundo_apellido as apellidos
From
jagcoleccionista
where
documento_identidad = @documento_identidad


-- Participacion (ParticipacionByIdDate)
SELECT
    s.id as subasta,
    to_char(s.fecha, 'DD-MM-YYYY') AS fecha,
    'Vendedor' as rol,
    c.nombre as club
from
    jagsubasta s,
    jaglistado l,
    jagdueno_historico dh,
    jagorg_inv oi,
    jagclub c,
    jagmembresia m

where
    s.fecha between '05-05-2000' and '05-05-2050' and
    l.subasta_id = s.id and
    l.dueno_historico_id = dh.id and
    dh.coleccionista_documento_identidad = 25385914 and
    m.coleccionista_documento_identidad = dh.coleccionista_documento_identidad and
    m.club_id = oi.CLUB_id_org and
    c.id = oi.CLUB_id_org

group by
	s.id, s.fecha, c.nombre


UNION

SELECT
    s.id as subasta,
    to_char(s.fecha, 'DD-MM-YYYY') AS fecha,
    'Comprador' as rol,
    c.nombre as club
from
    jagsubasta s,
    jagparticipante p,
    jagclub c

where
    s.fecha between '05-05-2000' and '05-05-2050' and
    p.subasta_id = s.id and
    p.membresia_coleccionista_documento_identidad = 25385914 and
    p.membresia_club_id = c.id

group by
	s.id, s.fecha, c.nombre

order by rol desc, fecha


