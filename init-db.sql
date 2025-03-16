-- Create the database
CREATE DATABASE IF NOT EXISTS ${DATABASE_NAME};

-- Create the user
CREATE USER IF NOT EXISTS '${DATABASE_USER}'@'%' IDENTIFIED BY '${DATABASE_PASSWORD}';

-- Grant privileges to the user on the database
GRANT ALL PRIVILEGES ON ${DATABASE_NAME}.* TO '${DATABASE_USER}'@'%';

-- Flush privileges
FLUSH PRIVILEGES;
