-- Create the schema if it doesn't exist
CREATE SCHEMA IF NOT EXISTS mydatabase;

-- Create the history table within that schema
CREATE TABLE IF NOT EXISTS mydatabase.history (
        id INT PRIMARY KEY AUTO_INCREMENT,
        text VARCHAR(255),
        created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
