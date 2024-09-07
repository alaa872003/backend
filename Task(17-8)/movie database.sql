create database Test
use Test
create schema movieSchema
create table movieSchema.actor(
act_id int ,
act_fname varchar(20),
act_lname varchar(20),
gender varchar(1)
primary key(act_id));

create table movieSchema.director(
dir_id int ,
dir_fname varchar(20),
dir_lname varchar(20),
primary key(dir_id));

create table movieSchema.movie(
mov_id int ,
mov_title varchar(50),
mov_year int,
mov_time int,
mov_lang varchar(50),
mov_dt_rell date,
mov_rell_country varchar(5),
primary key(mov_id));

create table movieSchema.reviewer(
rev_id int ,
rev_name varchar(30),
primary key(rev_id));

create table movieSchema.genres(
gen_id int ,
gen_title varchar(20),
primary key(gen_id));


create table movieSchema.movie_director(
dir_id int ,
mov_id int,

constraint fk_dir foreign key (dir_id) 
        references movieSchema.director(dir_id) on delete cascade,

 constraint fk_mov foreign key (mov_id) 
        references movieSchema.movie(mov_id) on delete cascade
);

create table movieSchema.movie_cast(
act_id int ,
mov_id int,
mc_role varchar(30)

constraint fk_act foreign key (act_id) 
        references movieSchema.actor(act_id) on delete cascade,

 constraint fk_mov_cast foreign key (mov_id) 
        references movieSchema.movie(mov_id) on delete cascade
);

create table movieSchema.movie_genres(
mov_id int,
gen_id int ,

 constraint fk_mov_gen foreign key (mov_id) 
        references movieSchema.movie(mov_id) on delete cascade,

constraint fk_gen foreign key (gen_id) 
        references movieSchema.genres(gen_id) on delete cascade
);

create table movieSchema.rating(
mov_id int,
rev_id int ,
rev_stars int,
num_0_ratings int
 constraint fk_mov_rate foreign key (mov_id) 
        references movieSchema.movie(mov_id) on delete cascade,

constraint fk_rev foreign key (rev_id) 
        references movieSchema.reviewer(rev_id) on delete cascade
);