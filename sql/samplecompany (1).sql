-- "NO_AUTO_VALUE_ON_ZERO" suppress generate the next sequence number for AUTO_INCREMENT column
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+08:00";

-- Database: `ProjectDB`
DROP DATABASE IF EXISTS `samplecompany`;
CREATE DATABASE IF NOT EXISTS `samplecompany` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `samplecompany`;

-- Drop tables in reverse order of dependencies to avoid foreign key blocks
DROP TABLE IF EXISTS `production_requests`;
DROP TABLE IF EXISTS `procurements`;
DROP TABLE IF EXISTS `logistics_shipments`;
DROP TABLE IF EXISTS `after_service_records`;
DROP TABLE IF EXISTS `order_details`;
DROP TABLE IF EXISTS `orders`;
DROP TABLE IF EXISTS `inventory`;
DROP TABLE IF EXISTS `user_accounts`;
DROP TABLE IF EXISTS `suppliers`;
DROP TABLE IF EXISTS `customer`;
DROP TABLE IF EXISTS `staff`;
DROP TABLE IF EXISTS `Customize`;
DROP TABLE IF EXISTS `CustomizeRequired`;

-- ============================================================================
-- 1. CREATE STAFF TABLE FIRST (Parent Table)
-- ============================================================================
CREATE TABLE `staff` (
  `staffID` varchar(10) NOT NULL,
  `fullName` varchar(100) NOT NULL,
  `role` varchar(50) NOT NULL,
  `department` varchar(50) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`staffID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `staff` (`staffID`, `fullName`, `role`, `department`, `email`) VALUES
('STF001', 'Alice Wong', 'System Admin', 'IT', 'alice.wong@furniture.com'),
('STF002', 'Bob Chen', 'Sales Manager', 'Sales', 'bob.chen@furniture.com'),
('STF003', 'Charlie Lee', 'Inventory Officer', 'Warehouse', 'charlie.lee@furniture.com'),
('STF004', 'David Kwok', 'Procurement Specialist', 'Purchasing', 'david.kwok@furniture.com'),
('STF005', 'Eva Cheung', 'Logistics Coordinator', 'Logistics', 'eva.cheung@furniture.com'),
('STF006', 'Frank Liu', 'Production Supervisor', 'Production', 'frank.liu@furniture.com'),
('STF007', 'Grace Ho', 'Support Agent', 'After-Service', 'grace.ho@furniture.com'),
('STF008', 'Henry Lam', 'Sales Associate', 'Sales', 'henry.lam@furniture.com'),
('STF009', 'Ivy Ma', 'Warehouse Assistant', 'Warehouse', 'ivy.ma@furniture.com'),
('STF010', 'Jack Tang', 'Procurement Agent', 'Purchasing', 'jack.tang@furniture.com');

-- ============================================================================
-- 2. CREATE CUSTOMER TABLE SECOND
-- ============================================================================
CREATE TABLE `customer` (
  `customerNumber` int(11) NOT NULL,
  `customerName` varchar(50) NOT NULL,
  `contactLastName` varchar(50) NOT NULL,
  `contactFirstName` varchar(50) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `addressLine1` varchar(50) NOT NULL,
  `addressLine2` varchar(50) DEFAULT NULL,
  `city` varchar(50) NOT NULL,
  `country` varchar(50) NOT NULL,
  `cardNumber` varchar(19) DEFAULT NULL,
  `expiredDay` varchar(10) DEFAULT NULL,
  `cvv` varchar(4) DEFAULT NULL,
  `staffID` varchar(10) DEFAULT NULL,
  `creditLimit` double DEFAULT NULL,
  PRIMARY KEY (`customerNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
LOCK TABLES `customer` WRITE;
INSERT INTO `customer` (
    `customerNumber`, 
    `customerName`, 
    `contactLastName`, 
    `contactFirstName`, 
    `phone`, 
    `addressLine1`, 
    `addressLine2`, 
    `city`, 
    `country`, 
    `cardNumber`, 
    `expiredDay`, 
    `cvv`, 
    `staffID`, 
    `creditLimit`
) 
VALUES 
(103, 'Atelier graphique', 'Schmtt', 'Carine', '40.32.2555', '54, rue Royale', NULL, 'Paris', 'France', '4532 7153 9024 1485', '2028-11-15', '382', NULL, 21000.00),
(112, 'Signal Gift Stores', 'King', 'Jean', '7025551838', '8489 Strong St.', NULL, 'Las Vegas', 'USA', '5412 8831 0047 6291', '2027-04-02', '915', NULL, 71800.00),
(114, 'Australian Collectors, Co.', 'Ferguson', 'Peter', '03 9520 4555', '636 St Kilda Road', 'Level 3', 'Melbourne', 'Australia', '3782 4916 2503 774', '2029-08-22', '4421', NULL, 117300.00),
(119, 'La Rochelle Gifts', 'Labrune', 'Janine', '40.67.8555', '67, rue des Cinquante Otages', NULL, 'Nantes', 'France', '6011 0284 5591 3306', '2026-12-09', '073', NULL, 118200.00),
(121, 'Baane Mini Imports', 'Bergulfsen', 'Jonas', '07-98 9555', 'Erling Skakkes gate 78', NULL, 'Stavern', 'Norway', '4916 9312 0054 8819', '2030-05-18', '516', NULL, 81700.00),
(124, 'Mini Gifts Distributions Ltd.', 'Nelson', 'Susan', '4155551450', '5677 Strong St.', NULL, 'San Rafael', 'USA', NULL, NULL, NULL, NULL, 210500.00),
(125, 'Havel & Zbyszek Co.', 'Piestrzeniewicz', 'Zbyszek', '(26) 642-7555', 'ul. Filtrowa 68', NULL, 'Warszawa', 'Poland', NULL, NULL, NULL, NULL, 0.00),
(128, 'Blauer See Auto, Co.', 'Keitel', 'Roland', '+49 69 66 90 2555', 'Lyonerstr. 34', NULL, 'Frankfurt', 'Germany', NULL, NULL, NULL, NULL, 59700.00),
(129, 'Mini Wheels Co.', 'Murphy', 'Julie', '6505555787', '5557 North Line Rd.', NULL, 'South San Francisco', 'USA', NULL, NULL, NULL, NULL, 64600.00),
(131, 'Land of Toys Inc.', 'Lee', 'Kwai', '2125557818', '897 Long Airport Avenue', NULL, 'NYC', 'USA', NULL, NULL, NULL, NULL, 114900.00),
(141, 'Euro+ Shopping Channel', 'Freyre', 'Diego', '(91) 555 94 44', 'C/ Moralzarzal, 86', NULL, 'Madrid', 'Spain', NULL, NULL, NULL, NULL, 227600.00),
(144, 'Volvo Model Replicas, Co.', 'Berglund', 'Christina', '0921-12 3555', 'Berguvsvägen 8', NULL, 'Luleå', 'Sweden', NULL, NULL, NULL, NULL, 53100.00),
(145, 'Danish Wholesale Imports', 'Petersen', 'Jytte', '31 12 3555', 'Vinbæltet 34', NULL, 'København', 'Denmark', NULL, NULL, NULL, NULL, 83400.00),
(146, 'Saveley & Henriot Co.', 'Saveley', 'Mary', '78.32.5555', '2, rue du Commerce', NULL, 'Lyon', 'France', NULL, NULL, NULL, NULL, 123900.00),
(148, 'Dragon Souvenirs, Ltd.', 'Natividad', 'Eric', '+65 221 7555', 'Bronzini St.', NULL, 'Singapore', 'Singapore', NULL, NULL, NULL, NULL, 103800.00);
UNLOCK TABLES;
-- ============================================================================
-- 3. CREATE SUPPLIERS TABLE
-- ============================================================================
CREATE TABLE `suppliers` (
  `supplierID` int(11) NOT NULL AUTO_INCREMENT,
  `supplierName` varchar(100) NOT NULL,
  `contactName` varchar(50) NOT NULL,
  `phone` varchar(30) NOT NULL,
  `address` varchar(150) NOT NULL,
  PRIMARY KEY (`supplierID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `suppliers` (`supplierName`, `contactName`, `phone`, `address`) VALUES
('Timberland Lumber Co.', 'John Smith', '+852 2345 6789', 'Kwai Chung Industrial Bldg, HK'),
('Steel & Iron Components Ltd.', 'Mark Davis', '+852 3456 7890', 'Tsuen Wan Industrial Center, HK'),
('Foam & Fabrics Wholesale', 'Sarah Jenkins', '+852 4567 8901', 'Kwun Tong Fabric Center, HK'),
('Hardware Fasteners Corp.', 'Peter Parker', '+852 5678 9012', 'Shatin Enterprise Hub, HK'),
('Eco-Plastics & Veneers', 'Lisa Wong', '+852 6789 0123', 'Fanling Plastics Zone, HK');

-- ============================================================================
-- 4. SYSTEM SECURITY & CONTROL (User Credentials) - 🌟已修复反引号与外键类型错误
-- ============================================================================
CREATE TABLE IF NOT EXISTS `user_accounts` (
  `username` varchar(50) NOT NULL,
  `passwordHash` varchar(255) NOT NULL,
  `staffID` varchar(10) DEFAULT NULL,
  `customerID` int(11) DEFAULT NULL, -- 🌟 修复：补全反引号并将类型改成 int(11) 以对齐客户表主键
  `accessLevel` varchar(20) NOT NULL,
  PRIMARY KEY (`username`),
  CONSTRAINT `fk_user_staff` FOREIGN KEY (`staffID`) REFERENCES `staff` (`staffID`) ON DELETE CASCADE,
  CONSTRAINT `fk_user_customer` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerNumber`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `user_accounts` (`username`, `passwordHash`, `staffID`, `customerID`, `accessLevel`) VALUES
('admin', 'admin123', 'STF001', NULL, 'Admin'),
('sales01', 'sales123', 'STF002', NULL, 'Sales'),
('warehouse01', 'wh123', 'STF003', NULL, 'Warehouse'),
('buyer01', 'buy123', 'STF004', NULL, 'Procurement'),
('logistics01', 'log123', 'STF005', NULL, 'Logistics'),
('prod01', 'prod123', 'STF006', NULL, 'Production'),
('service01', 'svc123', 'STF007', NULL, 'After-Service'),
('sales02', 'sales456', 'STF008', NULL, 'Sales'),        
('customer103', 'cust123', NULL, 103, 'Customer');       

-- ============================================================================
-- 5. INVENTORY CONTROL & RAW MATERIAL MANAGEMENT
-- ============================================================================
CREATE TABLE `inventory` (
  `itemID` varchar(10) NOT NULL,
  `itemName` varchar(100) NOT NULL,
  `itemType` enum('Finished Goods','Raw Material') NOT NULL,
  `quantityInStock` int(11) NOT NULL DEFAULT 0,
  `unit` varchar(20) NOT NULL,
  `location` varchar(50) NOT NULL,
  PRIMARY KEY (`itemID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `inventory` (`itemID`, `itemName`, `itemType`, `quantityInStock`, `unit`, `location`) VALUES
('RM001', 'Oak Wood Planks', 'Raw Material', 450, 'pcs', 'Aisle A1'),
('RM002', 'Steel Frame Supports', 'Raw Material', 180, 'pcs', 'Aisle B3'),
('RM003', 'High-Density Foam Block', 'Raw Material', 95, 'pcs', 'Aisle C2'),
('RM004', 'Leather Fabric Roll (Black)', 'Raw Material', 25, 'rolls', 'Aisle D1'),
('RM005', 'M8 Assembly Screws', 'Raw Material', 5000, 'units', 'Bin 12'),
('FG001', 'Ergonomic Office Chair', 'Finished Goods', 45, 'units', 'Zone Alpha'),
('FG002', 'Mahogany Dining Table', 'Finished Goods', 12, 'units', 'Zone Beta'),
('FG003', '3-Seater Velvet Sofa', 'Finished Goods', 8, 'units', 'Zone Gamma'),
('FG004', 'Minimalist Study Desk', 'Finished Goods', 30, 'units', 'Zone Alpha'),
('FG005', 'Modular Bookcase Rack', 'Finished Goods', 15, 'units', 'Zone Beta');
  
-- ============================================================================
-- CUSTOMIZATION TABLES (Updated for MySQL Compatibility)
-- ============================================================================

-- Customize Table: Stores the initial customization request
CREATE TABLE `Customize` (
    `customizeID` INT NOT NULL AUTO_INCREMENT,
    `customerID` INT(11) NOT NULL,
    `type` VARCHAR(50),
    `color` VARCHAR(30),
    `size` VARCHAR(50),
    `desktopMaterialID` VARCHAR(10) NOT NULL,
    `desktopMaterialName` VARCHAR(100),
    `legMaterialID` VARCHAR(10) NOT NULL,
    `legMaterialName` VARCHAR(100),
    `description` TEXT,
    `file` LONGBLOB,
    `price` DOUBLE,
    `newPrice` DOUBLE DEFAULT NULL,        -- New attribute added
    `rejectResult` TEXT DEFAULT NULL,      -- New attribute added
    `status` ENUM('processing', 'rejected', 'determined', 'accepted', 'edited') DEFAULT 'processing',
    PRIMARY KEY (`customizeID`),
    CONSTRAINT `fk_cust_customer` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerNumber`),
    CONSTRAINT `fk_cust_desktop` FOREIGN KEY (`desktopMaterialID`) REFERENCES `inventory` (`itemID`),
    CONSTRAINT `fk_cust_leg` FOREIGN KEY (`legMaterialID`) REFERENCES `inventory` (`itemID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
INSERT INTO Customize (customerID, type, color, size, desktopMaterialID,desktopMaterialName, legMaterialID,legMaterialName, description, price, status) 
VALUES (103, 'Desk', 'Mahogany', 'Large', 'RM001','123', 'RM002','123', 'Test Customization', 5500.00, 'processing');

-- CustomizeRequired Table: Stores specific material usage for a confirmed request
CREATE TABLE  `CustomizeRequired` (
    `requirementID` INT NOT NULL AUTO_INCREMENT,
    `customizeID` INT NOT NULL,
    `desktopMaterialID` VARCHAR(10),
    `desktopQty` INT,
    `legMaterialID` VARCHAR(10),
    `legQty` INT,
    `type` VARCHAR(50),
    `color` VARCHAR(30),
    `size` VARCHAR(50),
    `description` TEXT,
    `file` LONGBLOB,
    PRIMARY KEY (`requirementID`),
    CONSTRAINT `fk_req_customize` FOREIGN KEY (`customizeID`) REFERENCES `Customize` (`customizeID`) ON DELETE CASCADE,
    CONSTRAINT `fk_req_desktop` FOREIGN KEY (`desktopMaterialID`) REFERENCES `inventory` (`itemID`),
    CONSTRAINT `fk_req_leg` FOREIGN KEY (`legMaterialID`) REFERENCES `inventory` (`itemID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
INSERT INTO CustomizeRequired (customizeID, desktopMaterialID, desktopQty, legMaterialID, legQty, type, size, color) 
VALUES (1, 'RM001', 1, 'RM002', 4, 'Table', 'Large', 'Oak');

-- ============================================================================
-- 6. ORDER PROCESSING MANAGEMENT
-- ============================================================================
CREATE TABLE `orders` (
  `orderNumber` int(11) NOT NULL AUTO_INCREMENT,
  `orderDate` date NOT NULL,
  `customerNumber` int(11) NOT NULL,
  `totalAmount` double NOT NULL,
  `orderStatus` enum('Pending','Processing','Shipped','Cancelled') NOT NULL DEFAULT 'Pending',
  `customizeRequiredID` int DEFAULT NULL,
  PRIMARY KEY (`orderNumber`),
  KEY `idx_customerNumber` (`customerNumber`),
  CONSTRAINT `fk_orders_customer` FOREIGN KEY (`customerNumber`) REFERENCES `customer` (`customerNumber`) ON DELETE CASCADE,
  CONSTRAINT `fk_orders_customize` FOREIGN KEY (`customizeRequiredID`) REFERENCES `CustomizeRequired` (`requirementID`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=1001 DEFAULT CHARSET=latin1;

LOCK TABLES `orders` WRITE;
INSERT INTO `orders` (`orderNumber`, `orderDate`, `customerNumber`, `totalAmount`, `orderStatus`, `customizeRequiredID`) VALUES
(1001, '2026-06-01', 103, 4500.00, 'Shipped', NULL),
(1002, '2026-06-05', 112, 1250.00, 'Processing', NULL),
(1003, '2026-06-10', 114, 8900.00, 'Pending', NULL),
(1004, '2026-06-12', 119, 3200.00, 'Processing', NULL),
(1005, '2026-06-14', 121, 15000.00, 'Pending', NULL),
(1006, '2026-06-15', 124, 600.00, 'Cancelled', NULL),
(1007, '2026-06-15', 125, 2450.00, 'Pending', NULL),
(1008, '2026-06-16', 103, 3100.00, 'Pending', NULL);
UNLOCK TABLES;

-- Order Details
CREATE TABLE `order_details` (
  `orderNumber` int(11) NOT NULL,
  `itemID` varchar(10) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unitPrice` double NOT NULL,
  PRIMARY KEY (`orderNumber`,`itemID`),
  KEY `idx_order_item` (`itemID`),
  CONSTRAINT `fk_details_order` FOREIGN KEY (`orderNumber`) REFERENCES `orders` (`orderNumber`) ON DELETE CASCADE,
  CONSTRAINT `fk_details_inventory` FOREIGN KEY (`itemID`) REFERENCES `inventory` (`itemID`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

LOCK TABLES `order_details` WRITE;
INSERT INTO `order_details` (`orderNumber`, `itemID`, `quantity`, `unitPrice`) VALUES
(1001, 'FG001', 3, 1500.00),
(1002, 'FG004', 1, 1250.00),
(1003, 'FG003', 2, 4450.00),
(1004, 'FG005', 2, 1600.00),
(1005, 'FG002', 3, 5000.00),
(1006, 'FG001', 1, 600.00),
(1007, 'FG001', 1, 1500.00),
(1007, 'FG004', 1, 950.00),
(1008, 'FG005', 2, 1550.00);
UNLOCK TABLES;

-- ============================================================================
-- 7. PRODUCTION PROCESSING MANAGEMENT
-- ============================================================================
CREATE TABLE `production_requests` (
  `requestID` int(11) NOT NULL AUTO_INCREMENT,
  `requestDate` date NOT NULL,
  `targetItemID` varchar(10) NOT NULL,
  `rawMaterialID` varchar(10) NOT NULL,
  `quantityRequested` int(11) NOT NULL,
  `status` enum('Allocated','Fulfilled','Shortage') NOT NULL DEFAULT 'Allocated',
  PRIMARY KEY (`requestID`),
  KEY `idx_targetItem` (`targetItemID`),
  KEY `idx_rawMaterial` (`rawMaterialID`),
  CONSTRAINT `fk_prod_target` FOREIGN KEY (`targetItemID`) REFERENCES `inventory` (`itemID`),
  CONSTRAINT `fk_prod_material` FOREIGN KEY (`rawMaterialID`) REFERENCES `inventory` (`itemID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `production_requests` (`requestID`, `requestDate`, `targetItemID`, `rawMaterialID`, `quantityRequested`, `status`) VALUES
(1, '2026-06-02', 'FG001', 'RM002', 20, 'Fulfilled'),
(2, '2026-06-06', 'FG001', 'RM003', 15, 'Fulfilled'),
(3, '2026-06-11', 'FG003', 'RM004', 5, 'Allocated'),
(4, '2026-06-14', 'FG002', 'RM001', 40, 'Allocated'),
(5, '2026-06-16', 'FG004', 'RM001', 100, 'Shortage'),
(6, '2026-06-16', 'FG005', 'RM001', 30, 'Allocated');

-- ============================================================================
-- 8. RAW MATERIAL PROCUREMENT MANAGEMENT
-- ============================================================================
CREATE TABLE `procurements` (
  `procurementID` int(11) NOT NULL AUTO_INCREMENT,
  `orderDate` date NOT NULL,
  `supplierID` int(11) NOT NULL,
  `rawMaterialID` varchar(10) NOT NULL,
  `quantityOrdered` int(11) NOT NULL,
  `expectedDelivery` date NOT NULL,
  `status` enum('Ordered','In-Transit','Delivered') NOT NULL DEFAULT 'Ordered',
  PRIMARY KEY (`procurementID`),
  KEY `idx_proc_supplier` (`supplierID`),
  KEY `idx_proc_material` (`rawMaterialID`),
  CONSTRAINT `fk_proc_supplier` FOREIGN KEY (`supplierID`) REFERENCES `suppliers` (`supplierID`),
  CONSTRAINT `fk_proc_material` FOREIGN KEY (`rawMaterialID`) REFERENCES `inventory` (`itemID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `procurements` (`procurementID`, `orderDate`, `supplierID`, `rawMaterialID`, `quantityOrdered`, `expectedDelivery`, `status`) VALUES
(1, '2026-05-20', 1, 'RM001', 200, '2026-06-01', 'Delivered'),
(2, '2026-06-01', 2, 'RM002', 50, '2026-06-10', 'Delivered'),
(3, '2026-06-10', 3, 'RM004', 15, '2026-06-20', 'In-Transit'),
(4, '2026-06-15', 4, 'RM005', 2000, '2026-06-19', 'Ordered'),
(5, '2026-06-16', 1, 'RM001', 500, '2026-06-25', 'Ordered');

-- ============================================================================
-- 9. LOGISTICS PROCESSING
-- ============================================================================
CREATE TABLE `logistics_shipments` (
  `deliveryNoteID` int(11) NOT NULL AUTO_INCREMENT,
  `orderNumber` int(11) NOT NULL,
  `dispatchDate` date NOT NULL,
  `deliveryAddress` varchar(150) NOT NULL,
  `driverName` varchar(50) NOT NULL,
  `replySlipReceived` enum('Yes','No') NOT NULL DEFAULT 'No',
  `conditionReport` varchar(100) DEFAULT 'Good Condition',
  PRIMARY KEY (`deliveryNoteID`),
  KEY `idx_log_order` (`orderNumber`),
  CONSTRAINT `fk_log_order` FOREIGN KEY (`orderNumber`) REFERENCES `orders` (`orderNumber`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `logistics_shipments` (`deliveryNoteID`, `orderNumber`, `dispatchDate`, `deliveryAddress`, `driverName`, `replySlipReceived`, `conditionReport`) VALUES
(1, 1001, '2026-06-03', '54, rue Royale, Paris', 'Michael Chang', 'Yes', 'Signed - Perfect Condition'),
(2, 1002, '2026-06-08', '8489 Strong St., Tokyo', 'David Lau', 'Yes', 'Signed - Box damaged but item intact'),
(3, 1004, '2026-06-15', '67, rue des Cinquante, Paris', 'Michael Chang', 'No', 'Pending Delivery Tracking');

-- ============================================================================
-- 10. AFTER-SERVICE MANAGEMENT
-- ============================================================================
CREATE TABLE `after_service_records` (
  `caseID` int(11) NOT NULL AUTO_INCREMENT,
  `orderNumber` int(11) NOT NULL,
  `requestDate` date NOT NULL,
  `requestType` enum('Return','Replacement','Refund','Repair') NOT NULL,
  `reason` text NOT NULL,
  `resolutionStatus` enum('Open','Approved','Rejected','Closed') NOT NULL DEFAULT 'Open',
  PRIMARY KEY (`caseID`),
  KEY `idx_service_order` (`orderNumber`),
  CONSTRAINT `fk_service_order` FOREIGN KEY (`orderNumber`) REFERENCES `orders` (`orderNumber`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
  
INSERT INTO `after_service_records` (`caseID`, `orderNumber`, `requestDate`, `requestType`, `reason`, `resolutionStatus`) VALUES
(1, 1001, '2026-06-05', 'Repair', 'Slight loose threading on office chair armrest cushion padding', 'Closed'),
(2, 1002, '2026-06-11', 'Replacement', 'Received correct frame layout style but table color tone too dark', 'Approved'),
(3, 1001, '2026-06-16', 'Refund', 'Accidental duplicate charge encountered during automated billing sync', 'Open');


COMMIT;
-- "NO_AUTO_VALUE_ON_ZERO" suppress generate the next sequence number for AUTO_INCREMENT column
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+08:00";

-- Database: `ProjectDB`
DROP DATABASE IF EXISTS `samplecompany`;
CREATE DATABASE IF NOT EXISTS `samplecompany` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `samplecompany`;

-- Drop tables in reverse order of dependencies to avoid foreign key blocks
DROP TABLE IF EXISTS `production_requests`;
DROP TABLE IF EXISTS `procurements`;
DROP TABLE IF EXISTS `logistics_shipments`;
DROP TABLE IF EXISTS `after_service_records`;
DROP TABLE IF EXISTS `order_details`;
DROP TABLE IF EXISTS `orders`;
DROP TABLE IF EXISTS `inventory`;
DROP TABLE IF EXISTS `user_accounts`;
DROP TABLE IF EXISTS `suppliers`;
DROP TABLE IF EXISTS `customer`;
DROP TABLE IF EXISTS `staff`;

-- ============================================================================
-- 1. CREATE STAFF TABLE FIRST (Parent Table)
-- ============================================================================
CREATE TABLE `staff` (
  `staffID` varchar(10) NOT NULL,
  `fullName` varchar(100) NOT NULL,
  `role` varchar(50) NOT NULL,
  `department` varchar(50) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`staffID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `staff` (`staffID`, `fullName`, `role`, `department`, `email`) VALUES
('STF001', 'Alice Wong', 'System Admin', 'IT', 'alice.wong@furniture.com'),
('STF002', 'Bob Chen', 'Sales Manager', 'Sales', 'bob.chen@furniture.com'),
('STF003', 'Charlie Lee', 'Inventory Officer', 'Warehouse', 'charlie.lee@furniture.com'),
('STF004', 'David Kwok', 'Procurement Specialist', 'Purchasing', 'david.kwok@furniture.com'),
('STF005', 'Eva Cheung', 'Logistics Coordinator', 'Logistics', 'eva.cheung@furniture.com'),
('STF006', 'Frank Liu', 'Production Supervisor', 'Production', 'frank.liu@furniture.com'),
('STF007', 'Grace Ho', 'Support Agent', 'After-Service', 'grace.ho@furniture.com'),
('STF008', 'Henry Lam', 'Sales Associate', 'Sales', 'henry.lam@furniture.com'),
('STF009', 'Ivy Ma', 'Warehouse Assistant', 'Warehouse', 'ivy.ma@furniture.com'),
('STF010', 'Jack Tang', 'Procurement Agent', 'Purchasing', 'jack.tang@furniture.com');

-- ============================================================================
-- 2. CREATE CUSTOMER TABLE SECOND
-- ============================================================================
CREATE TABLE `customer` (
  `customerNumber` int(11) NOT NULL,
  `customerName` varchar(50) NOT NULL,
  `contactLastName` varchar(50) NOT NULL,
  `contactFirstName` varchar(50) NOT NULL,
  `phone` varchar(50) NOT NULL,
  `addressLine1` varchar(50) NOT NULL,
  `addressLine2` varchar(50) DEFAULT NULL,
  `city` varchar(50) NOT NULL,
  `country` varchar(50) NOT NULL,
  `cardNumber` varchar(19) DEFAULT NULL,
  `expiredDay` varchar(10) DEFAULT NULL,
  `cvv` varchar(4) DEFAULT NULL,
  `staffID` varchar(10) DEFAULT NULL,
  `creditLimit` double DEFAULT NULL,
  PRIMARY KEY (`customerNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

LOCK TABLES `customer` WRITE;
INSERT INTO `customer` VALUES 
(103, 'Atelier graphique', 'Schmtt', 'Carine', '40.32.2555', '54, rue Royale', NULL, 'Paris', 'France', '4532 7153 9024 1485', '2028-11-15', '382', NULL, 21000.00),
(112, 'Signal Gift Stores', 'King', 'Jean', '7025551838', '8489 Strong St.', NULL, 'Las Vegas', 'USA', '5412 8831 0047 6291', '2027-04-02', '915', NULL, 71800.00),
(114, 'Australian Collectors, Co.', 'Ferguson', 'Peter', '03 9520 4555', 'Level 3', '636 St Kilda Road', 'Melbourne', 'Australia', '3782 4916 2503 774', '2029-08-22', '4421', NULL, 117300.00),
(119, 'La Rochelle Gifts', 'Labrune', 'Janine', '40.67.8555', '67, rue des Cinquante Otages', NULL, 'Nantes', 'France', '6011 0284 5591 3306', '2026-12-09', '073', NULL, 118200.00),
(121, 'Baane Mini Imports', 'Bergulfsen', 'Jonas', '07-98 9555', 'Erling Skakkes gate 78', NULL, 'Stavern', 'Norway', '4916 9312 0054 8819', '2030-05-18', '516', NULL, 81700.00),
(124, 'Mini Gifts Distributions Ltd.', 'Nelson', 'Susan', '4155551450', '5677 Strong St.', NULL, 'San Rafael', 'USA', NULL, NULL, NULL, NULL, 210500.00),
(125, 'Havel & Zbyszek Co.', 'Piestrzeniewicz', 'Zbyszek', '(26) 642-7555', 'ul. Filtrowa 68', NULL, 'Warszawa', 'Poland', NULL, NULL, NULL, NULL, 0.00),
(128, 'Blauer See Auto, Co.', 'Keitel', 'Roland', '+49 69 66 90 2555', 'Lyonerstr. 34', NULL, 'Frankfurt', 'Germany', NULL, NULL, NULL, NULL, 59700.00),
(129, 'Mini Wheels Co.', 'Murphy', 'Julie', '6505555787', '5557 North Line Rd.', NULL, 'South San Francisco', 'USA', NULL, NULL, NULL, NULL, 64600.00),
(131, 'Land of Toys Inc.', 'Lee', 'Kwai', '2125557818', '897 Long Airport Avenue', NULL, 'NYC', 'USA', NULL, NULL, NULL, NULL, 114900.00),
(141, 'Euro+ Shopping Channel', 'Freyre', 'Diego', '(91) 555 94 44', 'C/ Moralzarzal, 86', NULL, 'Madrid', 'Spain', NULL, NULL, NULL, NULL, 227600.00),
(144, 'Volvo Model Replicas, Co.', 'Berglund', 'Christina', '0921-12 3555', 'Berguvsvägen 8', NULL, 'Luleå', 'Sweden', NULL, NULL, NULL, NULL, 53100.00),
(145, 'Danish Wholesale Imports', 'Petersen', 'Jytte', '31 12 3555', 'Vinbæltet 34', NULL, 'København', 'Denmark', NULL, NULL, NULL, NULL, 83400.00),
(146, 'Saveley & Henriot Co.', 'Saveley', 'Mary', '78.32.5555', '2, rue du Commerce', NULL, 'Lyon', 'France', NULL, NULL, NULL, NULL, 123900.00),
(148, 'Dragon Souvenirs, Ltd.', 'Natividad', 'Eric', '+65 221 7555', 'Bronzini St.', NULL, 'Singapore', 'Singapore', NULL, NULL, NULL, NULL, 103800.00);
UNLOCK TABLES;



-- ============================================================================
-- 3. CREATE SUPPLIERS TABLE
-- ============================================================================
CREATE TABLE `suppliers` (
  `supplierID` int(11) NOT NULL AUTO_INCREMENT,
  `supplierName` varchar(100) NOT NULL,
  `contactName` varchar(50) NOT NULL,
  `phone` varchar(30) NOT NULL,
  `address` varchar(150) NOT NULL,
  PRIMARY KEY (`supplierID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `suppliers` (`supplierName`, `contactName`, `phone`, `address`) VALUES
('Timberland Lumber Co.', 'John Smith', '+852 2345 6789', 'Kwai Chung Industrial Bldg, HK'),
('Steel & Iron Components Ltd.', 'Mark Davis', '+852 3456 7890', 'Tsuen Wan Industrial Center, HK'),
('Foam & Fabrics Wholesale', 'Sarah Jenkins', '+852 4567 8901', 'Kwun Tong Fabric Center, HK'),
('Hardware Fasteners Corp.', 'Peter Parker', '+852 5678 9012', 'Shatin Enterprise Hub, HK'),
('Eco-Plastics & Veneers', 'Lisa Wong', '+852 6789 0123', 'Fanling Plastics Zone, HK');

-- ============================================================================
-- 4. SYSTEM SECURITY & CONTROL (User Credentials) - 🌟已修复反引号与外键类型错误
-- ============================================================================
CREATE TABLE IF NOT EXISTS `user_accounts` (
  `username` varchar(50) NOT NULL,
  `passwordHash` varchar(255) NOT NULL,
  `staffID` varchar(10) DEFAULT NULL,
  `customerID` int(11) DEFAULT NULL, -- 🌟 修复：补全反引号并将类型改成 int(11) 以对齐客户表主键
  `accessLevel` varchar(20) NOT NULL,
  PRIMARY KEY (`username`),
  CONSTRAINT `fk_user_staff` FOREIGN KEY (`staffID`) REFERENCES `staff` (`staffID`) ON DELETE CASCADE,
  CONSTRAINT `fk_user_customer` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerNumber`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `user_accounts` (`username`, `passwordHash`, `staffID`, `customerID`, `accessLevel`) VALUES
('admin', 'admin123', 'STF001', NULL, 'Admin'),
('sales01', 'sales123', 'STF002', NULL, 'Sales'),
('warehouse01', 'wh123', 'STF003', NULL, 'Warehouse'),
('buyer01', 'buy123', 'STF004', NULL, 'Procurement'),
('logistics01', 'log123', 'STF005', NULL, 'Logistics'),
('prod01', 'prod123', 'STF006', NULL, 'Production'),
('service01', 'svc123', 'STF007', NULL, 'After-Service'),
('sales02', 'sales456', 'STF008', NULL, 'Sales'),        -- 🌟 新增员工行
('customer103', 'cust123', NULL, 103, 'Customer');       -- 🌟 新增客户行

-- ============================================================================
-- 5. INVENTORY CONTROL & RAW MATERIAL MANAGEMENT
-- ============================================================================
CREATE TABLE `inventory` (
  `itemID` varchar(10) NOT NULL,
  `itemName` varchar(100) NOT NULL,
  `itemType` enum('Finished Goods','Raw Material') NOT NULL,
  `quantityInStock` int(11) NOT NULL DEFAULT 0,
  `unit` varchar(20) NOT NULL,
  `location` varchar(50) NOT NULL,
  PRIMARY KEY (`itemID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `inventory` (`itemID`, `itemName`, `itemType`, `quantityInStock`, `unit`, `location`) VALUES
('RM001', 'Oak Wood Planks', 'Raw Material', 450, 'pcs', 'Aisle A1'),
('RM002', 'Steel Frame Supports', 'Raw Material', 180, 'pcs', 'Aisle B3'),
('RM003', 'High-Density Foam Block', 'Raw Material', 95, 'pcs', 'Aisle C2'),
('RM004', 'Leather Fabric Roll (Black)', 'Raw Material', 25, 'rolls', 'Aisle D1'),
('RM005', 'M8 Assembly Screws', 'Raw Material', 5000, 'units', 'Bin 12'),
('FG001', 'Ergonomic Office Chair', 'Finished Goods', 45, 'units', 'Zone Alpha'),
('FG002', 'Mahogany Dining Table', 'Finished Goods', 12, 'units', 'Zone Beta'),
('FG003', '3-Seater Velvet Sofa', 'Finished Goods', 8, 'units', 'Zone Gamma'),
('FG004', 'Minimalist Study Desk', 'Finished Goods', 30, 'units', 'Zone Alpha'),
('FG005', 'Modular Bookcase Rack', 'Finished Goods', 15, 'units', 'Zone Beta');

-- ============================================================================
-- 6. ORDER PROCESSING MANAGEMENT
-- ============================================================================
CREATE TABLE `orders` (
  `orderNumber` int(11) NOT NULL AUTO_INCREMENT,
  `orderDate` date NOT NULL,
  `customerNumber` int(11) NOT NULL,
  `totalAmount` double NOT NULL,
  `orderStatus` enum('Pending','Processing','Shipped','Cancelled') NOT NULL DEFAULT 'Pending',
  PRIMARY KEY (`orderNumber`),
  KEY `idx_customerNumber` (`customerNumber`),
  CONSTRAINT `fk_orders_customer` FOREIGN KEY (`customerNumber`) REFERENCES `customer` (`customerNumber`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1001 DEFAULT CHARSET=latin1;

LOCK TABLES `orders` WRITE;
INSERT INTO `orders` (`orderNumber`, `orderDate`, `customerNumber`, `totalAmount`, `orderStatus`) VALUES
(1001, '2026-06-01', 103, 4500.00, 'Shipped'),
(1002, '2026-06-05', 112, 1250.00, 'Processing'),
(1003, '2026-06-10', 114, 8900.00, 'Pending'),
(1004, '2026-06-12', 119, 3200.00, 'Processing'),
(1005, '2026-06-14', 121, 15000.00, 'Pending'),
(1006, '2026-06-15', 124, 600.00, 'Cancelled'),
(1007, '2026-06-15', 125, 2450.00, 'Pending'),
(1008, '2026-06-16', 103, 3100.00, 'Pending');
UNLOCK TABLES;

-- Order Details
CREATE TABLE `order_details` (
  `orderNumber` int(11) NOT NULL,
  `itemID` varchar(10) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unitPrice` double NOT NULL,
  PRIMARY KEY (`orderNumber`,`itemID`),
  KEY `idx_order_item` (`itemID`),
  CONSTRAINT `fk_details_order` FOREIGN KEY (`orderNumber`) REFERENCES `orders` (`orderNumber`) ON DELETE CASCADE,
  CONSTRAINT `fk_details_inventory` FOREIGN KEY (`itemID`) REFERENCES `inventory` (`itemID`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

LOCK TABLES `order_details` WRITE;
INSERT INTO `order_details` (`orderNumber`, `itemID`, `quantity`, `unitPrice`) VALUES
(1001, 'FG001', 3, 1500.00),
(1002, 'FG004', 1, 1250.00),
(1003, 'FG003', 2, 4450.00),
(1004, 'FG005', 2, 1600.00),
(1005, 'FG002', 3, 5000.00),
(1006, 'FG001', 1, 600.00),
(1007, 'FG001', 1, 1500.00),
(1007, 'FG004', 1, 950.00),
(1008, 'FG005', 2, 1550.00);
UNLOCK TABLES;

-- ============================================================================
-- 7. PRODUCTION PROCESSING MANAGEMENT
-- ============================================================================
CREATE TABLE `production_requests` (
  `requestID` int(11) NOT NULL AUTO_INCREMENT,
  `requestDate` date NOT NULL,
  `targetItemID` varchar(10) NOT NULL,
  `rawMaterialID` varchar(10) NOT NULL,
  `quantityRequested` int(11) NOT NULL,
  `status` enum('Allocated','Fulfilled','Shortage') NOT NULL DEFAULT 'Allocated',
  PRIMARY KEY (`requestID`),
  KEY `idx_targetItem` (`targetItemID`),
  KEY `idx_rawMaterial` (`rawMaterialID`),
  CONSTRAINT `fk_prod_target` FOREIGN KEY (`targetItemID`) REFERENCES `inventory` (`itemID`),
  CONSTRAINT `fk_prod_material` FOREIGN KEY (`rawMaterialID`) REFERENCES `inventory` (`itemID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `production_requests` (`requestID`, `requestDate`, `targetItemID`, `rawMaterialID`, `quantityRequested`, `status`) VALUES
(1, '2026-06-02', 'FG001', 'RM002', 20, 'Fulfilled'),
(2, '2026-06-06', 'FG001', 'RM003', 15, 'Fulfilled'),
(3, '2026-06-11', 'FG003', 'RM004', 5, 'Allocated'),
(4, '2026-06-14', 'FG002', 'RM001', 40, 'Allocated'),
(5, '2026-06-16', 'FG004', 'RM001', 100, 'Shortage'),
(6, '2026-06-16', 'FG005', 'RM001', 30, 'Allocated');

-- ============================================================================
-- 8. RAW MATERIAL PROCUREMENT MANAGEMENT
-- ============================================================================
CREATE TABLE `procurements` (
  `procurementID` int(11) NOT NULL AUTO_INCREMENT,
  `orderDate` date NOT NULL,
  `supplierID` int(11) NOT NULL,
  `rawMaterialID` varchar(10) NOT NULL,
  `quantityOrdered` int(11) NOT NULL,
  `expectedDelivery` date NOT NULL,
  `status` enum('Ordered','In-Transit','Delivered') NOT NULL DEFAULT 'Ordered',
  PRIMARY KEY (`procurementID`),
  KEY `idx_proc_supplier` (`supplierID`),
  KEY `idx_proc_material` (`rawMaterialID`),
  CONSTRAINT `fk_proc_supplier` FOREIGN KEY (`supplierID`) REFERENCES `suppliers` (`supplierID`),
  CONSTRAINT `fk_proc_material` FOREIGN KEY (`rawMaterialID`) REFERENCES `inventory` (`itemID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `procurements` (`procurementID`, `orderDate`, `supplierID`, `rawMaterialID`, `quantityOrdered`, `expectedDelivery`, `status`) VALUES
(1, '2026-05-20', 1, 'RM001', 200, '2026-06-01', 'Delivered'),
(2, '2026-06-01', 2, 'RM002', 50, '2026-06-10', 'Delivered'),
(3, '2026-06-10', 3, 'RM004', 15, '2026-06-20', 'In-Transit'),
(4, '2026-06-15', 4, 'RM005', 2000, '2026-06-19', 'Ordered'),
(5, '2026-06-16', 1, 'RM001', 500, '2026-06-25', 'Ordered');

-- ============================================================================
-- 9. LOGISTICS PROCESSING
-- ============================================================================
CREATE TABLE `logistics_shipments` (
  `deliveryNoteID` int(11) NOT NULL AUTO_INCREMENT,
  `orderNumber` int(11) NOT NULL,
  `dispatchDate` date NOT NULL,
  `deliveryAddress` varchar(150) NOT NULL,
  `driverName` varchar(50) NOT NULL,
  `replySlipReceived` enum('Yes','No') NOT NULL DEFAULT 'No',
  `conditionReport` varchar(100) DEFAULT 'Good Condition',
  PRIMARY KEY (`deliveryNoteID`),
  KEY `idx_log_order` (`orderNumber`),
  CONSTRAINT `fk_log_order` FOREIGN KEY (`orderNumber`) REFERENCES `orders` (`orderNumber`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `logistics_shipments` (`deliveryNoteID`, `orderNumber`, `dispatchDate`, `deliveryAddress`, `driverName`, `replySlipReceived`, `conditionReport`) VALUES
(1, 1001, '2026-06-03', '54, rue Royale, Paris', 'Michael Chang', 'Yes', 'Signed - Perfect Condition'),
(2, 1002, '2026-06-08', '8489 Strong St., Tokyo', 'David Lau', 'Yes', 'Signed - Box damaged but item intact'),
(3, 1004, '2026-06-15', '67, rue des Cinquante, Paris', 'Michael Chang', 'No', 'Pending Delivery Tracking');

-- ============================================================================
-- 10. AFTER-SERVICE MANAGEMENT
-- ============================================================================
CREATE TABLE `after_service_records` (
  `caseID` int(11) NOT NULL AUTO_INCREMENT,
  `orderNumber` int(11) NOT NULL,
  `requestDate` date NOT NULL,
  `requestType` enum('Return','Replacement','Refund','Repair') NOT NULL,
  `reason` text NOT NULL,
  `resolutionStatus` enum('Open','Approved','Rejected','Closed') NOT NULL DEFAULT 'Open',
  PRIMARY KEY (`caseID`),
  KEY `idx_service_order` (`orderNumber`),
  CONSTRAINT `fk_service_order` FOREIGN KEY (`orderNumber`) REFERENCES `orders` (`orderNumber`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
  
INSERT INTO `after_service_records` (`caseID`, `orderNumber`, `requestDate`, `requestType`, `reason`, `resolutionStatus`) VALUES
(1, 1001, '2026-06-05', 'Repair', 'Slight loose threading on office chair armrest cushion padding', 'Closed'),
(2, 1002, '2026-06-11', 'Replacement', 'Received correct frame layout style but table color tone too dark', 'Approved'),
(3, 1001, '2026-06-16', 'Refund', 'Accidental duplicate charge encountered during automated billing sync', 'Open');
  
COMMIT;