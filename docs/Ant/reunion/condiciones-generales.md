# Condiciones generales para el diseño y la implementacion del sistema de bases de datos transaccional 
  
### El sistema informatico debe contemplar la automatizacion de: 

<br />

1. **Mantenimiento de historicos de membresia y de objetos de coleccion**
    * Registrar los miembros nuevos de un club, cerrar membresia cuando se retiran 
    * Registrar para cada objeto el dueño actual y actualizar su historia añadiendo los nuevos dueños cada vez que se subaste. 
 
2. **Planificacion de un evento de subasta:** 
 
    * Consultar planificacion de los demas clubes antes de armar el calendario anual de subastas

    * Crear el evento con todos los datos requeridos (si no se realiza, eliminar la informacion registrada)
    
    * Para ***todas*** las subastas:

        - Elegir clubes a participar como compradores 
        - Enviar invitaciones a los clubes anteriores 
        - Inscribir los participantes
        - Definir lista de objetos a subastar (con precio base segun reglas indicadas) 

    * Segun sea el tipo:
         
        - ***Presencial***:
            
            - Asignar lugar

            1. ***Beneficos***: 
                
                - Elegir clubes participantes como organizadores 
                - Elegir organizaciones y % a donar 
                
            2. ***Regulares***:

                - \~
                    
        - ***Virtual***:
            
            - \~

3. **Ejecucion del evento de subasta:**
 
    * Presencial ***benefica***: 
        1. Por cada objeto a subastar registrar el ganador (el coleccionista que escribio la oferta mas alta) 
        2. Actualizar historia del objeto 
        3. Asignar ganancia a la organizacion (o a varias si aplica) 
 
 
    * Presencial ***regular*** o ***virtual***: 
        1. Por objeto en el orden especificado (uno a la vez), pedir puja validando precio ascendente hasta que se acabe el tiempo - la ultima oferta es la ganadora. Registrar precio y coleccionista ganador. 
        2. Actualizar historia del objeto 
 
 
    > Nota: Los pasos anteriores resumen lo minimo esperado en la implementacion del proceso de negocio  - cada actividad debe cumplir con todas las reglas pertinentes, indicadas en el enunciado.
    > 
    > Para que se pueda automatizar el proceso anterior, **la base de datos debe tener insertada toda la informacion de entrada necesaria - clubes, objetos, lugares, coleccionistas, organizaciones de caridad, entre otros.** 

4. **Para completar los requerimientos del negocio es necesaria la implementacion de los siguientes reportes:**

        ver archivo reportes.md 
 
    >  


---

* En general se debe realizar el modelo ER, el diseño logico y la implementacion de la b/d a traves del sistema a desarrollar de acuerdo a lo especificado. Adicionalmente se debe poder realizar cualquier operacien basica directamente a la b/d a traves del uso del lenguaje SQL. 

* Todas las reglas de integridad implicitas (modelo relacional y constraints) deben estar implementadas directamente en la b/d y las reglas de negocio que no se deriven en una restriccion implicita se deben implementar a traves de las interfaces a construir. 

* Cada reporte debe seguir un diseño o formato apropiado a la naturaleza del negocio y al tipo de informacion solicitada (titulos, criterios de ordenamiento, espaciado, justificacion de columnas, parametros de busqueda, totalizaciones, etc.). Al momento de demostrar la implementacion realizada, cada reporte debe tener habilitados los parametros pertinentes. Cada equipo de proyecto debe diseñar una plantilla base que personalice sus reportes. 



* Para asegurar que cada equipo inserte informacion apropiada, suficiente y no repetida deben cumplir las siguientes condiciones:  

    > Cada equipo de proyecto debe registrar al menos 6 clubes. Deben tener al menos 12 coleccionistas con colecciones de al menos 4 objetos de los cuales al menos 2 deben ser comics (24 comics y 24 objetos de eleccion libre en total). Para cada una de las demes tablas deben insertar al menos 9 registros.


--- 
### Footers:
> 2. Precio base es el precio inicial a partir del cual comienzan las pujas u ofertas. 

> 3. Una subasta de caridad puede tener mas de un club organizador y se puede beneficiar a una o varias organizaciones - cuando son varias, se debe especificar el % que le corresponde recibir a cada organizacion.

> 4. La automatizacion implica el almacenamiento y procesamiento de la informacion relacionada a los procesos de negocio identificados. 

> 5. Tanto los coleccionistas como comics y los demas objetos deben ser reales.



