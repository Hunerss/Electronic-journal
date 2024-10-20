-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 20, 2024 at 05:44 PM
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

-- --------------------------------------------------------

--
-- Table structure for table `grades`
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
-- Table structure for table `lessons`
--

CREATE TABLE `lessons` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `class` int(11) NOT NULL,
  `classroom` int(11) NOT NULL,
  `teacher_id` int(11) NOT NULL,
  `class_id` int(11) NOT NULL,
  `lesson` int(11) NOT NULL
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
(1, 'Piotr', 'Nowak', 19635659, 1),
(2, 'Joanna', 'Nowak', 19766907, 0),
(3, 'Andrzej', 'Kowalski', 19614459, 1),
(4, 'Maria', 'Kowalska', 19691214, 0),
(5, 'Marek', 'Wiśniewski', 19660021, 1),
(6, 'Małgorzata', 'Wiśniewska', 19817793, 0),
(7, 'Jan', 'Wójcik', 19792512, 1),
(8, 'Barbara', 'Wójcik', 19679526, 0),
(9, 'Marcin', 'Kowalczyk', 19638132, 1),
(10, 'Barbara', 'Kowalczyk', 19751755, 0),
(11, 'Piotr', 'Kamiński', 19645957, 1),
(12, 'Agnieszka', 'Kamińska', 19704188, 0),
(13, 'Krzysztof', 'Lewandowski', 19655258, 1),
(14, 'Anna', 'Lewandowska', 19786073, 0),
(15, 'Tomasz', 'Zieliński', 19694057, 1),
(16, 'Magdalena', 'Zielińska', 19679657, 0),
(17, 'Jan', 'Woźniak', 19609608, 1),
(18, 'Katarzyna', 'Woźniak', 19809558, 0),
(19, 'Piotr', 'Szymański', 19675153, 1),
(20, 'Maria', 'Szymańska', 19758601, 0),
(21, 'Tomasz', 'Dąbrowski', 19647264, 1),
(22, 'Barbara', 'Dąbrowska', 19692205, 0),
(23, 'Andrzej', 'Kozłowski', 19691690, 1),
(24, 'Maria', 'Kozłowska', 19687041, 0),
(25, 'Grzegorz', 'Mazur', 19651066, 1),
(26, 'Agnieszka', 'Mazurska', 19738672, 0),
(27, 'Grzegorz', 'Jankowski', 19662419, 1),
(28, 'Agnieszka', 'Jankowska', 19833277, 0),
(29, 'Marek', 'Kwiatkowski', 19678237, 1),
(30, 'Zofia', 'Kwiatkowska', 19670952, 0),
(31, 'Tomasz', 'Wojciechowski', 19631368, 1),
(32, 'Małgorzata', 'Wojciechowska', 19849399, 0),
(33, 'Marek', 'Krawczyk', 19786111, 1),
(34, 'Joanna', 'Krawczyk', 19670762, 0),
(35, 'Tomasz', 'Kaczmarek', 19737003, 1),
(36, 'Zofia', 'Kaczmarek', 19838519, 0),
(37, 'Marek', 'Piotrowski', 19725038, 1),
(38, 'Anna', 'Piotrowska', 19707886, 0),
(39, 'Tomasz', 'Grabowski', 19656298, 1),
(40, 'Joanna', 'Grabowska', 19748928, 0),
(41, 'Piotr', 'Zając', 19731849, 1),
(42, 'Zofia', 'Zając', 19675527, 0),
(43, 'Marcin', 'Pawłowski', 19666196, 1),
(44, 'Barbara', 'Pawłowska', 19790230, 0),
(45, 'Adam', 'Król', 19718191, 1),
(46, 'Magdalena', 'Król', 19718313, 0),
(47, 'Grzegorz', 'Michalski', 19756772, 1),
(48, 'Katarzyna', 'Michalska', 19761946, 0),
(49, 'Krzysztof', 'Wróbel', 19797785, 1),
(50, 'Agnieszka', 'Wróbel', 19798653, 0),
(51, 'Tomasz', 'Wieczorek', 19716409, 1),
(52, 'Magdalena', 'Wieczorek', 19815920, 0),
(53, 'Grzegorz', 'Jabłoński', 19767114, 1),
(54, 'Magdalena', 'Jabłońska', 19729042, 0),
(55, 'Andrzej', 'Nowakowski', 19770128, 1),
(56, 'Anna', 'Nowakowska', 19750652, 0),
(57, 'Piotr', 'Majewski', 19753783, 1),
(58, 'Magdalena', 'Majewska', 19850521, 0),
(59, 'Piotr', 'Olszewski', 19712307, 1),
(60, 'Barbara', 'Olszewska', 19675962, 0);

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
(1, 'Andrzej', 'Nowak', '1A', 20097280, 15, 1, 1, 2),
(2, 'Maria', 'Kowalska', '1A', 20090106, 15, 0, 3, 4),
(3, 'Paweł', 'Wiśniewski', '1A', 20097196, 15, 1, 5, 6),
(4, 'Barbara', 'Wójcik', '1A', 20091151, 15, 0, 7, 8),
(5, 'Andrzej', 'Kowalczyk', '1A', 20099545, 15, 1, 9, 10),
(6, 'Małgorzata', 'Kamińska', '1A', 20097262, 15, 0, 11, 12),
(7, 'Jan', 'Lewandowski', '1A', 20104967, 14, 1, 13, 14),
(8, 'Katarzyna', 'Zielińska', '1A', 20094971, 15, 0, 15, 16),
(9, 'Krzysztof', 'Woźniak', '1A', 20091460, 15, 1, 17, 18),
(10, 'Zofia', 'Szymańska', '1A', 20094812, 15, 0, 19, 20),
(11, 'Adam', 'Dąbrowski', '1A', 20090479, 15, 1, 21, 22),
(12, 'Magdalena', 'Kozłowska', '1A', 20090735, 16, 0, 23, 24),
(13, 'Paweł', 'Mazur', '1A', 20090106, 15, 1, 25, 26),
(14, 'Anna', 'Jankowska', '1A', 20107390, 14, 0, 27, 28),
(15, 'Tomasz', 'Kwiatkowski', '1A', 20091962, 15, 1, 29, 30),
(16, 'Marek', 'Wojciechowski', '1A', 20097486, 15, 1, 31, 32),
(17, 'Zofia', 'Krawczyk', '1A', 20096588, 15, 0, 33, 34),
(18, 'Piotr', 'Kaczmarek', '1A', 20092085, 15, 1, 35, 36),
(19, 'Joanna', 'Piotrowska', '1A', 20103606, 14, 0, 37, 38),
(20, 'Tomasz', 'Grabowski', '1A', 20099545, 15, 1, 39, 40),
(21, 'Zofia', 'Zając', '1A', 20099471, 15, 0, 41, 42),
(22, 'Marek', 'Pawłowski', '1A', 20098745, 15, 1, 43, 44),
(23, 'Anna', 'Król', '1A', 20095165, 15, 0, 45, 46),
(24, 'Krzysztof', 'Michalski', '1A', 20096234, 15, 1, 47, 48),
(25, 'Maria', 'Wróbel', '1A', 20096555, 15, 0, 49, 50),
(26, 'Adam', 'Wieczorek', '1A', 20098415, 15, 1, 51, 52),
(27, 'Joanna', 'Jabłońska', '1A', 20094560, 15, 0, 53, 54),
(28, 'Piotr', 'Nowakowski', '1A', 20093478, 15, 1, 55, 56),
(29, 'Zofia', 'Majewska', '1A', 20096588, 15, 0, 57, 58),
(30, 'Tomasz', 'Olszewski', '1A', 20099345, 15, 1, 59, 60);

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
(11, 'Jacek', 'Dąbrowski', 'Wychowanie fizyczne (WF)', '', 0, 19751230, 48, 1),
(12, 'Joanna', 'Kozłowska', 'Edukacja dla bezpieczeństwa (EDB)', '3c', 113, 19861205, 37, 0),
(13, 'Katarzyna', 'Mazur', 'Religia', '', 114, 19790801, 45, 0),
(14, 'Grzegorz', 'Jankowski', 'Etyka', '', 115, 19890316, 35, 1),
(15, 'Rafał', 'Kwiatkowski', 'Język rosyjski', '3d', 116, 19841110, 40, 1),
(16, 'Anna', 'Wojciechowska', 'Podstawy przedsiębiorczości', '4a', 117, 19910425, 33, 0),
(17, 'Iwona', 'Krawczyk', 'Wychowanie fizyczne (WF)', '4b', 0, 19931220, 30, 0),
(18, 'Paweł', 'Kaczmarek', 'Język angielski', '4c', 119, 19871001, 37, 1),
(19, 'Barbara', 'Piotrowska', 'Matematyka', '4d', 120, 19760606, 48, 0),
(20, 'Maciej', 'Grabowski', 'Język angielski', '', 201, 19890905, 35, 1),
(21, 'Monika', 'Zając', 'Język angielski', '', 202, 19801219, 43, 0),
(22, 'Wojciech', 'Król', 'Język polski', '', 203, 19900411, 34, 1),
(23, 'Piotr', 'Wróbel', 'Matematyka', '', 204, 19740828, 50, 1),
(24, 'Zofia', 'Wieczorek', 'Język angielski', '', 205, 19930914, 31, 0),
(25, 'Robert', 'Jabłoński', 'Matematyka', '', 206, 19810525, 43, 1),
(26, 'Marta', 'Nowakowska', 'Wychowanie fizyczne (WF)', '', 0, 19770330, 47, 0),
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
(0, 0, 0, 'admin@school.edu.pl', 'fb001dfcffd1c899f3297871406242f097aecf1a5342ccf3ebcd116146188e4b'),
(1, 1, 1, 'anna.nowak@school.edu.pl', 'e0a27c499a41bf594164978838e0819c873b15a99b213dd869c376c54e2fb605'),
(2, 1, 2, 'jan.kowalski@school.edu.pl', '0435f5096de91709706b2ca5eea0c81d99350e87ca416ddb5b74dfc59ee9d9d4'),
(3, 1, 3, 'maria.wiśniewska@school.edu.pl', '42878af23cd4b5b84d1c6c51c0715c7ffef1585157aa1a5da7d2e9e459f2cafd'),
(4, 1, 4, 'tomasz.wójcik@school.edu.pl', '6e8178449e12e68b03f491384db4ab64c2d03d1f1607749e4a7851fcdccc6b9d'),
(5, 1, 5, 'ewa.kowalczyk@school.edu.pl', '15b4885a01a9856456aba01ef1c836279a19c64291aefd7271c226ac65007a8e'),
(6, 1, 6, 'krzysztof.kamiński@school.edu.pl', '94e3a64b1d4ac8881b3e41b08d6fb13ec282812fdfa00487d0d7294d20c8b44c'),
(7, 1, 7, 'marek.lewandowski@school.edu.pl', '506f588b99eb750434d3d644e2493b81fa12d2350f9fc4005abef6eead5ff784'),
(8, 1, 8, 'magdalena.zielińska@school.edu.pl', '13a19be0646eeddc1d2dee3def94fb18a79232e3cdaeb088426863540e0edb58'),
(9, 1, 9, 'piotr.woźniak@school.edu.pl', 'c12a6b106d4dcb7ee79419f0abbd708b1fff9aa6f983358705ca484f146d05d9'),
(10, 1, 10, 'agnieszka.szymańska@school.edu.pl', 'd5271eb1bc764277738a383e61881fd8daf9239ec451a055c8894ef7f19b57e3'),
(11, 1, 11, 'jacek.dąbrowski@school.edu.pl', '9409809e618c67ca004c045128e0e4e7287c58086694ef89bec9d13550055cc4'),
(12, 1, 12, 'joanna.kozłowska@school.edu.pl', 'bc443d8506c434840951aeb6e12446988482f93814d4c9b4536be882768b94ed'),
(13, 1, 13, 'katarzyna.mazur@school.edu.pl', 'f28f925c37d41a33fb0709f95dac68cf9633efec13a756024a55879de92d68bc'),
(14, 1, 14, 'grzegorz.jankowski@school.edu.pl', '6a073c5a558ee07bc2bd0318f8f4651661de90a57e2a93553c6a1c5dabf0beb2'),
(15, 1, 15, 'rafał.kwiatkowski@school.edu.pl', '751bd331e598ef506315be7c06d1767817038b0013ffb6800080599d92230d7e'),
(16, 1, 16, 'anna.wojciechowska@school.edu.pl', '23fb2c46caa075a533527c51e6b1fe847f243868a54b84069e44517331d905f2'),
(17, 1, 17, 'iwona.krawczyk@school.edu.pl', '6c70f3ddc8b818b5c4543fbb75d5f655e4b16f56b18b5aa128d0e72299587ed2'),
(18, 1, 18, 'paweł.kaczmarek@school.edu.pl', '8dd46c09726eacd890680994ac604b6c9f5793db15c6b2c80815713812886b31'),
(19, 1, 19, 'barbara.piotrowska@school.edu.pl', '117026b897c502ed2a533f816818bd9da7ac3adc1095606a737de084180dc62a'),
(20, 2, 1, 'andrzej.nowak@school.edu.pl', '86ebd3cf2227d63d8b9535e5d07c0544b45fa1e4a2adf0ef1eb42e05d7a4e057'),
(21, 2, 2, 'maria.kowalska@school.edu.pl', 'f4e661456cc63492501ae89d8b356cfe28b0fc27f1c6c166e042cfcb8395c74a'),
(22, 2, 3, 'pawel.wiśniewski@school.edu.pl', '07ae2b3576c5812a548bd07a8d871fca865b274c49046faebd1e590dbb882e3f'),
(23, 2, 4, 'barbara.wójcik@school.edu.pl', 'dff3e5a71a2f30bde07c1449db19e8fa41b1e1cf2be09918b4f3f85362736753'),
(24, 2, 5, 'andrzej.kowalczyk@school.edu.pl', '217ae7098e7aa8b129eff208bb38cb03d2fb51176b991799f7734492b95d7e07'),
(25, 2, 6, 'malgorzata.kamińska@school.edu.pl', '8a53f033a43a1a7b582cda0a61f992afee576b1db63a29a15ad85bb7cc5f3256'),
(26, 2, 7, 'jan.lewandowski@school.edu.pl', 'ee9937b066ae72b1b5cb65a5ce164b135b19a5aa4f32a8c7b77ecfc63707f2af'),
(27, 2, 8, 'katarzyna.zielińska@school.edu.pl', '7a8a84049c9bb9a74cf3888890c2287de6a44140b3190aafde4fa6a178ca1999'),
(28, 2, 9, 'krzysztof.woźniak@school.edu.pl', 'ad25dd75c93f4e5c63c24a9cb708d331bf7b83a126c17de0ef8d82cb37c7be6d'),
(29, 2, 10, 'zofia.szymańska@school.edu.pl', '58fcac3277c80973a25db0af9200ac0f634f3147e5ab8c5579b3dc31ff19b8ee'),
(30, 2, 11, 'adam.dąbrowski@school.edu.pl', 'b6e8bfb58e17b8f364ec76d08f8595ae236820401f4908e54b44baf0a340f8ff'),
(31, 2, 12, 'magdalena.kozłowska@school.edu.pl', 'ed818d878f5c1daef56f3d76fd64fa9c536e29f2b92696aa399a2ba23a9d89be'),
(32, 2, 13, 'pawel.mazur@school.edu.pl', '3335fc146f85bc19b336f132e53621d19a07d28c90db284d986b0bfa6bc5f74b'),
(33, 2, 14, 'anna.jankowska@school.edu.pl', '2010e865b7e20a37ccf37ac3e960ac1eb75625f57d0d2536d240b0b2e6548a3c'),
(34, 2, 15, 'tomasz.kwiatkowski@school.edu.pl', '8e39ddc0d7a674d7354411874f352c54f3b609ae33f6149f4770c267bc89fd26'),
(35, 2, 16, 'marek.wojciechowski@school.edu.pl', 'b3b88b38055cf1c34a88be8014893e7aab83af1676a4a63083f83d64f22d47f1'),
(36, 2, 17, 'zofia.krawczyk@school.edu.pl', '44b48f00f24181c1df746da062ed4d9d609a4cbac5aa6ad27e9027d509c8d1a2'),
(37, 2, 18, 'piotr.kaczmarek@school.edu.pl', 'e45e81903cc1fbe31de7d878ce7850706808d23b6532369be255be8f07cfa3cb'),
(38, 2, 19, 'joanna.piotrowska@school.edu.pl', '144b3481d1b2b1222b9dce555a64fb8991c799939a53c87dcf5892a258fa2922'),
(39, 2, 20, 'tomasz.grabowski@school.edu.pl', '646c2fffa24c95c46268da4a4ba3e57d0039a5b81e5365bc5f882e8c4f9af3e7'),
(40, 2, 21, 'zofia.zając@school.edu.pl', '786a789bc33ac82f14e45812e34adbb89139e6cbd7855eb374d1fd953e627e3d'),
(41, 2, 22, 'marek.pawłowski@school.edu.pl', '9a220b010b2bc1108c740cb1e0c67a0dc2e9ebadd99cf953962dba14f3b401fc'),
(42, 2, 23, 'anna.król@school.edu.pl', '4c1c01c1d84b14c0e12b46d6d826230b032e2ce332d223272d70c7fa2262401d'),
(43, 2, 24, 'krzysztof.michalski@school.edu.pl', 'b5da149682d72fa308db279d123960b47d80b74dd1231182141dd1673b93cc1e'),
(44, 2, 25, 'maria.wróbel@school.edu.pl', 'fbb5353a6e93ea2d9cfb5e80842a0972c95b722ff25b37dd930426d4db65b2e4'),
(45, 2, 26, 'adam.wieczorek@school.edu.pl', '92e3bb8c64089cb1ce56d776ace3cb68e58d3bfb2646487fae0cf3d80cd2e469'),
(46, 2, 27, 'joanna.jabłońska@school.edu.pl', 'd3fa43422b8a1d89af6785c87762e420fa424fc64f90c6f92ab75f0f337bd138'),
(47, 2, 28, 'piotr.nowakowski@school.edu.pl', '005de0845f86018f3991fa048ee04f415a8e0b1c1d49fe9944c84ce5947e3da0'),
(48, 2, 29, 'zofia.majewska@school.edu.pl', '72882e41a1876668bbd755865f2b3ae2af13fd3fc318e0a84d2403194a6beea1'),
(49, 2, 30, 'tomasz.olszewski@school.edu.pl', 'ab60b869c1611ab2718f7e4a72176fe3bda6347e60e767d92b681df72d71043f'),
(50, 3, 1, 'piotr.nowak@school.edu.pl', 'cb2c5a8dcf36a9a127240f05728f9dc1364c60c22c1167c680a45bb5198fda8b'),
(51, 3, 1, 'joanna.nowak@school.edu.pl', 'ce376474fd63a130cf9c2f14d8e1ef82c86f0b758c8ae563b1b0498bba8ad42a'),
(52, 3, 2, 'andrzej.kowalski@school.edu.pl', 'd9e2b752baf567d496689aa4bb8f7b0f256c7b0ad601e53f36b57b1c3c8a74b4'),
(53, 3, 2, 'maria.kowalska@school.edu.pl', '69e0b9ddf0386a0d56f580fb5370262ad37fb64bff1ebcf4f34c8be3a2f0c1b7'),
(54, 3, 3, 'marek.wiśniewski@school.edu.pl', '3a72210fae8358baf712f5cc93e351b65719c3e2fa3dc30ed073f29cc9259203'),
(55, 3, 3, 'malgorzata.wiśniewska@school.edu.pl', '7be98ef9920ae0ef66dc942a3b47cb2ba00806e5994536ba1b7f6e40c0c93713'),
(56, 3, 4, 'jan.wojcik@school.edu.pl', '202c0cbdfc6bc57e14b27d0ec28a3bc37f12121896e39b003cf18fd9ca14f5e5'),
(57, 3, 4, 'barbara.wojcik@school.edu.pl', 'a9fc60f41da34dfc86ed7cf8c98d3e0399988e5885a3aabdb67f419bcd209c63'),
(58, 3, 5, 'marcin.kowalczyk@school.edu.pl', '24cc07adabcb8a0918a226ea053f2e19f5c1b7ab482f589e36ffb740a8fc6ed0'),
(59, 3, 5, 'barbara.kowalczyk@school.edu.pl', '81e1ae55c942383175e1907e6d12a3f129d9097f79af4a42d2e4ff618c34d711'),
(60, 3, 6, 'piotr.kaminski@school.edu.pl', '0f365b53d19348cf167e3b0086b4dcaaed1a9aeaa6b59eb69ae282af9131d142'),
(61, 3, 6, 'agnieszka.kaminska@school.edu.pl', '23d2f7cf65e417164e734bb20da2786ae2ac620a8a73749e93cc5b2fa23dc21a'),
(62, 3, 7, 'krzysztof.lewandowski@school.edu.pl', 'd8597b6f447d7a2f4c812b1ff00c432cc96e8fc978db4225e7ff81fe9b4e7416'),
(63, 3, 7, 'anna.lewandowska@school.edu.pl', 'f8ef843924215aee7bc44efeb06fdd8acde2a69e51e679ce7a89f847bd8b9fa9'),
(64, 3, 8, 'tomasz.zielinski@school.edu.pl', '7877a42f2a42c32501ab0c8c76dd420e6f510ca3018c7db4c0f4d0537fa1eb7e'),
(65, 3, 8, 'magdalena.zielinska@school.edu.pl', '0309cba52815f6c6a105c191fe248eb3b47d4f7cc1b372a31e03b3a491ce1b07'),
(66, 3, 9, 'jan.wozniak@school.edu.pl', 'f34b442a69c32f111d3a6eab0f5157c1183e5266f56c37720e53b90a7cb61642'),
(67, 3, 9, 'katarzyna.wozniak@school.edu.pl', '54c1357d482f82b80c6fa00ac35106ccad9c741d55d7b1c6c78b17e16d73898f'),
(68, 3, 10, 'piotr.szymanski@school.edu.pl', 'f833a00c489683c697abac7c37e7080fbb39457951838b2847d90e1a73593b31'),
(69, 3, 10, 'maria.szymanska@school.edu.pl', 'fbe07c011949f0b9b40368b6710b60b4dcdad3f63b9ec3f92664f92edacde7b7'),
(70, 3, 11, 'tomasz.dabrowski@school.edu.pl', '65041ff8b95d2d535d368f145dfeaa2c6f0a546452d3dc0c6e0c17fe2162df6b'),
(71, 3, 11, 'barbara.dabrowska@school.edu.pl', 'c3a98e7c4c9b0b55df6661fc7f8024c03ff0b2173d3dc5f9c73c00fbdac79969'),
(72, 3, 12, 'andrzej.kozlowski@school.edu.pl', 'a1ad8741a24a71894967fe4fa5467ba91ab9a84ebaa65c38cf6aaf84d236a736'),
(73, 3, 12, 'maria.kozlowska@school.edu.pl', 'fe251ec06d1c4be04f7aa251cba063db95a13d47d0f5d65f7082d184cc39dbee'),
(74, 3, 13, 'grzegorz.mazur@school.edu.pl', '3cb18c7750c1f2ec97964c75e853f2a8c5228f9026f9469d6d24ef4238e3c083'),
(75, 3, 13, 'agnieszka.mazurska@school.edu.pl', '74e85f98a8f8ff605404740705c8b69cc0140bc30a5760dd6576ed1134da3f4d'),
(76, 3, 14, 'grzegorz.jankowski@school.edu.pl', '4c56c4d632eb914eb7058bc7caa2417f056b3295255c24b7c30dded70246b8f1'),
(77, 3, 14, 'agnieszka.jankowska@school.edu.pl', '9cb0f2a270425376a155a95e98db58071a849d7799fd174047bf6c4c322f2519'),
(78, 3, 15, 'marek.kwiatkowski@school.edu.pl', 'de8dff51f2a616a1ec3a2d3d14f27ae515337d47134a0b69b8d54633e2345975'),
(79, 3, 15, 'zofia.kwiatkowska@school.edu.pl', '37fe5a256a934b6b01fd29af9d56e7c6d9917d848fbc7e41b24e24cb654098cc'),
(80, 3, 16, 'tomasz.wojciechowski@school.edu.pl', 'f9dc327fa328ff535b8ef870bb1e51544c1a24cc773cb303e0e5358a77ce41ba'),
(81, 3, 16, 'malgorzata.wojciechowska@school.edu.pl', '75f6c9b781cf3f27dc79fc2ec792e21254dbbb74fbb7d04ba1999f9b3fb74fc4'),
(82, 3, 17, 'marek.krawczyk@school.edu.pl', 'd9462768dfd645e70f52716c4fc158ad5e6fb1f5ac11919239b44cb745dba6f2'),
(83, 3, 17, 'joanna.krawczyk@school.edu.pl', 'f5c9d8a86aeb5ba3fe9fcff89fca04ad59a0ba667d9de7886b3bb38a3a08e960'),
(84, 3, 18, 'tomasz.kaczmarek@school.edu.pl', 'fc6b1d46c999f35cb6bc4de946b7e999647399c3fce74f7a6817c3b784d3f274'),
(85, 3, 18, 'zofia.kaczmarek@school.edu.pl', '47348527d30945125370ce358d6de1055869afec611e7c0a52bbffb4a002cb32'),
(86, 3, 19, 'marek.piotrowski@school.edu.pl', '1d00db2fa33b263e2f3185b787ef03b5f5f3e32b1d1937fe4843f7452b5fef40'),
(87, 3, 19, 'anna.piotrowska@school.edu.pl', '9166d7e5a89d3d3e3519b5a1a71f9e4c6cb38fd8cf80a57358fbf7338e1e108a'),
(88, 3, 20, 'tomasz.grabowski@school.edu.pl', '61ab9f61c49bc342ff85878e669dc279f68ad08adf277240b253b9c8c06dfb4b'),
(89, 3, 20, 'joanna.grabowska@school.edu.pl', 'dd9f3d6f364da83bb319dc50063c942d4101e3bc44b6b77f1e236ce3b531d7c2'),
(90, 3, 21, 'piotr.zajac@school.edu.pl', '2d1b19efc2cbb8a1b2d1b6d2b7291659e1aef12a0ff26a1597e3e5ac59d567a6'),
(91, 3, 21, 'zofia.zajac@school.edu.pl', 'c815d9c34820bc1d2e3e44c6ff05781994629c42171773cb5da9a640d8d5e517'),
(92, 3, 22, 'marcin.pawlowski@school.edu.pl', '4a0482ca15d48de8b9cc83cc74b53545a9bbd2cb45c2109ce496bf4cf6b258d7'),
(93, 3, 22, 'barbara.pawlowska@school.edu.pl', '2e35efbd2cb705df9f38891811efed7466701272c31f4d3245fbe90989c1f653'),
(94, 3, 23, 'adam.krol@school.edu.pl', '25e19d95ed6f17d9188029b206de63566a7a85b14b6e5f20792fba31cbd0984a'),
(95, 3, 23, 'magdalena.krol@school.edu.pl', 'ddcb5a6f205645d4f26904006eb372b05f64602ad85d5fc7242ac2b1f7f8ef7a'),
(96, 3, 24, 'grzegorz.michalski@school.edu.pl', 'd58364f0ca3ad0490df139b13b4eb4c0e57691b210fc871e9f6bc7fe0b565b58'),
(97, 3, 24, 'katarzyna.michalska@school.edu.pl', '9b5996e2831a9f3e66c59fc606e1104b02c81c2f1ae354ed32be6a1f110a9c1b'),
(98, 3, 25, 'krzysztof.wrobel@school.edu.pl', 'e253dc96b5d4403e429fd8f9e4acda8537d4fa7a7f25e0b2b0125db580d2a872'),
(99, 3, 25, 'agnieszka.wrobel@school.edu.pl', '44e0b1925c34c6e3eb2ac00faad3d73be57d118c738f34b3b60f8799495e6165'),
(100, 3, 26, 'tomasz.wieczorek@school.edu.pl', '3440f3f8187e67a2e3202c91f4316e66074a6098b23e0e460c0b5d4e79e8fb2f'),
(101, 3, 26, 'magdalena.wieczorek@school.edu.pl', '67f7b0418e4a8ff94b71bcb5de27d22601e9cf51b354a0e775bd224c9279b22d'),
(102, 3, 27, 'grzegorz.jablonski@school.edu.pl', '738191731631655c99ed567ad0e2b9008d875f6f283cde855a3b196dd7b46541'),
(103, 3, 27, 'magdalena.jablonska@school.edu.pl', '5a982c37be52394618f5da31edbe72ca203789d3f2a1d0989fb5cb086b6d8b6c'),
(104, 3, 28, 'andrzej.nowakowski@school.edu.pl', 'e3c7436ecaa78082d35352fc2d44b9c5f06a7f818d128d5a59427443a0f57f1a'),
(105, 3, 28, 'anna.nowakowska@school.edu.pl', 'bbf39992534f07b2e55be68d1fbfdab6df2977b6f896d2f2b2db1c3f45cf1f93'),
(106, 3, 29, 'piotr.majewski@school.edu.pl', '402729a1a9ba1376317cdb1d62c5ad2a282105fae7e2b4b9a64b68d6f376a7d2'),
(107, 3, 29, 'magdalena.majewska@school.edu.pl', '5f20748d76fe28f2cf9476f3665411d4d98923b1a4a5b60c55ed0abff9a8dc35'),
(108, 3, 30, 'piotr.olszewski@school.edu.pl', '26f456b9f57b9ef940455f3a33b2ad145ac12fbff5d78be02626c745b7430156'),
(109, 3, 30, 'barbara.olszewska@school.edu.pl', '9e5364df89f2feef6cf1565b3487e1e37d0d117da54454cba89c4a85b1100d38');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `grades`
--
ALTER TABLE `grades`
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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=110;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
