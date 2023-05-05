CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
    ) default charset utf8mb4 COMMENT '';

CREATE TABLE
    IF NOT EXISTS keeps(
        id INT NOT NULL AUTO_INCREMENT primary key,
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(255) NOT NULL,
        description VARCHAR (500) NOT NULL,
        img VARCHAR (500) NOT NULL,
        views INT NOT NULL,
        kept INT NOT NULL,
        createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8mb4 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaultKeeps(
        id INT NOT NULL AUTO_INCREMENT primary key,
        creatorId VARCHAR(255) NOT NULL,
        vaultId INT NOT NULL,
        keepId INT NOT NULL,
        createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
        FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
    ) default charset utf8mb4 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaults(
        id INT NOT NULL AUTO_INCREMENT primary key,
        creatorId VARCHAR(255) NOT NULL,
        name VARCHAR(255) NOT NULL,
        description VARCHAR(500) NOT NULL,
        img VARCHAR (255) NOT NULL,
        isPrivate BOOLEAN NOT NULL DEFAULT FALSE,
        createdAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8mb4 COMMENT '';

ALTER TABLE accounts ADD COLUMN coverImg VARCHAR (255) NOT NULL;