CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Battles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `StartDate` datetime(6) NOT NULL,
    `EndDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_Battles` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Samurais` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `BattleId` int NOT NULL,
    CONSTRAINT `PK_Samurais` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Samurais_Battles_BattleId` FOREIGN KEY (`BattleId`) REFERENCES `Battles` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Quotes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Text` longtext CHARACTER SET utf8mb4 NOT NULL,
    `SamuraiId` int NOT NULL,
    CONSTRAINT `PK_Quotes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Quotes_Samurais_SamuraiId` FOREIGN KEY (`SamuraiId`) REFERENCES `Samurais` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Quotes_SamuraiId` ON `Quotes` (`SamuraiId`);

CREATE INDEX `IX_Samurais_BattleId` ON `Samurais` (`BattleId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241011061533_Initial', '8.0.10');

COMMIT;

