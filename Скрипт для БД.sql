-- =====================================================
-- ПОЛНЫЙ СКРИПТ БАЗЫ ДАННЫХ "hotel_management"
-- С ТАБЛИЦЕЙ ДОЛЖНОСТЕЙ И СТАТУСАМИ ДЛЯ ДОМОВ
-- БЕЗ ФИНАНСОВЫХ ТАБЛИЦ
-- =====================================================

-- Создание базы данных
DROP DATABASE IF EXISTS hotel_management;
CREATE DATABASE IF NOT EXISTS hotel_management;
USE hotel_management;

-- =====================================================
-- 1. ТАБЛИЦА РОЛЕЙ
-- =====================================================
CREATE TABLE role (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    role_name VARCHAR(50) NOT NULL UNIQUE,
    description TEXT NULL
);

-- =====================================================
-- 2. ТАБЛИЦА ДОЛЖНОСТЕЙ
-- =====================================================
CREATE TABLE positions (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    position_name VARCHAR(100) NOT NULL UNIQUE,
    description TEXT NULL,
    base_salary DECIMAL(10,2) DEFAULT 0.00,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- =====================================================
-- 3. ТАБЛИЦА ПЕРСОНАЛА (С ХРАНЕНИЕМ ФОТО В BLOB)
-- =====================================================
CREATE TABLE personal (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    FIO VARCHAR(100) NOT NULL,
    position_id INTEGER NOT NULL,
    job_title VARCHAR(50) NOT NULL,
    email VARCHAR(50) UNIQUE,
    passport_series_number VARCHAR(20) UNIQUE,
    address TEXT,
    telephone_number VARCHAR(20),
    photo LONGBLOB NULL,
    hire_date DATE NULL,
    salary DECIMAL(10,2) DEFAULT 0.00,
    is_active BOOLEAN DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (position_id) REFERENCES positions(id)
);

-- =====================================================
-- 4. ТАБЛИЦА ПОЛЬЗОВАТЕЛЕЙ
-- =====================================================
CREATE TABLE users (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    personal_id INTEGER NOT NULL UNIQUE,
    login VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(64) NOT NULL,
    role_id INTEGER NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    last_login DATETIME NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (personal_id) REFERENCES personal(id) ON DELETE CASCADE,
    FOREIGN KEY (role_id) REFERENCES role(id)
);

-- =====================================================
-- 5. ТАБЛИЦА КЛИЕНТОВ
-- =====================================================
CREATE TABLE client (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    FIO VARCHAR(100) NOT NULL,
    passport_series_number VARCHAR(20) UNIQUE,
    date_of_birth DATE,
    telephone_number VARCHAR(20),
    email VARCHAR(50),
    gender VARCHAR(10),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- =====================================================
-- 6. ТАБЛИЦА КЛАССОВ ДОМОВ
-- =====================================================
CREATE TABLE home_class (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    class VARCHAR(50) NOT NULL UNIQUE,
    description TEXT NULL
);

-- =====================================================
-- 7. ТАБЛИЦА УСЛУГ
-- =====================================================
CREATE TABLE services (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    name_services VARCHAR(100) NOT NULL,
    duration INTEGER,
    description TEXT,
    price DECIMAL(10,2),
    is_active BOOLEAN DEFAULT TRUE
);

-- =====================================================
-- 8. ТАБЛИЦА ДОМОВ (С ДОБАВЛЕННЫМИ СТАТУСАМИ)
-- =====================================================
CREATE TABLE house (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    home_class_id INTEGER NOT NULL,
    name VARCHAR(100) NOT NULL,
    address_number VARCHAR(10) NOT NULL,
    capacity INTEGER,
    description TEXT,
    status ENUM('available', 'maintenance', 'retired') DEFAULT 'available',
    status_comment TEXT NULL,
    last_status_change DATETIME NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (home_class_id) REFERENCES home_class(id)
);

-- =====================================================
-- 9. ТАБЛИЦА БРОНИРОВАНИЙ
-- =====================================================
CREATE TABLE booking (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    client_id INTEGER NOT NULL,
    house_id INTEGER NOT NULL,
    user_id INTEGER NOT NULL,
    booking_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    check_in_date DATE NOT NULL,
    check_out_date DATE NOT NULL,
    status VARCHAR(50) DEFAULT 'pending',
    days_count INTEGER NOT NULL,
    total_price DECIMAL(10,2) NOT NULL,
    deposit_paid DECIMAL(10,2) DEFAULT 0.00,
    notes TEXT,
    FOREIGN KEY (client_id) REFERENCES client(id),
    FOREIGN KEY (house_id) REFERENCES house(id),
    FOREIGN KEY (user_id) REFERENCES users(id)
);

-- =====================================================
-- 10. ТАБЛИЦА ЗАСЕЛЕНИЙ
-- =====================================================
CREATE TABLE check_in (
    order_number INTEGER PRIMARY KEY AUTO_INCREMENT,
    client_id INTEGER NOT NULL,
    house_id INTEGER NOT NULL,
    user_id INTEGER NOT NULL,
    check_in_date DATE,
    check_out_date DATE,
    residence_time INTEGER NOT NULL,
    tag VARCHAR(50),
    house_total_price DECIMAL(10,2),
    FOREIGN KEY (client_id) REFERENCES client(id),
    FOREIGN KEY (house_id) REFERENCES house(id),
    FOREIGN KEY (user_id) REFERENCES users(id)
);

-- =====================================================
-- 11. ТАБЛИЦА УСЛУГ В ЗАКАЗАХ
-- =====================================================
CREATE TABLE check_in_services (
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    order_number INTEGER NOT NULL,
    service_id INTEGER NOT NULL,
    quantity INTEGER DEFAULT 1,
    service_total_price DECIMAL(10,2),
    FOREIGN KEY (order_number) REFERENCES check_in(order_number) ON DELETE CASCADE,
    FOREIGN KEY (service_id) REFERENCES services(id)
);

-- =====================================================
-- 12. ТАБЛИЦА УВЕДОМЛЕНИЙ
-- =====================================================
CREATE TABLE notifications (
    id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    booking_id INT,
    type VARCHAR(50),
    message TEXT,
    sent_at DATETIME,
    is_read BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (booking_id) REFERENCES booking(id)
);

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ РОЛЕЙ
-- =====================================================
INSERT INTO role (id, role_name, description) VALUES 
(1, 'Администратор', 'Полный доступ к системе, управление пользователями'),
(2, 'Ресепшен', 'Работа с клиентами, бронированиями и заказами'),
(3, 'Управляющий', 'Управление домом, услугами, отчёты');

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ ДОЛЖНОСТЕЙ
-- =====================================================
INSERT INTO positions (id, position_name, description, base_salary) VALUES
(1, 'Директор', 'Руководитель базы отдыха', 120000.00),
(2, 'Администратор', 'Администратор системы', 80000.00),
(3, 'Старший администратор', 'Старший администратор', 70000.00),
(4, 'Менеджер по бронированию', 'Управление бронированиями', 60000.00),
(5, 'Сотрудник ресепшена', 'Встреча гостей, оформление', 50000.00),
(6, 'Горничная', 'Уборка номеров', 35000.00),
(7, 'Официант', 'Обслуживание в ресторане', 40000.00),
(8, 'Повар', 'Приготовление блюд', 45000.00),
(9, 'Охранник', 'Охрана территории', 40000.00),
(10, 'Технический работник', 'Обслуживание территории', 35000.00),
(11, 'Бухгалтер', 'Ведение бухгалтерии', 70000.00),
(12, 'Маркетолог', 'Продвижение услуг', 60000.00),
(13, 'Портье', 'Встреча гостей, багаж', 38000.00),
(14, 'Уборщица', 'Уборка помещений', 32000.00),
(15, 'Менеджер', 'Общее управление', 65000.00);

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ ПЕРСОНАЛА (50 записей)
-- =====================================================
INSERT INTO personal (FIO, position_id, job_title, email, passport_series_number, address, telephone_number, hire_date, salary, is_active) VALUES
('Иванов Иван Иванович', 1, 'Директор', 'ivanov@mail.ru', '4001123456', 'Москва, ул. Ленина 1', '+79150001101', '2023-01-15', 120000, TRUE),
('Петров Петр Петрович', 2, 'Администратор', 'petrov@mail.ru', '4001123457', 'Москва, ул. Ленина 2', '+79150001102', '2023-02-10', 80000, TRUE),
('Сидорова Мария Владимировна', 6, 'Горничная', 'sidorova@mail.ru', '4001123458', 'Москва, ул. Ленина 3', '+79150001103', '2023-03-05', 35000, TRUE),
('Козлов Алексей Сергеевич', 13, 'Портье', 'kozlov@mail.ru', '4001123459', 'Москва, ул. Ленина 4', '+79150001104', '2023-01-20', 38000, TRUE),
('Николаева Анна Дмитриевна', 14, 'Уборщица', 'nikolaeva@mail.ru', '4001123460', 'Москва, ул. Ленина 5', '+79150001105', '2023-04-12', 32000, TRUE),
('Федоров Дмитрий Игоревич', 9, 'Охранник', 'fedorov@mail.ru', '4001123461', 'Москва, ул. Ленина 6', '+79150001106', '2023-02-28', 40000, TRUE),
('Орлова Екатерина Павловна', 5, 'Сотрудник ресепшена', 'orlova@mail.ru', '4001123462', 'Москва, ул. Ленина 7', '+79150001107', '2023-05-17', 50000, TRUE),
('Васнецов Сергей Викторович', 4, 'Менеджер по бронированию', 'vasnecov@mail.ru', '4001123463', 'Москва, ул. Ленина 8', '+79150001108', '2023-03-22', 60000, TRUE),
('Зайцева Ольга Николаевна', 6, 'Горничная', 'zayceva@mail.ru', '4001123464', 'Москва, ул. Ленина 9', '+79150001109', '2023-06-08', 35000, TRUE),
('Белов Андрей Александрович', 3, 'Старший администратор', 'belov@mail.ru', '4001123465', 'Москва, ул. Ленина 10', '+79150001110', '2023-01-05', 70000, TRUE),
('Крылова Ирина Васильевна', 14, 'Уборщица', 'krylova@mail.ru', '4001123466', 'Москва, ул. Ленина 11', '+79150001111', '2023-07-14', 32000, TRUE),
('Тихонов Павел Олегович', 9, 'Охранник', 'tihonov@mail.ru', '4001123467', 'Москва, ул. Ленина 12', '+79150001112', '2023-04-30', 40000, TRUE),
('Морозова Татьяна Борисовна', 5, 'Сотрудник ресепшена', 'morozova@mail.ru', '4001123468', 'Москва, ул. Ленина 13', '+79150001113', '2023-08-19', 50000, TRUE),
('Егоров Артем Витальевич', 15, 'Менеджер', 'egorov@mail.ru', '4001123469', 'Москва, ул. Ленина 14', '+79150001114', '2023-02-14', 65000, TRUE),
('Полякова Светлана Игоревна', 6, 'Горничная', 'polyakova@mail.ru', '4001123470', 'Москва, ул. Ленина 15', '+79150001115', '2023-09-25', 35000, TRUE),
('Громов Виктор Сергеевич', 13, 'Портье', 'gromov@mail.ru', '4001123471', 'Москва, ул. Ленина 16', '+79150001116', '2023-05-11', 38000, TRUE),
('Лебедева Наталья Алексеевна', 14, 'Уборщица', 'lebedeva@mail.ru', '4001123472', 'Москва, ул. Ленина 17', '+79150001117', '2023-10-03', 32000, TRUE),
('Соловьев Игорь Петрович', 9, 'Охранник', 'soloviev@mail.ru', '4001123473', 'Москва, ул. Ленина 18', '+79150001118', '2023-06-20', 40000, TRUE),
('Воробьева Елена Дмитриевна', 5, 'Сотрудник ресепшена', 'vorobeva@mail.ru', '4001123474', 'Москва, ул. Ленина 19', '+79150001119', '2023-11-07', 50000, TRUE),
('Павлов Максим Андреевич', 4, 'Менеджер по бронированию', 'pavlov@mail.ru', '4001123475', 'Москва, ул. Ленина 20', '+79150001120', '2023-07-29', 60000, TRUE),
('Романова Юлия Викторовна', 6, 'Горничная', 'romanova@mail.ru', '4001123476', 'Москва, ул. Ленина 21', '+79150001121', '2023-12-12', 35000, TRUE),
('Кузнецов Александр Ильич', 2, 'Администратор', 'kuznecov@mail.ru', '4001123477', 'Москва, ул. Ленина 22', '+79150001122', '2023-08-05', 80000, TRUE),
('Ильина Марина Олеговна', 14, 'Уборщица', 'ilina@mail.ru', '4001123478', 'Москва, ул. Ленина 23', '+79150001123', '2024-01-18', 32000, TRUE),
('Новиков Роман Сергеевич', 9, 'Охранник', 'novikov@mail.ru', '4001123479', 'Москва, ул. Ленина 24', '+79150001124', '2023-09-09', 40000, TRUE),
('Жукова Алиса Артемовна', 5, 'Сотрудник ресепшена', 'zhukova@mail.ru', '4001123480', 'Москва, ул. Ленина 25', '+79150001125', '2023-10-22', 50000, TRUE),
('Борисов Евгений Вадимович', 15, 'Менеджер', 'borisov@mail.ru', '4001123481', 'Москва, ул. Ленина 26', '+79150001126', '2023-11-15', 65000, TRUE),
('Данилова Вероника Игоревна', 6, 'Горничная', 'danilova@mail.ru', '4001123482', 'Москва, ул. Ленина 27', '+79150001127', '2024-02-03', 35000, TRUE),
('Мельников Аркадий Денисович', 13, 'Портье', 'melnikov@mail.ru', '4001123483', 'Москва, ул. Ленина 28', '+79150001128', '2023-12-05', 38000, TRUE),
('Савельева Дарья Романовна', 14, 'Уборщица', 'savelieva@mail.ru', '4001123484', 'Москва, ул. Ленина 29', '+79150001129', '2024-01-27', 32000, TRUE),
('Герасимов Тимур Олегович', 9, 'Охранник', 'gerasimov@mail.ru', '4001123485', 'Москва, ул. Ленина 30', '+79150001130', '2023-08-18', 40000, TRUE),
('Одинцова Кристина Васильевна', 5, 'Сотрудник ресепшена', 'odincova@mail.ru', '4001123486', 'Москва, ул. Ленина 31', '+79150001131', '2023-09-30', 50000, TRUE),
('Тимофеев Вадим Юрьевич', 4, 'Менеджер по бронированию', 'timofeev@mail.ru', '4001123487', 'Москва, ул. Ленина 32', '+79150001132', '2023-10-10', 60000, TRUE),
('Фролова Анастасия Павловна', 6, 'Горничная', 'frolova@mail.ru', '4001123488', 'Москва, ул. Ленина 33', '+79150001133', '2023-11-28', 35000, TRUE),
('Комаров Станислав Аркадьевич', 2, 'Администратор', 'komarov@mail.ru', '4001123489', 'Москва, ул. Ленина 34', '+79150001134', '2023-12-20', 80000, TRUE),
('Гусева Эльвира Рудольфовна', 14, 'Уборщица', 'guseva@mail.ru', '4001123490', 'Москва, ул. Ленина 35', '+79150001135', '2024-02-15', 32000, TRUE),
('Щербаков Григорий Макарович', 9, 'Охранник', 'scherbakov@mail.ru', '4001123491', 'Москва, ул. Ленина 36', '+79150001136', '2023-07-25', 40000, TRUE),
('Масленникова Виктория Валерьевна', 5, 'Сотрудник ресепшена', 'maslennikova@mail.ru', '4001123492', 'Москва, ул. Ленина 37', '+79150001137', '2023-08-08', 50000, TRUE),
('Андреев Константин Львович', 15, 'Менеджер', 'andreev@mail.ru', '4001123493', 'Москва, ул. Ленина 38', '+79150001138', '2023-09-17', 65000, TRUE),
('Панина Людмила Георгиевна', 6, 'Горничная', 'panina@mail.ru', '4001123494', 'Москва, ул. Ленина 39', '+79150001139', '2023-10-29', 35000, TRUE),
('Лазарев Денис Евгеньевич', 13, 'Портье', 'lazarev@mail.ru', '4001123495', 'Москва, ул. Ленина 40', '+79150001140', '2023-11-05', 38000, TRUE),
('Семенова Валерия Артемовна', 14, 'Уборщица', 'semenova@mail.ru', '4001123496', 'Москва, ул. Ленина 41', '+79150001141', '2023-12-15', 32000, TRUE),
('Горбунов Арсений Дмитриевич', 9, 'Охранник', 'gorbunov@mail.ru', '4001123497', 'Москва, ул. Ленина 42', '+79150001142', '2024-01-10', 40000, TRUE),
('Власова Ульяна Романовна', 5, 'Сотрудник ресепшена', 'vlasova@mail.ru', '4001123498', 'Москва, ул. Ленина 43', '+79150001143', '2024-02-22', 50000, TRUE),
('Максимов Руслан Ильдарович', 4, 'Менеджер по бронированию', 'maksimov@mail.ru', '4001123499', 'Москва, ул. Ленина 44', '+79150001144', '2023-09-03', 60000, TRUE),
('Филиппова Галина Степановна', 6, 'Горничная', 'filippova@mail.ru', '4001123500', 'Москва, ул. Ленина 45', '+79150001145', '2023-10-14', 35000, TRUE),
('Дорофеев Валерий Анатольевич', 2, 'Администратор', 'dorofeev@mail.ru', '4001123501', 'Москва, ул. Ленина 46', '+79150001146', '2023-11-22', 80000, TRUE),
('Ефимова Инна Борисовна', 14, 'Уборщица', 'efimova@mail.ru', '4001123502', 'Москва, ул. Ленина 47', '+79150001147', '2023-12-30', 32000, TRUE),
('Галкин Матвей Сергеевич', 9, 'Охранник', 'galkin@mail.ru', '4001123503', 'Москва, ул. Ленина 48', '+79150001148', '2024-01-20', 40000, TRUE),
('Коновалова Регина Эдуардовна', 5, 'Сотрудник ресепшена', 'konovalova@mail.ru', '4001123504', 'Москва, ул. Ленина 49', '+79150001149', '2024-02-05', 50000, TRUE),
('Смирнова Анна Сергеевна', 6, 'Горничная', 'smirnova@mail.ru', '4001123505', 'Москва, ул. Ленина 50', '+79150001150', '2023-08-25', 35000, TRUE);

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ ПОЛЬЗОВАТЕЛЕЙ
-- =====================================================
INSERT INTO users (personal_id, login, password, role_id, is_active) VALUES
(1, 'ivanov_i', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, TRUE),
(2, 'petrov_p', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(3, 'sidorova_m', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(4, 'kozlov_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(5, 'nikolaeva_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(6, 'fedorov_d', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(7, 'orlova_e', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(8, 'vasnecov_s', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 3, TRUE),
(9, 'zayceva_o', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(10, 'belov_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 3, TRUE),
(11, 'krylova_i', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(12, 'tihonov_p', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(13, 'morozova_t', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(14, 'egorov_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 3, TRUE),
(15, 'polyakova_s', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(16, 'gromov_v', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(17, 'lebedeva_n', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(18, 'soloviev_i', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(19, 'vorobeva_e', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(20, 'pavlov_m', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 3, TRUE),
(21, 'romanova_y', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(22, 'kuznecov_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, TRUE),
(23, 'ilina_m', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(24, 'novikov_r', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(25, 'zhukova_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(26, 'borisov_e', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 3, TRUE),
(27, 'danilova_v', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(28, 'melnikov_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(29, 'savelieva_d', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(30, 'gerasimov_t', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(31, 'odincova_k', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(32, 'timofeev_v', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 3, TRUE),
(33, 'frolova_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(34, 'komarov_s', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, TRUE),
(35, 'guseva_e', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(36, 'scherbakov_g', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(37, 'maslennikova_v', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(38, 'andreev_k', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 3, TRUE),
(39, 'panina_l', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(40, 'lazarev_d', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(41, 'semenova_v', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(42, 'gorbunov_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(43, 'vlasova_u', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(44, 'maksimov_r', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 3, TRUE),
(45, 'filippova_g', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(46, 'dorofeev_v', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, TRUE),
(47, 'efimova_i', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(48, 'galkin_m', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(49, 'konovalova_r', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE),
(50, 'smirnova_a', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2, TRUE);

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ КЛИЕНТОВ (50 записей)
-- =====================================================
INSERT INTO client (FIO, passport_series_number, date_of_birth, telephone_number, email, gender) VALUES
('Сидоров Алексей Владимирович', '4005123456', '1990-05-15', '+79160001101', 'sidorov@mail.ru', 'Мужской'),
('Козлова Мария Игоревна', '4005123457', '1985-12-20', '+79160001102', 'kozlova@mail.ru', 'Женский'),
('Никитин Дмитрий Олегович', '4005123458', '1978-03-10', '+79160001103', 'nikitin@mail.ru', 'Мужской'),
('Орлова Елена Викторовна', '4005123459', '1992-07-22', '+79160001104', 'orlova_e@mail.ru', 'Женский'),
('Волков Сергей Александрович', '4005123460', '1982-11-30', '+79160001105', 'volkov@mail.ru', 'Мужской'),
('Попова Анна Сергеевна', '4005123461', '1995-02-14', '+79160001106', 'popova@mail.ru', 'Женский'),
('Лебедев Михаил Юрьевич', '4005123462', '1975-09-05', '+79160001107', 'lebedev@mail.ru', 'Мужской'),
('Новикова Ольга Дмитриевна', '4005123463', '1988-04-18', '+79160001108', 'novikova@mail.ru', 'Женский'),
('Кузнецов Андрей Павлович', '4005123464', '1991-08-25', '+79160001109', 'kuznecov_a@mail.ru', 'Мужской'),
('Соколова Ирина Анатольевна', '4005123465', '1987-01-12', '+79160001110', 'sokolova@mail.ru', 'Женский'),
('Фролов Артем Владимирович', '4005123466', '1993-06-08', '+79160001111', 'frolov@mail.ru', 'Мужской'),
('Андреева Татьяна Игоревна', '4005123467', '1980-12-03', '+79160001112', 'andreeva@mail.ru', 'Женский'),
('Морозов Виктор Сергеевич', '4005123468', '1976-10-17', '+79160001113', 'morozov@mail.ru', 'Мужской'),
('Павлова Екатерина Алексеевна', '4005123469', '1994-03-28', '+79160001114', 'pavlova@mail.ru', 'Женский'),
('Семенов Роман Олегович', '4005123470', '1983-07-11', '+79160001115', 'semenov@mail.ru', 'Мужской'),
('Голубева Надежда Витальевна', '4005123471', '1979-05-24', '+79160001116', 'golubeva@mail.ru', 'Женский'),
('Ковалев Денис Ильич', '4005123472', '1996-09-02', '+79160001117', 'kovalev@mail.ru', 'Мужской'),
('Ильина Вероника Романовна', '4005123473', '1984-02-15', '+79160001118', 'ilina_v@mail.ru', 'Женский'),
('Зайцев Вадим Андреевич', '4005123474', '1977-11-08', '+79160001119', 'zaycev@mail.ru', 'Мужской'),
('Егорова Людмила Петровна', '4005123475', '1997-04-21', '+79160001120', 'egorova@mail.ru', 'Женский'),
('Макаров Станислав Викторович', '4005123476', '1981-08-14', '+79160001121', 'makarov@mail.ru', 'Мужской'),
('Федорова Галина Степановна', '4005123477', '1974-01-27', '+79160001122', 'fedorova@mail.ru', 'Женский'),
('Дмитриев Евгений Аркадьевич', '4005123478', '1998-07-03', '+79160001123', 'dmitriev@mail.ru', 'Мужской'),
('Савельева Оксана Борисовна', '4005123479', '1986-10-16', '+79160001124', 'savelieva_o@mail.ru', 'Женский'),
('Титов Александр Денисович', '4005123480', '1973-12-09', '+79160001125', 'titov@mail.ru', 'Мужской'),
('Комарова Лариса Евгеньевна', '4005123481', '1999-05-22', '+79160001126', 'komarova@mail.ru', 'Женский'),
('Беляев Игорь Николаевич', '4005123482', '1989-03-07', '+79160001127', 'belyaev@mail.ru', 'Мужской'),
('Григорьева Светлана Вадимовна', '4005123483', '1972-09-19', '+79160001128', 'grigorieva@mail.ru', 'Женский'),
('Киселев Аркадий Павлович', '4005123484', '1990-11-01', '+79160001129', 'kiselev@mail.ru', 'Мужской'),
('Титова Валентина Ильинична', '4005123485', '1985-06-13', '+79160001130', 'titova@mail.ru', 'Женский'),
('Сорокин Владислав Георгиевич', '4005123486', '1978-02-26', '+79160001131', 'sorokin@mail.ru', 'Мужской'),
('Власова Инна Александровна', '4005123487', '1993-08-09', '+79160001132', 'vlasova_i@mail.ru', 'Женский'),
('Филиппов Максим Рудольфович', '4005123488', '1980-04-23', '+79160001133', 'filippov@mail.ru', 'Мужской'),
('Данилова Елена Викторовна', '4005123489', '1975-10-06', '+79160001134', 'danilova_e@mail.ru', 'Женский'),
('Жуков Борис Семенович', '4005123490', '1994-01-18', '+79160001135', 'zhukov@mail.ru', 'Мужской'),
('Медведева Алла Дмитриевна', '4005123491', '1987-07-31', '+79160001136', 'medvedeva@mail.ru', 'Женский'),
('Николаев Геннадий Иванович', '4005123492', '1979-12-14', '+79160001137', 'nikolaev@mail.ru', 'Мужской'),
('Петрова Зоя Анатольевна', '4005123493', '1996-03-27', '+79160001138', 'petrova@mail.ru', 'Женский'),
('Степанов Валерий Олегович', '4005123494', '1982-09-10', '+79160001139', 'stepanov@mail.ru', 'Мужской'),
('Михайлова Регина Эдуардовна', '4005123495', '1976-05-24', '+79160001140', 'mihailova@mail.ru', 'Женский'),
('Васильев Павел Артемович', '4005123496', '1991-10-07', '+79160001141', 'vasiliev@mail.ru', 'Мужской'),
('Алексеева Ксения Романовна', '4005123497', '1984-02-19', '+79160001142', 'alekseeva@mail.ru', 'Женский'),
('Захаров Тимур Витальевич', '4005123498', '1977-08-02', '+79160001143', 'zaharov@mail.ru', 'Мужской'),
('Романова Диана Игоревна', '4005123499', '1998-11-15', '+79160001144', 'romanova_d@mail.ru', 'Женский'),
('Гаврилов Руслан Денисович', '4005123500', '1983-04-28', '+79160001145', 'gavrilov@mail.ru', 'Мужской'),
('Логинова Маргарита Сергеевна', '4005123501', '1974-07-11', '+79160001146', 'loginova@mail.ru', 'Женский'),
('Быков Артем Алексеевич', '4005123502', '1995-12-24', '+79160001147', 'bykov@mail.ru', 'Мужской'),
('Ершова Виктория Павловна', '4005123503', '1988-06-06', '+79160001148', 'ershova@mail.ru', 'Женский'),
('Миронов Денис Владимирович', '4005123504', '1971-01-29', '+79160001149', 'mironov@mail.ru', 'Мужской'),
('Кудрявцева Юлия Борисовна', '4005123505', '1992-08-12', '+79160001150', 'kudryavceva@mail.ru', 'Женский');

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ КЛАССОВ ДОМОВ
-- =====================================================
INSERT INTO home_class (class, description) VALUES
('Эконом', 'Базовый класс для бюджетного отдыха'),
('Комфорт', 'Улучшенный класс с дополнительными удобствами'),
('Люкс', 'Повышенной комфортности'),
('Премиум', 'Элитный класс'),
('Бизнес', 'Для деловых поездок');

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ УСЛУГ
-- =====================================================
INSERT INTO services (name_services, duration, description, price) VALUES
('Завтрак в номер', 30, 'Континентальный завтрак', 500.00),
('Экскурсия по городу', 120, 'Обзорная экскурсия', 1500.00),
('Трансфер из аэропорта', 45, 'Трансфер на комфортабельном авто', 1200.00),
('Спа-процедуры', 60, 'Расслабляющий массаж', 3000.00),
('Ужин в ресторане', 90, 'Трехразовое меню', 2500.00),
('Прачечная', 1440, 'Стирка и глажка белья', 800.00),
('Аренда автомобиля', 1440, 'Аренда на 24 часа', 3500.00),
('Фитнес-центр', 120, 'Посещение фитнес-центра', 700.00),
('Бассейн', 60, 'Посещение бассейна', 600.00),
('Конференц-зал', 480, 'Аренда зала на 8 часов', 8000.00),
('Химчистка', 1440, 'Чистка одежды', 1500.00),
('Услуги няни', 240, 'Присмотр за детьми', 2000.00),
('Бар', 180, 'Посещение бара', 1200.00),
('Сауна', 120, 'Посещение сауны', 2500.00),
('Бильярд', 60, 'Аренда бильярдного стола', 900.00),
('Теннисный корт', 120, 'Аренда корта', 1800.00),
('Гольф', 240, 'Игра в гольф', 3500.00),
('Караоке', 180, 'Аренда караоке-зала', 2200.00),
('Кинотеатр', 120, 'Просмотр фильма', 800.00),
('Боулинг', 120, 'Игра в боулинг', 1600.00);

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ ДОМОВ
-- =====================================================
INSERT INTO house (home_class_id, name, address_number, capacity, description, status) VALUES
(1, 'Уютный домик у озера', '10A', 2, 'Небольшой уютный домик с видом на озеро', 'available'),
(2, 'Семейный коттедж', '15B', 6, 'Просторный коттедж для семейного отдыха', 'available'),
(3, 'Вип вилла', '25', 8, 'Роскошная вилла с бассейном и садом', 'available'),
(4, 'Премиум резиденция', '30', 12, 'Элитная резиденция с полным сервисом', 'available'),
(5, 'Бизнес апартаменты', '5', 4, 'Современные апартаменты для деловых поездок', 'available'),
(1, 'Эконом студия', '8', 2, 'Компактная студия для бюджетного проживания', 'available'),
(2, 'Комфорт люкс', '12', 4, 'Комфортабельные апартаменты с кухней', 'available'),
(3, 'Люкс с джакузи', '18', 6, 'Просторный номер с гидромассажной ванной', 'available'),
(4, 'Президентский люкс', '1', 10, 'Эксклюзивный номер высшего класса', 'available'),
(5, 'Деловой центр', '3', 8, 'Апартаменты для проведения встреч и переговоров', 'available'),
(1, 'Стандарт плюс', '7', 3, 'Улучшенный стандартный номер', 'available'),
(2, 'Семейный люкс', '14', 5, 'Просторный номер для семьи с детьми', 'available'),
(3, 'Романтическое гнездышко', '22', 2, 'Уютный номер для романтического отдыха', 'available'),
(4, 'Королевская вилла', '28', 15, 'Огромная вилла с прилегающей территорией', 'available'),
(5, 'Элит пентхаус', '2', 6, 'Пентхаус с панорамным видом', 'available'),
(1, 'Бюджетный вариант', '9', 2, 'Экономичный вариант для короткого пребывания', 'available'),
(2, 'Улучшенный комфорт', '11', 4, 'Комфортабельный номер с балконом', 'available'),
(3, 'Люкс с камином', '17', 4, 'Уютный номер с камином', 'available'),
(4, 'Эксклюзивная вилла', '26', 8, 'Вилла с частным бассейном', 'available'),
(5, 'Бизнес класс', '4', 6, 'Апартаменты для длительных командировок', 'available');

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ БРОНИРОВАНИЙ
-- =====================================================
INSERT INTO booking (client_id, house_id, user_id, check_in_date, check_out_date, status, days_count, total_price, deposit_paid, notes) VALUES
(1, 3, 8, '2025-03-01', '2025-03-05', 'confirmed', 4, 32000.00, 10000.00, 'Деловая поездка'),
(2, 2, 2, '2025-03-10', '2025-03-15', 'confirmed', 5, 25000.00, 5000.00, 'Семейный отдых'),
(3, 5, 8, '2025-03-20', '2025-03-25', 'pending', 5, 35000.00, 0.00, 'Корпоратив'),
(4, 1, 2, '2025-04-01', '2025-04-03', 'pending', 2, 4000.00, 0.00, 'Выходные'),
(5, 7, 8, '2025-04-05', '2025-04-10', 'confirmed', 5, 40000.00, 20000.00, 'Отпуск');

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ ЗАСЕЛЕНИЙ
-- =====================================================
INSERT INTO check_in (client_id, house_id, user_id, check_in_date, check_out_date, residence_time, tag, house_total_price) VALUES
(1, 1, 2, '2025-02-15', '2025-02-20', 5, 'раннее заселение', 15000.00),
(2, 2, 3, '2025-02-16', '2025-02-19', 3, 'позднее выселение', 12000.00),
(3, 3, 4, '2025-02-17', '2025-02-24', 7, 'VIP клиент', 35000.00),
(4, 4, 5, '2025-02-18', '2025-02-20', 2, 'стандарт', 18000.00),
(5, 5, 6, '2025-02-19', '2025-02-26', 10, 'длительное проживание', 45000.00),  -- Исправлено с 29 на 26
(6, 6, 7, '2025-02-20', '2025-02-24', 4, 'бизнес поездка', 16000.00);

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ УСЛУГ В ЗАКАЗАХ
-- =====================================================
INSERT INTO check_in_services (order_number, service_id, quantity, service_total_price) VALUES
(1, 1, 5, 2500.00),
(1, 3, 1, 1200.00),
(2, 2, 1, 1500.00),
(3, 4, 3, 9000.00),
(3, 7, 7, 24500.00),
(4, 1, 2, 1000.00),
(5, 6, 1, 800.00),
(5, 9, 10, 6000.00);

-- =====================================================
-- ЗАПОЛНЕНИЕ ТАБЛИЦЫ УВЕДОМЛЕНИЙ
-- =====================================================
INSERT INTO notifications (user_id, booking_id, type, message, sent_at, is_read) VALUES
(2, 1, 'booking_reminder', 'Напоминание: заезд клиента Сидоров А.В. через 3 дня', DATE_SUB(NOW(), INTERVAL 1 DAY), FALSE),
(8, 2, 'deposit_reminder', 'Необходимо внести депозит по бронированию №2', DATE_SUB(NOW(), INTERVAL 2 DAY), FALSE),
(2, 3, 'check_in_today', 'Сегодня заезд клиента Никитин Д.О.', NOW(), FALSE);

-- =====================================================
-- СОЗДАНИЕ ИНДЕКСОВ ДЛЯ УСКОРЕНИЯ ЗАПРОСОВ
-- =====================================================
CREATE INDEX idx_client_passport ON client(passport_series_number);
CREATE INDEX idx_client_email ON client(email);
CREATE INDEX idx_users_login ON users(login);
CREATE INDEX idx_booking_client ON booking(client_id);
CREATE INDEX idx_booking_house ON booking(house_id);
CREATE INDEX idx_booking_dates ON booking(check_in_date, check_out_date);
CREATE INDEX idx_booking_status ON booking(status);
CREATE INDEX idx_check_in_client ON check_in(client_id);
CREATE INDEX idx_check_in_house ON check_in(house_id);
CREATE INDEX idx_check_in_dates ON check_in(check_in_date, check_out_date);
CREATE INDEX idx_personal_position ON personal(position_id);
CREATE INDEX idx_personal_active ON personal(is_active);
CREATE INDEX idx_house_status ON house(status);

-- =====================================================
-- ФУНКЦИЯ ДЛЯ ПРОВЕРКИ ДОСТУПНОСТИ ДОМА
-- =====================================================
DELIMITER $$
CREATE FUNCTION check_house_availability(
    p_house_id INT,
    p_check_in DATE,
    p_check_out DATE
) RETURNS BOOLEAN
DETERMINISTIC
BEGIN
    DECLARE v_overlap_count INT;
    
    -- Проверяем пересечение с бронированиями
    SELECT COUNT(*) INTO v_overlap_count
    FROM booking b
    WHERE b.house_id = p_house_id
      AND b.status IN ('pending', 'confirmed')
      AND (p_check_in < b.check_out_date AND p_check_out > b.check_in_date);
    
    -- Проверяем пересечение с заселениями
    SELECT COUNT(*) + v_overlap_count INTO v_overlap_count
    FROM check_in ci
    WHERE ci.house_id = p_house_id
      AND (p_check_in < ci.check_out_date AND p_check_out > ci.check_in_date);
    
    -- Проверяем статус дома
    SELECT COUNT(*) + v_overlap_count INTO v_overlap_count
    FROM house h
    WHERE h.id = p_house_id AND h.status != 'available';
    
    RETURN v_overlap_count = 0;
END$$
DELIMITER ;

-- =====================================================
-- ТРИГГЕР ДЛЯ АВТОМАТИЧЕСКОГО РАСЧЕТА СТОИМОСТИ УСЛУГ
-- =====================================================
DELIMITER $$
CREATE TRIGGER calculate_service_price BEFORE INSERT ON check_in_services
FOR EACH ROW
BEGIN
    DECLARE service_price DECIMAL(10,2);
    SELECT price INTO service_price FROM services WHERE id = NEW.service_id;
    SET NEW.service_total_price = service_price * NEW.quantity;
END$$
DELIMITER ;

-- =====================================================
-- ФУНКЦИЯ ДЛЯ ПОЛУЧЕНИЯ ОБЩЕЙ СУММЫ ЗАКАЗА
-- =====================================================
DELIMITER $$
CREATE FUNCTION get_order_total(order_id INT) RETURNS DECIMAL(10,2)
DETERMINISTIC
BEGIN
    DECLARE total DECIMAL(10,2);
    
    SELECT 
        ci.house_total_price + IFNULL(SUM(cis.service_total_price), 0)
    INTO total
    FROM check_in ci
    LEFT JOIN check_in_services cis ON ci.order_number = cis.order_number
    WHERE ci.order_number = order_id;
    
    RETURN total;
END$$
DELIMITER ;

-- =====================================================
-- ПРЕДСТАВЛЕНИЯ ДЛЯ УДОБНОЙ РАБОТЫ
-- =====================================================

-- Представление для просмотра сотрудников с должностями
CREATE VIEW staff_view AS
SELECT 
    p.id,
    p.FIO,
    pos.position_name,
    p.job_title,
    p.email,
    p.telephone_number,
    CASE WHEN p.photo IS NOT NULL THEN 'Есть фото' ELSE 'Нет фото' END as photo_status,
    p.hire_date,
    p.is_active,
    u.id as user_id,
    u.login,
    r.role_name,
    CASE 
        WHEN u.id IS NOT NULL THEN 'Есть доступ'
        ELSE 'Нет доступа'
    END as access_status
FROM personal p
LEFT JOIN positions pos ON p.position_id = pos.id
LEFT JOIN users u ON p.id = u.personal_id
LEFT JOIN role r ON u.role_id = r.id
ORDER BY p.FIO;

-- Представление для просмотра активных бронирований
CREATE VIEW active_bookings AS
SELECT 
    b.id,
    c.FIO as client_name,
    h.name as house_name,
    hc.class as house_class,
    u.login as created_by,
    b.check_in_date,
    b.check_out_date,
    b.days_count,
    b.total_price,
    b.deposit_paid,
    b.status,
    DATEDIFF(b.check_in_date, CURDATE()) as days_until_checkin
FROM booking b
JOIN client c ON b.client_id = c.id
JOIN house h ON b.house_id = h.id
JOIN home_class hc ON h.home_class_id = hc.id
JOIN users u ON b.user_id = u.id
WHERE b.status IN ('pending', 'confirmed')
ORDER BY b.check_in_date;

-- Представление для просмотра активных заселений
CREATE VIEW active_checkins AS
SELECT 
    ci.order_number,
    c.FIO as client_name,
    h.name as house_name,
    hc.class as house_class,
    u.login as created_by,
    ci.check_in_date,
    ci.check_out_date,
    ci.residence_time,
    ci.house_total_price,
    DATEDIFF(ci.check_out_date, CURDATE()) as days_remaining
FROM check_in ci
JOIN client c ON ci.client_id = c.id
JOIN house h ON ci.house_id = h.id
JOIN home_class hc ON h.home_class_id = hc.id
JOIN users u ON ci.user_id = u.id
WHERE ci.check_out_date >= CURDATE()
ORDER BY ci.check_out_date;

-- Представление для просмотра доступных домов
CREATE VIEW available_houses AS
SELECT 
    h.id,
    h.name,
    hc.class,
    h.capacity,
    h.description,
    h.address_number,
    CASE hc.class
        WHEN 'Эконом' THEN 3000
        WHEN 'Комфорт' THEN 5000
        WHEN 'Люкс' THEN 8000
        WHEN 'Премиум' THEN 12000
        WHEN 'Бизнес' THEN 10000
        ELSE 5000
    END as estimated_price_per_night
FROM house h
JOIN home_class hc ON h.home_class_id = hc.id
WHERE h.status = 'available'
ORDER BY h.name;

-- Представление для статистики по домам
CREATE VIEW house_statistics AS
SELECT 
    h.id,
    h.name,
    hc.class,
    COUNT(ci.order_number) as total_bookings,
    AVG(ci.residence_time) as avg_stay_duration,
    SUM(ci.house_total_price) as total_revenue,
    IFNULL(SUM(cis.service_total_price), 0) as services_revenue,
    SUM(ci.house_total_price) + IFNULL(SUM(cis.service_total_price), 0) as total_income
FROM house h
JOIN home_class hc ON h.home_class_id = hc.id
LEFT JOIN check_in ci ON h.id = ci.house_id
LEFT JOIN check_in_services cis ON ci.order_number = cis.order_number
GROUP BY h.id, h.name, hc.class;

-- =====================================================
-- ФИНАЛЬНОЕ СООБЩЕНИЕ
-- =====================================================
SELECT '✅ База данных успешно создана!' as status;
SELECT 'Пользователи (пароль для всех: 123456):' as info;
SELECT '  - ivanov_i (администратор)' as info;
SELECT '  - petrov_p (ресепшен)' as info;
SELECT '  - vasnecov_s (управляющий)' as info;
SELECT '  - egorov_a (управляющий)' as info;
SELECT '  - belov_a (управляющий)' as info;
SELECT 'Всего сотрудников: 50' as info;
SELECT 'Всего клиентов: 50' as info;
SELECT 'Всего домов: 20' as info;
SELECT 'Всего услуг: 20' as info;