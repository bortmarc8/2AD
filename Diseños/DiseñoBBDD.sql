-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.4.10-MariaDB - mariadb.org binary distribution
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

-- Volcando estructura para tabla placemybet.mercados
DROP TABLE IF EXISTS `mercados`;
CREATE TABLE IF NOT EXISTS `mercados` (
  `ID` int(11) NOT NULL,
  `dineroOver` float NOT NULL,
  `dineroUnder` float NOT NULL,
  `cuotaOver` float NOT NULL,
  `cuotaUnder` float NOT NULL,
  `tipo` enum('o_1_5','u_1_5','o_2_5','u_2_5','o_2_5','u_3_5') NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla placemybet.mercados: ~1 rows (aproximadamente)
DELETE FROM `mercados`;
/*!40000 ALTER TABLE `mercados` DISABLE KEYS */;
INSERT INTO `mercados` (`ID`, `dineroOver`, `dineroUnder`, `cuotaOver`, `cuotaUnder`, `tipo`) VALUES
	(0, 0, 0, 0, 0, 'o_1_5');
/*!40000 ALTER TABLE `mercados` ENABLE KEYS */;

-- Volcando estructura para tabla placemybet.eventos
DROP TABLE IF EXISTS `eventos`;
CREATE TABLE IF NOT EXISTS `eventos` (
  `ID` int(11) NOT NULL,
  `local` varchar(256) NOT NULL,
  `visitante` varchar(256) NOT NULL,
  `mercado1_ref` int(11) DEFAULT NULL,
  `mercado2_ref` int(11) DEFAULT NULL,
  `mercado3_ref` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `mercado1` (`mercado1_ref`),
  KEY `mercado2` (`mercado2_ref`),
  KEY `mercado3` (`mercado3_ref`),
  CONSTRAINT `mercado1` FOREIGN KEY (`mercado1_ref`) REFERENCES `mercados` (`ID`),
  CONSTRAINT `mercado2` FOREIGN KEY (`mercado2_ref`) REFERENCES `mercados` (`ID`),
  CONSTRAINT `mercado3` FOREIGN KEY (`mercado3_ref`) REFERENCES `mercados` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla placemybet.eventos: ~1 rows (aproximadamente)
DELETE FROM `eventos`;
/*!40000 ALTER TABLE `eventos` DISABLE KEYS */;
INSERT INTO `eventos` (`ID`, `local`, `visitante`, `mercado1_ref`, `mercado2_ref`, `mercado3_ref`) VALUES
	(0, 'Valencia', 'Madrid', 0, NULL, NULL);
/*!40000 ALTER TABLE `eventos` ENABLE KEYS */;

-- Volcando estructura para tabla placemybet.usuarios
DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE IF NOT EXISTS `usuarios` (
  `email_id` varchar(256) NOT NULL,
  `nombre` varchar(256) NOT NULL,
  `apellido` varchar(256) NOT NULL,
  `saldo` float NOT NULL,
  `nombrebanco` varchar(256) NOT NULL,
  `numtargeta` varchar(256) NOT NULL,
  PRIMARY KEY (`email_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla placemybet.usuarios: ~1 rows (aproximadamente)
DELETE FROM `usuarios`;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` (`email_id`, `nombre`, `apellido`, `saldo`, `nombrebanco`, `numtargeta`) VALUES
	('maboto01@floridauniversitaria.es', 'Mark', 'Bort Tomás', 0, 'Santander', '0000-0000-0000-0000');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;

-- Volcando estructura para tabla placemybet.relusuarioseventos
DROP TABLE IF EXISTS `relusuarioseventos`;
CREATE TABLE IF NOT EXISTS `relusuarioseventos` (
  `ID` int(11) NOT NULL,
  `usuario_ref` varchar(256) NOT NULL,
  `evento_ref` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `usuarios` (`usuario_ref`),
  KEY `eventos` (`evento_ref`),
  CONSTRAINT `eventos` FOREIGN KEY (`evento_ref`) REFERENCES `eventos` (`ID`),
  CONSTRAINT `usuarios` FOREIGN KEY (`usuario_ref`) REFERENCES `usuarios` (`email_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla placemybet.relusuarioseventos: ~1 rows (aproximadamente)
DELETE FROM `relusuarioseventos`;
/*!40000 ALTER TABLE `relusuarioseventos` DISABLE KEYS */;
INSERT INTO `relusuarioseventos` (`ID`, `usuario_ref`, `evento_ref`) VALUES
	(0, 'maboto01@floridauniversitaria.es', 0);
/*!40000 ALTER TABLE `relusuarioseventos` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
