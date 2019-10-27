-- Procedimientos almacenados para CRUD interno en BD

-- Get all users
CREATE PROC DB_USERS_GET_ALL 
AS
	SELECT * FROM users ORDER BY user_id DESC
	-- SELECT top 200 * FROM users ORDER BY user_id DESC
GO

-- Get name users
CREATE PROC DB_USERS_FIND_NAME 
@varName VARCHAR(50) 
AS
	SELECT * FROM users WHERE user_nombre LIKE '%' + @varName + '%'
GO

-- Insert user
CREATE PROC DB_USERS_REGISTER 
@varID INT OUTPUT,
@varUser VARCHAR(50),
@varName VARCHAR(50),
@varPassword VARCHAR(256)
AS
	INSERT INTO users (user_id, user_username, user_name, user_password) VALUES (NULL, @varUser, @varName, @varPassword)
GO