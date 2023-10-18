# PruebaTecnica
Prueba técnica para postulantes al cargo de ingeniero de desarrollo FinFast

**Objetivos**

Se intenta medir el grado de conocimiento, realizando una tarea común en desarrollo de software, que permitirá indagar sobre su manejo de tecnologías ligadas a la conexión con la base de datos, consultas a ella (ORM), construcción de una Web API y consumo de estos métodos mediante tecnología JavaScript / Typescript.

***
En este repositorio encontrará en la carpeta SQL un script que crea la estructura y los datos de una base llamada "PruebaTecnica". Esta base de datos funciona en versiones de SQL Server mayor o igual a 2008.

**Lo que se pide es lo siguiente:**

En la base de datos que usted restauró, encontrará una tabla llamada persona, en donde se almacenan datos básicos de identificación y contacto. En este modelo también encontrará las tablas dbo.Sexo, dbo.Region, dbo.Ciudad, dbo.Comuna. El modelo de datos lo puede encontrar en un carpeta llamada modelos, el diagrama se llama modelo.png.

La idea es que pueda crear un mantenedor usando .Net core y Entity Framework, además de React y la librería css que a usted le acomode. Debe ser un mantenedor responsivo, que permita realizar las actividades de edición, eliminación y registro. Se plantean los siguientes requerimientos funcionales:

1. El usuario puede registrar una nueva persona
2. El usuario puede editar los datos de una persona ya registrada
3. El usuario puede eliminar registros uno a uno
4. El sistema debe solicitar confirmación al usuario, cuando este quiera eliminar un registro
5. El usuario puede poder visualizar en una lista todas las personas registradas
6. El sistema debe validar la información como R.U.T., fecha de nacimiento, email y todos los datos obligatorios
7. El sistema debe actualizar La lista de personas registradas cada vez que se registre, elimine o edite algún registro
8. El sistema debe emitir un mensaje de éxito o error cada vez que el usuario realice una transacción

Como se ve, son requerimientos básicos para un mantenedor.

Como requerimientos no funcionales:

1. Debe utilizar la tecnología Web Api del framework .Net Core

2. Debe usar React, considerando que la capa de presentación es desacoplada

3. Debe ser un sitio responsivo

***
**Información de útil**

Primero que todo, realice la configuración de Entity Framework, para ello, debe instalar  mediante nugget, en la bibliotecas de clases que disponga para acceder a datos, los siguientes paquetes:

- EntityFramework
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Desing
- Microsoft.EntityFrameworkCore.Proxies
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.Extensions.Configuration.FileExtension
- Microsoft.Extensions.Configuration.Json

Luego con el comando **Scaffold-DBContext** puede generar las clases necesarias.

No olvide agregar una cadena de conexión en un archivo de configuración, como por ejemplo, appsettings.json.

Con la base de datos mapeada, y con el acceso a ella configurado, usted ya puede construir las API necesarias, requiere al menos 4, para listar las personas, registrar, actualizar y eliminar.

También podría aportar a su desarrollo, 2 mockups que se encuentra en la carpeta del mismo nombre, es una idea general de lo que se espera como entrega.

No considere tokens de seguridad, o autenticación. En la vista utilice todos los recursos accesorios a React que le faciliten la tarea, como bibliotecas de CSS.

***
**Información importante para la entrega**

Debe crear una rama a partir de master con las inciales de su nombre, debe informar a los correos **gzuleta@finfast.com**, **sgonzalez@finfast.com** y **kmijares@finfast.com**, que inicia la tarea, e informar a estos mismos correos cuando finalice. El plazo considerado para que pueda realizar esta labor es de 48 horas, a partir del aviso de inicio. También puede contactarse a estos mismos correos para recibir orientación adicional en caso de dudas.

agradeciendo su postulación al cargo, y el tiempo que otorga a esta actividad.

Saluda a usted.

Guillermo Zuleta Flores.<br/>
Líder técnico. FinFast
