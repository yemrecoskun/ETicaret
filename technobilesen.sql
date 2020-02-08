create database if not exists `technobilesen`;
create table if not exists `kullanici`
(
`kullanici_id` varchar(45) not null,
`kullanici_adi` varchar(45) not null,
`kullanici_soyadi` varchar(45) not null,
`kullanici_sifre` varchar(45) not null,
primary key (`kullanici_id`)
);
create table if not exists `siparis`
(
`siparis_id` int not null auto_increment,
`kullanici_id` varchar(45) not null,
primary key(`siparis_id`),
constraint foreign key (`kullanici_id`) references `kullanici`(`kullanici_id`),
`kullanici_siparisdurumu` varchar(45) not null
);
create table if not exists `urun_marka`
(
`urun_markaid` int not null auto_increment,
`urun_adi` varchar(45) not null,
`urun_markaadi` varchar(45) not null,
primary key(`urun_markaid`)
);
create table if not exists`urun`(
`urun_id` int not null auto_increment ,
`urun_adi` varchar(45) not null,
`urun_markaid` int not null,
`urun_modeladi` varchar(45) not null,
`urun_fiyati` varchar(45) not null,
`urun_indirimfiyati` varchar(45) not null,
`urun_resim` varchar(100) not null,
primary key(`urun_id`),
constraint foreign key (`urun_markaid`) references `urun_marka`(`urun_markaid`)
);
create table if not exists `siparis_urunleri`
(
`siparis_urun_id` int not null auto_increment,
`siparis_id` int not null,
`kullanici_siparisurunid` int not null,
primary key(`siparis_urun_id`),
constraint foreign key(`kullanici_siparisurunid`) references `urun`(`urun_id`),
constraint foreign key(`siparis_id`) references `siparis`(`kullanici_siparis_id`)
);
create table if not exists`urun_ozellik`
(
`urun_ozellikid` int not null auto_increment,
primary key(`urun_ozellikid`),
`urun_id` int not null,
constraint foreign key (`urun_id`) references `urun`(`urun_id`),
`urun_ozellikadi` varchar(300) not null,
`urun_ozellik` varchar(300) not null
);
create table if not exists `satilan_urunler`
(
`satilan_urunid` int not null auto_increment,
`urun_id` int not null,
`satilan_miktar` int not null,
primary key(`satilan_urunid`),
constraint foreign key(`urun_id`) references `urun`(`urun_id`)
);

create table if not exists `urun_star`(
`star_id` int not null auto_increment,
`urun_id` int not null,
`star1` int not null,
`star2` int not null,
`star3` int not null,
`star4` int not null,
`star5` int not null,
primary key(`star_id`),
constraint foreign key (`urun_id`) references `urun`(`urun_id`)
);
create table if not exists `urun_yorum`(
`yorum_id` int not null auto_increment,
`urun_id` int not null,
`kullanici_id` varchar(45) not null,
`yorum` varchar(5000) not null,
primary key(`yorum_id`),
constraint foreign key (`urun_id`) references `urun`(`urun_id`),
constraint foreign key (`kullanici_id`) references  `kullanici`(`kullanici_id`)
);
use `technobilesen`
DELIMITER //
CREATE PROCEDURE urun_sorgula()
BEGIN
SELECT urun.urun_id,urun.urun_adi,urun_marka.urun_markaadi,urun.urun_modeladi,urun.urun_fiyati,urun.urun_indirimfiyati,urun.urun_resim,urun_star.star1,urun_star.star2,urun_star.star3,urun_star.star4,urun_star.star5 FROM urun
inner join urun_marka on urun_marka.urun_markaid=urun.urun_markaid 
inner join urun_star on urun_star.urun_id = urun.urun_id order by urun_id desc limit 10;
END //
CREATE PROCEDURE Tum_Urunler()
BEGIN
SELECT urun.urun_id,urun.urun_adi,urun_marka.urun_markaadi,urun.urun_modeladi,urun.urun_fiyati,urun.urun_indirimfiyati,urun.urun_resim,urun_star.star1,urun_star.star2,urun_star.star3,urun_star.star4,urun_star.star5 FROM urun
inner join urun_marka on urun_marka.urun_markaid=urun.urun_markaid 
inner join urun_star on urun_star.urun_id = urun.urun_id order by urun_id ;
END //
CREATE PROCEDURE urunozellik_sorgula()
BEGIN
SELECT * FROM urun_ozellik;
END //
CREATE PROCEDURE satilan_urun_sorgula()
BEGIN
SELECT * FROM satilan_urunler order by satilan_miktar desc;
END //
CREATE PROCEDURE urun_marka_sorgula()
BEGIN
select * from urun_marka;
END //
DELIMITER ;
insert into `urun_marka`(`urun_markaadi`,`urun_adi`)
values("Lenovo","laptop"),
	  ("HP","laptop"),
      ("Apple","laptop"),
      ("Monster","laptop"),
      ("Asus","laptop"),
      ("Casper","laptop"),
      ("Toshiba","laptop"),
      ("MSI","laptop"),
      ("Hometech","laptop"),
      ("Microsoft","laptop"),
      ("Dell","laptop"),
      ("Acer","laptop");