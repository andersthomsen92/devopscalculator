Create table history (
    id int primary key auto_increment,
    text varchar(255),
    created_at timestamp default current_timestamp
);