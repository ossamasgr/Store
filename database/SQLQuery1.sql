create database store
use store
create table users(
id varchar(100) primary key,
full_name varchar(100),
password varchar(100),
type varchar(100)
)
create table products(
id int primary key,
name varchar(100),
price float,
)
create table storage(
id int foreign key references products,
qte_in_stock int,
last_updated date
)
create table command(
order_id int primary key, 
id int foreign key references products,
qte int,
o_date date,
user_id varchar(100) foreign key references users
)