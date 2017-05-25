-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema pcs
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Table `customer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `customer` (
  `KODE_CUST` INT NOT NULL,
  `NAMA_CUST` VARCHAR(50) NOT NULL,
  `ALAMAT_CUST` VARCHAR(50) NOT NULL,
  `TELP_CUST` VARCHAR(12) NULL,
  `EMAIL_CUST` VARCHAR(45) NULL,
  PRIMARY KEY (`KODE_CUST`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `kamar`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `kamar` (
  `KODE_KAMAR` INT NOT NULL,
  `TIPE_KAMAR` VARCHAR(20) NOT NULL,
  `CATATAN` VARCHAR(45) NULL,
  `HARGA_KAMAR` INT NOT NULL,
  PRIMARY KEY (`KODE_KAMAR`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `hotel_hjual`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hotel_hjual` (
  `NOTA_HOTEL` INT NOT NULL,
  `KODE_CUST` INT NOT NULL,
  PRIMARY KEY (`NOTA_HOTEL`, `KODE_CUST`),
  INDEX `FK_KODE_CUST_HOTEL` (`KODE_CUST` ASC),
  CONSTRAINT `FK_KODE_CUST_HOTEL`
    FOREIGN KEY (`KODE_CUST`)
    REFERENCES `customer` (`KODE_CUST`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `hotel_djual`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `hotel_djual` (
  `NOTA_HOTEL` INT NOT NULL,
  `KODE_KAMAR` INT NOT NULL,
  `TGL_IN` DATE NOT NULL,
  `TGL_OUT` DATE NOT NULL,
  INDEX `FK_NOTA_HOTEL` (`NOTA_HOTEL` ASC),
  INDEX `FK_KODE_KAMAR` (`KODE_KAMAR` ASC),
  PRIMARY KEY (`NOTA_HOTEL`),
  CONSTRAINT `FK_KODE_KAMAR`
    FOREIGN KEY (`KODE_KAMAR`)
    REFERENCES `kamar` (`KODE_KAMAR`),
  CONSTRAINT `FK_NOTA_HOTEL`
    FOREIGN KEY (`NOTA_HOTEL`)
    REFERENCES `hotel_hjual` (`NOTA_HOTEL`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `laundry_jenis`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `laundry_jenis` (
  `KODE_LAUNDRY` INT NOT NULL,
  `JENIS_LAUNDRY` VARCHAR(20) NOT NULL,
  `HARGA_LAUNDRY` INT NOT NULL,
  PRIMARY KEY (`KODE_LAUNDRY`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `laundry_hjual`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `laundry_hjual` (
  `NOTA_LAUNDRY` INT NOT NULL,
  `TGL_LAUNDRY` DATE NOT NULL,
  `KODE_KAMAR` INT NOT NULL,
  PRIMARY KEY (`NOTA_LAUNDRY`),
  INDEX `fk_laundry_hjual_kamar1_idx` (`KODE_KAMAR` ASC),
  CONSTRAINT `fk_laundry_hjual_kamar1`
    FOREIGN KEY (`KODE_KAMAR`)
    REFERENCES `kamar` (`KODE_KAMAR`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `laundry_djual`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `laundry_djual` (
  `NOTA_LAUNDRY` INT NOT NULL,
  `KODE_LAUNDRY` INT NOT NULL,
  `BERAT_LAUNDRY` INT NOT NULL,
  INDEX `FK_NOTA_LAUNDRY` (`NOTA_LAUNDRY` ASC),
  INDEX `FK_KODE_LAUNDRY` (`KODE_LAUNDRY` ASC),
  CONSTRAINT `FK_KODE_LAUNDRY`
    FOREIGN KEY (`KODE_LAUNDRY`)
    REFERENCES `laundry_jenis` (`KODE_LAUNDRY`),
  CONSTRAINT `FK_NOTA_LAUNDRY`
    FOREIGN KEY (`NOTA_LAUNDRY`)
    REFERENCES `laundry_hjual` (`NOTA_LAUNDRY`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `pegawai_divisi`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `pegawai_divisi` (
  `KODE_DIVISI` INT NOT NULL,
  `NAMA_DIVISI` VARCHAR(20) NOT NULL,
  `GAJI_DIVISI` INT NOT NULL,
  PRIMARY KEY (`KODE_DIVISI`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `pegawai`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `pegawai` (
  `KODE_PEG` INT NOT NULL,
  `KODE_DIVISI` INT NOT NULL,
  `NAMA_PEG` VARCHAR(50) NOT NULL,
  `USERNAME` VARCHAR(45) NOT NULL,
  `PASSWORD` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`KODE_PEG`),
  INDEX `FK_KODE_DIVISI` (`KODE_DIVISI` ASC),
  CONSTRAINT `FK_KODE_DIVISI`
    FOREIGN KEY (`KODE_DIVISI`)
    REFERENCES `pegawai_divisi` (`KODE_DIVISI`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `penggajian`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `penggajian` (
  `KODE_GAJI` INT NOT NULL,
  `KODE_PEG` INT NOT NULL,
  `TGL_GAJI` DATE NOT NULL,
  `JUM_GAJI` INT NOT NULL,
  INDEX `fk_penggajian_pegawai1_idx` (`KODE_PEG` ASC),
  PRIMARY KEY (`KODE_GAJI`, `KODE_PEG`),
  CONSTRAINT `fk_penggajian_pegawai1`
    FOREIGN KEY (`KODE_PEG`)
    REFERENCES `pegawai` (`KODE_PEG`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `restoran_menu`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restoran_menu` (
  `KODE_MENU` INT NOT NULL,
  `JENIS_MENU` VARCHAR(10) NOT NULL,
  `NAMA_MENU` VARCHAR(20) NOT NULL,
  `HARGA_MENU` INT NOT NULL,
  `SOLDOUT` TINYINT(1) NOT NULL,
  PRIMARY KEY (`KODE_MENU`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `restoran_hjual`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restoran_hjual` (
  `NOTA_RESTO` INT NOT NULL,
  `TGL_RESTO` DATETIME NOT NULL,
  `KODE_KAMAR` INT NULL,
  `MEJA` INT NULL,
  PRIMARY KEY (`NOTA_RESTO`),
  INDEX `fk_restoran_hjual_kamar1_idx` (`KODE_KAMAR` ASC),
  CONSTRAINT `fk_restoran_hjual_kamar1`
    FOREIGN KEY (`KODE_KAMAR`)
    REFERENCES `kamar` (`KODE_KAMAR`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `restoran_djual`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `restoran_djual` (
  `NOTA_RESTO` INT NOT NULL,
  `KODE_MENU` INT NOT NULL,
  `QUANTITY` INT NOT NULL,
  `SELESAI` TINYINT(1) NOT NULL,
  INDEX `FK_NOTA_RESTO` (`NOTA_RESTO` ASC),
  INDEX `FK_KODE_MAKANAN` (`KODE_MENU` ASC),
  PRIMARY KEY (`NOTA_RESTO`, `KODE_MENU`),
  CONSTRAINT `FK_KODE_MAKANAN`
    FOREIGN KEY (`KODE_MENU`)
    REFERENCES `restoran_menu` (`KODE_MENU`),
  CONSTRAINT `FK_NOTA_RESTO`
    FOREIGN KEY (`NOTA_RESTO`)
    REFERENCES `restoran_hjual` (`NOTA_RESTO`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `pelamar`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `pelamar` (
  `KODE_PELAMAR` INT NOT NULL,
  `NAMA` VARCHAR(45) NOT NULL,
  `KOTALAHIR` VARCHAR(45) NOT NULL,
  `TGLLAHIR_PELAMAR` DATE NOT NULL,
  `JK_PELAMAR` TINYINT(1) NOT NULL,
  `AGAMA_PELAMAR` VARCHAR(45) NOT NULL,
  `WNI_PELAMAR` TINYINT(1) NOT NULL,
  `MENIKAH_PELAMAR` TINYINT(1) NOT NULL,
  `PENDIDIKAN_PELAMAR` VARCHAR(45) NOT NULL,
  `ALAMAT_PELAMAR` VARCHAR(45) NOT NULL,
  `TELEPON_PELAMAR` INT NOT NULL,
  `EMAIL_PELAMAR` VARCHAR(45) NOT NULL,
  `KODE_DIVISI` INT NOT NULL,
  PRIMARY KEY (`KODE_PELAMAR`),
  INDEX `fk_pelamar_pegawai_divisi1_idx` (`KODE_DIVISI` ASC),
  CONSTRAINT `fk_pelamar_pegawai_divisi1`
    FOREIGN KEY (`KODE_DIVISI`)
    REFERENCES `pegawai_divisi` (`KODE_DIVISI`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `message`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `message` (
  `KODE_MESSAGE` INT NOT NULL,
  `KIRIM_KODE_DIVISI` INT NOT NULL,
  `TEIRMA_KODE_DIVISI` INT NOT NULL,
  `WAKTU` DATETIME NULL,
  `PESAN` VARCHAR(45) NULL,
  PRIMARY KEY (`KODE_MESSAGE`),
  INDEX `fk_message_pegawai_divisi1_idx` (`KIRIM_KODE_DIVISI` ASC),
  INDEX `fk_message_pegawai_divisi2_idx` (`TEIRMA_KODE_DIVISI` ASC),
  CONSTRAINT `fk_message_pegawai_divisi1`
    FOREIGN KEY (`KIRIM_KODE_DIVISI`)
    REFERENCES `pegawai_divisi` (`KODE_DIVISI`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_message_pegawai_divisi2`
    FOREIGN KEY (`TEIRMA_KODE_DIVISI`)
    REFERENCES `pegawai_divisi` (`KODE_DIVISI`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `customer`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `customer` (`KODE_CUST`, `NAMA_CUST`, `ALAMAT_CUST`, `TELP_CUST`, `EMAIL_CUST`) VALUES (1, 'Customer 1', 'Alamat 1', '12345789', 'email@email.com');
INSERT INTO `customer` (`KODE_CUST`, `NAMA_CUST`, `ALAMAT_CUST`, `TELP_CUST`, `EMAIL_CUST`) VALUES (2, 'Customer 2', 'Alamat 2', '9856541235', 'email@asdf.com');
INSERT INTO `customer` (`KODE_CUST`, `NAMA_CUST`, `ALAMAT_CUST`, `TELP_CUST`, `EMAIL_CUST`) VALUES (3, 'Customer 3', 'Alamat 3', '154982154', 'email@fdsa.com');

COMMIT;


-- -----------------------------------------------------
-- Data for table `kamar`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `kamar` (`KODE_KAMAR`, `TIPE_KAMAR`, `CATATAN`, `HARGA_KAMAR`) VALUES (101, 'Standart', 'Banyak Kecoak', 300000);
INSERT INTO `kamar` (`KODE_KAMAR`, `TIPE_KAMAR`, `CATATAN`, `HARGA_KAMAR`) VALUES (102, 'Standart', NULL, 400000);
INSERT INTO `kamar` (`KODE_KAMAR`, `TIPE_KAMAR`, `CATATAN`, `HARGA_KAMAR`) VALUES (103, 'Standart', 'Hujan Bocor', 250000);
INSERT INTO `kamar` (`KODE_KAMAR`, `TIPE_KAMAR`, `CATATAN`, `HARGA_KAMAR`) VALUES (104, 'Standart', NULL, 375000);
INSERT INTO `kamar` (`KODE_KAMAR`, `TIPE_KAMAR`, `CATATAN`, `HARGA_KAMAR`) VALUES (105, 'Standart', NULL, 360000);
INSERT INTO `kamar` (`KODE_KAMAR`, `TIPE_KAMAR`, `CATATAN`, `HARGA_KAMAR`) VALUES (201, 'Triple', NULL, 500000);
INSERT INTO `kamar` (`KODE_KAMAR`, `TIPE_KAMAR`, `CATATAN`, `HARGA_KAMAR`) VALUES (202, 'Triple', NULL, 550000);
INSERT INTO `kamar` (`KODE_KAMAR`, `TIPE_KAMAR`, `CATATAN`, `HARGA_KAMAR`) VALUES (203, 'Triple', NULL, 570000);
INSERT INTO `kamar` (`KODE_KAMAR`, `TIPE_KAMAR`, `CATATAN`, `HARGA_KAMAR`) VALUES (204, 'Suite', NULL, 800000);

COMMIT;


-- -----------------------------------------------------
-- Data for table `hotel_hjual`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `hotel_hjual` (`NOTA_HOTEL`, `KODE_CUST`) VALUES (1, 1);
INSERT INTO `hotel_hjual` (`NOTA_HOTEL`, `KODE_CUST`) VALUES (2, 1);
INSERT INTO `hotel_hjual` (`NOTA_HOTEL`, `KODE_CUST`) VALUES (3, 2);
INSERT INTO `hotel_hjual` (`NOTA_HOTEL`, `KODE_CUST`) VALUES (4, 3);

COMMIT;


-- -----------------------------------------------------
-- Data for table `hotel_djual`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `hotel_djual` (`NOTA_HOTEL`, `KODE_KAMAR`, `TGL_IN`, `TGL_OUT`) VALUES (1, 101, '2017-05-15', '2017-05-20');
INSERT INTO `hotel_djual` (`NOTA_HOTEL`, `KODE_KAMAR`, `TGL_IN`, `TGL_OUT`) VALUES (2, 101, '2017-05-20', '2017-05-22');
INSERT INTO `hotel_djual` (`NOTA_HOTEL`, `KODE_KAMAR`, `TGL_IN`, `TGL_OUT`) VALUES (3, 103, '2017-05-12', '2017-05-13');
INSERT INTO `hotel_djual` (`NOTA_HOTEL`, `KODE_KAMAR`, `TGL_IN`, `TGL_OUT`) VALUES (4, 104, '2017-05-11', '2017-05-13');

COMMIT;


-- -----------------------------------------------------
-- Data for table `laundry_jenis`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `laundry_jenis` (`KODE_LAUNDRY`, `JENIS_LAUNDRY`, `HARGA_LAUNDRY`) VALUES (1, 'Cuci Basah', 5000);
INSERT INTO `laundry_jenis` (`KODE_LAUNDRY`, `JENIS_LAUNDRY`, `HARGA_LAUNDRY`) VALUES (2, 'Cuci Kering', 9000);
INSERT INTO `laundry_jenis` (`KODE_LAUNDRY`, `JENIS_LAUNDRY`, `HARGA_LAUNDRY`) VALUES (3, 'Setrika', 15000);

COMMIT;


-- -----------------------------------------------------
-- Data for table `laundry_hjual`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `laundry_hjual` (`NOTA_LAUNDRY`, `TGL_LAUNDRY`, `KODE_KAMAR`) VALUES (1, '2017-05-20', 101);
INSERT INTO `laundry_hjual` (`NOTA_LAUNDRY`, `TGL_LAUNDRY`, `KODE_KAMAR`) VALUES (2, '2017-05-20', 102);

COMMIT;


-- -----------------------------------------------------
-- Data for table `laundry_djual`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `laundry_djual` (`NOTA_LAUNDRY`, `KODE_LAUNDRY`, `BERAT_LAUNDRY`) VALUES (1, 1, 5);
INSERT INTO `laundry_djual` (`NOTA_LAUNDRY`, `KODE_LAUNDRY`, `BERAT_LAUNDRY`) VALUES (1, 2, 4);
INSERT INTO `laundry_djual` (`NOTA_LAUNDRY`, `KODE_LAUNDRY`, `BERAT_LAUNDRY`) VALUES (1, 3, 9);
INSERT INTO `laundry_djual` (`NOTA_LAUNDRY`, `KODE_LAUNDRY`, `BERAT_LAUNDRY`) VALUES (2, 2, 5);
INSERT INTO `laundry_djual` (`NOTA_LAUNDRY`, `KODE_LAUNDRY`, `BERAT_LAUNDRY`) VALUES (2, 3, 8);

COMMIT;


-- -----------------------------------------------------
-- Data for table `pegawai_divisi`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `pegawai_divisi` (`KODE_DIVISI`, `NAMA_DIVISI`, `GAJI_DIVISI`) VALUES (1, 'Receptionist', 500000);
INSERT INTO `pegawai_divisi` (`KODE_DIVISI`, `NAMA_DIVISI`, `GAJI_DIVISI`) VALUES (2, 'Restoran', 600000);
INSERT INTO `pegawai_divisi` (`KODE_DIVISI`, `NAMA_DIVISI`, `GAJI_DIVISI`) VALUES (3, 'Dapur', 400000);
INSERT INTO `pegawai_divisi` (`KODE_DIVISI`, `NAMA_DIVISI`, `GAJI_DIVISI`) VALUES (4, 'Laundry', 300000);
INSERT INTO `pegawai_divisi` (`KODE_DIVISI`, `NAMA_DIVISI`, `GAJI_DIVISI`) VALUES (5, 'HRD', 900000);

COMMIT;


-- -----------------------------------------------------
-- Data for table `pegawai`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `pegawai` (`KODE_PEG`, `KODE_DIVISI`, `NAMA_PEG`, `USERNAME`, `PASSWORD`) VALUES (1, 1, 'Tukang Receptionist 1', 'receptionist1', 'pass');
INSERT INTO `pegawai` (`KODE_PEG`, `KODE_DIVISI`, `NAMA_PEG`, `USERNAME`, `PASSWORD`) VALUES (2, 1, 'Tukang Receptionist 2', 'receptionist2', 'pass');
INSERT INTO `pegawai` (`KODE_PEG`, `KODE_DIVISI`, `NAMA_PEG`, `USERNAME`, `PASSWORD`) VALUES (3, 2, 'Tukang Restoran 1', 'restoran1', 'pass');
INSERT INTO `pegawai` (`KODE_PEG`, `KODE_DIVISI`, `NAMA_PEG`, `USERNAME`, `PASSWORD`) VALUES (4, 2, 'Tukang Restoran 2', 'restoran2', 'pass');
INSERT INTO `pegawai` (`KODE_PEG`, `KODE_DIVISI`, `NAMA_PEG`, `USERNAME`, `PASSWORD`) VALUES (5, 3, 'Tukang Dapur 1', 'dapur1', 'pass');
INSERT INTO `pegawai` (`KODE_PEG`, `KODE_DIVISI`, `NAMA_PEG`, `USERNAME`, `PASSWORD`) VALUES (6, 3, 'Tukang Dapur 2', 'dapur2', 'pass');
INSERT INTO `pegawai` (`KODE_PEG`, `KODE_DIVISI`, `NAMA_PEG`, `USERNAME`, `PASSWORD`) VALUES (7, 4, 'Tukang Laundry 1', 'laundry1', 'pass');
INSERT INTO `pegawai` (`KODE_PEG`, `KODE_DIVISI`, `NAMA_PEG`, `USERNAME`, `PASSWORD`) VALUES (8, 4, 'Tukang Laundry 2', 'laundry2', 'pass');
INSERT INTO `pegawai` (`KODE_PEG`, `KODE_DIVISI`, `NAMA_PEG`, `USERNAME`, `PASSWORD`) VALUES (9, 5, 'Tukang HRD 1', 'hrd1', 'pass');
INSERT INTO `pegawai` (`KODE_PEG`, `KODE_DIVISI`, `NAMA_PEG`, `USERNAME`, `PASSWORD`) VALUES (10, 5, 'Tukang HRD 2', 'hrd2', 'pass');

COMMIT;


-- -----------------------------------------------------
-- Data for table `penggajian`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `penggajian` (`KODE_GAJI`, `KODE_PEG`, `TGL_GAJI`, `JUM_GAJI`) VALUES (1, 1, '2017-05-20', 60000);
INSERT INTO `penggajian` (`KODE_GAJI`, `KODE_PEG`, `TGL_GAJI`, `JUM_GAJI`) VALUES (2, 2, '2017-05-20', 40000);

COMMIT;


-- -----------------------------------------------------
-- Data for table `restoran_menu`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `restoran_menu` (`KODE_MENU`, `JENIS_MENU`, `NAMA_MENU`, `HARGA_MENU`, `SOLDOUT`) VALUES (1, 'Makanan', 'Makanan 1', 60000, 0);
INSERT INTO `restoran_menu` (`KODE_MENU`, `JENIS_MENU`, `NAMA_MENU`, `HARGA_MENU`, `SOLDOUT`) VALUES (2, 'Makanan', 'Makanan 2', 40000, 0);
INSERT INTO `restoran_menu` (`KODE_MENU`, `JENIS_MENU`, `NAMA_MENU`, `HARGA_MENU`, `SOLDOUT`) VALUES (3, 'Makanan', 'Makanan 3', 90000, 1);
INSERT INTO `restoran_menu` (`KODE_MENU`, `JENIS_MENU`, `NAMA_MENU`, `HARGA_MENU`, `SOLDOUT`) VALUES (4, 'Minuman', 'Minuman 1', 40000, 0);
INSERT INTO `restoran_menu` (`KODE_MENU`, `JENIS_MENU`, `NAMA_MENU`, `HARGA_MENU`, `SOLDOUT`) VALUES (5, 'Minuman', 'Minuman 2', 60000, 0);
INSERT INTO `restoran_menu` (`KODE_MENU`, `JENIS_MENU`, `NAMA_MENU`, `HARGA_MENU`, `SOLDOUT`) VALUES (6, 'Minuman', 'Minuman 3', 50000, 1);

COMMIT;


-- -----------------------------------------------------
-- Data for table `restoran_hjual`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `restoran_hjual` (`NOTA_RESTO`, `TGL_RESTO`, `KODE_KAMAR`, `MEJA`) VALUES (1, '2017-05-20', NULL, 1);
INSERT INTO `restoran_hjual` (`NOTA_RESTO`, `TGL_RESTO`, `KODE_KAMAR`, `MEJA`) VALUES (2, '2017-05-20', 101, NULL);

COMMIT;


-- -----------------------------------------------------
-- Data for table `restoran_djual`
-- -----------------------------------------------------
START TRANSACTION;
INSERT INTO `restoran_djual` (`NOTA_RESTO`, `KODE_MENU`, `QUANTITY`, `SELESAI`) VALUES (1, 1, 1, 1);
INSERT INTO `restoran_djual` (`NOTA_RESTO`, `KODE_MENU`, `QUANTITY`, `SELESAI`) VALUES (1, 2, 1, 1);
INSERT INTO `restoran_djual` (`NOTA_RESTO`, `KODE_MENU`, `QUANTITY`, `SELESAI`) VALUES (1, 5, 1, 1);
INSERT INTO `restoran_djual` (`NOTA_RESTO`, `KODE_MENU`, `QUANTITY`, `SELESAI`) VALUES (2, 1, 1, 0);
INSERT INTO `restoran_djual` (`NOTA_RESTO`, `KODE_MENU`, `QUANTITY`, `SELESAI`) VALUES (2, 5, 1, 0);
INSERT INTO `restoran_djual` (`NOTA_RESTO`, `KODE_MENU`, `QUANTITY`, `SELESAI`) VALUES (2, 4, 1, 0);

COMMIT;

