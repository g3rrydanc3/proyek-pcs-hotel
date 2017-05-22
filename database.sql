DROP TABLE "MESSAGE" CASCADE CONSTRAINTS;
DROP TABLE "CUSTOMER" CASCADE CONSTRAINTS;
DROP TABLE "KAMAR" CASCADE CONSTRAINTS;
DROP TABLE "HOTEL_HJUAL" CASCADE CONSTRAINTS;
DROP TABLE "HOTEL_DJUAL" CASCADE CONSTRAINTS;
DROP TABLE "LAUNDRY_JENIS" CASCADE CONSTRAINTS;
DROP TABLE "LAUNDRY_HJUAL" CASCADE CONSTRAINTS;
DROP TABLE "LAUNDRY_DJUAL" CASCADE CONSTRAINTS;
DROP TABLE "PEGAWAI_DIVISI" CASCADE CONSTRAINTS;
DROP TABLE "PEGAWAI" CASCADE CONSTRAINTS;
DROP TABLE "PENGGAJIAN" CASCADE CONSTRAINTS;
DROP TABLE "RESTORAN_MENU" CASCADE CONSTRAINTS;
DROP TABLE "RESTORAN_HJUAL" CASCADE CONSTRAINTS;
DROP TABLE "RESTORAN_DJUAL" CASCADE CONSTRAINTS;
DROP TABLE "PELAMAR" CASCADE CONSTRAINTS;
purge recyclebin;

-- -----------------------------------------------------
-- Table `customer`
-- -----------------------------------------------------
CREATE TABLE customer (
  KODE_CUST NUMBER NOT NULL,
  NAMA_CUST VARCHAR2(50) NOT NULL,
  ALAMAT_CUST VARCHAR2(50) NOT NULL,
  TELP_CUST VARCHAR2(12) NULL,
  EMAIL_CUST VARCHAR2(45) NULL,
  PRIMARY KEY (KODE_CUST))
;

-- -----------------------------------------------------
-- Table `kamar`
-- -----------------------------------------------------
CREATE TABLE kamar (
  KODE_KAMAR NUMBER NOT NULL,
  TIPE_KAMAR VARCHAR2(20) NOT NULL,
  CATATAN VARCHAR2(45) NULL,
  HARGA_KAMAR NUMBER NOT NULL,
  PRIMARY KEY (KODE_KAMAR))
;

-- -----------------------------------------------------
-- Table `hotel_hjual`
-- -----------------------------------------------------
CREATE TABLE hotel_hjual (
  NOTA_HOTEL NUMBER NOT NULL,
  KODE_CUST NUMBER NOT NULL,
  PRIMARY KEY (NOTA_HOTEL)
 ,
  CONSTRAINT FK_KODE_CUST_HOTEL
    FOREIGN KEY (KODE_CUST)
    REFERENCES customer (KODE_CUST))
;

-- -----------------------------------------------------
-- Table `hotel_djual`
-- -----------------------------------------------------
CREATE TABLE hotel_djual (
  NOTA_HOTEL NUMBER NOT NULL,
  KODE_KAMAR NUMBER NOT NULL,
  TGL_IN DATE NOT NULL,
  TGL_OUT DATE NOT NULL
 ,
  PRIMARY KEY (NOTA_HOTEL, KODE_KAMAR),
  CONSTRAINT FK_KODE_KAMAR
    FOREIGN KEY (KODE_KAMAR)
    REFERENCES kamar (KODE_KAMAR),
  CONSTRAINT FK_NOTA_HOTEL
    FOREIGN KEY (NOTA_HOTEL)
    REFERENCES hotel_hjual (NOTA_HOTEL))
;

-- -----------------------------------------------------
-- Table `laundry_jenis`
-- -----------------------------------------------------
CREATE TABLE laundry_jenis (
  KODE_LAUNDRY NUMBER NOT NULL,
  JENIS_LAUNDRY VARCHAR2(20) NOT NULL,
  HARGA_LAUNDRY NUMBER NOT NULL,
  PRIMARY KEY (KODE_LAUNDRY))
;

-- -----------------------------------------------------
-- Table `laundry_hjual`
-- -----------------------------------------------------
CREATE TABLE laundry_hjual (
  NOTA_LAUNDRY NUMBER NOT NULL,
  TGL_LAUNDRY DATE NOT NULL,
  KODE_KAMAR NUMBER NOT NULL,
  PRIMARY KEY (NOTA_LAUNDRY)
 ,
  CONSTRAINT fk_laundry_hjual_kamar1
    FOREIGN KEY (KODE_KAMAR)
    REFERENCES kamar (KODE_KAMAR)
   )
;

-- -----------------------------------------------------
-- Table `laundry_djual`
-- -----------------------------------------------------
CREATE TABLE laundry_djual (
  NOTA_LAUNDRY NUMBER NOT NULL,
  KODE_LAUNDRY NUMBER NOT NULL,
  BERAT_LAUNDRY NUMBER NOT NULL
 ,
  CONSTRAINT FK_KODE_LAUNDRY
    FOREIGN KEY (KODE_LAUNDRY)
    REFERENCES laundry_jenis (KODE_LAUNDRY),
  CONSTRAINT FK_NOTA_LAUNDRY
    FOREIGN KEY (NOTA_LAUNDRY)
    REFERENCES laundry_hjual (NOTA_LAUNDRY))
;

-- -----------------------------------------------------
-- Table `pegawai_divisi`
-- -----------------------------------------------------
CREATE TABLE pegawai_divisi (
  KODE_DIVISI NUMBER NOT NULL,
  NAMA_DIVISI VARCHAR2(20) NOT NULL,
  GAJI_DIVISI NUMBER NOT NULL,
  PRIMARY KEY (KODE_DIVISI))
;

-- -----------------------------------------------------
-- Table `pegawai`
-- -----------------------------------------------------
CREATE TABLE pegawai (
  KODE_PEG NUMBER NOT NULL,
  KODE_DIVISI NUMBER NOT NULL,
  NAMA_PEG VARCHAR2(50) NOT NULL,
  USERNAME VARCHAR2(45) NOT NULL,
  PASSWORD VARCHAR2(45) NOT NULL,
  PRIMARY KEY (KODE_PEG)
 ,
  CONSTRAINT FK_KODE_DIVISI
    FOREIGN KEY (KODE_DIVISI)
    REFERENCES pegawai_divisi (KODE_DIVISI))
;

-- -----------------------------------------------------
-- Table `penggajian`
-- -----------------------------------------------------
CREATE TABLE penggajian (
  KODE_GAJI NUMBER NOT NULL,
  KODE_PEG NUMBER NOT NULL,
  TGL_GAJI DATE NOT NULL,
  JUM_GAJI NUMBER NOT NULL
 ,
  PRIMARY KEY (KODE_GAJI, KODE_PEG),
  CONSTRAINT fk_penggajian_pegawai1
    FOREIGN KEY (KODE_PEG)
    REFERENCES pegawai (KODE_PEG)
   )
;

-- -----------------------------------------------------
-- Table `restoran_menu`
-- -----------------------------------------------------
CREATE TABLE restoran_menu (
  KODE_MENU NUMBER NOT NULL,
  JENIS_MENU VARCHAR2(10) NOT NULL,
  NAMA_MENU VARCHAR2(20) NOT NULL,
  HARGA_MENU NUMBER NOT NULL,
  SOLDOUT NUMBER(3) NOT NULL,
  PRIMARY KEY (KODE_MENU))
;

-- -----------------------------------------------------
-- Table `restoran_hjual`
-- -----------------------------------------------------
CREATE TABLE restoran_hjual (
  NOTA_RESTO NUMBER NOT NULL,
  TGL_RESTO TIMESTAMP(0) NOT NULL,
  KODE_KAMAR NUMBER NULL,
  MEJA NUMBER NULL,
  PRIMARY KEY (NOTA_RESTO)
 ,
  CONSTRAINT fk_restoran_hjual_kamar1
    FOREIGN KEY (KODE_KAMAR)
    REFERENCES kamar (KODE_KAMAR)
   )
;

-- -----------------------------------------------------
-- Table `restoran_djual`
-- -----------------------------------------------------
CREATE TABLE restoran_djual (
  NOTA_RESTO NUMBER NOT NULL,
  KODE_MAKANAN NUMBER NOT NULL,
  HARGA NUMBER NOT NULL,
  SELESAI NUMBER(3) NOT NULL
 ,
  PRIMARY KEY (KODE_MAKANAN, NOTA_RESTO),
  CONSTRAINT FK_KODE_MAKANAN
    FOREIGN KEY (KODE_MAKANAN)
    REFERENCES restoran_menu (KODE_MENU),
  CONSTRAINT FK_NOTA_RESTO
    FOREIGN KEY (NOTA_RESTO)
    REFERENCES restoran_hjual (NOTA_RESTO))
;

-- -----------------------------------------------------
-- Table `pelamar`
-- -----------------------------------------------------
CREATE TABLE pelamar (
  KODE_PELAMAR NUMBER NOT NULL,
  NAMA VARCHAR2(45) NOT NULL,
  KOTALAHIR VARCHAR2(45) NOT NULL,
  TGLLAHIR_PELAMAR DATE NOT NULL,
  JK_PELAMAR NUMBER(3) NOT NULL,
  AGAMA_PELAMAR VARCHAR2(45) NOT NULL,
  WNI_PELAMAR NUMBER(3) NOT NULL,
  MENIKAH_PELAMAR NUMBER(3) NOT NULL,
  PENDIDIKAN_PELAMAR VARCHAR2(45) NOT NULL,
  ALAMAT_PELAMAR VARCHAR2(45) NOT NULL,
  TELEPON_PELAMAR NUMBER NOT NULL,
  EMAIL_PELAMAR VARCHAR2(45) NOT NULL,
  KODE_DIVISI NUMBER NOT NULL,
  PRIMARY KEY (KODE_PELAMAR)
 ,
  CONSTRAINT fk_pelamar_pegawai_divisi1
    FOREIGN KEY (KODE_DIVISI)
    REFERENCES pegawai_divisi (KODE_DIVISI)
   )
;

-- -----------------------------------------------------
-- Table `message`
-- -----------------------------------------------------
CREATE TABLE message (
  KODE_MESSAGE NUMBER NOT NULL,
  KIRIM_KODE_DIVISI NUMBER NOT NULL,
  TEIRMA_KODE_DIVISI NUMBER NOT NULL,
  WAKTU TIMESTAMP(0) NULL,
  PESAN VARCHAR2(45) NULL,
  PRIMARY KEY (KODE_MESSAGE)
 ,
  CONSTRAINT fk_message_pegawai_divisi1
    FOREIGN KEY (KIRIM_KODE_DIVISI)
    REFERENCES pegawai_divisi (KODE_DIVISI)
   ,
  CONSTRAINT fk_message_pegawai_divisi2
    FOREIGN KEY (TEIRMA_KODE_DIVISI)
    REFERENCES pegawai_divisi (KODE_DIVISI)
   )
;


-- -----------------------------------------------------
-- Data for table `customer`
-- -----------------------------------------------------
INSERT INTO customer (KODE_CUST, NAMA_CUST, ALAMAT_CUST, TELP_CUST, EMAIL_CUST) VALUES (1, 'Customer 1', 'Alamat 1', '12345789', 'email@email.com');
INSERT INTO customer (KODE_CUST, NAMA_CUST, ALAMAT_CUST, TELP_CUST, EMAIL_CUST) VALUES (2, 'Customer 2', 'Alamat 2', '9856541235', 'email@asdf.com');
INSERT INTO customer (KODE_CUST, NAMA_CUST, ALAMAT_CUST, TELP_CUST, EMAIL_CUST) VALUES (3, 'Customer 3', 'Alamat 3', '154982154', 'email@fdsa.com');

-- -----------------------------------------------------
-- Data for table `kamar`
-- -----------------------------------------------------
INSERT INTO kamar (KODE_KAMAR, TIPE_KAMAR, CATATAN, HARGA_KAMAR) VALUES (101, 'Standart', 'Banyak Kecoak', 300000);
INSERT INTO kamar (KODE_KAMAR, TIPE_KAMAR, CATATAN, HARGA_KAMAR) VALUES (102, 'Standart', NULL, 400000);
INSERT INTO kamar (KODE_KAMAR, TIPE_KAMAR, CATATAN, HARGA_KAMAR) VALUES (103, 'Standart', 'Hujan Bocor', 250000);
INSERT INTO kamar (KODE_KAMAR, TIPE_KAMAR, CATATAN, HARGA_KAMAR) VALUES (104, 'Standart', NULL, 375000);
INSERT INTO kamar (KODE_KAMAR, TIPE_KAMAR, CATATAN, HARGA_KAMAR) VALUES (105, 'Standart', NULL, 360000);
INSERT INTO kamar (KODE_KAMAR, TIPE_KAMAR, CATATAN, HARGA_KAMAR) VALUES (201, 'Triple', NULL, 500000);
INSERT INTO kamar (KODE_KAMAR, TIPE_KAMAR, CATATAN, HARGA_KAMAR) VALUES (202, 'Triple', NULL, 550000);
INSERT INTO kamar (KODE_KAMAR, TIPE_KAMAR, CATATAN, HARGA_KAMAR) VALUES (203, 'Triple', NULL, 570000);
INSERT INTO kamar (KODE_KAMAR, TIPE_KAMAR, CATATAN, HARGA_KAMAR) VALUES (204, 'Suite', NULL, 800000);

-- -----------------------------------------------------
-- Data for table `hotel_hjual`
-- -----------------------------------------------------
INSERT INTO hotel_hjual (NOTA_HOTEL, KODE_CUST) VALUES (1, 1);
INSERT INTO hotel_hjual (NOTA_HOTEL, KODE_CUST) VALUES (2, 1);
INSERT INTO hotel_hjual (NOTA_HOTEL, KODE_CUST) VALUES (3, 2);
INSERT INTO hotel_hjual (NOTA_HOTEL, KODE_CUST) VALUES (4, 3);

-- -----------------------------------------------------
-- Data for table `hotel_djual`
-- -----------------------------------------------------
INSERT INTO hotel_djual (NOTA_HOTEL, KODE_KAMAR, TGL_IN, TGL_OUT) VALUES (1, 101, to_date('2017-05-15', 'YYYY-MM-DD'), to_date('2017-05-20', 'YYYY-MM-DD'));
INSERT INTO hotel_djual (NOTA_HOTEL, KODE_KAMAR, TGL_IN, TGL_OUT) VALUES (2, 101, to_date('2017-05-20', 'YYYY-MM-DD'), to_date('2017-05-22', 'YYYY-MM-DD'));
INSERT INTO hotel_djual (NOTA_HOTEL, KODE_KAMAR, TGL_IN, TGL_OUT) VALUES (3, 103, to_date('2017-05-12', 'YYYY-MM-DD'), to_date('2017-05-13', 'YYYY-MM-DD'));
INSERT INTO hotel_djual (NOTA_HOTEL, KODE_KAMAR, TGL_IN, TGL_OUT) VALUES (4, 104, to_date('2017-05-11', 'YYYY-MM-DD'), to_date('2017-05-13', 'YYYY-MM-DD'));

-- -----------------------------------------------------
-- Data for table `laundry_jenis`
-- -----------------------------------------------------
INSERT INTO laundry_jenis (KODE_LAUNDRY, JENIS_LAUNDRY, HARGA_LAUNDRY) VALUES (1, 'Cuci Basah', 5000);
INSERT INTO laundry_jenis (KODE_LAUNDRY, JENIS_LAUNDRY, HARGA_LAUNDRY) VALUES (2, 'Cuci Kering', 9000);
INSERT INTO laundry_jenis (KODE_LAUNDRY, JENIS_LAUNDRY, HARGA_LAUNDRY) VALUES (3, 'Setrika', 15000);

-- -----------------------------------------------------
-- Data for table `laundry_hjual`
-- -----------------------------------------------------
INSERT INTO laundry_hjual (NOTA_LAUNDRY, TGL_LAUNDRY, KODE_KAMAR) VALUES (1, to_date('2017-05-20', 'YYYY-MM-DD'), 101);
INSERT INTO laundry_hjual (NOTA_LAUNDRY, TGL_LAUNDRY, KODE_KAMAR) VALUES (2, to_date('2017-05-20', 'YYYY-MM-DD'), 102);

-- -----------------------------------------------------
-- Data for table `laundry_djual`
-- -----------------------------------------------------
INSERT INTO laundry_djual (NOTA_LAUNDRY, KODE_LAUNDRY, BERAT_LAUNDRY) VALUES (1, 1, 5);
INSERT INTO laundry_djual (NOTA_LAUNDRY, KODE_LAUNDRY, BERAT_LAUNDRY) VALUES (1, 2, 4);
INSERT INTO laundry_djual (NOTA_LAUNDRY, KODE_LAUNDRY, BERAT_LAUNDRY) VALUES (1, 3, 9);
INSERT INTO laundry_djual (NOTA_LAUNDRY, KODE_LAUNDRY, BERAT_LAUNDRY) VALUES (2, 2, 5);
INSERT INTO laundry_djual (NOTA_LAUNDRY, KODE_LAUNDRY, BERAT_LAUNDRY) VALUES (2, 3, 8);

-- -----------------------------------------------------
-- Data for table `pegawai_divisi`
-- -----------------------------------------------------
INSERT INTO pegawai_divisi (KODE_DIVISI, NAMA_DIVISI, GAJI_DIVISI) VALUES (1, 'Receptionist', 500000);
INSERT INTO pegawai_divisi (KODE_DIVISI, NAMA_DIVISI, GAJI_DIVISI) VALUES (2, 'Restoran', 600000);
INSERT INTO pegawai_divisi (KODE_DIVISI, NAMA_DIVISI, GAJI_DIVISI) VALUES (3, 'Dapur', 400000);
INSERT INTO pegawai_divisi (KODE_DIVISI, NAMA_DIVISI, GAJI_DIVISI) VALUES (4, 'Laundry', 300000);
INSERT INTO pegawai_divisi (KODE_DIVISI, NAMA_DIVISI, GAJI_DIVISI) VALUES (5, 'HRD', 900000);

-- -----------------------------------------------------
-- Data for table `pegawai`
-- -----------------------------------------------------
INSERT INTO pegawai (KODE_PEG, KODE_DIVISI, NAMA_PEG, USERNAME, PASSWORD) VALUES (1, 1, 'Tukang Receptionist 1', 'receptionist1', 'pass');
INSERT INTO pegawai (KODE_PEG, KODE_DIVISI, NAMA_PEG, USERNAME, PASSWORD) VALUES (2, 1, 'Tukang Receptionist 2', 'receptionist2', 'pass');
INSERT INTO pegawai (KODE_PEG, KODE_DIVISI, NAMA_PEG, USERNAME, PASSWORD) VALUES (3, 2, 'Tukang Restoran 1', 'restoran1', 'pass');
INSERT INTO pegawai (KODE_PEG, KODE_DIVISI, NAMA_PEG, USERNAME, PASSWORD) VALUES (4, 2, 'Tukang Restoran 2', 'restoran2', 'pass');
INSERT INTO pegawai (KODE_PEG, KODE_DIVISI, NAMA_PEG, USERNAME, PASSWORD) VALUES (5, 3, 'Tukang Dapur 1', 'dapur1', 'pass');
INSERT INTO pegawai (KODE_PEG, KODE_DIVISI, NAMA_PEG, USERNAME, PASSWORD) VALUES (6, 3, 'Tukang Dapur 2', 'dapur2', 'pass');
INSERT INTO pegawai (KODE_PEG, KODE_DIVISI, NAMA_PEG, USERNAME, PASSWORD) VALUES (7, 4, 'Tukang Laundry 1', 'laundry1', 'pass');
INSERT INTO pegawai (KODE_PEG, KODE_DIVISI, NAMA_PEG, USERNAME, PASSWORD) VALUES (8, 4, 'Tukang Laundry 2', 'laundry2', 'pass');
INSERT INTO pegawai (KODE_PEG, KODE_DIVISI, NAMA_PEG, USERNAME, PASSWORD) VALUES (9, 5, 'Tukang HRD 1', 'hrd1', 'pass');
INSERT INTO pegawai (KODE_PEG, KODE_DIVISI, NAMA_PEG, USERNAME, PASSWORD) VALUES (10, 5, 'Tukang HRD 2', 'hrd2', 'pass');

-- -----------------------------------------------------
-- Data for table `penggajian`
-- -----------------------------------------------------
INSERT INTO penggajian (KODE_GAJI, KODE_PEG, TGL_GAJI, JUM_GAJI) VALUES (1, '1', to_date('2017-05-20', 'YYYY-MM-DD'), 60000);
INSERT INTO penggajian (KODE_GAJI, KODE_PEG, TGL_GAJI, JUM_GAJI) VALUES (2, '2', to_date('2017-05-20', 'YYYY-MM-DD'), 40000);

-- -----------------------------------------------------
-- Data for table `restoran_menu`
-- -----------------------------------------------------
INSERT INTO restoran_menu (KODE_MENU, JENIS_MENU, NAMA_MENU, HARGA_MENU, SOLDOUT) VALUES (1, 'Makanan', 'Makanan 1', 60000, 0);
INSERT INTO restoran_menu (KODE_MENU, JENIS_MENU, NAMA_MENU, HARGA_MENU, SOLDOUT) VALUES (2, 'Makanan', 'Makanan 2', 40000, 0);
INSERT INTO restoran_menu (KODE_MENU, JENIS_MENU, NAMA_MENU, HARGA_MENU, SOLDOUT) VALUES (3, 'Makanan', 'Makanan 3', 90000, 1);
INSERT INTO restoran_menu (KODE_MENU, JENIS_MENU, NAMA_MENU, HARGA_MENU, SOLDOUT) VALUES (4, 'Minuman', 'Minuman 1', 40000, 0);
INSERT INTO restoran_menu (KODE_MENU, JENIS_MENU, NAMA_MENU, HARGA_MENU, SOLDOUT) VALUES (5, 'Minuman', 'Minuman 2', 60000, 0);
INSERT INTO restoran_menu (KODE_MENU, JENIS_MENU, NAMA_MENU, HARGA_MENU, SOLDOUT) VALUES (6, 'Minuman', 'Minuman 3', 50000, 1);

-- -----------------------------------------------------
-- Data for table `restoran_hjual`
-- -----------------------------------------------------
INSERT INTO restoran_hjual (NOTA_RESTO, TGL_RESTO, KODE_CUST) VALUES (1, to_date('2017-05-20', 'YYYY-MM-DD'), 101);
INSERT INTO restoran_hjual (NOTA_RESTO, TGL_RESTO, KODE_CUST) VALUES (2, to_date('2017-05-20', 'YYYY-MM-DD'), null);

-- -----------------------------------------------------
-- Data for table `restoran_djual`
-- -----------------------------------------------------
INSERT INTO restoran_djual (NOTA_RESTO, KODE_MAKANAN, HARGA, SELESAI) VALUES (1, 1, 999999, 1);
INSERT INTO restoran_djual (NOTA_RESTO, KODE_MAKANAN, HARGA, SELESAI) VALUES (1, 2, 650000, 1);
INSERT INTO restoran_djual (NOTA_RESTO, KODE_MAKANAN, HARGA, SELESAI) VALUES (1, 5, 400000, 1);
INSERT INTO restoran_djual (NOTA_RESTO, KODE_MAKANAN, HARGA, SELESAI) VALUES (2, 1, 600000, 0);
INSERT INTO restoran_djual (NOTA_RESTO, KODE_MAKANAN, HARGA, SELESAI) VALUES (2, 5, 800000, 0);
INSERT INTO restoran_djual (NOTA_RESTO, KODE_MAKANAN, HARGA, SELESAI) VALUES (2, 4, 999000, 0);

COMMIT;
