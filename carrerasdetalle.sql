/*
Navicat MySQL Data Transfer

Source Server         : osys
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : atletica

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2016-09-02 23:44:30
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `carrerasdetalle`
-- ----------------------------
DROP TABLE IF EXISTS `carrerasdetalle`;
CREATE TABLE `carrerasdetalle` (
  `IdEmpresa` int(11) NOT NULL,
  `IdCarrera` int(11) NOT NULL,
  `Id` int(11) NOT NULL,
  `Numero` int(11) DEFAULT NULL,
  `Competidor` varchar(255) DEFAULT NULL,
  `FechaNacimiento` date DEFAULT NULL,
  `Genero` varchar(9) DEFAULT NULL,
  `Ciudad` varchar(100) DEFAULT NULL,
  `IdDistancia` int(11) DEFAULT NULL,
  `IdCategoria` int(11) DEFAULT NULL,
  `Rama` varchar(7) DEFAULT NULL,
  `Chip` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdEmpresa`,`IdCarrera`,`Id`),
  KEY `IdEmpresa` (`IdEmpresa`,`IdDistancia`),
  CONSTRAINT `carrerasdetalle_ibfk_1` FOREIGN KEY (`IdEmpresa`, `IdCarrera`) REFERENCES `carreras` (`IdEmpresa`, `IdCarrera`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `carrerasdetalle_ibfk_3` FOREIGN KEY (`IdEmpresa`) REFERENCES `empresas` (`idEmpresa`) ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of carrerasdetalle
-- ----------------------------
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '1', '201', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 35 14 10 88 67');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '2', '202', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 38 14 10 87 9F');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '3', '203', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 17 14 10 87 78');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '4', '204', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 97 14 10 87 56');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '5', '205', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 93 14 10 87 48');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '6', '206', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 85 14 10 87 38');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '7', '207', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 57 14 10 87 06');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '8', '208', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 40 14 10 86 DE');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '9', '209', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 36 14 10 86 D0');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '10', '210', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 32 14 10 86 CE');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '11', '211', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 28 14 10 86 C0');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '12', '212', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 20 14 10 86 B0');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '13', '213', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 14 14 20 84 6D');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '14', '214', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 22 14 20 84 7D');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '15', '215', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 31 14 20 84 95');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '16', '216', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 35 14 20 84 97');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '17', '217', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 73 14 20 84 E6');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '18', '218', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 77 14 20 84 E8');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '19', '219', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 81 14 20 84 F6');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '20', '220', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 93 14 20 85 08');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '21', '221', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 97 14 20 85 16');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '22', '222', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 09 14 20 85 28');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '23', '223', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 25 14 20 85 48');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '24', '224', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 29 14 20 85 56');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '25', '225', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 42 14 20 85 6D');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '26', '226', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 50 14 20 85 7D');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '27', '227', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 54 14 20 85 7F');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '28', '228', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 74 14 20 85 AD');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '29', '229', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 78 14 20 85 AF');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '30', '230', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 82 14 20 85 BD');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '31', '231', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 90 14 20 85 CD');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '32', '232', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 17 14 20 86 06');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '33', '233', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 33 14 20 86 26');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '34', '234', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 41 14 20 86 36');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '35', '235', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 57 14 20 86 56');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '36', '236', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 65 14 20 86 66');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '37', '237', '', null, '', '', '0', '0', '', 'E2 00 40 74 94 10 01 24 09 80 B7 E9');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '38', '238', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 85 14 30 88 C4');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '39', '239', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 57 14 30 88 92');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '40', '240', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 53 14 30 88 84');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '41', '241', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 37 14 30 88 64');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '42', '242', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 14 14 30 88 39');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '43', '243', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 01 14 30 88 22');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '44', '244', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 95 14 30 88 13');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '45', '245', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 91 14 30 88 11');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '46', '246', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 87 14 30 88 03');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '47', '247', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 67 14 30 87 E1');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '48', '248', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 47 14 30 87 B3');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '49', '249', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 43 14 30 87 B1');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '50', '250', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 19 14 30 87 81');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '51', '251', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 91 14 30 87 43');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '52', '252', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 83 14 30 87 33');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '53', '253', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 79 14 30 87 31');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '54', '254', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 75 14 30 87 23');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '55', '255', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 63 14 30 87 11');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '56', '256', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 59 14 30 87 03');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '57', '257', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 55 14 30 87 01');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '58', '258', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 33 14 30 86 D2');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '59', '259', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 29 14 30 86 C4');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '60', '260', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 25 14 30 86 C2');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '61', '261', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 13 14 30 86 A4');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '62', '262', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 14 14 40 84 69');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '63', '263', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 26 14 40 84 7B');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '64', '264', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 35 14 40 84 93');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '65', '265', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 56 14 40 84 BA');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '66', '266', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 84 14 40 84 EC');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '67', '267', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 27 14 40 85 51');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '68', '268', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 43 14 40 85 71');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '69', '269', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 47 14 40 85 73');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '70', '270', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 51 14 40 85 81');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '71', '271', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 63 14 40 85 93');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '72', '272', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 67 14 40 85 A1');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '73', '273', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 71 14 40 85 A3');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '74', '274', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 30 14 40 86 19');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '75', '275', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 85 14 50 84 48');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '76', '276', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 73 14 50 84 36');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '77', '277', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 65 14 50 84 26');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '78', '278', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 53 14 50 84 08');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '79', '279', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 28 14 50 83 D0');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '80', '280', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 11 14 50 83 B7');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '81', '281', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 90 14 50 83 8D');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '82', '282', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 82 14 50 83 7D');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '83', '283', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 66 14 50 83 5D');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '84', '284', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 62 14 50 83 4F');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '85', '285', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 46 14 50 83 2F');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '86', '286', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 42 14 50 83 2D');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '87', '287', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 30 14 50 83 0F');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '88', '288', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 98 14 50 82 CF');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '89', '289', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 94 14 50 82 CD');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '90', '290', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 90 14 50 82 BF');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '91', '291', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 82 14 50 82 AF');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '92', '292', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 74 14 50 82 9F');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '93', '293', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 39 14 50 82 65');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '94', '294', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 24 14 60 7F FE');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '95', '295', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 15 14 60 7F F5');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '96', '296', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 11 14 70 82 23');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '97', '297', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 27 14 70 82 43');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '98', '298', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 45 14 70 82 64');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '99', '299', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 58 14 70 82 7B');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '100', '300', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 62 14 70 82 89');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '101', '301', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 74 14 70 82 9B');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '102', '302', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 90 14 70 82 BB');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '103', '303', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 06 14 70 82 DB');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '104', '304', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 14 14 70 82 EB');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '105', '305', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 50 14 70 83 39');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '106', '306', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 66 14 70 83 59');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '107', '307', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 70 14 70 83 5B');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '108', '308', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 78 14 70 83 6B');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '109', '309', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 84 14 70 83 7A');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '110', '310', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 88 14 70 83 7C');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '111', '311', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 92 14 70 83 8A');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '112', '312', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 18 14 70 83 BB');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '113', '313', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 22 14 70 83 C9');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '114', '314', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 30 14 70 83 D9');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '115', '315', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 38 14 70 83 E9');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '116', '316', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 59 14 70 84 13');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '117', '317', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 63 14 70 84 21');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '118', '318', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 71 14 70 84 31');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '119', '319', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 79 14 70 84 41');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '120', '320', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 68 14 80 81 DC');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '121', '321', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 64 14 80 81 DA');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '122', '322', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 27 14 80 81 93');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '123', '323', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 23 14 80 81 91');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '124', '324', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 19 14 80 81 83');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '125', '325', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 02 03 14 80 81 63');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '126', '326', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 89 14 80 81 44');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '127', '327', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 85 14 80 81 42');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '128', '328', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 73 14 80 81 24');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '129', '329', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 65 14 80 81 14');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '130', '330', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 61 14 80 81 12');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '131', '331', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 48 14 80 80 EC');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '132', '332', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 40 14 80 80 DC');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '133', '333', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 32 14 80 80 CC');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '134', '334', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 24 14 80 80 BC');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '135', '335', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 20 14 80 80 BA');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '136', '336', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 01 12 14 80 80 AA');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '137', '337', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 99 14 80 80 93');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '138', '338', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 95 14 80 80 91');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '139', '339', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 83 14 80 80 73');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '140', '340', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 79 14 80 80 71');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '141', '341', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 71 14 80 80 61');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '142', '342', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 67 14 80 80 53');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '143', '343', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 63 14 80 80 51');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '144', '344', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 55 14 80 80 41');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '145', '345', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 35 14 80 80 13');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '146', '346', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 25 14 80 80 02');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '147', '347', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 21 14 80 7F F4');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '148', '348', '', null, '', '', '0', '0', '', 'FF FF FF 42 FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '149', '349', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 61 14 90 7E 08');
INSERT INTO `carrerasdetalle` VALUES ('14', '1', '150', '350', '', null, '', '', '0', '0', '', 'E2 00 40 05 73 0D 00 95 14 90 7E 55');
