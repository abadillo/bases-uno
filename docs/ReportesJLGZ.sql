--Query Clubes
SELECT 
    club.id, to_char(club.fecha_fundacion, 'DD-MM-YYYY') AS fecha_fundacion, 
    club.telefono, 
    club.pagina_web, 
    club.proposito, 
    club.nombre, 
    direccion.nombre AS direccion, 
    estado.nombre AS estado, 
    ciudad.nombre AS ciudad, 
    pais.nombre AS pais, 
    responsable.primer_nombre AS primer_nombre_responsable, 
    responsable.segundo_nombre AS segundo_nombre_responsable, 
    responsable.primer_apellido AS primer_apellido_responsable, 
    responsable.segundo_apellido AS segundo_apellido_responsable, 
    nro_miembros.nro_miembros_activos, 
    CASE 
        WHEN EXISTS (
            SELECT 
                COUNT(club_id_org) AS nro_subastas_organizadas 
            FROM jagorg_inv subastas_organizadas 
            WHERE subastas_organizadas.club_id_org = club.id 
            GROUP BY subastas_organizadas.club_id_org
        ) 
        THEN  (
            SELECT COUNT(club_id_org) AS nro_subastas_organizadas 
            FROM jagorg_inv subastas_organizadas 
            WHERE subastas_organizadas.club_id_org = club.id 
            GROUP BY subastas_organizadas.club_id_org
        )
        ELSE '0' 
    END AS nro_subastas_organizadas,
    CASE 
        WHEN EXISTS (
            SELECT 
                club_id_inv, 
                COUNT(club_id_inv) AS nro_subastas_invitadas 
            FROM jagorg_inv subastas_invitadas 
            WHERE subastas_invitadas.club_id_inv = club.id 
            GROUP BY subastas_invitadas.club_id_inv
        ) 
        THEN  (
            SELECT 
                COUNT(club_id_inv) AS nro_subastas_invitadas 
                FROM jagorg_inv subastas_invitadas 
                WHERE subastas_invitadas.club_id_inv = club.id 
                GROUP BY subastas_invitadas.club_id_inv
        )
        ELSE '0' 
    END AS nro_subastas_invitadas,
    CASE
        WHEN EXISTS (
            SELECT SUM(aux.monto_recibido)
            FROM (SELECT * FROM jagorg_sub, jagorg_inv WHERE jagorg_sub.subasta_id = jagorg_inv.subasta_id) AS aux
            WHERE aux.club_id_org = club.id
			GROUP BY aux.club_id_org
        )
        THEN (
            SELECT SUM(aux.monto_recibido)
            FROM (SELECT * FROM jagorg_sub, jagorg_inv WHERE jagorg_sub.subasta_id = jagorg_inv.subasta_id) AS aux
            WHERE aux.club_id_org = club.id
			GROUP BY aux.club_id_org
        )
        ELSE '0'
    END AS donaciones
FROM 
    jagclub club, 
    jaglugar direccion, 
    jaglugar ciudad, 
    jaglugar estado, 
    jaglugar pais, 
    jagmembresia membresia_responsable, 
    jagcoleccionista responsable, 
    (
        SELECT 
            club_id, 
            COUNT(club_id) AS nro_miembros_activos 
        FROM jagmembresia membresia 
        WHERE membresia.fecha_retiro IS NULL 
        GROUP BY membresia.club_id
    ) nro_miembros
WHERE 
    club.lugar_id = direccion.id 
    AND direccion.lugar_id = ciudad.id 
    AND ciudad.lugar_id = estado.id 
    AND estado.lugar_id = pais.id 
    AND club.id = membresia_responsable.club_id_lider 
    AND membresia_responsable.coleccionista_documento_identidad = responsable.documento_identidad
    AND nro_miembros.club_id = club.id 
    AND club.id = @id

--Coleccionistas
SELECT 
    coleccionista.documento_identidad,
    coleccionista.primer_nombre,
    coleccionista.segundo_nombre,
    coleccionista.primer_apellido,
    coleccionista.segundo_apellido,
    coleccionista.telefono,
    to_char(coleccionista.fecha_nacimiento, 'DD-MM-YYYY') AS fecha_nacimiento,
    nacionalidad.nombre,
    CASE 
        WHEN coleccionista.coleccionista_documento_identidad IS NOT NULL 
        THEN (
            SELECT 
                to_char(aux.documento_identidad, 9)
            FROM 
                jagcoleccionista aux
            WHERE
                aux.documento_identidad = coleccionista.coleccionista_documento_identidad
        )
        WHEN coleccionista.representante_documento_identidad IS NOT NULL 
        THEN (
            SELECT
                to_char(aux.documento_identidad, 9)
            FROM
                jagrepresentante aux
            WHERE
                aux.documento_identidad = coleccionista.representante_documento_identidad
        )
        ELSE ' '
    END AS representante_documento_identidad,
    CASE 
        WHEN coleccionista.coleccionista_documento_identidad IS NOT NULL 
        THEN 'Si'
        WHEN coleccionista.representante_documento_identidad IS NOT NULL 
        THEN 'No'
        ELSE ' '
    END AS es_representante_coleccionista,
    direccion.nombre AS direccion, 
    estado.nombre AS estado, 
    ciudad.nombre AS ciudad, 
    pais.nombre AS pais, 
    CASE 
        WHEN EXISTS (
            SELECT 
                COUNT(participante.subasta_id) AS nro_subastas_participadas
            FROM
                jagparticipante participante
            WHERE
                participante.membresia_coleccionista_documento_identidad = coleccionista. documento_identidad
            GROUP BY participante.membresia_coleccionista_documento_identidad
        )
        THEN (
            SELECT 
                COUNT(participante.subasta_id) AS nro_subastas_participadas
            FROM
                jagparticipante participante
            WHERE
                participante.membresia_coleccionista_documento_identidad = coleccionista. documento_identidad
            GROUP BY participante.membresia_coleccionista_documento_identidad
        )
        ELSE '0'
    END AS nro_subastas_participadas,
    CASE
        WHEN EXISTS (
            SELECT 
                club.nombre
            FROM
                jagclub club, jagmembresia membresia
            WHERE
                club.id = membresia.club_id_lider
                AND membresia.coleccionista_documento_identidad = coleccionista.documento_identidad
                AND membresia.fecha_retiro IS NULL

        )
        THEN (
            SELECT 
                club.nombre
            FROM
                jagclub club, jagmembresia membresia
            WHERE
                club.id = membresia.club_id_lider
                AND membresia.coleccionista_documento_identidad = coleccionista.documento_identidad
                AND membresia.fecha_retiro IS NULL
        )
        ELSE ' '
    END AS club_responsable
FROM 
    jagcoleccionista coleccionista,
    jaglugar direccion, 
    jaglugar ciudad, 
    jaglugar estado, 
    jaglugar pais, 
    jaglugar nacionalidad
WHERE 
    coleccionista.lugar_id_direccion = direccion.id 
    AND direccion.lugar_id = ciudad.id 
    AND ciudad.lugar_id = estado.id 
    AND estado.lugar_id = pais.id 
    AND coleccionista.lugar_id_nacionalidad = nacionalidad.id 
    AND coleccionista.documento_identidad = @id

SELECT 
	to_char(MAX(fecha_registro), 'DD-MM-YYYY') AS fecha_adquisision,
    CASE
        WHEN dueno.comic_id IS NOT NULL
        THEN comic.titulo
        WHEN dueno.coleccionable_id IS NOT NULL
        THEN coleccionable.nombre
    END as nombre
FROM 
    jagcomic comic
        FULL JOIN jagdueno_historico dueno ON comic.id = dueno.comic_id
            FULL JOIN jagcoleccionable coleccionable on dueno.coleccionable_id = coleccionable.id
WHERE
    dueno.coleccionista_documento_identidad = @id
GROUP BY 
	dueno.comic_id,
	dueno.coleccionable_id,
	comic.titulo,
	coleccionable.nombre