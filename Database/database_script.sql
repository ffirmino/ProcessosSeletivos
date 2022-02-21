/*
 * Back-end Webmotors
 *
 * Fabio Firmino
 * 
 */

CREATE DATABASE teste_webmotors

GO

CREATE TABLE teste_webmotors..tb_AnuncioWebmotors(
	ID INT IDENTITY NOT NULL,
	marca VARCHAR(45) NOT NULL,
	modelo VARCHAR(45) NOT NULL,
	versao VARCHAR(45) NOT NULL,
	ano INT NOT NULL,
	quilometragem INT NOT NULL,
	observacao TEXT NOT NULL
)
