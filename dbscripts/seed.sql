\connect postgres

CREATE TABLE todos
(
 id serial PRIMARY KEY,
 action VARCHAR (250) NOT NULL
);

ALTER TABLE "todos" OWNER TO postgres;