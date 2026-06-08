create table Role(
RoleID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
RoleName VARCHAR(50) NOT NULL
);
create table Categories(
CategoriesID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
CategoriesName VARCHAR(50) NOT NULL
);
create table Suppler(
SupplerID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
SupplerName VARCHAR(50) NOT NULL
);
create table Munufacturied(
MunufacturiedID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
MunufacturiedName VARCHAR(50) NOT NULL
);
create table StatusOrder(
StatusOrderID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
StatusOrderName VARCHAR(50) NOT NULL
);
create table Users(
UsersID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
UsersName VARCHAR(50) NOT NULL,
UsersLogin VARCHAR(50) NOT NULL,
UsersPassword VARCHAR(50) NOT NULL,
UsersRole INT NOT NULL,
FOREIGN KEY(UsersRole) REFERENCES Role(RoleID)
);
create table Product(
ProductID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
ProductArtucul VARCHAR(50) NOT NULL,
ProductName VARCHAR(50) NOT NULL,
ProductUnit VARCHAR(50) NOT NULL,
ProductPrice INT NOT NULL,
ProductSuppler INT NOT NULL,
ProductMunufacturied INT NOT NULL,
ProductCategories INT NOT NULL,
ProductDiscount INT NOT NULL,
ProductQuantitiInStock INT NOT NULL,
ProductDescription VARCHAR(250) NOT NULL,
ProductPhoto VARCHAR(50) NOT NULL,
FOREIGN KEY(ProductSuppler) REFERENCES Suppler(SupplerID),
FOREIGN KEY(ProductMunufacturied) REFERENCES Munufacturied(MunufacturiedID),
FOREIGN KEY(ProductCategories) REFERENCES Categories(CategoriesID)
);
create table PickUpPoint(
PickUpPointID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
PickUpPointNumber INT NOT NULL,
PickUpPointAddres VARCHAR(50) NOT NULL
);
create table OrderTable(
OrderTableID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
OrderTableDate DATE NOT NULL,
OrderTableDeliveryDate DATE,
OrderTablePickupAddress VARCHAR(300) NOT NULL,
OrderTableClient INT NOT NULL,
OrderTablePickupCode VARCHAR(50) NOT NULL,
OrderTableStatusOrder INT NOT NULL,
FOREIGN KEY(OrderTableClient) REFERENCES Users(UsersID),
FOREIGN KEY(OrderTableStatusOrder) REFERENCES StatusOrder(StatusOrderID)
);

create table OrderItem(
OrderItemID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
OrderItemOrder INT NOT NULL,
OrderItemProduct INT NOT NULL,
OrderItemQuantity INT NOT NULL,
FOREIGN KEY(OrderItemOrder) REFERENCES OrderTable(OrderTableID),
FOREIGN KEY(OrderItemProduct) REFERENCES Product(ProductID)
);
