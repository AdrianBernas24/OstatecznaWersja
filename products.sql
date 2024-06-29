-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Cze 28, 2024 at 11:04 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `selfcheckout`
--

-- --------------------------------------------------------
CREATE DATABASE selfcheckout;
USE selfcheckout;
--
-- Struktura tabeli dla tabeli `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `category` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `name`, `price`, `category`) VALUES
(1, 'Chleb', 4.50, 'bakery'),
(2, 'Bułka', 1.20, 'bakery'),
(3, 'Marchewka', 2.00, 'vegetable'),
(4, 'Jabłko', 1.50, 'fruit'),
(5, 'Mleko', 3.20, 'dairy'),
(6, 'Woda', 1.00, 'beverage'),
(7, 'Rogalik', 2.50, 'bakery'),
(8, 'Ziemniak', 3.00, 'vegetable'),
(9, 'Pomidor', 3.50, 'vegetable'),
(10, 'Banan', 2.00, 'fruit'),
(11, 'Pomarańcza', 3.00, 'fruit'),
(12, 'Jogurt', 2.50, 'dairy'),
(13, 'Ser', 5.00, 'dairy'),
(14, 'Sok', 3.00, 'beverage'),
(15, 'Herbata', 2.50, 'beverage');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
