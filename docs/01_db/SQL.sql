CREATE TABLE Login (

    id         INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL, 
    login_id   VARCHAR(10) NOT NULL UNIQUE,
    pass       VARCHAR(250) NOT NULL
    PRIMARY KEY (id)
);

CREATE TABLE Departments (

    id               INTEGER GENERATED ALWAYS AS IDENTITY,
    dept_name        VARCHAR(50) NOT NULL,
    created_at       TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    created_emp_no   VARCHAR(10) NOT NULL,
    updated_at       TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_emp_no   VARCHAR(10),
    PRIMARY KEY (id)
);

CREATE TABLE Employees (

    id           INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL,
    employee_no  VARCHAR(10) NOT NULL,
    name         VARCHAR(50) NOT NULL,
    birthday     DATE NOT NULL,
    email        VARCHAR(100) NOT NULL,
    hire_date    DATE NOT NULL,
    dept_id      INTEGER NOT NULL,
    status       INTEGER DEFAULT 1 NOT NULL,
    created_at   TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    created_no   VARCHAR(10) NOT NULL,
    updated_at   TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_no   VARCHAR(10),
    PRIMARY KEY (id),
    UNIQUE (employee_no),
    CONSTRAINT fk_employees_dept_id FOREIGN KEY (dept_id) 
        REFERENCES Departments (id),
    CONSTRAINT fk_employees_login_id FOREIGN KEY (employee_no) 
        REFERENCES Login (login_id)

);

--ログインの外部キーの制約を削除するために実行しました。
ALTER TABLE "Employees"
DROP CONSTRAINT "fk_employees_login_id";


INSERT INTO "Departments"(dept_name, created_emp_no) VALUES
('営業部','202001'),
('人事部','202001'),
('システム開発部','202001'),
('経理部','202002');

INSERT INTO "Login" (login_id, pass) VALUES
('202001', 'abc123'),
('202002', 'xyz789'),
('202003', 'qwe456'),
('202101','rty789'),
('202102','uio567');


INSERT INTO "Employees" (employee_no, name, birthday, email, hire_date, dept_id, status, created_no) VALUES
('202001', '山田 太郎', '1990-05-15', 'yamada@example.com', '2020-04-01', 3, 1, '202001'),
('202002', '佐藤 花子', '1995-08-22', 'sato@example.com',   '2021-10-01', 2, 1, '202001'),
('202003', '鈴木 一郎', '1988-12-03', 'suzuki@example.com', '2022-04-01', 1, 1, '202001'),
('202101','佐野 祐介','1991-07-02','sano@example.com','2021-06-01',3,1,'202001'),
('202102','遠藤 祐樹','1991-12-04','endo@example.com','2020-04-01',4,1,'202001');