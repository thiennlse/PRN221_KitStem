create database KitStemDB
go
use KitStemDB
go

CREATE TABLE Users (
    id INT PRIMARY KEY,
    roleId VARCHAR(255),
    name VARCHAR(255),
    phone VARCHAR(255),
    email VARCHAR(255),
    password VARCHAR(255),
    username VARCHAR(255),
    role INT,
    description TEXT,
    DOB DATETIME,
    status TINYINT
);

CREATE TABLE Kit_Stems (
    id INT PRIMARY KEY,
    attribute VARCHAR(255),
    status INT
);

CREATE TABLE Labs (
    id INT PRIMARY KEY,
    kit_id INT,
    description TEXT,
    FOREIGN KEY (kit_id) REFERENCES Kit_Stems(id)
);

CREATE TABLE Steps (
    id INT PRIMARY KEY,
    lab_id INT,
    description TEXT,
    FOREIGN KEY (lab_id) REFERENCES Labs(id)
);

CREATE TABLE User_Labs (
    id INT PRIMARY KEY,
    user_id INT,
    lab_id INT,
    FOREIGN KEY (user_id) REFERENCES Users(id),
    FOREIGN KEY (lab_id) REFERENCES Labs(id)
);

CREATE TABLE Help_Histories (
    id INT PRIMARY KEY,
    user_lab_id INT,
    step_id INT,
    FOREIGN KEY (user_lab_id) REFERENCES User_Labs(id),
    FOREIGN KEY (step_id) REFERENCES Steps(id)
);

CREATE TABLE Cart_Items (
    id INT PRIMARY KEY,
    user_id INT,
    kit_id INT,
    quantity INT,
    FOREIGN KEY (user_id) REFERENCES Users(id),
    FOREIGN KEY (kit_id) REFERENCES Kit_Stems(id)
);

CREATE TABLE Orders (
    id INT PRIMARY KEY,
    staff_id INT,
    user_id INT,
    phone VARCHAR(255),
    create_day DATETIME,
    order_day DATETIME,
    total_price FLOAT,
    image VARCHAR(255),
    status INT,
    FOREIGN KEY (user_id) REFERENCES Users(id)
);

CREATE TABLE Kit_Orders (
    id INT PRIMARY KEY,
    order_id INT,
    kit_id INT,
    quantity INT,
    price FLOAT,
    FOREIGN KEY (order_id) REFERENCES Orders(id),
    FOREIGN KEY (kit_id) REFERENCES Kit_Stems(id)
);

CREATE TABLE Favorites (
    id INT PRIMARY KEY,
    user_id INT,
    kit_id INT,
    FOREIGN KEY (user_id) REFERENCES Users(id),
    FOREIGN KEY (kit_id) REFERENCES Kit_Stems(id)
);
