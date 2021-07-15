USE master

USE lab
CREATE TABLE Utilizador(
	nome				VARCHAR(35) NOT NULL,
	email				VARCHAR(35) NOT NULL,
	username			VARCHAR(20) PRIMARY KEY NOT NULL,
	pass_word			VARCHAR(20) NOT NULL,
	foto				VARCHAR(50),
	ContaConfirmada		BIT DEFAULT(0) NOT NULL,
);

USE lab
CREATE TABLE Cliente(
	Username				VARCHAR(20) PRIMARY KEY  NOT NULL,
	FOREIGN KEY (Username) references Utilizador(username),
);

USE lab
CREATE TABLE Prato_Dia(
	ID			INTEGER NOT NULL,
	Nome		VARCHAR(35) NOT NULL,
	tipo		VARCHAR(15) NOT NULL,
	preco		FLOAT NOT NULL,
	descricao	VARCHAR(100) NOT NULL,
	foto		VARCHAR(50),
	PRIMARY KEY(ID),
);

CREATE TABLE PratosFavoritos(
	UsernameCliente			VARCHAR(20)  NOT NULL,
	Id_Prato				INT PRIMARY KEY NOT NULL,
	FOREIGN KEY (UsernameCliente) references Cliente(Username),
	FOREIGN KEY (Id_Prato) references Prato_Dia(ID),
);

USE lab
CREATE TABLE Administrador(
	Username	VARCHAR(20) PRIMARY KEY NOT NULL,
	FOREIGN KEY (Username) references Utilizador(username),
	
);

USE lab
CREATE TABLE Restaurante(
	Username				VARCHAR(20) PRIMARY KEY NOT NULL,
    Nome					VARCHAR(35) NOT NULL,
	morada					VARCHAR(50) NOT NULL,				
	telefone				INT NOT NULL,
	gps						VARCHAR(50) NOT NULL,
	horario					VARCHAR(100) NOT NULL,
	Dia_Descanso			VARCHAR(25) NOT NULL,
	tipo_servico			VARCHAR(50) NOT NULL,
	Foto					Varchar(50) NOT NULL,
	QuemAprovou				Varchar(20),
	FOREIGN KEY (Username) references Utilizador(username),

);

CREATE TABLE RestaurantesFavoritos(
	UsernameCliente				VARCHAR(20)  NOT NULL,
	UsernameRestaurante			VARCHAR(20) PRIMARY KEY  NOT NULL,
	FOREIGN KEY (UsernameCliente) references Cliente(Username),
	FOREIGN KEY (UsernameRestaurante) references Restaurante(Username),
);

USE lab
CREATE TABLE Bloquear(
	Username_Administrador	VARCHAR(20) NOT NULL,
	Username_Utilizador		VARCHAR(20) NOT NULL,
	motivo					VARCHAR(50) NOT NULL,
	DataBloqueio			DATE NOT NULL,
	PRIMARY KEY(Username_Utilizador,DataBloqueio),
	FOREIGN KEY (Username_Administrador) references Administrador(Username),
	FOREIGN KEY (Username_Utilizador) references Utilizador(username),
);




USE lab
CREATE TABLE Avaliar_restaurates(
	Username_Restaurante	VARCHAR(20)  NOT NULL,
	Username_Cliente		VARCHAR(20)  NOT NULL,
	avaliacao		INTEGER,
	comentario		VARCHAR(50),
	PRIMARY KEY(Username_Restaurante,Username_Cliente),
	FOREIGN KEY (Username_Cliente) REFERENCES Cliente(Username),
	FOREIGN KEY (Username_Restaurante) REFERENCES Restaurante(Username),
);

USE lab
CREATE TABLE Avaliar_pratos(
	Id_prato	INT  NOT NULL,
	Username_Cliente		VARCHAR(20)  NOT NULL,
	avaliacao INTEGER,
	comentario VARCHAR(50),
	PRIMARY KEY(Username_Cliente,Id_prato),
	FOREIGN KEY (Username_Cliente) REFERENCES Cliente(Username),
	FOREIGN KEY (Id_prato) REFERENCES Prato_dia(ID),
	
);

USE lab
CREATE TABLE Possuir(
	ID_Prato				INT NOT NULL,
	Username_Restaurante	VARCHAR(20) NOT NULL,
	Data_PratoDia			DATE NOT NULL,
	PRIMARY KEY(ID_Prato,Username_Restaurante),
	FOREIGN KEY (Username_Restaurante) references Restaurante(Username),
	FOREIGN KEY (ID_Prato) references Prato_Dia(ID),
);