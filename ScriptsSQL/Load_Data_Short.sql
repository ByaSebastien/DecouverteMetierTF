USE DECOUVERTEMETIERTF;
GO

INSERT INTO Category (Name)
VALUES 
('Romans'),
('Science-fiction'),
('Fantasy'),
('Policier'),
('Biographie'),
('Histoire'),
('Philosophie'),
('Science'),
('Informatique'),
('Cuisine'),
('Art'),
('Musique');
GO
USE DECOUVERTEMETIERTF;
GO

INSERT INTO Book (Title, Author, Description, CategoryId)
VALUES
('Harry Potter et la Chambre des Secrets', 'J.K. Rowling', 'Harry Potter à l''école des sorciers est le premier roman de la série littéraire centrée sur le personnage de Harry Potter créé par J. K. Rowling.', 3),
('Le Comte de Monte-Cristo', 'Alexandre Dumas', 'Le Comte de Monte-Cristo est un roman d''aventures de l''écrivain français Alexandre Dumas, publié en feuilleton pendant l''année 1844.', 1),
('Les Misérables', 'Victor Hugo', 'Les Misérables est un roman de Victor Hugo publié en 1862. Il est considéré comme l''un des plus grands romans de la littérature française et mondiale.', 1),
('Le Guide du voyageur galactique', 'Douglas Adams', 'Le Guide du voyageur galactique est un roman humoristique de science-fiction écrit par Douglas Adams.', 2),
('L''étranger', 'Albert Camus', 'L''étranger est un roman d''Albert Camus, publié en 1942.', 7),
('Le Cycle de Dune', 'Frank Herbert', 'Le Cycle de Dune est une série de romans de science-fiction écrits par Frank Herbert.', 2),
('Le Crime de l''Orient-Express', 'Agatha Christie', 'Le Crime de l''Orient-Express est un roman policier d''Agatha Christie publié en 1934.', 4),
('Steve Jobs', 'Walter Isaacson', 'Steve Jobs est une biographie autorisée de Steve Jobs, écrite par Walter Isaacson.', 5),
('Le mythe de Sisyphe', 'Albert Camus', 'Le mythe de Sisyphe est un essai philosophique d''Albert Camus publié en 1942.', 7),
('Le Petit Prince', 'Antoine de Saint-Exupéry', 'Le Petit Prince est un conte poétique de Saint-Exupéry publié en 1943.', 1);
