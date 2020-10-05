-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.4.14-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para placemybet
DROP DATABASE IF EXISTS `placemybet`;
CREATE DATABASE IF NOT EXISTS `placemybet` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `placemybet`;

-- Volcando estructura para tabla placemybet.apuestas
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

-- Volcando datos para la tabla placemybet.apuestas: ~0 rows (aproximadamente)
DELETE FROM `apuestas`;
/*!40000 ALTER TABLE `apuestas` DISABLE KEYS */;
/*!40000 ALTER TABLE `apuestas` ENABLE KEYS */;

-- Volcando estructura para tabla placemybet.cuentas
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

-- Volcando datos para la tabla placemybet.cuentas: ~0 rows (aproximadamente)
DELETE FROM `cuentas`;
/*!40000 ALTER TABLE `cuentas` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuentas` ENABLE KEYS */;

-- Volcando estructura para tabla placemybet.eventos
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

-- Volcando datos para la tabla placemybet.eventos: ~0 rows (aproximadamente)
DELETE FROM `eventos`;
/*!40000 ALTER TABLE `eventos` DISABLE KEYS */;
/*!40000 ALTER TABLE `eventos` ENABLE KEYS */;

-- Volcando estructura para tabla placemybet.mercados
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

-- Volcando datos para la tabla placemybet.mercados: ~0 rows (aproximadamente)
DELETE FROM `mercados`;
/*!40000 ALTER TABLE `mercados` DISABLE KEYS */;
/*!40000 ALTER TABLE `mercados` ENABLE KEYS */;

-- Volcando estructura para tabla placemybet.usuarios
DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE IF NOT EXISTS `usuarios` (
  `email_id` varchar(256) NOT NULL,
  `nombre` varchar(256) NOT NULL,
  `apellido` varchar(256) NOT NULL,
  `edad` date NOT NULL,
  PRIMARY KEY (`email_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla placemybet.usuarios: ~1 rows (aproximadamente)
DELETE FROM `usuarios`;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` (`email_id`, `nombre`, `apellido`, `edad`) VALUES
	('maboto01@floridauniversitaria.es', 'Mark', 'Bort Tomás', '2001-03-14');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
