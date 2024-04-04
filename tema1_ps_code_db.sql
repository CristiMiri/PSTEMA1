DROP TABLE IF EXISTS participanti;
DROP TABLE IF EXISTS prezentari;
DROP TABLE IF EXISTS utilizatori;
DROP TABLE IF EXISTS conferinte;


-- Create the Conferinte table
CREATE TABLE Conferinte (
    id SERIAL PRIMARY KEY,
    titlu VARCHAR(100),
    locatie VARCHAR(100),
    data DATE
);

-- Create the Prezentari table
CREATE TABLE Prezentari (
    id SERIAL PRIMARY KEY,
    titlu VARCHAR(100),
    autor VARCHAR(100),
    descriere TEXT,
    data DATE,
    ora TIME,
    sectiune VARCHAR(50), -- enum values 
    id_conferinta INTEGER REFERENCES Conferinte(id) -- Reference to the Conferinte table
);

-- Create the table participanti
CREATE TABLE participanti (
    id SERIAL PRIMARY KEY,
    nume VARCHAR(255),
    email VARCHAR(255),
    telefon VARCHAR(20),
    id_prezentare INTEGER REFERENCES Prezentari(id),
    UNIQUE(email, id_prezentare)
);


-- Create the table utilizatori
CREATE TABLE utilizatori (
    id SERIAL PRIMARY KEY,
    nume VARCHAR(255),
    email VARCHAR(255) UNIQUE,
    parola VARCHAR(255),
    user_type VARCHAR(50),
    telefon VARCHAR(20),
    password VARCHAR(255)
);

-- Insert dummy values into Conferinte table
INSERT INTO Conferinte (titlu, locatie, data) VALUES 
('AI Conference', 'New York', '2024-04-10'),
('Web Development Summit', 'San Francisco', '2024-04-15'),
('Medical Research Symposium', 'Chicago', '2024-05-05');

-- Insert dummy values into Prezentari table
INSERT INTO Prezentari (titlu, autor, descriere, data, ora, sectiune, id_conferinta) VALUES 
('Introduction to Quantum Computing', 'Alice Johnson', 'An overview of quantum computing principles', '2024-04-10', '09:00', 'STIINTE', 1),
('Web Development Trends', 'Bob Smith', 'Exploring the latest trends in web development', '2024-04-11', '10:30', 'TEHNOLOGIE', 1),
('Advancements in Cancer Treatment', 'Dr. Emily Williams', 'Recent breakthroughs in cancer treatment', '2024-04-12', '13:45', 'MEDICINA', 2),
('Modern Art and Its Impact', 'Eva Martinez', 'Analyzing contemporary art movements', '2024-04-13', '15:00', 'ARTA', 2),
('The Science of Athletic Performance', 'Michael Johnson', 'Understanding the physiology behind sports performance', '2024-04-14', '11:00', 'SPORT', 3);

-- Insert dummy values into the table utilizatori
INSERT INTO utilizatori (nume, email, parola, user_type, telefon, password)
VALUES
    ('John Doe', 'john@example.com', 'password123', 'PARTICIPANT', '123456789', 'password123'),
    ('Jane Smith', 'jane@example.com', 'password456', 'ORGANIZATOR', '987654321', 'password456'),
    ('Admin User', 'admin@example.com', 'adminpassword', 'ADMINISTRATOR', '555555555', 'adminpassword');

INSERT INTO participanti (nume, email, telefon, id_prezentare) VALUES 
('Alex Green', 'alex.green@example.com', '555-1234', 1),
('Samantha Blue', 's.blue@example.com', '555-5678', 1),
('Chris Yellow', 'chris.yellow@example.com', '555-9012', 2),
('Patricia White', 'patricia.white@example.com', '555-3456', 2);

