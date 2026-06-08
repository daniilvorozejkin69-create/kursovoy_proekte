CREATE DATABASE IF NOT EXISTS hotel_management;
USE hotel_management;

-- Роли
CREATE TABLE role (
    id INT PRIMARY KEY AUTO_INCREMENT,
    role_name VARCHAR(50) NOT NULL,
    description TEXT
);
INSERT INTO role VALUES (1, 'Администратор', 'Полный доступ'), (2, 'Ресепшен', 'Работа с клиентами'), (3, 'Управляющий', 'Управление и отчёты');

-- Классы домов
CREATE TABLE home_class (
    id INT PRIMARY KEY AUTO_INCREMENT,
    class VARCHAR(50) NOT NULL,
    description TEXT
);
INSERT INTO home_class VALUES (1, 'Эконом', 'Бюджетный'), (2, 'Комфорт', 'Улучшенный'), (3, 'Люкс', 'Премиум');

-- Дома
CREATE TABLE house (
    id INT PRIMARY KEY AUTO_INCREMENT,
    home_class_id INT,
    name VARCHAR(100),
    address_number VARCHAR(10),
    capacity INT,
    description TEXT,
    status VARCHAR(20) DEFAULT 'available',
    FOREIGN KEY (home_class_id) REFERENCES home_class(id)
);
INSERT INTO house VALUES (1, 1, 'Домик у озера', '10A', 2, 'Уютный домик', 'available'), (2, 2, 'Семейный коттедж', '15B', 6, 'Просторный', 'available'), (3, 3, 'Вип вилла', '25', 8, 'С бассейном', 'available');

-- Клиенты
CREATE TABLE client (
    id INT PRIMARY KEY AUTO_INCREMENT,
    FIO VARCHAR(100),
    passport_series_number VARCHAR(20),
    date_of_birth DATE,
    telephone_number VARCHAR(20),
    email VARCHAR(50),
    gender VARCHAR(10)
);
INSERT INTO client VALUES (1, 'Иванов Иван Иванович', '4005123456', '1990-05-15', '+79160001101', 'ivanov@mail.ru', 'Мужской'), (2, 'Петрова Анна Сергеевна', '4005123457', '1988-03-20', '+79160001102', 'petrova@mail.ru', 'Женский');

-- Должности
CREATE TABLE positions (
    id INT PRIMARY KEY AUTO_INCREMENT,
    position_name VARCHAR(100),
    description TEXT,
    base_salary DECIMAL(10,2)
);
INSERT INTO positions VALUES (1, 'Директор', 'Руководитель', 120000), (2, 'Администратор', 'Управление', 80000), (3, 'Горничная', 'Уборка', 35000);

-- Сотрудники
CREATE TABLE personal (
    id INT PRIMARY KEY AUTO_INCREMENT,
    FIO VARCHAR(100),
    position_id INT,
    job_title VARCHAR(50),
    email VARCHAR(50),
    passport_series_number VARCHAR(20),
    address TEXT,
    telephone_number VARCHAR(20),
    salary DECIMAL(10,2),
    is_active TINYINT DEFAULT 1,
    FOREIGN KEY (position_id) REFERENCES positions(id)
);
INSERT INTO personal VALUES (1, 'Смирнов Алексей Петрович', 1, 'Директор', 'smirnov@mail.ru', '4001123456', 'Москва', '+79150001101', 120000, 1), (2, 'Козлова Мария Ивановна', 2, 'Администратор', 'kozlova@mail.ru', '4001123457', 'Москва', '+79150001102', 80000, 1);

-- Пользователи (пароль admin)
CREATE TABLE users (
    id INT PRIMARY KEY AUTO_INCREMENT,
    personal_id INT,
    login VARCHAR(50),
    password VARCHAR(64),
    role_id INT,
    is_active TINYINT DEFAULT 1,
    FOREIGN KEY (personal_id) REFERENCES personal(id),
    FOREIGN KEY (role_id) REFERENCES role(id)
);
INSERT INTO users VALUES (1, 1, 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, 1), (2, 2, 'reception', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 2, 1);

-- Услуги
CREATE TABLE services (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name_services VARCHAR(100),
    duration INT,
    description TEXT,
    price DECIMAL(10,2),
    is_active TINYINT DEFAULT 1
);
INSERT INTO services VALUES (1, 'Завтрак в номер', 30, 'Континентальный завтрак', 500, 1), (2, 'Трансфер', 45, 'Из аэропорта', 1200, 1), (3, 'Спа', 60, 'Массаж', 3000, 1);

-- Бронирования
CREATE TABLE booking (
    id INT PRIMARY KEY AUTO_INCREMENT,
    client_id INT,
    house_id INT,
    user_id INT,
    booking_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    check_in_date DATE,
    check_out_date DATE,
    status VARCHAR(50) DEFAULT 'pending',
    days_count INT,
    total_price DECIMAL(10,2),
    deposit_paid DECIMAL(10,2) DEFAULT 0,
    notes TEXT,
    FOREIGN KEY (client_id) REFERENCES client(id),
    FOREIGN KEY (house_id) REFERENCES house(id),
    FOREIGN KEY (user_id) REFERENCES users(id)
);
INSERT INTO booking VALUES (1, 1, 3, 2, NOW(), '2025-06-01', '2025-06-05', 'confirmed', 4, 32000, 10000, 'Отпуск');

-- Заселения
CREATE TABLE check_in (
    order_number INT PRIMARY KEY AUTO_INCREMENT,
    client_id INT,
    house_id INT,
    user_id INT,
    check_in_date DATE,
    check_out_date DATE,
    residence_time INT,
    tag VARCHAR(50),
    house_total_price DECIMAL(10,2),
    FOREIGN KEY (client_id) REFERENCES client(id),
    FOREIGN KEY (house_id) REFERENCES house(id),
    FOREIGN KEY (user_id) REFERENCES users(id)
);
INSERT INTO check_in VALUES (1, 1, 3, 2, '2025-06-01', '2025-06-05', 4, NULL, 32000);

-- Услуги в заселении
CREATE TABLE check_in_services (
    id INT PRIMARY KEY AUTO_INCREMENT,
    order_number INT,
    service_id INT,
    quantity INT DEFAULT 1,
    service_total_price DECIMAL(10,2),
    FOREIGN KEY (order_number) REFERENCES check_in(order_number),
    FOREIGN KEY (service_id) REFERENCES services(id)
);
INSERT INTO check_in_services VALUES (1, 1, 1, 2, 1000), (2, 1, 2, 1, 1200);

-- Скидки
CREATE TABLE discounts (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100),
    type VARCHAR(20),
    percent DECIMAL(5,2),
    min_days INT DEFAULT 1,
    min_bookings INT DEFAULT 0,
    start_date DATE,
    end_date DATE,
    promo_code VARCHAR(20),
    description TEXT,
    is_active TINYINT DEFAULT 1
);
INSERT INTO discounts VALUES (1, 'Летний сезон', 'season', 10, 3, 0, NULL, NULL, NULL, 'Скидка 10% летом', 1), (2, 'Постоянный клиент', 'loyalty', 15, 1, 5, NULL, NULL, NULL, 'Скидка 15%', 1);

-- Уведомления
CREATE TABLE notifications (
    id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    booking_id INT,
    type VARCHAR(50),
    message TEXT,
    sent_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_read TINYINT DEFAULT 0,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (booking_id) REFERENCES booking(id)
);
INSERT INTO notifications VALUES (1, 2, 1, 'reminder', 'Заезд через 3 дня', NOW(), 0);

-- Очистка старых пользователей
DELETE FROM users;

-- Добавление новых пользователей
-- Пароль везде "123", SHA-256 хеш: a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3

INSERT INTO users (id, personal_id, login, password, role_id, is_active) VALUES
(1, 1, 'ivanov_i', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, 1),
(2, 2, 'petrov_p', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, 1),
(3, 14, 'egorov_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 3, 1);