-- Создание базы данных
CREATE DATABASE IF NOT EXISTS hotel_management;
USE hotel_management;

-- Таблица ролей
CREATE TABLE role (
    id INT PRIMARY KEY AUTO_INCREMENT,
    role_name VARCHAR(50) NOT NULL,
    description TEXT
);

INSERT INTO role VALUES 
(1, 'Администратор', 'Полный доступ к системе'),
(2, 'Ресепшен', 'Работа с клиентами и бронированиями'),
(3, 'Управляющий', 'Управление домом, услугами, отчёты');

-- Таблица классов домов
CREATE TABLE home_class (
    id INT PRIMARY KEY AUTO_INCREMENT,
    class VARCHAR(50) NOT NULL,
    description TEXT
);

INSERT INTO home_class VALUES 
(1, 'Эконом', 'Базовый класс'),
(2, 'Комфорт', 'Улучшенный класс'),
(3, 'Люкс', 'Повышенной комфортности'),
(4, 'Премиум', 'Элитный класс'),
(5, 'Бизнес', 'Для деловых поездок');

-- Таблица домов
CREATE TABLE house (
    id INT PRIMARY KEY AUTO_INCREMENT,
    home_class_id INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    address_number VARCHAR(10) NOT NULL,
    capacity INT DEFAULT 2,
    description TEXT,
    status VARCHAR(20) DEFAULT 'available',
    FOREIGN KEY (home_class_id) REFERENCES home_class(id)
);

INSERT INTO house VALUES 
(1, 1, 'Уютный домик у озера', '10A', 2, 'Небольшой домик с видом на озеро', 'available'),
(2, 2, 'Семейный коттедж', '15B', 6, 'Просторный коттедж для семьи', 'available'),
(3, 3, 'Вип вилла', '25', 8, 'Роскошная вилла с бассейном', 'available'),
(4, 4, 'Премиум резиденция', '30', 12, 'Элитная резиденция', 'available'),
(5, 5, 'Бизнес апартаменты', '5', 4, 'Для деловых поездок', 'available'),
(6, 1, 'Эконом студия', '8', 2, 'Компактная студия', 'available'),
(7, 2, 'Комфорт люкс', '12', 4, 'Комфортабельные апартаменты', 'available'),
(8, 3, 'Люкс с джакузи', '18', 6, 'Номер с гидромассажной ванной', 'available'),
(9, 4, 'Президентский люкс', '1', 10, 'Эксклюзивный номер', 'available'),
(10, 5, 'Деловой центр', '3', 8, 'Для встреч и переговоров', 'available'),
(11, 1, 'Стандарт плюс', '7', 3, 'Улучшенный стандарт', 'available'),
(12, 2, 'Семейный люкс', '14', 5, 'Для семьи с детьми', 'available'),
(13, 3, 'Романтическое гнездышко', '22', 2, 'Для романтического отдыха', 'available'),
(14, 4, 'Королевская вилла', '28', 15, 'Огромная вилла', 'available'),
(15, 5, 'Элит пентхаус', '2', 6, 'С панорамным видом', 'available'),
(16, 1, 'Бюджетный вариант', '9', 2, 'Для короткого пребывания', 'available'),
(17, 2, 'Улучшенный комфорт', '11', 4, 'С балконом', 'available'),
(18, 3, 'Люкс с камином', '17', 4, 'Уютный номер с камином', 'available'),
(19, 4, 'Эксклюзивная вилла', '26', 8, 'С частным бассейном', 'available'),
(20, 5, 'Бизнес класс', '4', 6, 'Для длительных командировок', 'available');

-- Таблица клиентов
CREATE TABLE client (
    id INT PRIMARY KEY AUTO_INCREMENT,
    FIO VARCHAR(100) NOT NULL,
    passport_series_number VARCHAR(20),
    date_of_birth DATE,
    telephone_number VARCHAR(20),
    email VARCHAR(50),
    gender VARCHAR(10),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO client VALUES 
(1, 'Сидоров Алексей Владимирович', '4005123456', '1990-05-15', '+79160001101', 'sidorov@mail.ru', 'Мужской', NOW()),
(2, 'Козлова Мария Игоревна', '4005123457', '1985-12-20', '+79160001102', 'kozlova@mail.ru', 'Женский', NOW()),
(3, 'Никитин Дмитрий Олегович', '4005123458', '1978-03-10', '+79160001103', 'nikitin@mail.ru', 'Мужской', NOW()),
(4, 'Орлова Елена Викторовна', '4005123459', '1992-07-22', '+79160001104', 'orlova_e@mail.ru', 'Женский', NOW()),
(5, 'Волков Сергей Александрович', '4005123460', '1982-11-30', '+79160001105', 'volkov@mail.ru', 'Мужской', NOW());

-- Таблица должностей
CREATE TABLE positions (
    id INT PRIMARY KEY AUTO_INCREMENT,
    position_name VARCHAR(100) NOT NULL,
    base_salary DECIMAL(10,2) DEFAULT 0.00
);

INSERT INTO positions VALUES 
(1, 'Директор', 120000.00),
(2, 'Администратор', 80000.00),
(3, 'Старший администратор', 70000.00),
(4, 'Менеджер по бронированию', 60000.00),
(5, 'Сотрудник ресепшена', 50000.00),
(6, 'Горничная', 35000.00);

-- Таблица персонала
CREATE TABLE personal (
    id INT PRIMARY KEY AUTO_INCREMENT,
    FIO VARCHAR(100) NOT NULL,
    position_id INT NOT NULL,
    email VARCHAR(50),
    telephone_number VARCHAR(20),
    hire_date DATE,
    salary DECIMAL(10,2),
    is_active TINYINT DEFAULT 1,
    FOREIGN KEY (position_id) REFERENCES positions(id)
);

INSERT INTO personal VALUES 
(1, 'Иванов Иван Иванович', 1, 'ivanov@mail.ru', '+79150001101', '2023-01-15', 120000.00, 1),
(2, 'Петров Петр Петрович', 2, 'petrov@mail.ru', '+79150001102', '2023-02-10', 80000.00, 1),
(3, 'Сидорова Мария Владимировна', 6, 'sidorova@mail.ru', '+79150001103', '2023-03-05', 35000.00, 1),
(4, 'Козлов Алексей Сергеевич', 5, 'kozlov@mail.ru', '+79150001104', '2023-01-20', 50000.00, 1),
(5, 'Николаева Анна Дмитриевна', 6, 'nikolaeva@mail.ru', '+79150001105', '2023-04-12', 35000.00, 1);

-- Таблица пользователей
CREATE TABLE users (
    id INT PRIMARY KEY AUTO_INCREMENT,
    personal_id INT NOT NULL,
    login VARCHAR(50) NOT NULL,
    password VARCHAR(64) NOT NULL,
    role_id INT NOT NULL,
    is_active TINYINT DEFAULT 1,
    FOREIGN KEY (personal_id) REFERENCES personal(id),
    FOREIGN KEY (role_id) REFERENCES role(id)
);

INSERT INTO users VALUES 
(1, 1, 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, 1),
(2, 2, 'reception', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 2, 1),
(3, 3, 'manager', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 3, 1);

-- Таблица услуг
CREATE TABLE services (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name_services VARCHAR(100) NOT NULL,
    duration INT,
    description TEXT,
    price DECIMAL(10,2),
    is_active TINYINT DEFAULT 1
);

INSERT INTO services VALUES 
(1, 'Завтрак в номер', 30, 'Континентальный завтрак', 500.00, 1),
(2, 'Экскурсия по городу', 120, 'Обзорная экскурсия', 1500.00, 1),
(3, 'Трансфер из аэропорта', 45, 'Трансфер на авто', 1200.00, 1),
(4, 'Спа-процедуры', 60, 'Расслабляющий массаж', 3000.00, 1),
(5, 'Ужин в ресторане', 90, 'Трехразовое меню', 2500.00, 1),
(6, 'Прачечная', 1440, 'Стирка и глажка', 800.00, 1),
(7, 'Аренда автомобиля', 1440, 'На 24 часа', 3500.00, 1),
(8, 'Фитнес-центр', 120, 'Посещение центра', 700.00, 1),
(9, 'Бассейн', 60, 'Посещение бассейна', 600.00, 1),
(10, 'Конференц-зал', 480, 'Аренда на 8 часов', 8000.00, 1);

-- Таблица бронирования
CREATE TABLE booking (
    id INT PRIMARY KEY AUTO_INCREMENT,
    client_id INT NOT NULL,
    house_id INT NOT NULL,
    user_id INT NOT NULL,
    booking_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    check_in_date DATE NOT NULL,
    check_out_date DATE NOT NULL,
    status VARCHAR(50) DEFAULT 'pending',
    days_count INT NOT NULL,
    total_price DECIMAL(10,2) NOT NULL,
    deposit_paid DECIMAL(10,2) DEFAULT 0.00,
    notes TEXT,
    FOREIGN KEY (client_id) REFERENCES client(id),
    FOREIGN KEY (house_id) REFERENCES house(id),
    FOREIGN KEY (user_id) REFERENCES users(id)
);

-- Таблица заселения
CREATE TABLE check_in (
    order_number INT PRIMARY KEY AUTO_INCREMENT,
    client_id INT NOT NULL,
    house_id INT NOT NULL,
    user_id INT NOT NULL,
    check_in_date DATE,
    check_out_date DATE,
    residence_time INT NOT NULL,
    tag VARCHAR(50),
    house_total_price DECIMAL(10,2),
    FOREIGN KEY (client_id) REFERENCES client(id),
    FOREIGN KEY (house_id) REFERENCES house(id),
    FOREIGN KEY (user_id) REFERENCES users(id)
);

-- Таблица услуг в заселении
CREATE TABLE check_in_services (
    id INT PRIMARY KEY AUTO_INCREMENT,
    order_number INT NOT NULL,
    service_id INT NOT NULL,
    quantity INT DEFAULT 1,
    service_total_price DECIMAL(10,2),
    FOREIGN KEY (order_number) REFERENCES check_in(order_number),
    FOREIGN KEY (service_id) REFERENCES services(id)
);

-- Таблица скидок
CREATE TABLE discounts (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL,
    type VARCHAR(20) NOT NULL,
    percent DECIMAL(5,2) NOT NULL,
    min_days INT DEFAULT 1,
    min_bookings INT DEFAULT 0,
    description TEXT,
    is_active TINYINT DEFAULT 1,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO discounts VALUES 
(1, 'Летний сезон', 'season', 10.00, 3, 0, 'Скидка 10% летом от 3 дней', 1, NOW()),
(2, 'Постоянный клиент', 'loyalty', 15.00, 1, 5, 'Скидка 15% клиентам с 5+ бронированиями', 1, NOW()),
(3, 'Выходные', 'special', 5.00, 2, 0, 'Скидка 5% на заезды в выходные', 1, NOW()),
(4, 'Новый год', 'season', 20.00, 5, 0, 'Праздничная скидка 20%', 1, NOW()),
(5, 'Свадебная', 'special', 25.00, 3, 0, 'Специальная скидка для молодоженов', 1, NOW());

-- Таблица уведомлений
CREATE TABLE notifications (
    id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    booking_id INT,
    type VARCHAR(50),
    message TEXT,
    sent_at DATETIME,
    is_read TINYINT DEFAULT 0,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (booking_id) REFERENCES booking(id)
);