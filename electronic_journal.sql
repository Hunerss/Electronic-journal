-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 27, 2024 at 08:24 PM
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
(30, 'spr1', 'Sprawdzian z 1. rozdziału', '', 3, 30, '1a', 1, 20241027);

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
(4, 1, 1, 1, -1, 2, NULL, 'After school match', 'You were promoted to go and reprezent our school in after school football match on 07.11.2024, 19:00 at city stadium'),
(5, 0, -1, 1, 1, 1, NULL, 'Re: Bad Grade', 'Because of football turnament'),
(6, 0, -1, 1, 1, 1, NULL, 'Re: Bad Grade', 'Because of football turnament'),
(7, 0, -1, 1, -1, 2, NULL, 'Re: Bad Grade', 'Because of football turnament'),
(8, -1, -1, 1, 1, 1, NULL, 'Re: Bad Grade', 'Because of football turnament'),
(9, 2, 2, 1, 1, 1, NULL, 'Re: Bad Grade', 'Because of football turnament'),
(10, 1, 2, 1, 1, 1, NULL, 'Re: Bad Grade', 'Because of football turnament');

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
(32, 2, 1, 'Andrzej.Nowak@school.edu.pl', '6839bc25447d45c86dbf18226221f4679cd2174c572939c535fa8faad01c0ee3'),
(33, 2, 2, 'Maria.Kowalska@school.edu.pl', '79f4504c8b566e9dfbee791046646c6c28fb9484c8124a67fe3e93be0c8de9c1'),
(34, 2, 3, 'Paweł.Wiśniewski@school.edu.pl', '15a2d8cb5ed6cc6261b0b065603848d85ce4250715f4126302676258b5202393'),
(35, 2, 4, 'Barbara.Wójcik@school.edu.pl', 'c10cbf0d92e270317932cf6f8a39c137a11c124f38a42c366ae1294de907a43a'),
(36, 2, 5, 'Andrzej.Kowalczyk@school.edu.pl', '883d80917a16502882b80f54cbec715b928d560817f67db7688bb8c9606bd530'),
(37, 2, 6, 'Małgorzata.Kamińska@school.edu.pl', 'ee79762b275f457c36d895c94c7135c97d455d9da7c85ff57b790f42c3e83890'),
(38, 2, 7, 'Jan.Lewandowski@school.edu.pl', '9e4432c0f87bb85039910874fec6f10311f971c24186ba6f66c1432fc4f3ee19'),
(39, 2, 8, 'Katarzyna.Zielińska@school.edu.pl', '8b255804ca0dc6ab12688ee96d9216b5e43e5a89978748952b5fa74933fcc90b'),
(40, 2, 9, 'Krzysztof.Woźniak@school.edu.pl', 'a69c0bc76892b5c754fffb8c6f017b13693655d84b84f5f24c996207078e485f'),
(41, 2, 10, 'Zofia.Szymańska@school.edu.pl', 'd009ec3076f0337b29c1dbcba656e90ec4f78a6b7a77b680f0dac8fc2032633a'),
(42, 2, 11, 'Adam.Dąbrowski@school.edu.pl', '856236f1d02734ab9965cfd9af4329a1bc808ee3e7129cde76647852b8085bf4'),
(43, 2, 12, 'Magdalena.Kozłowska@school.edu.pl', 'dc7633ca1980c02f021cb7321992ca9758ba247bf34a1d3bae8bb99f7864a845'),
(44, 2, 13, 'Paweł.Mazur@school.edu.pl', '102db01db38547649ef9b5f842609b549a26653ae7171ff98ca4d1b083747a56'),
(45, 2, 14, 'Anna.Jankowska@school.edu.pl', 'd6797d75a93b111f85301759f9ab843ae37c6b96ab097dc0bf2ccf5ab497cbb0'),
(46, 2, 15, 'Tomasz.Kwiatkowski@school.edu.pl', 'e5b9afd8410251ec3add10149f5790bac56b485b831fbc3cf54543041ad198c2'),
(47, 2, 16, 'Marek.Wojciechowski@school.edu.pl', 'e5d23a6fce71c459312345280baa7f0bf65eaa4b33fdd4aea21477963bacc3cc'),
(48, 2, 17, 'Zofia.Krawczyk@school.edu.pl', '1ce6a4eeb2eb3d239145934fb241fba63904e800cb7eef626ff77dfc0d03e199'),
(49, 2, 18, 'Piotr.Kaczmarek@school.edu.pl', '147f216b2c2980cc9046d412415af1148502c454af376dfa08c16dd39c89889e'),
(50, 2, 19, 'Joanna.Piotrowska@school.edu.pl', '5fae8e352ffc69f1ff4dccbe76c58edb12933a5e5d2e8ffa157d8f8cf78a6b38'),
(51, 2, 20, 'Tomasz.Grabowski@school.edu.pl', '7279b5a0dde0b910b12bfac79c2552711da52d06d06aacfd7ef3f94eba26f92a'),
(52, 2, 21, 'Zofia.Zając@school.edu.pl', '476de191d171f4065bb6dbdfc48d58f12e390b70dd53fcd728f868f3605cdeca'),
(53, 2, 22, 'Marek.Pawłowski@school.edu.pl', '78f5bc3f3055d146d7d27f77d83e9b0993b622ae00585170c78509f446706c3d'),
(54, 2, 23, 'Anna.Król@school.edu.pl', 'c5f76b84cbb8878dfa28b9febbddd673172738808867411b7dfb4c25ec800587'),
(55, 2, 24, 'Krzysztof.Michalski@school.edu.pl', 'a618764e2c1dfd3ba78b1ba8735d82496b5b8a3e7ea9fb08a623280903214c26'),
(56, 2, 25, 'Maria.Wróbel@school.edu.pl', '798ba6e2072f9122b2ae7fc22dd448a16897e4caffaaa078c23cb56b57ddcaa6'),
(57, 2, 26, 'Adam.Wieczorek@school.edu.pl', '5102c7944d9fb199fca770986b7af24f59cbe10cd490dd15a667ee1c015e09dd'),
(58, 2, 27, 'Joanna.Jabłońska@school.edu.pl', '9c5e396773aeeb45ed02923db6a3b8425f027167fc429ae9702449950feb17fb'),
(59, 2, 28, 'Piotr.Nowakowski@school.edu.pl', '961263bb107f9fff387cb9b3d074c312293bf22549fd83f6b14ce5fbc8f0a165'),
(60, 2, 29, 'Zofia.Majewska@school.edu.pl', '23be3c2f01c3def8a6e51c16a61f99e23268e066af63ce3af900db185c31cab9'),
(61, 2, 30, 'Tomasz.Olszewski@school.edu.pl', 'f1d2290ff0fb8da4a2796340021120acc650db3b95b60b00bf811234eae4d505'),
(62, 3, 1, 'Piotr.Nowak@school.edu.pl', '49939cf1969166988571c32d9f1d072e2b401c5434a56a83207a6a5e8916a6e5'),
(63, 3, 2, 'Joanna.Nowak@school.edu.pl', '525a81c76ad3a0aa9b34b0b5ebafbde24f1b93b1c911421063f6ecf8f775a0ff'),
(64, 3, 3, 'Andrzej.Kowalski@school.edu.pl', '77d166020ee3feb3d27b424c3dd30bb783b1597b8103593847338432ae902312'),
(65, 3, 4, 'Maria.Kowalska@school.edu.pl', 'ad123c85b2c5ad466a4f57ecacf1eb3c28ff7c00108bc5f1d7a0c84719a32c12'),
(66, 3, 5, 'Marek.Wiśniewski@school.edu.pl', 'c22cf23700b7440b395e6c063aae5c96e203c8fc15d175055ff03e80a4c517d8'),
(67, 3, 6, 'Małgorzata.Wiśniewska@school.edu.pl', '9be96c226e47f1e5cd3bae1afc4ef59c05dc8acb0dfa182d5ac329b1a0522bcd'),
(68, 3, 7, 'Jan.Wójcik@school.edu.pl', '72777e28945917ec919ec8505a28f0ec57b7b52924d4f01c068c6adf30256fca'),
(69, 3, 8, 'Barbara.Wójcik@school.edu.pl', '824cc420ed76ba96fe34bc7d55408cb8504bc88981fea63f3e15d34e71c51406'),
(70, 3, 9, 'Marcin.Kowalczyk@school.edu.pl', '6deb58b956f42595ec141458c01ed0c5c17dff2be795033cd38e76172434b507'),
(71, 3, 10, 'Barbara.Kowalczyk@school.edu.pl', '711af4dd12cda127062e98c11bdf0b0f8b63bc1972d109fd336aafc533e8653a'),
(72, 3, 11, 'Piotr.Kamiński@school.edu.pl', '5a3eb87200f77c3473ff92c1ba75002566d2e986dc1908c1bdfbd9694e337e17'),
(73, 3, 12, 'Agnieszka.Kamińska@school.edu.pl', '6a1325e62219bfed5cb58b56f06c09d00172efdd5e0760e0b11c859dfa498b65'),
(74, 3, 13, 'Krzysztof.Lewandowski@school.edu.pl', '1ac6b9fb3af138f1d9fe80ff50b9dc8b6b1368c5f0acb95948d2e8cd3db72e0f'),
(75, 3, 14, 'Anna.Lewandowska@school.edu.pl', '97cca1c25e6226fced8f3a28d44d9cf17c66184947263d00c3dcdf8ebfc9aae1'),
(76, 3, 15, 'Tomasz.Zieliński@school.edu.pl', '0475e03da603b8f0d58dcd1371581fc7d241d7a7a353ae1f449bfb1defa3c2d6'),
(77, 3, 16, 'Magdalena.Zielińska@school.edu.pl', '93eb56471db413f449d8265da640fee792a45ea9a2f263378b4e863137ad065f'),
(78, 3, 17, 'Jan.Woźniak@school.edu.pl', 'c27fbd2794e45f91e7a43f315a6277facfe3e73248862b00c114cdea2ae50001'),
(79, 3, 18, 'Katarzyna.Woźniak@school.edu.pl', 'd3f41183ec248e74a44b66d5a3074f9f3e7787412bee94b4a9b65c9b4d989520'),
(80, 3, 19, 'Piotr.Szymański@school.edu.pl', 'bb65e0b414147b52a68dfd07cadadd93a6b236664f92303928e7c558c2db3a56'),
(81, 3, 20, 'Maria.Szymańska@school.edu.pl', '665b638005a0929eb5a1ed434c5d1fe5773a385ae916d79b2634b1647912401b'),
(82, 3, 21, 'Tomasz.Dąbrowski@school.edu.pl', '572ddb9617f7eb35481f8967ea38a47b929f1e06aa667fd5572626a387918619'),
(83, 3, 22, 'Barbara.Dąbrowska@school.edu.pl', 'e8b175b0e8df9ff10255c2dcd8a4c046e856cf0ac58e09fe896179b8329a4b42'),
(84, 3, 23, 'Andrzej.Kozłowski@school.edu.pl', '43557ea47437bb2294712f63d3f9bc7713619c0a36b57e9fda278f8e110b71d0'),
(85, 3, 24, 'Maria.Kozłowska@school.edu.pl', '2246a4ad0f6cfe00c23ded32488997344b4fcedcbcbbed1e11b49a2d891805db'),
(86, 3, 25, 'Grzegorz.Mazur@school.edu.pl', '4a529b8c33c250e4e5867618c68b70b6665b9858cc38ec006900ee5400a627d6'),
(87, 3, 26, 'Agnieszka.Mazurska@school.edu.pl', 'e487cee4df664e6e77aab6bd8c8317f0eca53047a83b7ed4335f13feaa1bffa9'),
(88, 3, 27, 'Grzegorz.Jankowski@school.edu.pl', '1a0a8d0743fa97f2d5f87cebc08893ca6652c95c4bb9bd0813ee9e46fe1c6b11'),
(89, 3, 28, 'Agnieszka.Jankowska@school.edu.pl', 'c69d7ab16ed1a95b2b3f78c3f773448af38063e015c1033d07d9eae83023c47f'),
(90, 3, 29, 'Marek.Kwiatkowski@school.edu.pl', '9d1423c4b7144410aa6b975c07ca92f0ab3d3966c49a566bb19ad8a7ee3eb13f'),
(91, 3, 30, 'Zofia.Kwiatkowska@school.edu.pl', 'dd64d655bc169d090a26c863d26cb60a4cb6f2cbc73c3f24f3ad7f82cd0b5ed6'),
(92, 3, 31, 'Tomasz.Wojciechowski@school.edu.pl', '98abf9c9ccb0a522aa3f991f55b9653c2c6f3ac5a2a648126504d6c8ef41b365'),
(93, 3, 32, 'Małgorzata.Wojciechowska@school.edu.pl', '373bdf2e99db9e5c2b80da094f4af8d3b0d4e0fe4f83eaa8800c3b7c04028330'),
(94, 3, 33, 'Marek.Krawczyk@school.edu.pl', '708c2c68b522ecfda66bc90e288e06e65d38604c73934ae72a3f76b0a8d54ba9'),
(95, 3, 34, 'Joanna.Krawczyk@school.edu.pl', '685e6c32f3c96eb7c62c114106e7e23c0df7e09f8c8c98de10a42b065022233f'),
(96, 3, 35, 'Tomasz.Kaczmarek@school.edu.pl', 'f969cd30bb232de7f2e10867795c62854506a9eae352049184e23771656a9d6c'),
(97, 3, 36, 'Zofia.Kaczmarek@school.edu.pl', '83d9ba41fa8d80366c9227d1d555917386234a04f96b0f2320d1d9b0d2b25a52'),
(98, 3, 37, 'Marek.Piotrowski@school.edu.pl', 'c1b1d3f6445ee12d0f46afe7fa800c29c6a9db19b63fe9391bb1abbed07867bf'),
(99, 3, 38, 'Anna.Piotrowska@school.edu.pl', 'b98c6afb31c10569b532c1356be20478150cb35ca5d82ada0adacf852c05eaac'),
(100, 3, 39, 'Tomasz.Grabowski@school.edu.pl', 'cd400dc52e21e572ea9e1b46bb6f70a83b9fc58c485a4e71b3395eeb38c594b3'),
(101, 3, 40, 'Joanna.Grabowska@school.edu.pl', '705263a32fae60c771aea79d3fcca5322b443ecbd201f3dd791b44a22e3884b5'),
(102, 3, 41, 'Piotr.Zając@school.edu.pl', '119f23411d65e787f0947cb8af70ddd3e7e41d5ed109b9ebb9d80f002586ccc4'),
(103, 3, 42, 'Zofia.Zając@school.edu.pl', '0b4bd299984272cb06548ec95de24a3aaf4ae1aa3706206975030c3878a779ba'),
(104, 3, 43, 'Marcin.Pawłowski@school.edu.pl', 'ecdc905efff1392b2f6bbb42a917d121c251beae89360d7c7a87958064a6e822'),
(105, 3, 44, 'Barbara.Pawłowska@school.edu.pl', '0285ac603046ebbbb99bf5c485c1dd2f9423d6df10bc7637456576e5be3c2102'),
(106, 3, 45, 'Adam.Król@school.edu.pl', '288728e04eb7d9cfc651214e85ad423012c53e8db2247e93c1df443a9e155e69'),
(107, 3, 46, 'Magdalena.Król@school.edu.pl', '9b86e6e04aac0cbec00c08affe8f14144765e46219d970df011aa2f3bd0b9d0b'),
(108, 3, 47, 'Grzegorz.Michalski@school.edu.pl', 'e1d8cbcff815d2b6c7ccb52bd93719145f730e5b6cc874131fce76488b9a1105'),
(109, 3, 48, 'Katarzyna.Michalska@school.edu.pl', 'e129c41b6b42c1c6c6472996ee3daa8de6563fb7cb836fcd3955fa9aa0088318'),
(110, 3, 49, 'Krzysztof.Wróbel@school.edu.pl', '4b796837f1312915670c3081c0acb0a7f9503834813ebacefba1b4042345b598'),
(111, 3, 50, 'Agnieszka.Wróbel@school.edu.pl', '139e9a61ac5ee4de45a735cb1d78cc8b8a85863373a13c8047b1d3dadc5d7d40'),
(112, 3, 51, 'Tomasz.Wieczorek@school.edu.pl', '7a7e7ec082a800b93865e598bd1a36ba7322f56deaeb92c3e79e1c4c8e2a6975'),
(113, 3, 52, 'Magdalena.Wieczorek@school.edu.pl', '91be18fbadbaa6855010c4ca23c6287fad95fdd255467d0bef9496d01bf93a1a'),
(114, 3, 53, 'Grzegorz.Jabłoński@school.edu.pl', 'adf398da02f0cb7ee864cd0aeab9277ca544ebc6030668fd473b56dbf20c8186'),
(115, 3, 54, 'Magdalena.Jabłońska@school.edu.pl', '9bfa44fbfd8d07423d5bda68cfd13956f5c97fd40523d11d2cd8f1049abb1be4'),
(116, 3, 55, 'Andrzej.Nowakowski@school.edu.pl', 'acdacbcbef76b7be0ed7cce78fc9d35f0ee5d9b59096b6138f87381ee1269bf8'),
(117, 3, 56, 'Anna.Nowakowska@school.edu.pl', '99a8d66471fb8c29bb6f2291f6c364f10375acb20bdf9442a9c2a5c03a323d3c'),
(118, 3, 57, 'Piotr.Majewski@school.edu.pl', 'c68deb7e9139fd04b9452f8ac541bda79811b234141ea1602129027ef0a6f5d0'),
(119, 3, 58, 'Magdalena.Majewska@school.edu.pl', '846eca3a2fde6a9519d3f35a1a590d351b85b2269388770a65fdbbac3079fd43'),
(120, 3, 59, 'Piotr.Olszewski@school.edu.pl', 'fdd662abfd4e8f9f92bdc9dc1b6291da11af8a6aec9bbf980779d4f0c0a59846'),
(121, 3, 60, 'Barbara.Olszewska@school.edu.pl', 'def86fff2b94548ed54b1c8a1adc7588dc8691f157546dd78ec6d1d71337f44d');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `lessons`
--
ALTER TABLE `lessons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=122;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
