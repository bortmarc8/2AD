DROP DATABASE IF EXISTS `placemybet`;
CREATE DATABASE IF NOT EXISTS `placemybet`;
USE `placemybet`;

DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE IF NOT EXISTS `usuarios` (
  `email_id` varchar(256) NOT NULL,
  `nombre` varchar(256) NOT NULL,
  `apellido` varchar(256) NOT NULL,
  `edad` date NOT NULL,
  PRIMARY KEY (`email_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


DROP TABLE IF EXISTS `mercados`;
CREATE TABLE IF NOT EXISTS `mercados` (
  `mercado_id` int(11) NOT NULL,
  `dineroOver` float NOT NULL,
  `dineroUnder` float NOT NULL,
  `cuotaOver` float NOT NULL,
  `cuotaUnder` float NOT NULL,
  `tipo` enum('o_1_5','u_1_5','o_2_5','u_2_5','o_3_5','u_3_5') NOT NULL,
  PRIMARY KEY (`mercado_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


DROP TABLE IF EXISTS `cuentas`;
CREATE TABLE IF NOT EXISTS `cuentas` (
  `cuenta_id` int(11) NOT NULL AUTO_INCREMENT,
  `saldo` float NOT NULL,
  `nombreBanco` varchar(256) NOT NULL,
  `numTarjeta` varchar(20) NOT NULL DEFAULT '0000-0000-0000-0000',
  `email_ref` varchar(256) NOT NULL,
  PRIMARY KEY (`cuenta_id`),
  UNIQUE KEY `ref_Email_unique` (`email_ref`),
  KEY `ref_Email` (`email_ref`),
  CONSTRAINT `cuentas_ibfk_1` FOREIGN KEY (`email_ref`) REFERENCES `usuarios` (`email_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


DROP TABLE IF EXISTS `eventos`;
CREATE TABLE IF NOT EXISTS `eventos` (
  `eventos_id` int(11) NOT NULL,
  `local` varchar(256) NOT NULL,
  `visitante` varchar(256) NOT NULL,
  `mercado1_ref` int(11) DEFAULT NULL,
  `mercado2_ref` int(11) DEFAULT NULL,
  `mercado3_ref` int(11) DEFAULT NULL,
  PRIMARY KEY (`eventos_id`),
  KEY `mercado1` (`mercado1_ref`),
  KEY `mercado2` (`mercado2_ref`),
  KEY `mercado3` (`mercado3_ref`),
  CONSTRAINT `eventos_ibfk_1` FOREIGN KEY (`mercado1_ref`) REFERENCES `mercados` (`mercado_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `eventos_ibfk_2` FOREIGN KEY (`mercado2_ref`) REFERENCES `mercados` (`mercado_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `eventos_ibfk_3` FOREIGN KEY (`mercado3_ref`) REFERENCES `mercados` (`mercado_id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


DROP TABLE IF EXISTS `apuestas`;
CREATE TABLE IF NOT EXISTS `apuestas` (
  `apuesta_id` int(11) NOT NULL AUTO_INCREMENT,
  `mercado_ref` int(11) NOT NULL,
  `usuario_ref` varchar(256) NOT NULL,
  `dinero` float NOT NULL,
  PRIMARY KEY (`apuesta_id`),
  KEY `apuestas_index` (`apuesta_id`,`mercado_ref`,`usuario_ref`),
  KEY `usuario_ref` (`usuario_ref`),
  KEY `mercado_ref` (`mercado_ref`),
  CONSTRAINT `apuestas_ibfk_2` FOREIGN KEY (`usuario_ref`) REFERENCES `usuarios` (`email_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `apuestas_ibfk_3` FOREIGN KEY (`mercado_ref`) REFERENCES `mercados` (`mercado_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

DELETE FROM `apuestas`;
DELETE FROM `usuarios`;
DELETE FROM `cuentas`;
DELETE FROM `eventos`;
DELETE FROM `mercados`;

INSERT INTO `apuestas` (`apuesta_id`, `mercado_ref`, `usuario_ref`, `dinero`) VALUES
	(1, 0, 'bortmarc8', 15);

INSERT INTO `eventos` (`eventos_id`, `local`, `visitante`, `mercado1_ref`, `mercado2_ref`, `mercado3_ref`) VALUES
	(0, 'Heretics', 'G2 Esports', 0, 1, 2);

INSERT INTO `mercados` (`mercado_id`, `dineroOver`, `dineroUnder`, `cuotaOver`, `cuotaUnder`, `tipo`) VALUES
	(0, 0, 0, 0, 0, 'o_1_5'),
	(1, 0, 0, 0, 0, 'o_2_5'),
	(2, 0, 0, 0, 0, 'o_3_5');

INSERT INTO `usuarios` (`email_id`, `nombre`, `apellido`, `edad`) VALUES
	('bortmarc8', 'Mark', 'Bort Tomás', '2001-03-14');


