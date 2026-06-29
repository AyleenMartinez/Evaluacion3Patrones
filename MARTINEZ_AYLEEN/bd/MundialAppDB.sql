IF EXISTS (SELECT * FROM sys.databases WHERE name = 'MundialAppDB')
BEGIN
    ALTER DATABASE MundialAppDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MundialAppDB;
END
GO

CREATE DATABASE MundialAppDB;
GO

USE MundialAppDB;
GO

CREATE TABLE Paises (
    IdPais INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Region VARCHAR(50) NOT NULL,
    GolesAnotados INT DEFAULT 0,
    CodigoIso VARCHAR(2) NOT NULL
);
GO

CREATE TABLE Jugadores (
    IdJugador INT IDENTITY(1,1) PRIMARY KEY,
    Numero INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Rol VARCHAR(50) NOT NULL,
    IdPais INT NOT NULL,
    CONSTRAINT FK_Jugadores_Paises FOREIGN KEY (IdPais) REFERENCES Paises(IdPais)
);
GO

INSERT INTO Paises (Nombre, Region, GolesAnotados, CodigoIso) VALUES 
('Argentina', 'CONMEBOL', 15, 'ar'),
('Francia', 'UEFA', 16, 'fr'),
('Chile', 'CONMEBOL', 0, 'cl'),
('Brasil', 'CONMEBOL', 12, 'br'),
('Japon', 'AFC', 4, 'jp'),
('Alemania', 'UEFA', 10, 'de'),
('Espana', 'UEFA', 11, 'es'),
('Portugal', 'UEFA', 8, 'pt'),
('Uruguay', 'CONMEBOL', 6, 'uy'),
('Colombia', 'CONMEBOL', 5, 'co'),
('Mexico', 'CONCACAF', 3, 'mx'),
('Italia', 'UEFA', 7, 'it'),
('Inglaterra', 'UEFA', 9, 'gb'),
('Paises Bajos', 'UEFA', 8, 'nl'),
('Belgica', 'UEFA', 6, 'be'),
('Croacia', 'UEFA', 5, 'hr'),
('Estados Unidos', 'CONCACAF', 4, 'us'),
('Canada', 'CONCACAF', 2, 'ca'),
('Senegal', 'CAF', 3, 'sn'),
('Marruecos', 'CAF', 5, 'ma'),
('Corea del Sur', 'AFC', 4, 'kr'),
('Australia', 'AFC', 3, 'au'),
('Ecuador', 'CONMEBOL', 4, 'ec'),
('Peru', 'CONMEBOL', 2, 'pe'),
('Suiza', 'UEFA', 4, 'ch'),
('Dinamarca', 'UEFA', 3, 'dk'),
('Serbia', 'UEFA', 2, 'rs'),
('Polonia', 'UEFA', 3, 'pl'),
('Camerun', 'CAF', 2, 'cm'),
('Ghana', 'CAF', 3, 'gh'),
('Arabia Saudita', 'AFC', 2, 'sa'),
('Iran', 'AFC', 1, 'ir');
GO

INSERT INTO Jugadores (Numero, Nombre, Rol, IdPais) VALUES 
(1, 'C. Bravo', 'Arquero', 3),
(12, 'B. Cortes', 'Arquero', 3),
(4, 'M. Isla', 'Defensa', 3),
(5, 'P. Diaz', 'Defensa', 3),
(17, 'G. Medel', 'Defensa', 3),
(2, 'G. Suazo', 'Defensa', 3),
(8, 'A. Vidal', 'Mediocampista', 3),
(20, 'C. Aranguiz', 'Mediocampista', 3),
(13, 'E. Pulgar', 'Mediocampista', 3),
(10, 'A. Sanchez', 'Delantero', 3),
(11, 'E. Vargas', 'Delantero', 3),
(22, 'B. Brereton', 'Delantero', 3),

(23, 'E. Martinez', 'Arquero', 1),
(19, 'N. Otamendi', 'Defensa', 1),
(13, 'C. Romero', 'Defensa', 1),
(7, 'R. De Paul', 'Mediocampista', 1),
(20, 'A. Mac Allister', 'Mediocampista', 1),
(10, 'L. Messi', 'Delantero', 1),
(9, 'J. Alvarez', 'Delantero', 1),
(11, 'A. Di Maria', 'Delantero', 1),

(16, 'M. Maignan', 'Arquero', 2),
(22, 'T. Hernandez', 'Defensa', 2),
(14, 'A. Rabiot', 'Mediocampista', 2),
(7, 'A. Griezmann', 'Mediocampista', 2),
(10, 'K. Mbappe', 'Delantero', 2),
(11, 'O. Dembele', 'Delantero', 2),

(1, 'Alisson', 'Arquero', 4),
(4, 'Marquinhos', 'Defensa', 4),
(5, 'Casemiro', 'Mediocampista', 4),
(8, 'L. Paqueta', 'Mediocampista', 4),
(7, 'Vinicius Jr.', 'Delantero', 4),
(10, 'Rodrygo', 'Delantero', 4),

(1, 'M. Neuer', 'Arquero', 6),
(2, 'A. Rudiger', 'Defensa', 6),
(8, 'T. Kroos', 'Mediocampista', 6),
(10, 'J. Musiala', 'Mediocampista', 6),
(9, 'N. Fullkrug', 'Delantero', 6),

(23, 'U. Simon', 'Arquero', 7),
(14, 'A. Laporte', 'Defensa', 7),
(16, 'Rodri', 'Mediocampista', 7),
(8, 'Pedri', 'Mediocampista', 7),
(19, 'L. Yamal', 'Delantero', 7),

(22, 'D. Costa', 'Arquero', 8),
(3, 'Pepe', 'Defensa', 8),
(8, 'B. Fernandes', 'Mediocampista', 8),
(10, 'B. Silva', 'Mediocampista', 8),
(7, 'C. Ronaldo', 'Delantero', 8),
(17, 'R. Leao', 'Delantero', 8),

(1, 'S. Rochet', 'Arquero', 9),
(4, 'R. Araujo', 'Defensa', 9),
(15, 'F. Valverde', 'Mediocampista', 9),
(9, 'D. Nunez', 'Delantero', 9),

(1, 'C. Vargas', 'Arquero', 10),
(23, 'D. Sanchez', 'Defensa', 10),
(10, 'J. Rodriguez', 'Mediocampista', 10),
(7, 'L. Diaz', 'Delantero', 10),

(13, 'G. Ochoa', 'Arquero', 11),
(4, 'E. Alvarez', 'Mediocampista', 11),
(22, 'H. Lozano', 'Delantero', 11),

(1, 'G. Donnarumma', 'Arquero', 12),
(23, 'A. Bastoni', 'Defensa', 12),
(18, 'N. Barella', 'Mediocampista', 12),
(9, 'G. Scamacca', 'Delantero', 12),

(1, 'J. Pickford', 'Arquero', 13),
(5, 'J. Stones', 'Defensa', 13),
(10, 'J. Bellingham', 'Mediocampista', 13),
(9, 'H. Kane', 'Delantero', 13),

(1, 'B. Verbruggen', 'Arquero', 14),
(4, 'V. van Dijk', 'Defensa', 14),
(21, 'F. de Jong', 'Mediocampista', 14),
(8, 'C. Gakpo', 'Delantero', 14),

(1, 'T. Courtois', 'Arquero', 15),
(7, 'K. De Bruyne', 'Mediocampista', 15),
(9, 'R. Lukaku', 'Delantero', 15),

(1, 'D. Livakovic', 'Arquero', 16),
(10, 'L. Modric', 'Mediocampista', 16),
(9, 'A. Kramaric', 'Delantero', 16),

(1, 'M. Turner', 'Arquero', 17),
(10, 'C. Pulisic', 'Delantero', 17),

(19, 'A. Davies', 'Defensa', 18),
(20, 'J. David', 'Delantero', 18),

(16, 'E. Mendy', 'Arquero', 19),
(10, 'S. Mane', 'Delantero', 19),

(1, 'Y. Bounou', 'Arquero', 20),
(2, 'A. Hakimi', 'Defensa', 20),

(7, 'H. Son', 'Delantero', 21),

(1, 'M. Ryan', 'Arquero', 22),

(13, 'E. Valencia', 'Delantero', 23),
(25, 'K. Paez', 'Mediocampista', 23),

(1, 'P. Gallese', 'Arquero', 24),
(9, 'G. Lapadula', 'Delantero', 24),

(1, 'Y. Sommer', 'Arquero', 25),
(10, 'G. Xhaka', 'Mediocampista', 25),

(1, 'K. Schmeichel', 'Arquero', 26),
(10, 'C. Eriksen', 'Mediocampista', 26),

(9, 'A. Mitrovic', 'Delantero', 27),

(9, 'R. Lewandowski', 'Delantero', 28),

(24, 'A. Onana', 'Arquero', 29),

(20, 'M. Kudus', 'Mediocampista', 30),

(10, 'S. Al-Dawsari', 'Mediocampista', 31),

(9, 'M. Taremi', 'Delantero', 32);
GO