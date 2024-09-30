
--******************************************************

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

IF OBJECT_ID('TCurso') IS NULL 
BEGIN
    CREATE TABLE TCurso (
        IdCurso INT PRIMARY KEY IDENTITY(1,1),
        NombreCurso VARCHAR(100) NOT NULL,
        Descripcion VARCHAR(100) NOT NULL,
		Nivel VARCHAR(50) NOT NULL,
        IdDocente INT NOT NULL,
        FOREIGN KEY (IdDocente) REFERENCES TDocente(IdDocente)
    );
END
GO

IF OBJECT_ID('TAsistencia') IS NULL
BEGIN
    CREATE TABLE TAsistencia (
        IdAsistencia INT PRIMARY KEY IDENTITY(1,1),
        IdAlumno INT NOT NULL,
        IdCurso INT NOT NULL, 
        Fecha DATE NOT NULL,
        Periodo VARCHAR(20),
        Estado VARCHAR(20) NOT NULL, 
        FOREIGN KEY (IdAlumno) REFERENCES TAlumno(IdAlumno),
        FOREIGN KEY (IdCurso) REFERENCES TCurso(IdCurso) 
    );
END
GO

IF OBJECT_ID('TInscripcion') IS NULL
BEGIN
    CREATE TABLE TInscripcion (
        IdInscripcion INT PRIMARY KEY IDENTITY(1,1),
        IdAlumno INT NOT NULL,
        IdCurso INT NOT NULL,
        FOREIGN KEY (IdAlumno) REFERENCES TAlumno(IdAlumno),
        FOREIGN KEY (IdCurso) REFERENCES TCurso(IdCurso)
    );
END
GO

INSERT INTO TUsuario (CodUsuario, Contrasena) VALUES 
('admin', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('juan.perez@gmail.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('maria.lopez@gmail.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('pedro.ramirez@gmail.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('alumno1@gmail.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('alumno2@gmail.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('auxiliar1@gmail.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('docente1@gmail.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234')),
('docente2@gmail.com', ENCRYPTBYPASSPHRASE('miFraseDeContraseña', '1234'));
GO


INSERT INTO TAlumno (Nombre, Telefono, CodUsuario, CursoGrado, Nivel, Direccion) VALUES 
('Juan Pérez', '123456789', 'alumno1@gmail.com', '1', 'Primaria', 'Av. Pasaje'),
('Ana Gómez', '987654321', 'alumno2@gmail.com', '2', 'Primaria', 'Calle Falsa');


INSERT INTO TAuxiliar (Nombre, Telefono, CodUsuario) VALUES 
('Ana López', '987654321', 'auxiliar1@gmail.com');
GO

INSERT INTO TDocente (Nombre, Telefono, CodUsuario) VALUES 
('Pedro Ramírez', '555444333', 'docente1@gmail.com'),
('María López', '444555666', 'docente2@gmail.com');



INSERT INTO TCurso (NombreCurso, Descripcion, Nivel, IdDocente) VALUES 
('Matemáticas', 'Matemáticas Básicas', 'Primaria', 1),
('Ciencias', 'Ciencias Naturales', 'Primaria', 1),
('Lengua', 'Lengua y Literatura', 'Secundaria', 2),
('Historia', 'Historia General', 'Secundaria', 2),  
('Física', 'Física Básica', 'Secundaria', 1);      
GO


INSERT INTO TInscripcion (IdAlumno, IdCurso) VALUES 
(1, 1), 
(1, 2), 
(2, 1), 
(2, 3); 


INSERT INTO TAsistencia (IdAlumno, IdCurso, Fecha, Estado) VALUES 
(1, 1, '2024-09-01', 'Presente'), 
(1, 2, '2024-09-02', 'Falta'), 
(2, 1, '2024-09-01', 'Presente'), 
(2, 3, '2024-09-02', 'Presente');



SELECT * FROM TDocente;
SELECT * FROM TUsuario;
SELECT * FROM TAlumno;
SELECT * FROM TAuxiliar;
SELECT * FROM TAsistencia;
SELECT * FROM TCurso;
SELECT * FROM TInscripcion; 
GO

--******************************

--********************************************--
