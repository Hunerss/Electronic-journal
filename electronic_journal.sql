-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 27, 2024 at 09:36 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

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

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `getEmail` (IN `id` INT, IN `role` INT, OUT `email` TEXT)   BEGIN
         SELECT users.email INTO email FROM users
         WHERE users.school_role_id = id AND users.school_role = role;
       END$$

--
-- Functions
--
CREATE DEFINER=`root`@`localhost` FUNCTION `GetEmail` (`id` INT, `role` INT) RETURNS TEXT CHARSET utf8mb4 COLLATE utf8mb4_general_ci DETERMINISTIC BEGIN
    DECLARE email TEXT;
      SELECT users.email INTO email 
      FROM users
      WHERE users.school_role_id = id AND users.school_role = role;
    RETURN email;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `GetFullName` (`studentId` INT) RETURNS VARCHAR(255) CHARSET utf8mb4 COLLATE utf8mb4_general_ci DETERMINISTIC BEGIN
    DECLARE fullName VARCHAR(255);

    SELECT CONCAT(name, ' ', surname) INTO fullName
    FROM students
    WHERE id = studentId;

    RETURN fullName;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `grades`
--

CREATE TABLE `grades` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `description` text NOT NULL,
  `grade` text NOT NULL,
  `weight` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `class` text NOT NULL,
  `teacher_id` int(11) NOT NULL,
  `creation_date` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `grades`
--

INSERT INTO `grades` (`id`, `name`, `description`, `grade`, `weight`, `student_id`, `class`, `teacher_id`, `creation_date`) VALUES
(1, 'spr1', 'Sprawdzian z 1. rozdziału', '2', 3, 1, '1a', 1, 20241027),
(2, 'spr1', 'Sprawdzian z 1. rozdziału', '3', 3, 2, '1a', 1, 20241027),
(3, 'spr1', 'Sprawdzian z 1. rozdziału', '3', 3, 3, '1a', 1, 20241027),
(4, 'spr1', 'Sprawdzian z 1. rozdziału', '4', 3, 4, '1a', 1, 20241027),
(5, 'spr1', 'Sprawdzian z 1. rozdziału', '3', 3, 5, '1a', 1, 20241027),
(6, 'spr1', 'Sprawdzian z 1. rozdziału', '5', 3, 6, '1a', 1, 20241027),
(7, 'spr1', 'Sprawdzian z 1. rozdziału', '5', 3, 7, '1a', 1, 20241027),
(8, 'spr1', 'Sprawdzian z 1. rozdziału', '4', 3, 8, '1a', 1, 20241027),
(9, 'spr1', 'Sprawdzian z 1. rozdziału', '3', 3, 9, '1a', 1, 20241027),
(10, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 10, '1a', 1, 20241027),
(11, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 11, '1a', 1, 20241027),
(12, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 12, '1a', 1, 20241027),
(13, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 13, '1a', 1, 20241027),
(14, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 14, '1a', 1, 20241027),
(15, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 15, '1a', 1, 20241027),
(16, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 16, '1a', 1, 20241027),
(17, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 17, '1a', 1, 20241027),
(18, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 18, '1a', 1, 20241027),
(19, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 19, '1a', 1, 20241027),
(20, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 20, '1a', 1, 20241027),
(21, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 21, '1a', 1, 20241027),
(22, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 22, '1a', 1, 20241027),
(23, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 23, '1a', 1, 20241027),
(24, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 24, '1a', 1, 20241027),
(25, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 25, '1a', 1, 20241027),
(26, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 26, '1a', 1, 20241027),
(27, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 27, '1a', 1, 20241027),
(28, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 28, '1a', 1, 20241027),
(29, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 29, '1a', 1, 20241027),
(30, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 30, '1a', 1, 20241027),
(31, 'odp1', 'edp1', '4', 2, 1, '1a', 1, 20241027),
(32, 'odp1', 'edp1', '4', 2, 1, '1a', 1, 20241027),
(33, 'odp1', 'edp1', '4', 2, 1, '1a', 1, 20241027),
(34, 'odp1', 'edp1', '4', 2, 1, '1a', 1, 20241027),
(35, 'odp1', 'mcmm', '6', 6, 1, '1a', 1, 20241027);

-- --------------------------------------------------------

--
-- Table structure for table `lessons`
--

CREATE TABLE `lessons` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `class` text NOT NULL,
  `classroom` int(11) NOT NULL,
  `teacher_id` int(11) NOT NULL,
  `lesson` int(11) NOT NULL,
  `day` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `lessons`
--

INSERT INTO `lessons` (`id`, `name`, `class`, `classroom`, `teacher_id`, `lesson`, `day`) VALUES
(1, 'Matematyka', '1a', 120, 19, 1, 1),
(2, 'Język polski', '1a', 101, 1, 1, 2),
(3, 'Język angielski', '1a', 103, 3, 1, 3),
(4, 'Historia', '1a', 104, 4, 1, 4),
(5, 'Język rosyjski', '1a', 116, 15, 1, 5),
(6, 'Fizyka', '1a', 109, 9, 2, 1),
(7, 'Matematyka', '1a', 120, 19, 2, 2),
(8, 'Język polski', '1a', 101, 1, 2, 3),
(9, 'Język angielski', '1a', 103, 3, 2, 4),
(10, 'Biologia', '1a', 107, 7, 2, 5),
(11, 'Historia', '1a', 104, 4, 3, 1),
(12, 'Chemia', '1a', 108, 8, 3, 2),
(13, 'Biologia', '1a', 106, 6, 3, 3),
(14, 'Matematyka', '1a', 120, 19, 3, 4),
(15, 'Fizyka', '1a', 109, 9, 3, 5),
(16, 'Język angielski', '1a', 103, 3, 4, 1),
(17, 'Wychowanie fizyczne (WF)', '1a', 1, 11, 4, 2),
(18, 'Wiedza o społeczeństwie (WOS)', '1a', 105, 5, 4, 3),
(19, 'Informatyka', '1a', 110, 10, 4, 4),
(20, 'Matematyka', '1a', 120, 19, 4, 5),
(21, 'Wychowanie fizyczne (WF)', '1a', 1, 11, 5, 1),
(22, 'Biologia', '1a', 107, 7, 5, 2),
(23, 'Religia', '1a', 114, 13, 5, 3),
(24, 'Geografia', '1a', 106, 6, 5, 4),
(25, 'Chemia', '1a', 108, 8, 5, 5),
(26, 'Edukacja dla bezpieczeństwa (EDB)', '1a', 113, 12, 6, 1),
(27, 'Język polski', '1a', 101, 1, 6, 2),
(28, 'Informatyka', '1a', 110, 10, 6, 3),
(29, 'Podstawy przedsiębiorczości', '1a', 117, 16, 6, 4),
(30, 'Etyka', '1a', 115, 14, 6, 5),
(31, 'Matematyka', '1b', 120, 19, 0, 1),
(32, 'Język polski', '1b', 101, 1, 1, 5);

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE `messages` (
  `id` int(11) NOT NULL,
  `author_id` int(11) NOT NULL,
  `school_role` int(11) NOT NULL,
  `single_target` tinyint(1) NOT NULL,
  `single_target_id` int(11) DEFAULT NULL,
  `target_school_role` int(11) NOT NULL,
  `group_target_id` text DEFAULT NULL,
  `title` text NOT NULL,
  `content` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `messages`
--

INSERT INTO `messages` (`id`, `author_id`, `school_role`, `single_target`, `single_target_id`, `target_school_role`, `group_target_id`, `title`, `content`) VALUES
(1, 1, 1, 0, 0, 2, '1a', '1a grades', 'grades'),
(2, 1, 1, 1, 1, 0, NULL, 'Disappearing Messages', 'Hello, My messages to our students started to disappear after last update. Can you fdo some thing with it'),
(3, 1, 1, 1, 1, 2, NULL, 'Bad grade', 'Why didnt you study for last test?'),
(4, 1, 1, 1, 1, 2, NULL, 'After school match', 'You were promoted to go and reprezent our school in after school football match on 07.11.2024, 19:00 at city stadium'),
(5, 0, 1, 1, 1, 1, NULL, 'Re: Bad Grade', 'Because of football turnament');

-- --------------------------------------------------------

--
-- Table structure for table `notes`
--

CREATE TABLE `notes` (
  `id` int(11) NOT NULL,
  `teacher_id` int(11) NOT NULL COMMENT 'author id',
  `student_id` int(11) NOT NULL COMMENT 'target_id',
  `title` text NOT NULL,
  `content` int(11) NOT NULL,
  `date` int(11) NOT NULL,
  `hour` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `parents`
--

CREATE TABLE `parents` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `surname` text NOT NULL,
  `birthday` int(11) NOT NULL,
  `sex` tinyint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `parents`
--

INSERT INTO `parents` (`id`, `name`, `surname`, `birthday`, `sex`) VALUES
(1, 'Piotr', 'Nowak', 19630506, 1),
(2, 'Joanna', 'Nowak', 19760907, 0),
(3, 'Andrzej', 'Kowalski', 19610414, 1),
(4, 'Maria', 'Kowalska', 19691214, 0),
(5, 'Marek', 'Wiśniewski', 19660601, 1),
(6, 'Małgorzata', 'Wiśniewska', 19810701, 0),
(7, 'Jan', 'Wójcik', 19791205, 1),
(8, 'Barbara', 'Wójcik', 19670926, 0),
(9, 'Marcin', 'Kowalczyk', 19630813, 1),
(10, 'Barbara', 'Kowalczyk', 19750501, 0),
(11, 'Piotr', 'Kamiński', 19640501, 1),
(12, 'Agnieszka', 'Kamińska', 19700101, 0),
(13, 'Krzysztof', 'Lewandowski', 19650501, 1),
(14, 'Anna', 'Lewandowska', 19780601, 0),
(15, 'Tomasz', 'Zieliński', 19690501, 1),
(16, 'Magdalena', 'Zielińska', 19670501, 0),
(17, 'Jan', 'Woźniak', 19600801, 1),
(18, 'Katarzyna', 'Woźniak', 19800801, 0),
(19, 'Piotr', 'Szymański', 19670101, 1),
(20, 'Maria', 'Szymańska', 19750101, 0),
(21, 'Tomasz', 'Dąbrowski', 19641201, 1),
(22, 'Barbara', 'Dąbrowska', 19691201, 0),
(23, 'Andrzej', 'Kozłowski', 19691201, 1),
(24, 'Maria', 'Kozłowska', 19681201, 0),
(25, 'Grzegorz', 'Mazur', 19651001, 1),
(26, 'Agnieszka', 'Mazurska', 19730601, 0),
(27, 'Grzegorz', 'Jankowski', 19661201, 1),
(28, 'Agnieszka', 'Jankowska', 19830701, 0),
(29, 'Marek', 'Kwiatkowski', 19670301, 1),
(30, 'Zofia', 'Kwiatkowska', 19650201, 0),
(31, 'Tomasz', 'Wojciechowski', 19630301, 1),
(32, 'Małgorzata', 'Wojciechowska', 19849399, 0),
(33, 'Marek', 'Krawczyk', 19786101, 1),
(34, 'Joanna', 'Krawczyk', 19670101, 0),
(35, 'Tomasz', 'Kaczmarek', 19730101, 1),
(36, 'Zofia', 'Kaczmarek', 19830101, 0),
(37, 'Marek', 'Piotrowski', 19720301, 1),
(38, 'Anna', 'Piotrowska', 19720101, 0),
(39, 'Tomasz', 'Grabowski', 19650301, 1),
(40, 'Joanna', 'Grabowska', 19750101, 0),
(41, 'Piotr', 'Zając', 19730101, 1),
(42, 'Zofia', 'Zając', 19670101, 0),
(43, 'Marcin', 'Pawłowski', 19660101, 1),
(44, 'Barbara', 'Pawłowska', 19750101, 0),
(45, 'Adam', 'Król', 19710101, 1),
(46, 'Magdalena', 'Król', 19710101, 0),
(47, 'Grzegorz', 'Michalski', 19750101, 1),
(48, 'Katarzyna', 'Michalska', 19760101, 0),
(49, 'Krzysztof', 'Wróbel', 19790101, 1),
(50, 'Agnieszka', 'Wróbel', 19790101, 0),
(51, 'Tomasz', 'Wieczorek', 19710101, 1),
(52, 'Magdalena', 'Wieczorek', 19820101, 0),
(53, 'Grzegorz', 'Jabłoński', 19710101, 1),
(54, 'Magdalena', 'Jabłońska', 19710101, 0),
(55, 'Andrzej', 'Nowakowski', 19710101, 1),
(56, 'Anna', 'Nowakowska', 19710101, 0),
(57, 'Piotr', 'Majewski', 19710101, 1),
(58, 'Magdalena', 'Majewska', 19820101, 0),
(59, 'Piotr', 'Olszewski', 19710101, 1),
(60, 'Barbara', 'Olszewska', 19670101, 0);

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `surname` text NOT NULL,
  `class` text NOT NULL,
  `birthday` int(11) NOT NULL,
  `age` int(11) NOT NULL,
  `sex` tinyint(1) NOT NULL,
  `parent_1_id` int(11) NOT NULL,
  `parent_2_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`id`, `name`, `surname`, `class`, `birthday`, `age`, `sex`, `parent_1_id`, `parent_2_id`) VALUES
(1, 'Andrzej', 'Nowak', '1A', 20090728, 15, 1, 1, 2),
(2, 'Maria', 'Kowalska', '1A', 20090106, 15, 0, 3, 4),
(3, 'Paweł', 'Wiśniewski', '1A', 20090719, 15, 1, 5, 6),
(4, 'Barbara', 'Wójcik', '1A', 20091101, 15, 0, 7, 8),
(5, 'Andrzej', 'Kowalczyk', '1A', 20090905, 15, 1, 9, 10),
(6, 'Małgorzata', 'Kamińska', '1A', 20090726, 15, 0, 11, 12),
(7, 'Jan', 'Lewandowski', '1A', 20100601, 14, 1, 13, 14),
(8, 'Katarzyna', 'Zielińska', '1A', 20090401, 15, 0, 15, 16),
(9, 'Krzysztof', 'Woźniak', '1A', 20090401, 15, 1, 17, 18),
(10, 'Zofia', 'Szymańska', '1A', 20090412, 15, 0, 19, 20),
(11, 'Adam', 'Dąbrowski', '1A', 20090301, 15, 1, 21, 22),
(12, 'Magdalena', 'Kozłowska', '1A', 20090701, 16, 0, 23, 24),
(13, 'Paweł', 'Mazur', '1A', 20090106, 15, 1, 25, 26),
(14, 'Anna', 'Jankowska', '1A', 20100601, 14, 0, 27, 28),
(15, 'Tomasz', 'Kwiatkowski', '1A', 20090301, 15, 1, 29, 30),
(16, 'Marek', 'Wojciechowski', '1A', 20090801, 15, 1, 31, 32),
(17, 'Zofia', 'Krawczyk', '1A', 20090601, 15, 0, 33, 34),
(18, 'Piotr', 'Kaczmarek', '1A', 20090501, 15, 1, 35, 36),
(19, 'Joanna', 'Piotrowska', '1A', 20100601, 14, 0, 37, 38),
(20, 'Tomasz', 'Grabowski', '1A', 20090905, 15, 1, 39, 40),
(21, 'Zofia', 'Zając', '1A', 20090501, 15, 0, 41, 42),
(22, 'Marek', 'Pawłowski', '1A', 20090801, 15, 1, 43, 44),
(23, 'Anna', 'Król', '1A', 20090516, 15, 0, 45, 46),
(24, 'Krzysztof', 'Michalski', '1A', 20090601, 15, 1, 47, 48),
(25, 'Maria', 'Wróbel', '1A', 20090501, 15, 0, 49, 50),
(26, 'Adam', 'Wieczorek', '1A', 20090815, 15, 1, 51, 52),
(27, 'Joanna', 'Jabłońska', '1A', 20090501, 15, 0, 53, 54),
(28, 'Piotr', 'Nowakowski', '1A', 20090301, 15, 1, 55, 56),
(29, 'Zofia', 'Majewska', '1A', 20090601, 15, 0, 57, 58),
(30, 'Tomasz', 'Olszewski', '1A', 20090915, 15, 1, 59, 60);

-- --------------------------------------------------------

--
-- Table structure for table `teachers`
--

CREATE TABLE `teachers` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `surname` text NOT NULL,
  `subject` text NOT NULL,
  `class` text NOT NULL,
  `classroom` int(11) NOT NULL,
  `birthday` int(11) NOT NULL,
  `age` int(11) NOT NULL,
  `sex` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `teachers`
--

INSERT INTO `teachers` (`id`, `name`, `surname`, `subject`, `class`, `classroom`, `birthday`, `age`, `sex`) VALUES
(1, 'Anna', 'Nowak', 'Język polski', '1a', 101, 19800512, 44, 0),
(2, 'Jan', 'Kowalski', 'Matematyka', '1b', 102, 19770516, 47, 1),
(3, 'Maria', 'Wiśniewska', 'Język angielski', '1c', 103, 19890815, 35, 0),
(4, 'Tomasz', 'Wójcik', 'Historia', '1d', 104, 19691224, 54, 1),
(5, 'Ewa', 'Kowalczyk', 'Wiedza o społeczeństwie (WOS)', '2a', 105, 19830729, 41, 0),
(6, 'Krzysztof', 'Kamiński', 'Geografia', '2b', 106, 19900118, 34, 1),
(7, 'Marek', 'Lewandowski', 'Biologia', '2c', 107, 19850907, 39, 1),
(8, 'Magdalena', 'Zielińska', 'Chemia', '2d', 108, 19870730, 37, 0),
(9, 'Piotr', 'Woźniak', 'Fizyka', '3a', 109, 19911019, 33, 1),
(10, 'Agnieszka', 'Szymańska', 'Informatyka', '3b', 110, 19810122, 43, 0),
(11, 'Jacek', 'Dąbrowski', 'Wychowanie fizyczne (WF)', '', 1, 19751230, 48, 1),
(12, 'Joanna', 'Kozłowska', 'Edukacja dla bezpieczeństwa (EDB)', '3c', 113, 19861205, 37, 0),
(13, 'Katarzyna', 'Mazur', 'Religia', '', 114, 19790801, 45, 0),
(14, 'Grzegorz', 'Jankowski', 'Etyka', '', 115, 19890316, 35, 1),
(15, 'Rafał', 'Kwiatkowski', 'Język rosyjski', '3d', 116, 19841110, 40, 1),
(16, 'Anna', 'Wojciechowska', 'Podstawy przedsiębiorczości', '4a', 117, 19910425, 33, 0),
(17, 'Iwona', 'Krawczyk', 'Wychowanie fizyczne (WF)', '4b', 2, 19931220, 30, 0),
(18, 'Paweł', 'Kaczmarek', 'Język angielski', '4c', 119, 19871001, 37, 1),
(19, 'Barbara', 'Piotrowska', 'Matematyka', '4d', 120, 19760606, 48, 0),
(20, 'Maciej', 'Grabowski', 'Język angielski', '', 201, 19890905, 35, 1),
(21, 'Monika', 'Zając', 'Język angielski', '', 202, 19801219, 43, 0),
(22, 'Wojciech', 'Król', 'Język polski', '', 203, 19900411, 34, 1),
(23, 'Piotr', 'Wróbel', 'Matematyka', '', 204, 19740828, 50, 1),
(24, 'Zofia', 'Wieczorek', 'Język angielski', '', 205, 19930914, 31, 0),
(25, 'Robert', 'Jabłoński', 'Matematyka', '', 206, 19810525, 43, 1),
(26, 'Marta', 'Nowakowska', 'Wychowanie fizyczne (WF)', '', 3, 19770330, 47, 0),
(27, 'Grzegorz', 'Majewski', 'Matematyka', '', 207, 19851018, 39, 1),
(28, 'Kamil', 'Olszewski', 'Filozofia', '', 208, 19911202, 33, 1),
(29, 'Ewa', 'Stępień', 'Język polski', '', 209, 19831215, 40, 0),
(30, 'Karol', 'Witkowski', 'Język polski', '', 210, 19870411, 37, 1);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `school_role` int(11) NOT NULL COMMENT '0 - admin, 1 - teacher, 2 - student, 3 - parent',
  `school_role_id` int(11) NOT NULL COMMENT 'id of user''s role in school',
  `email` text NOT NULL COMMENT 'also login',
  `password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `school_role`, `school_role_id`, `email`, `password`) VALUES
(1, 0, 1, 'admin@school.edu.pl', 'fb001dfcffd1c899f3297871406242f097aecf1a5342ccf3ebcd116146188e4b'),
(2, 1, 1, 'Anna.Nowak@school.edu.pl', 'b1292bfe2967647ad048d3d6ac93c24883e16a542c64767281a43d4d87745f0b'),
(3, 1, 2, 'Jan.Kowalski@school.edu.pl', 'cb5d389501217e7a853a2dfdd1258264fccefc0fb8509b6acf44afad6417a600'),
(4, 1, 3, 'Maria.Wiśniewska@school.edu.pl', 'ecfc57784418b24ed01c26f20c75997cc152371b11503b8ce842901a10999468'),
(5, 1, 4, 'Tomasz.Wójcik@school.edu.pl', 'da17e391ee0c2e62ab8a56cf51da3b31ed5578eed50a175991718e504c5d5ee9'),
(6, 1, 5, 'Ewa.Kowalczyk@school.edu.pl', '3e219b9b6dfa16dba1af19a5c5c9ad69db0e2bd2d603def07f4ddeca2af69b2c'),
(7, 1, 6, 'Krzysztof.Kamiński@school.edu.pl', '42231200b949a90de7a4a36b21b36dfb59b6d37d4bbcccbeae8e4e8870ab4539'),
(8, 1, 7, 'Marek.Lewandowski@school.edu.pl', 'e63fed7c40c6b471567249c3e81560f8297e6ffd8ee5295586f47b031e13ef94'),
(9, 1, 8, 'Magdalena.Zielińska@school.edu.pl', 'd5730264f7e4400a92ec4296f9c49f272a7fb449d9c37540f1e61fb164dd4ea5'),
(10, 1, 9, 'Piotr.Woźniak@school.edu.pl', 'd08c49b8e7986526cbfd904c8bd63b37bbfa71a45b245084b019400e89bc4272'),
(11, 1, 10, 'Agnieszka.Szymańska@school.edu.pl', '9e2232992528973a23fe57a970a060578af74714065096eb2cf20986f33438e0'),
(12, 1, 11, 'Jacek.Dąbrowski@school.edu.pl', 'b695a8e20c2da46c370fbbe80c8b90751f1b207639884af7f9c9baed4d5266e0'),
(13, 1, 12, 'Joanna.Kozłowska@school.edu.pl', 'f91765dcd493ab6dbac9ff87ad0791c3d95e12e9491d4077e11cec9dcf0acb5d'),
(14, 1, 13, 'Katarzyna.Mazur@school.edu.pl', '3026f565917dfc522992a4fe646f3f6bbe5d5911f4ed17724efcb6a6eba71ec4'),
(15, 1, 14, 'Grzegorz.Jankowski@school.edu.pl', '647ba8b1b9d33763bdb91228e9a21d879f645a729e41b91405873e6a94a3bb01'),
(16, 1, 15, 'Rafał.Kwiatkowski@school.edu.pl', 'bb522ee23c463a66049042dd38b6b5588517d9f671807a7dd1f94de9ad149bf7'),
(17, 1, 16, 'Anna.Wojciechowska@school.edu.pl', 'c0bcce1b93a7685930a3137a445ebbab7328ad6254ec1a68cd0b4491d2adb5cf'),
(18, 1, 17, 'Iwona.Krawczyk@school.edu.pl', '412f3e002345d76f6c0cfabc8ebbe4b6d17d40df7dfd2a7efb4da9a213b6e4b8'),
(19, 1, 18, 'Paweł.Kaczmarek@school.edu.pl', '6e76eb31ebc753a07ff3a7993e6f2ca67095ce95758fdd629b333bf927e5f648'),
(20, 1, 19, 'Barbara.Piotrowska@school.edu.pl', 'e787ed1bb31ebf8b801bc2ffbd8dd8ed5fda297264257c79ddf9f40513221e42'),
(21, 1, 20, 'Maciej.Grabowski@school.edu.pl', '92c246c8d1511aa6b19b8cc335a2fdddc7f4ee1cef9daa74d1d989c7ebd3926a'),
(22, 1, 21, 'Monika.Zając@school.edu.pl', '8eab088b8bb7457ab8359b90831dfdb0c9419987814c83f808cd52ac32fb2d99'),
(23, 1, 22, 'Wojciech.Król@school.edu.pl', '1683ef39b88ff826142fa5816a94df47c7bedcd15162637279af925e95a1a431'),
(24, 1, 23, 'Piotr.Wróbel@school.edu.pl', '82de1b2eb360d9722390a25d6872b6874aef8d2e417e84d4461dedae8596e2a3'),
(25, 1, 24, 'Zofia.Wieczorek@school.edu.pl', '2f5e1e5a12c4320a57283481143c8090465d77a379db8ccb6a538040bef501a9'),
(26, 1, 25, 'Robert.Jabłoński@school.edu.pl', '5b37743d0ae60bb1740a812c191e1de7f6092111f8eafe8ec00505143e271ec8'),
(27, 1, 26, 'Marta.Nowakowska@school.edu.pl', 'd8cce01cecd4df7c3627be67bb06b203ea81c16c1e246fa027a418b11d73e409'),
(28, 1, 27, 'Grzegorz.Majewski@school.edu.pl', 'f9cfc2cccd0f8e8ebbe39391f84cc87cb8d053ce489dd14577af112b0abd0a0c'),
(29, 1, 28, 'Kamil.Olszewski@school.edu.pl', 'edde0f6deacdfc823f50d4a694d24496de237518df77d5268aae213645b3960a'),
(30, 1, 29, 'Ewa.Stępień@school.edu.pl', '339f12005f6f89876a041bd87fdec5d02aeb70bf5187b093122a4f5c8d9ae89a'),
(31, 1, 30, 'Karol.Witkowski@school.edu.pl', '53e9ab672d13c49ec37e9fa059e56ac523ffee6dd23d86d4c01380879c84d67b'),
(32, 2, 1, 'Andrzej.Nowak@school.edu.pl', '8645e7ac39e439caa664f865edb9499212f4669c446e9353415f30cc1e1fbef9'),
(33, 2, 2, 'Maria.Kowalska@school.edu.pl', '79f4504c8b566e9dfbee791046646c6c28fb9484c8124a67fe3e93be0c8de9c1'),
(34, 2, 3, 'Paweł.Wiśniewski@school.edu.pl', '4badea3a6cd31c136be72eb2f6d6a3b13791a4ec26f6e732903ab7474d097fb1'),
(35, 2, 4, 'Barbara.Wójcik@school.edu.pl', 'ea7875b10a574845a8ad5c02c5869e68bd728538af094235e32e1128e01f57b6'),
(36, 2, 5, 'Andrzej.Kowalczyk@school.edu.pl', 'd6b5e6646bb5e7a0e556ac64a6cc6fbbd1e80dda0ada48e5df63faf13841c2d3'),
(37, 2, 6, 'Małgorzata.Kamińska@school.edu.pl', '9b095ca6c3d8ac91090359fcef350957baac9a86232f1e5f82468bea45946edb'),
(38, 2, 7, 'Jan.Lewandowski@school.edu.pl', 'ea0c724f757a3b11a52c7e212e5d6a7272cd16d45f0b2bfd54c1d7998890fd4c'),
(39, 2, 8, 'Katarzyna.Zielińska@school.edu.pl', '39721cc050ad0ac177071a0b1bc875dee9fea74f18ae1a1119ef4ba9b495679f'),
(40, 2, 9, 'Krzysztof.Woźniak@school.edu.pl', 'ddf7279395d9876ac7262071864d765279ce0dca6f4ab161dfde52e77a9adc6e'),
(41, 2, 10, 'Zofia.Szymańska@school.edu.pl', 'e283abc949e08f8601df7edbef00fd96cf6c144688da8a4687790c213741cd97'),
(42, 2, 11, 'Adam.Dąbrowski@school.edu.pl', '6869d86ac770a043e5d672b464bb288b8375aa7680314d5bab1c55fc58d2fdb4'),
(43, 2, 12, 'Magdalena.Kozłowska@school.edu.pl', '355054a52d34e52d204d5c97d68a3f57295315e0a4e61d7c11017ab997e7841e'),
(44, 2, 13, 'Paweł.Mazur@school.edu.pl', '102db01db38547649ef9b5f842609b549a26653ae7171ff98ca4d1b083747a56'),
(45, 2, 14, 'Anna.Jankowska@school.edu.pl', '045401ce864b1586aa28575b0d3b27369e538ab49f18f44e7f5e367ac2a2c9e7'),
(46, 2, 15, 'Tomasz.Kwiatkowski@school.edu.pl', '58d3147b30b381bdcef28a6796990fac00ae6ea12833dadfa83eb9bf99f801cc'),
(47, 2, 16, 'Marek.Wojciechowski@school.edu.pl', 'fc186563aca52a9d9614919ba2c390fa1ec8ec543c42b0942f6ac5809959a854'),
(48, 2, 17, 'Zofia.Krawczyk@school.edu.pl', 'e7d0f7dfd1388d81ebb4a3e5f9932e2ddb5b77d9b34b964bbccd45307fb02357'),
(49, 2, 18, 'Piotr.Kaczmarek@school.edu.pl', 'a7033f1af91ba661ea2225e831fa226ee0d391f50796cc9deb737866b4f2ed10'),
(50, 2, 19, 'Joanna.Piotrowska@school.edu.pl', '196a363ea32e9c56114f4628204bc5baa5f46e25206f1adc2952d75a23055b11'),
(51, 2, 20, 'Tomasz.Grabowski@school.edu.pl', '796e9233b704dd4748291fd69c91f5642aac1f4205b2d90d481124929e0b003f'),
(52, 2, 21, 'Zofia.Zając@school.edu.pl', '7de5de2354d5a810c976265ca7adc99382c5ac76129c8d417156055737bfc6d6'),
(53, 2, 22, 'Marek.Pawłowski@school.edu.pl', 'b6d5092a7c5a79b866947296490923681d841da815f867a2409950c2103a5542'),
(54, 2, 23, 'Anna.Król@school.edu.pl', 'acc48cbd2b47ecb69b2ea0c68b1e57cf582f76370047f8ef78fb0721684279ef'),
(55, 2, 24, 'Krzysztof.Michalski@school.edu.pl', '0d8acfdd15c313cba14e52a98dfaf8ba34a32a4b98ca56d48f2154842f28068a'),
(56, 2, 25, 'Maria.Wróbel@school.edu.pl', '451c0d050c82db8218658ebbb5f551bbcc03b5eb3b955ba137ed8159ca40da35'),
(57, 2, 26, 'Adam.Wieczorek@school.edu.pl', '5f9bfccf4c9d8dc3f549f620d6684081a6fbfe1aeaba5d690ed859628fc8aa64'),
(58, 2, 27, 'Joanna.Jabłońska@school.edu.pl', '90f758f2df108cc4f4348a42e8dddda87fa72cc88513a3c6baca2db75ef3a44f'),
(59, 2, 28, 'Piotr.Nowakowski@school.edu.pl', '34d2729d5d3c4a25be4ce7fb037df7072a07192397596d3b271a06b7ca292894'),
(60, 2, 29, 'Zofia.Majewska@school.edu.pl', '2edde37bbb174261868ac83e042ce0b43a61aa05f4f4ff0ebe0bb4820057a70d'),
(61, 2, 30, 'Tomasz.Olszewski@school.edu.pl', 'f2fa4662b89cc4250b36f9a19cf22d2c3295d48d06bc6d794edea3ebd2953112'),
(62, 3, 1, 'Piotr.Nowak@school.edu.pl', '789512a1f837363bc6d371f060a446571efee89086ff2d4f7c600c09fe7c7684'),
(63, 3, 2, 'Joanna.Nowak@school.edu.pl', '73987d0cb207cf14a6a03771e89ceb4701fb6a8a8bd9a6ab87168a895fd54715'),
(64, 3, 3, 'Andrzej.Kowalski@school.edu.pl', 'f2573332dca65b75d14a08a99ddaa7aa2f921ada6de27ab431338b420d7b8e94'),
(65, 3, 4, 'Maria.Kowalska@school.edu.pl', 'ad123c85b2c5ad466a4f57ecacf1eb3c28ff7c00108bc5f1d7a0c84719a32c12'),
(66, 3, 5, 'Marek.Wiśniewski@school.edu.pl', '48db46b16afb6d3a4654bfdd21b6f0088a265e0f87c381f64a4fc58ab94a5b9f'),
(67, 3, 6, 'Małgorzata.Wiśniewska@school.edu.pl', '4547e64d701c4e4279811bac6b3fa60c3726ae592de43eff4c1df67edd935693'),
(68, 3, 7, 'Jan.Wójcik@school.edu.pl', 'cb2af9674f0826ecea1850a4d0c088edfef271392c7f05f2ecff7be0c43c4163'),
(69, 3, 8, 'Barbara.Wójcik@school.edu.pl', '2897fbb566572754fa7a513014d02572d05777861c603573c2440ba2accd1590'),
(70, 3, 9, 'Marcin.Kowalczyk@school.edu.pl', 'd9f52c870cc8503e53234f2e267332b08c6109cc5e5200de1254a73a377ec3ac'),
(71, 3, 10, 'Barbara.Kowalczyk@school.edu.pl', '31764af338c802b9db10b6fd23ce88df4a7b86f6d7a29a6d496ca34267e4bc64'),
(72, 3, 11, 'Piotr.Kamiński@school.edu.pl', '44096bba172ccab83479fe8c158d638da120ed0cd96d38a699e546e3156530cb'),
(73, 3, 12, 'Agnieszka.Kamińska@school.edu.pl', 'ac37c7fd9d8f2140ebfeffb0432f9f4895b83f0b66d18b23ac66c94cf4d3b491'),
(74, 3, 13, 'Krzysztof.Lewandowski@school.edu.pl', 'f7d809ce345f68aed12a8bb376ad4ab184f5ecacc114d6ce235bcd9dd20ff99a'),
(75, 3, 14, 'Anna.Lewandowska@school.edu.pl', '979b80ff5158e35519c03a77597b791b6e3e39aee8ca45e632b69c615dff8f90'),
(76, 3, 15, 'Tomasz.Zieliński@school.edu.pl', 'b205878b13e17e034a682487333abf4660d0c28a3b763b52619adae1b51ef701'),
(77, 3, 16, 'Magdalena.Zielińska@school.edu.pl', '2a0497eb16983d9e25b094a7ab9b0dbd0da686fe76ed9413bf94b5702b8f800c'),
(78, 3, 17, 'Jan.Woźniak@school.edu.pl', '0e42c9e6fb62685ffda91dcf7f56fdde242f20fefa0eb25f9086b846e426cb11'),
(79, 3, 18, 'Katarzyna.Woźniak@school.edu.pl', '67a00443e3d9065c66550c2e01a3f04d7d3b5bcfc780c7c409e0d20e906c8b05'),
(80, 3, 19, 'Piotr.Szymański@school.edu.pl', 'edc9c5305509e7cbd4a1ed9d5629cf717cb44236861f09eebcb5642f7e0cc458'),
(81, 3, 20, 'Maria.Szymańska@school.edu.pl', '3fe0346a1f04df7f15818ce298fdb92c8e14106a6f1b410ef091b8f75cfdace3'),
(82, 3, 21, 'Tomasz.Dąbrowski@school.edu.pl', '1a9dbc0eafdf39875eecdb2d6bec972bb07db93c6da465b607beb6f23e290eba'),
(83, 3, 22, 'Barbara.Dąbrowska@school.edu.pl', 'f122afb562f873ac4e5e227159947686420d92d0f6e1896e4c4d10bc9fcd2dd0'),
(84, 3, 23, 'Andrzej.Kozłowski@school.edu.pl', '03426374c3e9b4d1727122652512269354a035d366be1ead5efd0609f24f89b3'),
(85, 3, 24, 'Maria.Kozłowska@school.edu.pl', '63a9003829f8b4335c5a69f88f092f5cb9c0efba2ade7e823ad26989c8c77b26'),
(86, 3, 25, 'Grzegorz.Mazur@school.edu.pl', 'e525b036920a825b54ecf6268e34d02f74782edf8922cf335dc358eb05d575d9'),
(87, 3, 26, 'Agnieszka.Mazurska@school.edu.pl', '1155e13b0f4472f4a3bfd640fed772faa76433bbc0084217a39c3805e740cab5'),
(88, 3, 27, 'Grzegorz.Jankowski@school.edu.pl', 'dbe309036b0ad400dd8af2bc0d699a395c2351d4e2b0ed3acc86dff67148f551'),
(89, 3, 28, 'Agnieszka.Jankowska@school.edu.pl', '472ed3b62e691af38b3beaa6f0ba6076d7c9c528d64ff460b2cea8a01d87d48b'),
(90, 3, 29, 'Marek.Kwiatkowski@school.edu.pl', 'f2164722cf3cfa5b76933626c6477715b09c87ea5cbe085cca54826e8e2f076c'),
(91, 3, 30, 'Zofia.Kwiatkowska@school.edu.pl', '4e57f2840c66d32258a469b68a1a444e2e651194e4ad0673bca0a39403da5288'),
(92, 3, 31, 'Tomasz.Wojciechowski@school.edu.pl', '6146ee2f88ccd380d8475f10f92141e8b2028158a676ad4aadd3fa254f0a73c2'),
(93, 3, 32, 'Małgorzata.Wojciechowska@school.edu.pl', '373bdf2e99db9e5c2b80da094f4af8d3b0d4e0fe4f83eaa8800c3b7c04028330'),
(94, 3, 33, 'Marek.Krawczyk@school.edu.pl', '40a2ed80a0a8974554b7a799dc5bef4c1ccd52ff47fc8fca6e1b48d24fced41a'),
(95, 3, 34, 'Joanna.Krawczyk@school.edu.pl', '9886e4fe68f810b01f5848beba190666d044971780b8aa2b2f60aa1e4014fe8c'),
(96, 3, 35, 'Tomasz.Kaczmarek@school.edu.pl', '3f87ab1129c3d93ea361680509647aee7528917b3d6f67b5db465dbff2c26fb9'),
(97, 3, 36, 'Zofia.Kaczmarek@school.edu.pl', 'b473c80e8762253324249ec162aabbd7a5de85a47a95a0cb645109e8c7c68b75'),
(98, 3, 37, 'Marek.Piotrowski@school.edu.pl', 'eccc890d03e5ed365121d6d010a166b4613da84ddf4807a32155dca96f01518c'),
(99, 3, 38, 'Anna.Piotrowska@school.edu.pl', '34ee296d9c104621cb3b681144f4c792e96508e2678bb14599619b37a60c85ae'),
(100, 3, 39, 'Tomasz.Grabowski@school.edu.pl', '7a79b19ed3c7b67890426bda245d580103f19b44e30d59ce9aa9e985e1defb1e'),
(101, 3, 40, 'Joanna.Grabowska@school.edu.pl', '202addc773b149d4df62f521c5f1f76c5a8715966763880c71898e577fe67741'),
(102, 3, 41, 'Piotr.Zając@school.edu.pl', 'a029defad20da6f92437f817dea959efa852ec8ae1801d8993687e4f835a40b7'),
(103, 3, 42, 'Zofia.Zając@school.edu.pl', '4a703cd738369e7dcb7f4928a726e24b65f89626f68ec6c88659448b80e35bfe'),
(104, 3, 43, 'Marcin.Pawłowski@school.edu.pl', 'e9d865f9e2e78cdf23dfb7f7032956e24bb8a2fa3e2fd50638bec30a5cfa302a'),
(105, 3, 44, 'Barbara.Pawłowska@school.edu.pl', '22484af81881d86e5b61987261830f4a61c150fbff28cca97120ac19d12a6683'),
(106, 3, 45, 'Adam.Król@school.edu.pl', '95cc85ba55ab289655629c42ccbf7b2c16077ce711f22d975c54c2a5e6250298'),
(107, 3, 46, 'Magdalena.Król@school.edu.pl', '803fea5bedebde7eaf37afccdd4014492631889c9e07988385c4676505157a99'),
(108, 3, 47, 'Grzegorz.Michalski@school.edu.pl', '204440b42f985bcb678980207cac58acb3aafad94c4708dc8203e9cb553702f6'),
(109, 3, 48, 'Katarzyna.Michalska@school.edu.pl', 'a5e46964b5a98cf94a8884e1b28ff1dc3bb24dfd6ab3eca922255481959dcf42'),
(110, 3, 49, 'Krzysztof.Wróbel@school.edu.pl', 'fafb44fa07c2419ea592fb1da0e0be1b7c84240d2cff01d3f1db248dbe94d70f'),
(111, 3, 50, 'Agnieszka.Wróbel@school.edu.pl', '1e7c805eec4c037c2237b5a1a2d69f10315fcc48ae02959830e172294e73c36e'),
(112, 3, 51, 'Tomasz.Wieczorek@school.edu.pl', '78da0d55e62ecaf1b495bbeb0724b303206ba37d2a749caf587b9983e7e8c7af'),
(113, 3, 52, 'Magdalena.Wieczorek@school.edu.pl', 'ae67ead1fbd08c5c0596df592fd4db73414e8c1667fe6ad8daf8b58bc7e0973a'),
(114, 3, 53, 'Grzegorz.Jabłoński@school.edu.pl', '4c6ff3e40652043534959ad7478d374faf9ce90a9f50e9ac17d8a58747c41eb0'),
(115, 3, 54, 'Magdalena.Jabłońska@school.edu.pl', 'c482bda8094c0169782119d437b542678f18bb6cf59bec20520c29d9f6b99651'),
(116, 3, 55, 'Andrzej.Nowakowski@school.edu.pl', '459cd29ce73dfdf08b1a299015d27580d53fba399c7753b04d3495cb9890523c'),
(117, 3, 56, 'Anna.Nowakowska@school.edu.pl', '603c0e00bc16598c9f3a696418fa2089869926f1832622f2f0e6d1a6f2e80d26'),
(118, 3, 57, 'Piotr.Majewski@school.edu.pl', '9909e660a97eed19bf85cdd1d2ea9a0d510277c2e7ffee3c016a2385bb5555e8'),
(119, 3, 58, 'Magdalena.Majewska@school.edu.pl', '5084639aebaccc02750592e76e54e552dfdfeb74b7f1222add998d8f1f629f2c'),
(120, 3, 59, 'Piotr.Olszewski@school.edu.pl', '0b42051dc65bd37f8a8e6cbc2b0abeff4184cd8ee2b28ed9c41195c6e635f91f'),
(121, 3, 60, 'Barbara.Olszewska@school.edu.pl', '63b4bc20c36fa810d92e2f6b6c04746689558e4e4ad01023996a7ca7c549e6c5');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `grades`
--
ALTER TABLE `grades`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `lessons`
--
ALTER TABLE `lessons`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `notes`
--
ALTER TABLE `notes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `parents`
--
ALTER TABLE `parents`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `teachers`
--
ALTER TABLE `teachers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `grades`
--
ALTER TABLE `grades`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT for table `lessons`
--
ALTER TABLE `lessons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `notes`
--
ALTER TABLE `notes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `parents`
--
ALTER TABLE `parents`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `teachers`
--
ALTER TABLE `teachers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=122;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
