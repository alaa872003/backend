--•	SELECT: Retrieve all columns from the Doctor table.
select* from prescription.doctors
--•	ORDER BY: List patients in the Patient table in ascending order of their ages.
select*from prescription.patients
order by age asc
--•	OFFSET FETCH: Retrieve the first 10 patients from the Patient table, starting from the 5th record.
select*from prescription.patients 
order by UR 
offset 5 rows fetch first 10 rows only 
--•	SELECT TOP: Retrieve the top 5 doctors from the Doctor table.
select top(5)* from prescription.doctors
--•	SELECT DISTINCT: Get a list of unique address from the Patient table.
select distinct patient_address from prescription.patients
--•	WHERE: Retrieve patients from the Patient table who are aged 25.
select*from prescription.patients
where age=25
--•	NULL: Retrieve patients from the Patient table whose email is not provided.
select*from prescription.doctors
where email is null
--•	AND: Retrieve doctors from the Doctor table who have experience greater than 5 years and specialize in 'Cardiology'.
select*from prescription.doctors
where experience_years >5 and specialty='Cardiology'
--•	IN: Retrieve doctors from the Doctor table whose speciality is either 'Dermatology' or 'Oncology'.
select*from prescription.doctors
where specialty in('Dermatology','Oncology')
--•	BETWEEN: Retrieve patients from the Patient table whose ages are between 18 and 30.
select*from prescription.patients
where age between 18 and 30
--•	LIKE: Retrieve doctors from the Doctor table whose names start with 'Dr.'.
select*from prescription.doctors
where doctor_name like 'Dr%'
--•	Column & Table Aliases: Select the name and email of doctors, aliasing them as 'DoctorName' and 'DoctorEmail'.
select doctor_name 'DoctorName', email 'DoctorEmail' from prescription.doctors

--•	Joins: Retrieve all prescriptions with corresponding patient names.
select * from prescription.prescriptions  inner join prescription.patients 
on prescription.prescriptions.patient_id = prescription.patients.UR

--•	GROUP BY: Retrieve the count of patients grouped by their addresses.
select  patient_address,count(*) patient_count from prescription.patients
group by patient_address

--•	HAVING: Retrieve cities with more than 3 patients.
select  patient_address,count(*) 'patient_count' from prescription.patients
group by patient_address
having count(*) > 3
--•	UNION: Retrieve a combined list of doctors and patients. (Search)
select Pname from prescription.patients union 
select doctor_name from prescription.doctors
--•	Common Table Expression (CTE): Retrieve patients along with their doctors using a CTE.
with cte_patient_doctor as (
    select Pname 'patient name',p.UR'patient id',count(p.UR) 'count',doctor_name'doctor name',doctor_id 'doctor id'
    from    prescription.patients p
        join prescription.doctors d on d.UR=p.UR
       group by d.doctor_id,d.doctor_name,p.Pname,p.UR
)

select * from cte_patient_doctor


--•	INSERT: Insert a new doctor into the Doctor table.
insert into prescription.doctors(doctor_id,doctor_name,email,experience_years,phone,specialty,UR) 
values(1001,'alaa','alaa@gmail.com',3,'01111111111','wwwww',2)

--•	INSERT Multiple Rows: Insert multiple patients into the Patient table.
insert into prescription.patients (Pname,age,phone,email,medicare_card,patient_address)
values ('ali', 20 ,'1203243224','ali@gmail.com','asdawwdds','aaaaaaaa'),
		('adam',30,'12345667','adam@gmail.com','aaaaaaaaaa','wwwwwwwwww'),
		('basmala',25,'876544322','basmala@gmail.com','eeeeeeee','jjjjjjjjj')
--•	UPDATE: Update the phone number of a doctor.
update prescription.doctors set phone='11'  WHERE doctor_id=1001
--•	UPDATE JOIN: Update the city of patients who have a prescription from a specific doctor.
update prescription.patients set patient_address='qqqqqqq'from prescription.patients p
inner join prescription.doctors d on d.UR=p.UR where d.doctor_id=1001

select * from prescription.patients 

--•	DELETE: Delete a patient from the Patient table.
delete from prescription.patients where UR=1001
--•	Transaction: Insert a new doctor and a patient, ensuring both operations succeed or fail together.
begin transaction
insert into prescription.doctors(doctor_id,doctor_name,email,experience_years,phone,specialty,UR)
values (1002,'gody','gody@gmail.com',4,'222222222','nurse',6)
insert into prescription.patients(Pname,age,phone,email,medicare_card,patient_address)
values ('omar',33,'3333333333','omar@gmail.com','aaa111aa11','madina naser')
commit

--•	View: Create a view that combines patient and doctor information for easy access.
create view prescription.combine_patient_doctor
as
select p.UR,p.Pname,d.doctor_id,d.doctor_name
from prescription.patients p INNER JOIN prescription.doctors d on d.UR=p.UR
select * from prescription.combine_patient_doctor
--•	Index: Create an index on the 'phone' column of the Patient table to improve search performance.
select*from prescription.patients
where phone='3333333333'

create index phone on prescription.patients(phone)
--•	Backup: Perform a backup of the entire database to ensure data safety.
backup database BarwonHealth
to disk = 'D:\Backend.net\30-8\task 30-8\backup'
with name='BarwonHealth-backup'

backup database BarwonHealth 
to disk = 'D:\Backend.net\30-8\task 30-8\backup' 
with differential,
name='differential-BarwonHealth-backup'

backup log BarwonHealth 
to disk = 'D:\Backend.net\30-8\task 30-8\backup' 
with name='transaction-BarwonHealth-backup'
