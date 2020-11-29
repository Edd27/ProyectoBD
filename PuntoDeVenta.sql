-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema PuntoDeVenta
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema PuntoDeVenta
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `PuntoDeVenta` DEFAULT CHARACTER SET utf8 ;
USE `PuntoDeVenta` ;

-- -----------------------------------------------------
-- Table `PuntoDeVenta`.`Usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PuntoDeVenta`.`Usuarios` (
  `IDusuario` INT NOT NULL AUTO_INCREMENT,
  `Login` VARCHAR(50) NOT NULL UNIQUE,
  `Nombre` VARCHAR(45) NOT NULL,
  `Apellidos` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NOT NULL,
  `Administrador` TINYINT NOT NULL,
  PRIMARY KEY (`IDusuario`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PuntoDeVenta`.`Inventario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PuntoDeVenta`.`Inventario` (
  `IDInventario` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(20) NOT NULL,
  `Descripcion` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IDInventario`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PuntoDeVenta`.`Producto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PuntoDeVenta`.`Producto` (
  `idProducto` INT NOT NULL,
  `Producto` VARCHAR(45) NOT NULL,
  `Descripcion` LONGTEXT NOT NULL,
  `Tipo` VARCHAR(45) NOT NULL,
  `Talla` CHAR(10) NOT NULL,
  `Precio` DOUBLE NOT NULL,
  `IDInventario` INT NOT NULL,
  PRIMARY KEY (`idProducto`),
  INDEX `fk_Producto_table1_idx` (`IDInventario` ASC),
  CONSTRAINT `fk_Producto_table1`
    FOREIGN KEY (`IDInventario`)
    REFERENCES `PuntoDeVenta`.`Inventario` (`IDInventario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PuntoDeVenta`.`Clientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PuntoDeVenta`.`Clientes` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NOT NULL,
  `Apellidos` VARCHAR(45) NOT NULL,
  `Numero_telefonico` CHAR(10) NOT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PuntoDeVenta`.`Ventas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PuntoDeVenta`.`Ventas` (
  `IDVenta` INT NOT NULL AUTO_INCREMENT,
  `Fecha` DATE NOT NULL,
  `Total` INT NOT NULL,
  `Usuarios_IDusuario` INT NOT NULL,
  `Clientes_ID` INT,
  PRIMARY KEY (`IDVenta`),
  INDEX `fk_table1_Usuarios1_idx` (`Usuarios_IDusuario` ASC),
  INDEX `fk_table1_Clientes1_idx` (`Clientes_ID` ASC),
  CONSTRAINT `fk_table1_Usuarios1`
    FOREIGN KEY (`Usuarios_IDusuario`)
    REFERENCES `PuntoDeVenta`.`Usuarios` (`IDusuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_table1_Clientes1`
    FOREIGN KEY (`Clientes_ID`)
    REFERENCES `PuntoDeVenta`.`Clientes` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `PuntoDeVenta`.`Reporte_de_Ventas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PuntoDeVenta`.`Reporte_de_Ventas` (
  `IDProducto` INT NOT NULL,
  `IDVenta` INT NOT NULL,
  `PrecioUnitario` DOUBLE NOT NULL,
  `Cantidad` INT NOT NULL,
  PRIMARY KEY (`IDProducto`, `IDVenta`),
  INDEX `fk_Producto_has_table1_table11_idx` (`IDVenta` ASC),
  INDEX `fk_Producto_has_table1_Producto1_idx` (`IDProducto` ASC),
  CONSTRAINT `fk_Producto_has_table1_Producto1`
    FOREIGN KEY (`IDProducto`)
    REFERENCES `PuntoDeVenta`.`Producto` (`idProducto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Producto_has_table1_table11`
    FOREIGN KEY (`IDVenta`)
    REFERENCES `PuntoDeVenta`.`Ventas` (`IDVenta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

INSERT INTO Usuarios(Login,Nombre,Apellidos,Password,Administrador) VALUES ('admin','Benito','Juárez',sha("root"),1);