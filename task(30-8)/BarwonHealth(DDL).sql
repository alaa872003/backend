create database BarwonHealth
use BarwonHealth
--create schema prescription 

--Create tables(DDL)--
--UR-name-address-age-phone-email-medicare_card--
create table prescription.patients(
UR int primary key identity(1,1) ,
Pname varchar(30),
age int,
phone varchar(20),
email varchar(50),
medicare_card varchar(50),
patient_address varchar(50)
)
--ID-name-specialty-experience_ years-phone-email-UR--
create table prescription.doctors(
doctor_id int primary key ,
doctor_name varchar(30),
experience_years int,
phone varchar(20),
email varchar(50),
specialty varchar(50),
UR int,
foreign key (UR) references prescription.patients(UR)
)

--ID-trade_name-strength--
create table prescription.drugs(
drug_id int primary key ,
trade_name varchar(50),
strength varchar(20)
)

--ID-name-address-phone--

create table prescription.pharmaceutical_companies(
company_id int primary key ,
company_name varchar(50),
company_address varchar(50)
)
--Drug_ID-com_ID-ID--
create table prescription.Supplied_drugs(
sup_id int primary key identity(1,1),
company_id int,
drug_id int,
 constraint fk_company foreign key (company_id) 
 references prescription.pharmaceutical_companies(company_id)
 on update cascade
 on delete cascade,
 constraint fk_drug foreign key (drug_id) 
 references prescription.drugs(drug_id)
 on update cascade
 on delete cascade
)

--Patient_ID-Doctor_ID-Drug_ID-Prescription_ID-date-quantity--
create table prescription.prescriptions(
prescription_id int primary key identity(1,1) ,
doctor_id int,
patient_id int,
drug_id int,
 constraint fk_doctor_prescript foreign key (doctor_id) 
 references prescription.doctors(doctor_id)
 on update cascade
 on delete cascade,
 constraint fk_patient_prescript foreign key (patient_id) 
 references prescription.patients(UR)
 on update cascade
 on delete cascade,

 constraint fk_drug_prescript foreign key (drug_id) 
 references prescription.drugs(drug_id)
 on update cascade
 on delete cascade
)




--===============================================================================--
