DROP TABLE IF EXISTS filme;
DROP TABLE IF EXISTS diretor;
DROP TABLE IF EXISTS genero;
DROP TABLE IF EXISTS filme_genero;


CREATE TABLE diretor (
	cd_diretor INT PRIMARY KEY IDENTITY(1, 1),
	nm_diretor NVARCHAR(255) NOT NULL
);

CREATE TABLE filme (
	cd_filme INT PRIMARY KEY IDENTITY(1, 1),
	nm_filme NVARCHAR(255) NOT NULL,
	nm_original_filme NVARCHAR(255) NOT NULL,
	dt_ano_lancamento INT,
	nm_faixa_etaria NVARCHAR(255) NOT NULL,
	qt_duracao_filme TIME,
	qt_avaliacao_filme DECIMAL(3,1),
	ds_sinopse_filme TEXT NOT NULL,
	cd_diretor INT NOT NULL,

	CONSTRAINT fk_diretor_filme FOREIGN KEY (cd_diretor) REFERENCES diretor(cd_diretor)
);

CREATE TABLE genero (
	cd_genero INT PRIMARY KEY IDENTITY(1, 1),
	nm_genero NVARCHAR(50) NOT NULL
);

CREATE TABLE filme_genero (
	cd_filme INT,
	cd_genero INT,

	CONSTRAINT pk_filme_genero PRIMARY KEY (cd_filme, cd_genero),
	CONSTRAINT fk_filme_filme_genero FOREIGN KEY (cd_filme) REFERENCES filme(cd_filme) ON DELETE CASCADE,
	CONSTRAINT FK_genero_filme_genero FOREIGN KEY (cd_genero) REFERENCES genero(cd_genero) ON DELETE CASCADE
);


INSERT INTO diretor (nm_diretor) VALUES 
('Christopher Nolan'),
('Quentin Tarantino'),
('Steven Spielberg'),
('Martin Scorsese'),
('James Cameron');

INSERT INTO genero (nm_genero) VALUES 
('Ação'),
('Drama'),
('Ficção Científica'),
('Comédia'),
('Animação'),
('Suspense'),
('Fantasia');


INSERT INTO filme (nm_filme, nm_original_filme, dt_ano_lancamento, nm_faixa_etaria, qt_duracao_filme, qt_avaliacao_filme, ds_sinopse_filme, cd_diretor) VALUES
('Inception', 'Inception', 2010, 14, '02:28:00', 8.8, 'Um filme sobre sonhos e espionagem no subconsciente.', 1),
('Pulp Fiction', 'Pulp Fiction', 1994, 18, '02:34:00', 8.9, 'Histórias interligadas de crime e redenção em Los Angeles.', 2),
('Jurassic Park', 'Jurassic Park', 1993, 12, '02:07:00', 8.1, 'Dinossauros trazidos de volta à vida causam caos em um parque temático.', 3),
('O Lobo de Wall Street', 'The Wolf of Wall Street', 2013, 18, '03:00:00', 8.2, 'A vida e os excessos de um corretor de ações corrupto.', 4),
('Avatar', 'Avatar', 2009, 12, '02:42:00', 7.9, 'Um humano se junta aos Na’vi em Pandora.', 5),
('Titanic', 'Titanic', 1997, 12, '03:14:00', 7.8, 'Uma história de amor a bordo do trágico RMS Titanic.', 5),
('E.T.', 'E.T. the Extra-Terrestrial', 1982, 10, '01:55:00', 7.9, 'Um garoto faz amizade com um alienígena perdido na Terra.', 3),
('Django Livre', 'Django Unchained', 2012, 18, '02:45:00', 8.4, 'Um escravo liberto busca resgatar sua esposa.', 2),
('A Origem', 'Inception', 2010, 14, '02:28:00', 8.8, 'Uma equipe invade sonhos para manipular memórias.', 1),
('O Resgate do Soldado Ryan', 'Saving Private Ryan', 1998, 16, '02:49:00', 8.6, 'Soldados procuram um paraquedista durante a Segunda Guerra Mundial.', 3);

-- Inception
INSERT INTO filme_genero (cd_filme, cd_genero) VALUES (1, 1), (1, 3), (1, 6);

-- Pulp Fiction
INSERT INTO filme_genero (cd_filme, cd_genero) VALUES (2, 2), (2, 6);

-- Jurassic Park
INSERT INTO filme_genero (cd_filme, cd_genero) VALUES (3, 3), (3, 1), (3, 7);

-- O Lobo de Wall Street
INSERT INTO filme_genero (cd_filme, cd_genero) VALUES (4, 2);

-- Avatar
INSERT INTO filme_genero (cd_filme, cd_genero) VALUES (5, 3), (5, 7);

-- Titanic
INSERT INTO filme_genero (cd_filme, cd_genero) VALUES (6, 2), (6, 7);

-- E.T.
INSERT INTO filme_genero (cd_filme, cd_genero) VALUES (7, 3), (7, 7);

-- Django Livre
INSERT INTO filme_genero (cd_filme, cd_genero) VALUES (8, 2), (8, 1);

-- A Origem
INSERT INTO filme_genero (cd_filme, cd_genero) VALUES (9, 1), (9, 3);

-- O Resgate do Soldado Ryan
INSERT INTO filme_genero (cd_filme, cd_genero) VALUES (10, 1), (10, 2);