
IF DB_ID('BDControlAsistencia') IS NOT NULL
BEGIN
    DROP DATABASE BDControlAsistencia;
END
GO


CREATE DATABASE BDControlAsistencia;
GO


USE BDControlAsistencia;
GO


IF OBJECT_ID('TUsuario') IS NULL
BEGIN
    CREATE TABLE TUsuario (
        IdUsuario INT IDENTITY(1,1),
        CodUsuario VARCHAR(50) PRIMARY KEY,
        Contrasena VARBINARY(8000) NOT NULL
    );
END
GO

IF OBJECT_ID('TAlumno') IS NULL
BEGIN
    CREATE TABLE TAlumno (
        IdAlumno INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Telefono VARCHAR(20) NOT NULL,
        CodUsuario VARCHAR(50) NOT NULL,
        CursoGrado VARCHAR(50) NOT NULL,
        Nivel VARCHAR(50) NOT NULL,
        Direccion NVARCHAR(255) NOT NULL,
        FOREIGN KEY (CodUsuario) REFERENCES TUsuario(CodUsuario)
    );
END
GO


IF OBJECT_ID('TAuxiliar') IS NULL
BEGIN
    CREATE TABLE TAuxiliar (
        IdAuxiliar INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Telefono VARCHAR(20) NOT NULL,
        CodUsuario VARCHAR(50) NOT NULL,
        FOREIGN KEY (CodUsuario) REFERENCES TUsuario(CodUsuario)
    );
END
GO


IF OBJECT_ID('TDocente') IS NULL
BEGIN
    CREATE TABLE TDocente (
        IdDocente INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Telefono VARCHAR(20) NOT NULL,
        CodUsuario VARCHAR(50) NOT NULL,
        FOREIGN KEY (CodUsuario) REFERENCES TUsuario(CodUsuario)
    );
END
GO


IF OBJECT_ID('TAsistencia') IS NULL
BEGIN
    CREATE TABLE TAsistencia (
        IdAsistencia INT PRIMARY KEY IDENTITY(1,1),
        IdAlumno INT NOT NULL,
        Fecha DATE NOT NULL,
        Estado VARCHAR(20) NOT NULL, -- Ej. 'Presente', 'Ausente'
        FOREIGN KEY (IdAlumno) REFERENCES TAlumno(IdAlumno)
    );
END
GO


IF OBJECT_ID('TAsignatura') IS NULL
BEGIN
    CREATE TABLE TAsignatura (
        IdAsignatura INT PRIMARY KEY IDENTITY(1,1),
        NombreAsignatura VARCHAR(100) NOT NULL,
		DescripcionAsignatura VARCHAR(100) NOT NULL,
        IdDocente INT NOT NULL,
        FOREIGN KEY (IdDocente) REFERENCES TDocente(IdDocente)
    );
END
GO


INSERT INTO TUsuario (CodUsuario, Contrasena) VALUES 
('admin', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('juan.perez@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('maria.lopez@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('pedro.ramirez@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('alumno1@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('auxiliar1@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('docente1@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('docente2@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234'));
GO


INSERT INTO TAlumno (Nombre, Telefono, CodUsuario, CursoGrado, Nivel, Direccion) VALUES 
('Juan Pérez', '123456789', 'alumno1@example.com', '1', 'Primaria', 'Av. Pasaje');
GO


INSERT INTO TAuxiliar (Nombre, Telefono, CodUsuario) VALUES 
('Ana López', '987654321', 'auxiliar1@example.com');
GO

INSERT INTO TDocente (Nombre, Telefono, CodUsuario) VALUES 
('Pedro Ramírez', '555444333', 'docente1@example.com');
GO


INSERT INTO TAsistencia (IdAlumno, Fecha, Estado) VALUES 
(1, '2024-09-01', 'Presente'),
(1, '2024-09-02', 'Ausente');
GO


INSERT INTO TAsignatura (NombreAsignatura,DescripcionAsignatura, IdDocente) VALUES 
('Matemáticas', 'eeee',1),
('Lengua','eee', 1);
GO


SELECT * FROM TDocente;
SELECT * FROM TUsuario;
SELECT * FROM TAlumno;
SELECT * FROM TAuxiliar;
SELECT * FROM TAsistencia;
SELECT * FROM TAsignatura;
GO

IF OBJECT_ID('spLogin') IS NOT NULL
BEGIN
    DROP PROCEDURE spLogin;
END
GO

CREATE PROCEDURE spLogin
    @CodUsuario VARCHAR(50),
    @Contrasena VARCHAR(50)
AS
BEGIN
    DECLARE @ContrasenaEncriptada VARBINARY(8000);
    DECLARE @ContrasenaDesencriptada VARCHAR(50);

    -- Obtener la contraseña encriptada de la base de datos
    SELECT @ContrasenaEncriptada = Contrasena
    FROM TUsuario
    WHERE CodUsuario = @CodUsuario;

    -- Desencriptar la contraseña almacenada
    SET @ContrasenaDesencriptada = CONVERT(VARCHAR(50), DECRYPTBYPASSPHRASE('miFraseDeContraseña', @ContrasenaEncriptada));

    -- Comparar la contraseña desencriptada con la proporcionada
    IF @ContrasenaDesencriptada = @Contrasena
    BEGIN
	
        IF @CodUsuario = 'admin'
        BEGIN
            SELECT CodError = 0, Mensaje = 'Administrador';
        END
        ELSE IF EXISTS (SELECT CodUsuario FROM TDocente WHERE CodUsuario = @CodUsuario)
        BEGIN
            SELECT CodError = 0, Mensaje = 'Docente';
        END
        ELSE IF EXISTS (SELECT CodUsuario FROM TAuxiliar WHERE CodUsuario = @CodUsuario)
        BEGIN
            SELECT CodError = 0, Mensaje = 'Auxiliar';
        END
		ELSE IF EXISTS (SELECT CodUsuario FROM dbo.TAlumno WHERE CodUsuario = @CodUsuario)
        BEGIN
            SELECT CodError = 0, Mensaje = 'Alumno';
        END
        ELSE
        BEGIN
            SELECT CodError = 1, Mensaje = 'Error: Usuario no tiene privilegio de cliente ni docente, auxiliar, consulte al administrador';
        END
    END
    ELSE
    BEGIN
        SELECT CodError = 1, Mensaje = 'Error: Usuario y/o contraseña incorrectos';
    END
END
GO
	
IF OBJECT_ID('spCambiarContrasena') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spCambiarContrasena;
END
GO

CREATE PROCEDURE spCambiarContrasena
    @CodUsuario VARCHAR(50),
    @ContrasenaActual VARCHAR(50),
    @NuevaContrasena VARCHAR(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM TUsuario WHERE CodUsuario = @CodUsuario AND CONVERT(VARCHAR(50), DECRYPTBYPASSPHRASE('miFraseDeContraseña', Contrasena)) = @ContrasenaActual)
    BEGIN
        UPDATE TUsuario
        SET Contrasena = ENCRYPTBYPASSPHRASE('miFraseDeContraseña', @NuevaContrasena)
        WHERE CodUsuario = @CodUsuario;
        
        SELECT 'Contraseña actualizada exitosamente' AS Mensaje;
    END
    ELSE
    BEGIN
        SELECT 'Error: Contraseña actual incorrecta' AS Mensaje;
    END
END
GO