
IF DB_ID('BDControlAsistencia') IS NOT NULL
BEGIN
    DROP DATABASE BDControlAsistencia;
END
GO


CREATE DATABASE BDControlAsistencia;
GO


USE BDControlAsistencia;
GO


IF OBJECT_ID('dbo.TUsuario') IS NULL
BEGIN
    CREATE TABLE dbo.TUsuario (
        CodUsuario VARCHAR(50) PRIMARY KEY,
        Contrasena VARBINARY(8000) NOT NULL
    );
END
GO


IF OBJECT_ID('dbo.TAlumno') IS NULL
BEGIN
    CREATE TABLE dbo.TAlumno (
        IdAlumno INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Telefono VARCHAR(20) NOT NULL,
        CodUsuario VARCHAR(50) NOT NULL,
        FOREIGN KEY (CodUsuario) REFERENCES dbo.TUsuario(CodUsuario)
    );
END
GO


IF OBJECT_ID('dbo.TAuxiliar') IS NULL
BEGIN
    CREATE TABLE dbo.TAuxiliar (
        IdAuxiliar INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Telefono VARCHAR(20) NOT NULL,
        CodUsuario VARCHAR(50) NOT NULL,
        FOREIGN KEY (CodUsuario) REFERENCES dbo.TUsuario(CodUsuario)
    );
END
GO


IF OBJECT_ID('dbo.TDocente') IS NULL
BEGIN
    CREATE TABLE dbo.TDocente (
        IdDocente INT PRIMARY KEY IDENTITY(1,1),
        Nombre VARCHAR(100) NOT NULL,
        Telefono VARCHAR(20) NOT NULL,
        CodUsuario VARCHAR(50) NOT NULL,
        FOREIGN KEY (CodUsuario) REFERENCES dbo.TUsuario(CodUsuario)
    );
END
GO


IF OBJECT_ID('dbo.TAsistencia') IS NULL
BEGIN
    CREATE TABLE dbo.TAsistencia (
        IdAsistencia INT PRIMARY KEY IDENTITY(1,1),
        IdAlumno INT NOT NULL,
        Fecha DATE NOT NULL,
        Estado VARCHAR(20) NOT NULL, -- Ej. 'Presente', 'Ausente'
        FOREIGN KEY (IdAlumno) REFERENCES dbo.TAlumno(IdAlumno)
    );
END
GO




IF OBJECT_ID('spLogin') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spLogin;
END
GO

CREATE PROCEDURE dbo.spLogin
    @CodUsuario VARCHAR(50),
    @Contrasena VARCHAR(50)
AS
BEGIN
    DECLARE @ContrasenaEncriptada VARBINARY(8000);
    DECLARE @ContrasenaDesencriptada VARCHAR(50);

    -- Obtener la contraseña encriptada de la base de datos
    SELECT @ContrasenaEncriptada = Contrasena
    FROM dbo.TUsuario
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
        ELSE IF EXISTS (SELECT CodUsuario FROM dbo.TDocente WHERE CodUsuario = @CodUsuario)
        BEGIN
            SELECT CodError = 0, Mensaje = 'Docente';
        END
        ELSE IF EXISTS (SELECT CodUsuario FROM dbo.TAuxiliar WHERE CodUsuario = @CodUsuario)
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
	
IF OBJECT_ID('dbo.spCambiarContrasena') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spCambiarContrasena;
END
GO

CREATE PROCEDURE dbo.spCambiarContrasena
    @CodUsuario VARCHAR(50),
    @ContrasenaActual VARCHAR(50),
    @NuevaContrasena VARCHAR(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.TUsuario WHERE CodUsuario = @CodUsuario AND CONVERT(VARCHAR(50), DECRYPTBYPASSPHRASE('miFraseDeContraseña', Contrasena)) = @ContrasenaActual)
    BEGIN
        UPDATE dbo.TUsuario
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




INSERT INTO dbo.TUsuario (CodUsuario, Contrasena) VALUES 
('admin', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('juan.perez@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('maria.lopez@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('pedro.ramirez@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('alumno1@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('auxiliar1@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('docente1@example.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234'));


INSERT INTO dbo.TAlumno (Nombre, Telefono, CodUsuario) VALUES 
('Juan Pérez', '123456789', 'alumno1@example.com');


INSERT INTO dbo.TAuxiliar (Nombre, Telefono, CodUsuario) VALUES 
('Ana López', '987654321', 'auxiliar1@example.com');


INSERT INTO dbo.TDocente (Nombre, Telefono, CodUsuario) VALUES 
('Pedro Ramírez', '555444333', 'docente1@example.com');


INSERT INTO dbo.TAsistencia (IdAlumno, Fecha, Estado) VALUES 
(1, '2024-09-01', 'Presente'),
(1, '2024-09-02', 'Ausente');
GO


SELECT * FROM dbo.TUsuario;
SELECT * FROM dbo.TAlumno;
SELECT * FROM dbo.TAuxiliar;
SELECT * FROM dbo.TDocente;
SELECT * FROM dbo.TAsistencia;
GO
