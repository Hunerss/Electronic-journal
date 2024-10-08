-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Paź 08, 2024 at 03:03 PM
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
-- Database: `electronic_journal`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `grades`
--

CREATE TABLE `grades` (
  `id` int(11) NOT NULL,
  `grade` text NOT NULL,
  `student_id` int(11) NOT NULL,
  `teacher_id` int(11) NOT NULL,
  `creation_date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `lessons`
--

CREATE TABLE `lessons` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `class` int(11) NOT NULL,
  `classroom` int(11) NOT NULL,
  `teacher_id` int(11) NOT NULL,
  `class_id` int(11) NOT NULL,
  `time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `students`
--

CREATE TABLE `students` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `surname` text NOT NULL,
  `class` text NOT NULL,
  `birthday` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `age` int(11) NOT NULL,
  `average` double NOT NULL,
  `sex` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `teachers`
--

CREATE TABLE `teachers` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `surname` text NOT NULL,
  `class` text NOT NULL,
  `classroom` int(11) NOT NULL,
  `birthday` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `age` int(11) NOT NULL,
  `sex` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `grades`
--
ALTER TABLE `grades`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `teachers`
--
ALTER TABLE `teachers`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `grades`
--
ALTER TABLE `grades`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `teachers`
--
ALTER TABLE `teachers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
