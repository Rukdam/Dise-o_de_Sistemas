CREATE DATABASE Diseño_BD;
GO

USE Diseño_BD;
GO

CREATE TABLE Usuario (
    id INT IDENTITY PRIMARY KEY,
    cedula INT NOT NULL UNIQUE,
    nombre VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL,
    telefono VARCHAR(50),
    usuario VARCHAR(50) UNIQUE NOT NULL,
    claveHash VARCHAR(500) NOT NULL,
    tipoUsuario VARCHAR(20) NOT NULL CHECK (tipoUsuario IN ('Usuario','Supervisor','Operario')),
    turno VARCHAR(50),           -- Solo para Operario
    habilidades VARCHAR(500)     -- Solo para Operario
);

------------------------------------------------------------
-- ROLES
------------------------------------------------------------
CREATE TABLE Role (
    id INT IDENTITY PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Accion (
    id INT IDENTITY PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE RoleAccion (
    idRole INT NOT NULL,
    idAccion INT NOT NULL,
    PRIMARY KEY (idRole, idAccion),
    FOREIGN KEY (idRole) REFERENCES Role(id),
    FOREIGN KEY (idAccion) REFERENCES Accion(id)
);

CREATE TABLE UsuarioRole (
    idUsuario INT NOT NULL,
    idRole INT NOT NULL,
    PRIMARY KEY (idUsuario, idRole),
    FOREIGN KEY (idUsuario) REFERENCES Usuario(id),
    FOREIGN KEY (idRole) REFERENCES Role(id)
);

------------------------------------------------------------
-- Enumeraciones EstadoOrden / EstadoTarea / TipoProducto
------------------------------------------------------------
CREATE TABLE EstadoOrden (
    id INT IDENTITY PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE EstadoTarea (
    id INT IDENTITY PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE TipoProducto (
    id INT IDENTITY PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE
);

------------------------------------------------------------
-- PRODUCTO
------------------------------------------------------------
CREATE TABLE Producto (
    id INT IDENTITY PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    descripcion VARCHAR(500),
    unidadMedida VARCHAR(50),
    costoUnitario DECIMAL(18,2) NOT NULL,
    idTipoProducto INT NOT NULL,
    FOREIGN KEY (idTipoProducto) REFERENCES TipoProducto(id)
);

------------------------------------------------------------
-- ORDEN DE PRODUCCIÓN
------------------------------------------------------------
CREATE TABLE OrdenProduccion (
    id INT IDENTITY PRIMARY KEY,
    numeroOrden INT NOT NULL UNIQUE,
    fechaIngreso DATETIME NOT NULL,
    fechaProgramada DATETIME NOT NULL,
    idEstadoOrden INT NOT NULL,
    cantidadProgramada INT NOT NULL,
    tiempoEstimadoMin INT NOT NULL,
    maquinaria VARCHAR(150),
    creadoPor INT NOT NULL,
    actualizadoPor INT NULL,
    FOREIGN KEY (idEstadoOrden) REFERENCES EstadoOrden(id),
    FOREIGN KEY (creadoPor) REFERENCES Usuario(id),
    FOREIGN KEY (actualizadoPor) REFERENCES Usuario(id)
);

------------------------------------------------------------
-- TAREAS DE EJECUCIÓN
------------------------------------------------------------
CREATE TABLE TareaEjecucion (
    id INT IDENTITY PRIMARY KEY,
    idOrden INT NOT NULL,
    inicio DATETIME,
    fin DATETIME,
    cantidadProducida INT,
    descripcion VARCHAR(500),
    idEstadoTarea INT NOT NULL,
    idOperario INT NULL,
    FOREIGN KEY (idOrden) REFERENCES OrdenProduccion(id),
    FOREIGN KEY (idEstadoTarea) REFERENCES EstadoTarea(id),
    FOREIGN KEY (idOperario) REFERENCES Usuario(id)
);

------------------------------------------------------------
-- INCIDENTES
------------------------------------------------------------
CREATE TABLE Incidente (
    id INT IDENTITY PRIMARY KEY,
    idOrden INT NOT NULL,
    descripcion VARCHAR(500),
    fecha DATETIME NOT NULL,
    severidad VARCHAR(50),
    FOREIGN KEY (idOrden) REFERENCES OrdenProduccion(id)
);

------------------------------------------------------------
-- RELACIÓN ORDEN - PRODUCTOS
------------------------------------------------------------
CREATE TABLE OrdenProduccionProducto (
    id INT IDENTITY PRIMARY KEY,
    idOrdenProduccion INT NOT NULL,
    idProducto INT NOT NULL,
    descripcion VARCHAR(500),
    FOREIGN KEY (idOrdenProduccion) REFERENCES OrdenProduccion(id),
    FOREIGN KEY (idProducto) REFERENCES Producto(id)
);
