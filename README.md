Descripción
Esta API permite gestionar un inventario de vinos. Las principales funcionalidades son:

1.-Registrar nuevos vinos.
2.-Consultar el inventario de vinos.
3.-Buscar vinos por su nombre.
4.-Registrar y consultar usuarios.

Endpoints Principales
Registrar vino (POST /api/wine): Permite agregar un vino con detalles como nombre, variedad, año, región y stock.
Consultar inventario (GET /api/wine): Devuelve la lista de todos los vinos en inventario.
Buscar vino por nombre (GET /api/wine/{name}): Devuelve los detalles de un vino específico.
Registrar usuario (POST /api/user): Permite registrar un nuevo usuario con nombre de usuario y contraseña.
Consultar usuarios (GET /api/user): Devuelve la lista de todos los usuarios registrados.
