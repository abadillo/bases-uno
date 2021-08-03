--Query Clubes
SELECT 
    club.id, to_char(club.fecha_fundacion, 'YYYY-MM-DD') as fecha_fundacion, 
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