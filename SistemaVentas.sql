CREATE DATABASE SistemaVentas;
USE SistemaVentas;

-- ======================================================
-- SCRIPT DE CREACIÓN DE TABLAS EN SQL SERVER
-- ======================================================

-- Tabla de Clientes: Guarda la información básica de los clientes.
CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    TipoDocumento VARCHAR(15), -- Ej: 'DNI', 'RUC' , Pasaporte
    NumeroDocumento VARCHAR(10) UNIQUE NOT NULL,
    Nombres VARCHAR(30) NOT NULL,
	Apellidos VARCHAR(60),
    Telefono VARCHAR(9)
);
GO

-- Tabla de Usuarios: Almacena los usuarios del sistema para el acceso.
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario VARCHAR(20) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Rol VARCHAR(15) NOT NULL
);
GO

-- Tabla de Productos: Registra los productos que se venden.
CREATE TABLE Producto (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    CodigoBarras VARCHAR(50) UNIQUE NOT NULL,
    PrecioVenta DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);
GO

-- Tabla de Ventas: Registra cada transacción de venta y sus montos.
CREATE TABLE Venta (
    IdVenta INT PRIMARY KEY IDENTITY(1,1),
    FechaVenta DATETIME NOT NULL DEFAULT GETDATE(),
    Subtotal DECIMAL(10, 2) NOT NULL,
    MontoIGV DECIMAL(10, 2) NOT NULL,
    MontoTotal DECIMAL(10, 2) NOT NULL,
    IdCliente INT,
    IdUsuario INT NOT NULL,
    
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);
GO

-- Tabla de Detalle de Venta: Vincula productos específicos con cada venta.
CREATE TABLE DetalleVenta (
    IdDetalleVenta INT PRIMARY KEY IDENTITY(1,1),
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    
    FOREIGN KEY (IdVenta) REFERENCES Ventas(IdVenta),
    FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);
GO