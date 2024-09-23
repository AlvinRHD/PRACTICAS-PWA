--Crear la base de datos.
CREATE DATABASE Hospital;
GO
USE Hospital;

--Crear las tablas correspondiente.
--paciente
CREATE TABLE Pacientes(
PacienteID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(30),
Edad INT, 
Genero VARCHAR(20),
Direccion VARCHAR(50),
Telefono VARCHAR(20),
FechaIngreso DATE,
FechaSalida DATE,
)

--medico
CREATE TABLE Medicos(
MedicoID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(40),
Especialidad VARCHAR(30),
)

--administrativo
CREATE TABLE Administrativo(
AdministrativoID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR (40),
Puesto VARCHAR (20),
)

--departamento
CREATE TABLE Departamentos(
DepartamentoID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(40),
)

--diagnosticos
CREATE TABLE Diagnosticos(
DiagnosticoID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(30),
Descripcion VARCHAR(200),
)

--tratamiento
CREATE TABLE Tratamientos(
TratamientoID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(40),
Descripcion VARCHAR(200),
CuantoDuro VARCHAR(90)
)

--medicina
CREATE TABLE Medicamentos(
MedicamentoID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(60),
)

--Establecer las relaciones
--consulta medica
CREATE TABLE Consulta(
ConsultaID INT PRIMARY KEY IDENTITY(1,1),
PacienteID INT,
MedicoID INT,
AdministrativoID INT,
DepartamentoID INT,
DiagnosticoID INT,
TratamientoID INT,
FOREIGN KEY (PacienteID) REFERENCES Pacientes(PacienteID),
FOREIGN KEY (MedicoID) REFERENCES Medicos(MedicoID),
FOREIGN KEY (AdministrativoID) REFERENCES Administrativo(AdministrativoID),
FOREIGN KEY (DepartamentoID) REFERENCES Departamentos(DepartamentoID),
FOREIGN KEY (DiagnosticoID) REFERENCES Diagnosticos(DiagnosticoID),
FOREIGN KEY (TratamientoID) REFERENCES Tratamientos(TratamientoID),
)



--Insertar al menos 2 datos por cada tabla
INSERT INTO Pacientes (Nombre, Edad, Genero, Direccion, Telefono, FechaIngreso, FechaSalida) VALUES ('Alvin Rosales', '20', 'M', 'Col.Fatima', '1212-1212', '1/12/2024', '5/12/2024');
INSERT INTO Pacientes (Nombre, Edad, Genero, Direccion, Telefono, FechaIngreso, FechaSalida) VALUES ('Wilfredo Vanegas', '19', 'M', 'Barrio Gasolina', '1212-1212', '1/12/2024', '5/12/2024');



INSERT INTO Medicos (Nombre, Especialidad) VALUES ('Dr.Carlos', 'Psicologo');
INSERT INTO Medicos (Nombre, Especialidad) VALUES ('Dr.Carlos', 'Psicologo');



INSERT INTO Administrativo (Nombre, Puesto) VALUES ('Pedro Ramos', 'Recepcionista');
INSERT INTO Administrativo (Nombre, Puesto) VALUES ('Pedro Ramos', 'Recepcionista');



INSERT INTO Departamentos (Nombre) VALUES ('Psicologia');
INSERT INTO Departamentos (Nombre) VALUES ('Psicologia');



INSERT INTO Diagnosticos (Nombre, Descripcion) VALUES ('Salud', 'Mental');
INSERT INTO Diagnosticos (Nombre, Descripcion) VALUES ('Salud', 'Mental');


INSERT INTO Tratamientos (Nombre, Descripcion, CuantoDuro) VALUES ('Control de enojo', 'Meditacion y monitorear', '30 días');
INSERT INTO Tratamientos (Nombre, Descripcion, CuantoDuro) VALUES ('Control de enojo', 'Meditacion y monitorear', '30 días');



INSERT INTO Medicamentos (Nombre) VALUES ('Acetaminofen');
INSERT INTO Medicamentos (Nombre) VALUES ('Acetaminofen');


INSERT INTO Consulta (PacienteID, MedicoID, AdministrativoID, DepartamentoID, DiagnosticoID, TratamientoID) VALUES (1, 1, 1, 1, 1, 1);
INSERT INTO Consulta (PacienteID, MedicoID, AdministrativoID, DepartamentoID, DiagnosticoID, TratamientoID) VALUES (2, 2, 2, 2, 2, 2);



SELECT c.ConsultaID, p.Nombre as Paciente, m.Nombre as Medico, d.Nombre as Diagnostico, t.Nombre as Tratamiento FROM Consulta as c INNER JOIN Pacientes as p on c.PacienteID = p.PacienteID INNER JOIN Medicos as m on c.MedicoID = m.MedicoID INNER JOIN Diagnosticos as d on c.DiagnosticoID = d.DiagnosticoID INNER JOIN Tratamientos as t on c.TratamientoID = t.TratamientoID;



---SELECT c.ConsultaID, a.Nombre as Administrativo, dept.Nombre as Departamento, med.Nombre as Medicamento
---FROM Consulta as c
---INNER JOIN Administrativo as a ON c.AdministrativoID = a.AdministrativoID
---INNER JOIN Departamentos as dept ON c.DepartamentoID = dept.DepartamentoID
---INNER JOIN Tratamientos as tr ON c.TratamientoID = tr.TratamientoID
---INNER JOIN Medicamentos as med ON tr.MedicamentoID = med.MedicamentoID;
