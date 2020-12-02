-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 02, 2020 at 02:38 PM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.4.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `placemybet_v2`
--

-- --------------------------------------------------------

--
-- Table structure for table `apuesta`
--

CREATE TABLE `apuesta` (
  `idApuesta` int(11) NOT NULL,
  `Dinero` double NOT NULL,
  `Cuota` double NOT NULL,
  `TipoApuesta` tinyint(1) NOT NULL,
  `fecha` datetime NOT NULL DEFAULT current_timestamp(),
  `idMercado` int(11) NOT NULL,
  `correoUsuario` varchar(45) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `banco`
--

CREATE TABLE `banco` (
  `idBanco` int(11) NOT NULL,
  `Saldo` double NOT NULL DEFAULT 0,
  `Nombre` varchar(64) COLLATE utf8_spanish_ci NOT NULL,
  `NumTarjeta` int(11) NOT NULL DEFAULT 0,
  `CorreoUsuario` varchar(45) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Table structure for table `mercado`
--

CREATE TABLE `mercado` (
  `idMercado` int(11) NOT NULL,
  `Tipo` varchar(45) COLLATE utf8_spanish_ci NOT NULL,
  `CuotaOver` double NOT NULL,
  `CuotaUnder` double NOT NULL,
  `DineroOver` double NOT NULL,
  `DineroUnder` double NOT NULL,
  `idPartido` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Dumping data for table `mercado`
--

INSERT INTO `mercado` (`idMercado`, `Tipo`, `CuotaOver`, `CuotaUnder`, `DineroOver`, `DineroUnder`, `idPartido`) VALUES
(1, '2_5', 0, 0, 0, 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `partido`
--

CREATE TABLE `partido` (
  `ID` int(11) NOT NULL,
  `EquipoLocal` varchar(45) COLLATE utf8_spanish_ci NOT NULL,
  `EquipoVisitante` varchar(45) COLLATE utf8_spanish_ci NOT NULL,
  `Goles` varchar(45) COLLATE utf8_spanish_ci NOT NULL,
  `Fecha` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Dumping data for table `partido`
--

INSERT INTO `partido` (`ID`, `EquipoLocal`, `EquipoVisitante`, `Goles`, `Fecha`) VALUES
(1, 'Valencia', 'Barcelona', '10', '2020-10-27 20:46:43'),
(2, 'Arsenal', 'Manchester City', '7', '2020-11-10 15:12:32');

-- --------------------------------------------------------

--
-- Table structure for table `usuario`
--

CREATE TABLE `usuario` (
  `correo` varchar(45) COLLATE utf8_spanish_ci NOT NULL,
  `Nombre` varchar(45) COLLATE utf8_spanish_ci NOT NULL,
  `Apellidos` varchar(45) COLLATE utf8_spanish_ci NOT NULL,
  `Edad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Dumping data for table `usuario`
--

INSERT INTO `usuario` (`correo`, `Nombre`, `Apellidos`, `Edad`) VALUES
('bortmarc7@gmail.com', 'Jose', 'Lacueva Mencias', 19),
('bortmarc8@gmail.com', 'Mark', 'Bort Tomás', 18);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `apuesta`
--
ALTER TABLE `apuesta`
  ADD PRIMARY KEY (`idApuesta`),
  ADD KEY `correo` (`correoUsuario`),
  ADD KEY `mercado` (`idMercado`) USING BTREE;

--
-- Indexes for table `banco`
--
ALTER TABLE `banco`
  ADD PRIMARY KEY (`idBanco`),
  ADD KEY `CorreoUsuario` (`CorreoUsuario`);

--
-- Indexes for table `mercado`
--
ALTER TABLE `mercado`
  ADD PRIMARY KEY (`idMercado`),
  ADD KEY `partido` (`idPartido`);

--
-- Indexes for table `partido`
--
ALTER TABLE `partido`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`correo`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `apuesta`
--
ALTER TABLE `apuesta`
  MODIFY `idApuesta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `mercado`
--
ALTER TABLE `mercado`
  MODIFY `idMercado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `partido`
--
ALTER TABLE `partido`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `apuesta`
--
ALTER TABLE `apuesta`
  ADD CONSTRAINT `apuesta_ibfk_1` FOREIGN KEY (`idMercado`) REFERENCES `mercado` (`idMercado`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `apuesta_ibfk_2` FOREIGN KEY (`correoUsuario`) REFERENCES `usuario` (`correo`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `banco`
--
ALTER TABLE `banco`
  ADD CONSTRAINT `banco_ibfk_1` FOREIGN KEY (`CorreoUsuario`) REFERENCES `usuario` (`correo`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Constraints for table `mercado`
--
ALTER TABLE `mercado`
  ADD CONSTRAINT `mercado_ibfk_1` FOREIGN KEY (`idPartido`) REFERENCES `partido` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
